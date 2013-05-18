'use strict'

@controls ?= {}

_compareTo = (a, b) ->
    unless isNaN a - b then a - b else a.toString().localeCompare b.toString()

class GridViewRow
    constructor: ->
        @data = []
        @nestedGrid = null

    addColumn: (args) ->
        @data.push col for col in args

        return @

    getNestedGrid: ->
        @nestedGrid = new GridView

    _renderData = (parent) ->
        tr = J('<tr />')

        tr.append J('<td />').text(col) for col in @data
        tr.addClass 'nested-row' if @nestedGrid?
        tr.data 'nestedGrid', @nestedGrid

        parent.append tr

    _renderNested = (parent) ->
        return unless @nestedGrid?

        td = J('<td />').attr('colspan', @data.length)
        tr = J('<tr />').hide().append(td)

        @nestedGrid.render td
        parent.append tr

    render: (parent) ->
        _renderData.call @, parent
        _renderNested.call @, parent

@controls.GridView = class GridView
    constructor: (selector) ->
        return new GridView selector unless @ instanceof GridView

        if selector?
            @element = J selector
            _delegate.call @

        @header = []
        @data = []

        @sortAscending = 1 # TODO: Save the current col

    addHeader: ->
        @header.push col for col in arguments

    addRow: ->
        row = new GridViewRow().addColumn arguments
        @data.push row

        return row

    _renderHeader = (parent) ->
        return unless @header.length

        tr = J('<tr />')

        for col, i in @header
            tr.append J('<th />').text(col).data('col', i)

        parent.append tr

    _renderData = (parent) ->
        row.render parent for row in @data

    _delegate = ->
        @element.click (e) ->
            return unless e.target instanceof HTMLTableCellElement
            e.stopPropagation()

            td = J(e.target)
            row = td.parent()

            switch
                when td[0].tagName.toLowerCase() == 'th'
                    table = row.parent()
                    grid = table.data('grid')

                    grid.sortBy td.data('col')
                    grid.render table.parent()

                when td[0].tagName.toLowerCase() == 'td'
                    row.next().toggle() if row.data('nestedGrid')?

    render: (parent) ->
        unless parent?
            parent = @element

        parent.children().remove()

        table = J('<table />').addClass('table').addClass('table-bordered').data('grid', @)

        _renderHeader.call @, table
        _renderData.call @, table

        parent.append(table)

    sortBy: (col) ->
        @sortAscending *= -1 if @previousSortCol == col
        @previousSortCol = col

        @data.sort (row1, row2) =>
            @sortAscending * _compareTo(row1.data[col], row2.data[col])
