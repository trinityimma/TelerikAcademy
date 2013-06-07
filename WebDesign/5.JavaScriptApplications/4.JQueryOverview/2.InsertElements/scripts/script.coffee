operations =
    '.js-before': 'insertBefore'
    '.js-after': 'insertAfter'

for el, action of operations
    do (action) ->
        $(el).click ->
            $('<div class="box" />')[action]($('#js-main'))
