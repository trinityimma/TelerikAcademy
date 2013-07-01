form = $('.js-register')

scope = form.closest('.js-view').data('scope')

form.submit (e) ->
    e.preventDefault()

    data = form.serializeObject()

    form.find('input, button').attr 'disabled', 'disabled'

    setTimeout ->
        scope.persister.register(data).done(->
            location.hash = '#!/sign-in.html'

            console.log 'Register success.'
        ).fail((err) ->
            message = JSON.parse(err.responseText).Message
            text = $('<p class="text-error" />').text(message)

            form.find('input, button').removeAttr 'disabled'

            form.append(text)

            console.log 'Register error.'

            setTimeout ->
                text.fadeOut()
            , 2000
        )
    , 500
