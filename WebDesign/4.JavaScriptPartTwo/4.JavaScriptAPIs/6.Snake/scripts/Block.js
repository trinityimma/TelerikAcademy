var Block = (function() {
    function Block(position) {
        GameObject.call(this, [[ true ]], position)
    }

    inherit(Block, GameObject)

    return Block
}())
