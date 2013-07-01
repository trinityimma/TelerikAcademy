game = $('.js-game')

scope = game.closest('.js-view').data('scope')

unless scope.persister.isLoggedIn()
    location.hash = '#!/'
    return

$('.js-logout').click ->
    scope.persister.logout().then(->
        location.hash = '#!/'
    )

$('.js-create-game').submit (e) ->
    e.preventDefault()

    data = $(this).serializeObject()

    $(this).find('input, button').attr 'disabled', 'disabled'

    scope.persister.createGame(data).then =>
        text = $('<p class="text-success" />').text('Game created.')

        $(this).append(text)

        setTimeout =>
            $(this).find('input, button').removeAttr 'disabled'
            text.fadeOut()
        , 500

gameItemTemplate = $('#js-game-item').text()

scope.persister.getOpenGames().done((games) ->
    html = games.map((game) ->
        Mustache.render gameItemTemplate, game
    ).join('')

    $('.js-open-games').html(html).find('li').click (e) ->
        e.preventDefault()

        $('.js-join-game').modal('show')
)

scope.persister.getMyActiveGames().done((games) ->
    html = games.map((game) ->
        Mustache.render gameItemTemplate, game
    ).join('')

    $('.js-my-active-games').html(html).find('li').click (e) ->
        e.preventDefault()
)
