// <p data-cloud-tag>cms, javascript, js, ASP.NET MVC, .net, .net, css, wordpress, xaml, js, http, web, asp.net, asp.net MVC, ASP.NET MVC, wp, javascript, js, cms, html, javascript, http, http, CMS</p>

J.prototype.cloudTag = function() {
    var MIN_FONT_SIZE = 17
      , MAX_FONT_SIZE = 42

    function _makeDictionary(tags) {
        var result = {}

        J.each(tags, function() {
            result[this] = result[this] || 0

            result[this]++
        })

        return result
    }

    function _makeHtml(dictionary, step) {
        var result = []

        J.each(dictionary, function(prop) {
            var size = (MIN_FONT_SIZE + (this * step) + 'px')

              , span = J('<span />').css('font-size', size).text(prop)

            console.log(size);

            result.push(span)
        })

        return result
    }

    return this.each(function() {
        var self = J(this)

          , tags = self.text().split(/\s*,\s*/)

          , dictionary = _makeDictionary(tags)

          , values = J.map(dictionary, function() {
              return this
          })

          , min = J.min(values)
          , max = J.max(values)

          , length = max - min + 1
          , fontLength = MAX_FONT_SIZE - MIN_FONT_SIZE + 1

          , step = fontLength / length

          , result = _makeHtml(dictionary, step)

        return self.html(J.map(result, function() {
            return this[0].outerHTML
        }).join(', '))
    })
}

J('[data-cloud-tag]').cloudTag()
