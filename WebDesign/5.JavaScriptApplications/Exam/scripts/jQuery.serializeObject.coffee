jQuery.fn.serializeObject = ->
    obj = {}

    obj[prop.name] = prop.value || '' for prop in @serializeArray()

    return obj
