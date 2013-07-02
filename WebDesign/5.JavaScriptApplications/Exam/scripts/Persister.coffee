class @Persister
    constructor: (@rootURL, @http, @encode) ->
        @sessionKey = sessionStorage.sessionKey if sessionStorage.sessionKey?
        @nickname = sessionStorage.nickname if sessionStorage.nickname?

    login: (data) ->
        url = @rootURL + 'user/login/'
        data = _.clone data
        data.authCode = @encode(data.username + data.password)

        @http.postJSON(url, data).done (data) =>
            @sessionKey = data.sessionKey
            @nickname = data.nickname

            sessionStorage.sessionKey = data.sessionKey
            sessionStorage.nickname = data.nickname

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

            delete @nickname
            delete sessionStorage.nickname

    scores: ->
        url = @rootURL + 'user/scores/' + @sessionKey

        @http.getJSON url

    isLoggedIn: ->
        @sessionKey?

    getNickname: ->
        @nickname

    createGame: (data) ->
        url = @rootURL + 'game/create/' + @sessionKey
        data = _.clone data

        if data.password? and data.password != ''
            data.password = @encode data.password
        else
            delete data.password

        @http.postJSON url, data

    joinGame: (data) ->
        url = @rootURL + 'game/join/' + @sessionKey
        data = _.clone data

        if data.password? and data.password != ''
            data.password = @encode data.password
        else
            delete data.password

        @http.postJSON url, data

    getOpenGames: ->
        url = @rootURL + 'game/open/' + @sessionKey

        @http.getJSON url

    getMyActiveGames: ->
        url = @rootURL + 'game/my-active/' + @sessionKey

        @http.getJSON url

    getUnreadMessages: ->
        url = @rootURL + 'messages/unread/' + @sessionKey

        @http.getJSON url

    getAllMessages: ->
        url = @rootURL + 'messages/all/' + @sessionKey

        @http.getJSON url
