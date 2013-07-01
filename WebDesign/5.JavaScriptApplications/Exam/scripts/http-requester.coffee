@http =
    getJSON: (url) ->
        $.ajax url,
            contentType: 'application/json',
            type: 'GET'

    postJSON: (url, data) ->
        $.ajax url,
            data: JSON.stringify(data),
            contentType: 'application/json',
            type: 'POST'
