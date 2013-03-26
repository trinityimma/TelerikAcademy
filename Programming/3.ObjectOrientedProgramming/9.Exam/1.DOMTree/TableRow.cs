using System;
using System.Linq;

class TableRow : ElementNode
{
    public TableRow()
        : base("tr")
    {
        return;
    }

    public TableRow AppendChild(params Node[] childNodes)
    {
        base.AppendChild(childNodes.Where(child =>
            (child is ElementNode) && (child as ElementNode).TagName == "td"
        ).ToArray());

        return this;
    }

    public ElementNode this[int index]
    {
        get { return this.childNodes[index] as ElementNode; }
    }
}
