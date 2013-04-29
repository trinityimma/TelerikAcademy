function makeMatrix(rows, cols) {
    var matrix = new Array(rows)

    var row, col

    for (row = 0; row < rows; row++) {
        matrix[row] = new Array(cols)

        for (col = 0; col < cols; col++)
            matrix[row][col] = false
    }

    return matrix
}

function inherit(Child, Parent) {
    Child.prototype = Object.create(Parent.prototype);
    Child.prototype.parent = Parent.prototype;
    Child.prototype.constructor = Child;
}
