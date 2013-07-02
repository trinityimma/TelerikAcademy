MESSAGES_POLLING_INTERVAL_IN_MS = 1000
UI_REFRESH_RATE_IN_MS = 1000
BATTLE_FIELD_SIZE = 9

game = $('.js-game')

scope = game.closest('.js-view').data('scope')

scope.currentGameId = null
scope.gameIdStarter = {}

messagesBuffer = ['Game entered']

unless scope.persister.isLoggedIn()
    location.hash = '#!/'
    return

$('.js-logout').click ->
    scope.persister.logout().then(->
        location.hash = '#!/'
    ).fail((err) ->
        messagesBuffer.push JSON.parse(err.responseText).Message
    )

$('.js-nickname').text scope.persister.getNickname()

$('.js-show-scores').click ->
    $('#scores').modal
        remote: 'templates/scores.html'

$('.js-show-create-game').popover
    placement: 'bottom'
    html: on
    content: $('#js-create-game-template').text()

game.on 'submit', '.js-create-game', ->
    data = $(this).serializeObject()

    $(this).find('input, button').attr 'disabled', 'disabled'

    # setTimeout =>
    scope.persister.createGame(data).then(=>
        $('[type = "submit"]', this).addClass('btn-success').val('Game created.')

        setTimeout ->
            $('.js-show-create-game').popover('hide')
        , 1000
    ).fail((err) =>
        $(this).find('input, button').removeAttr 'disabled'

        message = JSON.parse(err.responseText).Message
        text = $('<p class="text-error" />').text(message)
        $(this).append text
        text.delay(1000).fadeOut()
    )
    # , 500

renderOpenGames = ->
    return unless scope.persister.isLoggedIn()

    scope.persister.getOpenGames().done((games) ->
        gameItemTemplate = $('#js-game-item-template').text()

        html = games.map((game) ->
            Mustache.render gameItemTemplate, game
        ).join('')

        $('.js-open-games').html(html).find('li').click (e) ->
            e.preventDefault()

            $('.js-join-game').modal('show').data('id', $(this).data('id'))

        setTimeout renderOpenGames, UI_REFRESH_RATE_IN_MS
    ).fail((err) ->
        messagesBuffer.push JSON.parse(err.responseText).Message

        setTimeout renderOpenGames, UI_REFRESH_RATE_IN_MS
    )

renderOpenGames()

$('.js-join-game').submit (e) ->
    data = $(this).serializeObject()
    data.id = $(this).data('id')

    $(this).find('input, button').attr 'disabled', 'disabled'

    setTimeout =>
        $(this).find('input, button').attr 'disabled', 'disabled'

        scope.persister.joinGame(data).done(=>
            $(this).find('input, button').removeAttr 'disabled'

            alert 'Game joined'

            $(this).modal('hide')
        ).fail((err) =>
            $(this).find('input, button').removeAttr 'disabled'

            message = JSON.parse(err.responseText).Message
            text = $('<p class="text-error" />').text(message)
            $(this).find('.modal-body').append text
            text.delay(1000).fadeOut()
        )
    , 500

renderActiveGames = ->
    return unless scope.persister.isLoggedIn()

    scope.persister.getMyActiveGames().done((games) ->
        gameItemTemplate = $('#js-game-item-template').text()

        html = games.map((game) ->
            Mustache.render gameItemTemplate, game
        ).join('')

        elements = $('.js-my-active-games').html(html).find('li')

        elements.click((e) ->
            e.preventDefault()
        ).filter('[data-status="in-progress"]').click(->
            $(this).siblings().removeClass('active')
            $(this).addClass('active')
            renderBattlefield($(this).data('id'), true)
        )

        elements.filter('[data-id="' + scope.currentGameId + '"]').addClass('active')

        elements.filter('[data-status="full"]').click ->
            scope.persister.startGame($(this).data('id')).done(->
                alert('Game started')
            )

        setTimeout renderActiveGames, UI_REFRESH_RATE_IN_MS
    ).fail((err) ->
        messagesBuffer.push JSON.parse(err.responseText).Message

        setTimeout renderActiveGames, UI_REFRESH_RATE_IN_MS
    )

renderActiveGames()


