form = $('.js-login')

scope = form.closest('.js-view').data('scope')

form.submit (e) ->
    e.preventDefault()

    data = form.serializeObject()

    form.find('input, button').attr 'disabled', 'disabled'

    setTimeout ->
        scope.persister.login(data).done(->
            location.hash = '#!/game.html'

            console.log 'Login success.'
        ).fail((err) ->
            message = JSON.parse(err.responseText).Message
            text = $('<p class="text-error" />').text(message)

            form.find('input, button').removeAttr 'disabled'

            form.append(text)

            console.log 'Login error.'

            setTimeout ->
                text.fadeOut()
            , 2000
        )
    , 500
