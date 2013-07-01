class @Persister
    constructor: (@rootURL, @http, @encode) ->
        @sessionKey = sessionStorage.sessionKey if sessionStorage.sessionKey?

    login: (data) ->
        url = @rootURL + 'user/login/'
        data = _.clone data
        data.authCode = @encode(data.username + data.password)

        @http.postJSON(url, data).done (data) =>
            @sessionKey = data.sessionKey
            sessionStorage.sessionKey = data.sessionKey

    register: (data) ->
        url = @rootURL + 'user/register/'
        data = _.clone data
        data.authCode = @encode(data.username + data.password)

        @http.postJSON url, data

    logout: ->
        url = @rootURL + 'user/logout/' + @sessionKey

        @http.getJSON(url).done =>
            delete @sessionKey
            delete sessionStorage.sessionKey

    isLoggedIn: ->
        !!@sessionKey

    createGame: (data) ->
        url = @rootURL + 'game/create/' + @sessionKey
        data = _.clone data
        data.password = @encode data.password if data.password?

        @http.postJSON url, data

    joinGame: (data) ->
        url = @rootURL + 'game/join/' + @sessionKey
        data = _.clone data
        data.password = @encode data.password if data.password?

        @http.postJSON url, data

    getOpenGames: ->
        url = @rootURL + 'game/open/' + @sessionKey

        @http.getJSON url

    getMyActiveGames: ->
        url = @rootURL + 'game/my-active/' + @sessionKey

        @http.getJSON url