renderBattlefield = (id) ->
    return unless scope.persister.isLoggedIn()

    scope.persister.getMyColor id, (myColor) ->
        scope.persister.getGameField(id).done((data) ->
            clearTimeout renderBattlefield.timer

            currentPlayer = data.inTurn
            myTurn = currentPlayer is myColor

            console.log 'render', 'I am: ' + myColor, 'Current: ' + currentPlayer

            scope.currentGameId = id

            $('.js-battle-field-title').text(data.title)
            $('.js-battle-field-turn').text(data.turn)
            $('.js-battle-field-in-turn').text(data.inTurn)

            table = $('.js-battle-field')
            table.children().remove()

            tbody = $('<tbody />')

            for row in [0...BATTLE_FIELD_SIZE]
                rowEl = $('<tr />')

                for col in [0...BATTLE_FIELD_SIZE]
                    cell = $('<td />')

                    cell.data('row', row)
                    cell.data('col', col)

                    rowEl.append(cell)

                tbody.append rowEl

            table.append tbody


            table.removeClass 'active-blue active-red'
            table.addClass "active-#{currentPlayer}" if myTurn

            # TODO: BFS
            mark = (startRow, startCol, unitType) ->
                Unit

                switch unitType
                    when 'warrior' then Unit = Warrior
                    when 'ranger' then Unit = Ranger

                unit = new Unit()

                console.log 'mark', startRow, startCol, unit.range

                tbody.find('td').removeClass('rangeable').removeClass('movable')

                for row in [0...BATTLE_FIELD_SIZE]
                    for col in [0...BATTLE_FIELD_SIZE]
                        distance = Math.abs(row - startRow) + Math.abs(col - startCol)
                        cell = tbody.find('tr').eq(row).find('td').eq(col)

                        cell.data('distance', distance)

                        if distance <= unit.speed
                            cell.addClass('movable')

                        if distance <= unit.range
                            cell.addClass('rangeable')

            renderUnits = (units, color) ->
                currentColor = color
                enemyColor = if color is 'red' then 'blue' else 'red'

                for unit in units
                    # Copy closure
                    do (startRow = unit.position.y, startCol = unit.position.x,
                        unitType = unit.type, unitId = unit.id) ->

                        cell = tbody.find('tr').eq(unit.position.y).find('td').eq(unit.position.x)

                        cell.addClass unit.type
                        cell.attr 'title', "Hit points: #{unit.hitPoints}\nMode: #{unit.mode}"

                        cell.addClass(currentColor)

                        if myTurn and color is currentPlayer
                            cell.click ->
                                tbody.find('td').removeClass('picked')
                                mark(startRow, startCol, unitType)
                                $(this).addClass('picked')

                                possible = tbody.find('.movable')
                                possible.add(tbody.find('.rangeable'))

                                possible.click ->
                                    # console.log 'move', $(this).data('row'), $(this).data('col')

                                    currentRow = $(this).data 'row'
                                    currentCol = $(this).data 'col'

                                    dataToSend =
                                        unitId: unitId
                                        position:
                                            x: currentCol
                                            y: currentRow

                                    try
                                        switch
                                            when $(this).is('.' + enemyColor) and $(this).hasClass('rangeable')
                                                console.log 'attack'
                                                scope.persister.battleAttack(dataToSend, id).done(->
                                                    renderBattlefield(id, false)
                                                )

                                            when $(this).is('.' + currentColor)
                                                console.log 'defend'
                                                scope.persister.battleDefend(dataToSend.unitId, id).done(->
                                                    renderBattlefield(id, false)
                                                )

                                            when $(this).hasClass('movable') and $(this).hasClass('movable')
                                                console.log 'move'
                                                scope.persister.battleMove(dataToSend, id).done(->
                                                    renderBattlefield(id, false)
                                                )

                                    catch e
                                        alert JSON.parse(err.responseText).Message

            renderUnits(data.red.units, 'red')
            renderUnits(data.blue.units, 'blue')

            unless myTurn
                renderBattlefield.timer = setTimeout ->
                    renderBattlefield id, false
                , UI_REFRESH_RATE_IN_MS
        )

renderMessages = ->
    return unless scope.persister.isLoggedIn()

    # Async
    scope.persister.getUnreadMessages().done((messages) ->
        return unless messages.length > 0

        for msg in messages
            switch msg.type
                when 'game-move'
                    renderBattlefield(msg.gameId, true)

                when 'game-finished'
                    alert('game-finished')

        Array.prototype.push.apply(messagesBuffer, messages.map((msg) -> msg.text))
    ).fail((err) ->
        messagesBuffer.push JSON.parse(err.responseText).Message
    )

    if messagesBuffer.length > 0
        $('.js-messages-feed').prepend messagesBuffer.map((msg) ->
            $('<p />').text(JSON.stringify(msg))
        )

    messagesBuffer.length = 0

    setTimeout(renderMessages, MESSAGES_POLLING_INTERVAL_IN_MS)

renderMessages()
