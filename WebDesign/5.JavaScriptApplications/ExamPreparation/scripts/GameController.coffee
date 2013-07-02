MESSAGES_POLLING_INTERVAL_IN_MS = 1000

game = $('.js-game')

scope = game.closest('.js-view').data('scope')

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

    setTimeout =>
        scope.persister.createGame(data).then(->
            text = $('[type = "submit"]').addClass('btn-success').val('Game created.')

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
    , 500

scope.persister.getOpenGames().done((games) ->
    gameItemTemplate = $('#js-game-item-template').text()

    html = games.map((game) ->
        Mustache.render gameItemTemplate, game
    ).join('')

    $('.js-open-games').html(html).find('li').click (e) ->
        e.preventDefault()

        $('.js-join-game').modal('show').data('id', $(this).data('id'))
).fail((err) ->
    messagesBuffer.push JSON.parse(err.responseText).Message
)

$('.js-join-game').submit (e) ->
    data = $(this).serializeObject()
    data.id = $(this).data('id')

    $(this).find('input, button').attr 'disabled', 'disabled'

    setTimeout =>
        scope.persister.joinGame(data).done(=>
            $(this).find('input, button').removeAttr 'disabled'

            $(this).modal('hide')
        ).fail((err) =>
            $(this).find('input, button').removeAttr 'disabled'

            message = JSON.parse(err.responseText).Message
            text = $('<p class="text-error" />').text(message)
            $(this).find('.modal-body').append text
            text.delay(1000).fadeOut()
        )
    , 500

scope.persister.getMyActiveGames().done((games) ->
    html = games.map((game) ->
        Mustache.render gameItemTemplate, game
    ).join('')

    $('.js-my-active-games').html(html).find('li').click (e) ->
        e.preventDefault()
).fail((err) ->
    messagesBuffer.push JSON.parse(err.responseText).Message
)

setTimeout(getMessages = (->
    # Async
    scope.persister.getUnreadMessages().done((messages) ->
        Array.prototype.push.apply(messagesBuffer, messages)
    ).fail((err) ->
        messagesBuffer.push JSON.parse(err.responseText).Message
    )

    return unless messagesBuffer.length > 0

    $('.js-messages-feed').prepend messagesBuffer.map((msg) ->
        $('<p />').text(msg)
    )

    messagesBuffer.length = 0

    setTimeout(getMessages, MESSAGES_POLLING_INTERVAL_IN_MS)
), 0)
