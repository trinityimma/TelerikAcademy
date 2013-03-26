using System;
using System.Linq;

class Table : ElementNode
{
    public Table()
        : base("table")
    {
        return;
    }

    public Table AppendChild(params Node[] childNodes)
    {
        base.AppendChild(childNodes.Where(child =>
            child is TableRow
        ).ToArray());

        return this;
    }

    public TableRow this[int index]
    {
        get { return this.childNodes[index] as TableRow; }
    }
}
