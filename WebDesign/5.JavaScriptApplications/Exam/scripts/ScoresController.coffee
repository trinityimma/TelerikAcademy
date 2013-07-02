table = $('.js-table')

scope = table.closest('.js-view').data('scope')

scope.persister.scores().done (scores) ->
    scoreItemTemplate = $('#js-score-item-template').text()

    html = _.sortBy(scores, (s) -> -s.score).map((score, i) ->
        score.position = i + 1 # TODO: Modifying parameter
        Mustache.render scoreItemTemplate, score
    ).join('')

    table.append($('<tbody />').html(html))
