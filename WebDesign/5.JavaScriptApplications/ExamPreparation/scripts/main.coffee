persister = new Persister 'http://localhost:40643/api/', @http, (str) ->
    CryptoJS.SHA1(str).toString()

# persister.register(
#     username: 'username'
#     nickname: 'nickname'
#     password: 'password'
# )

# persister.login(
#     username: 'username'
#     password: 'password'
# )

# persister.getOpenGames().done (data) ->
#     console.log data

# persister.getMyActiveGames().done (data) ->
#     console.log data

scope = {}
$('.js-view').data 'scope', scope
scope.persister = persister

route = ->
    unless location.hash.length > 3
        location.hash = if persister.isLoggedIn() then '#!/game.html' else '#!/sign-in.html'

    page = location.hash.substr(3)
    $('.js-view').load('templates/' + page)

window.addEventListener 'hashchange', route
route()
