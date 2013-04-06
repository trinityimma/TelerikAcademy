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
            (child is ElementNode) && (child as ElementNode).TagName == "tr"
        ).ToArray());

        return this;
    }

    public TableRow this[int index]
    {
        get { return this.childNodes[index] as TableRow; }
    }
}
