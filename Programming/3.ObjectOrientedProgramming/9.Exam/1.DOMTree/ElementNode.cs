using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class ElementNode : Node, IEnumerable
{
    protected readonly List<Node> childNodes = new List<Node>();

    public string TagName { get; private set; }

    public Node FirstChild
    {
        get { return this.childNodes.FirstOrDefault(); }
    }

    public Node LastChild
    {
        get { return this.childNodes.LastOrDefault(); }
    }

    public ElementNode(string tagName)
    {
        this.TagName = tagName.ToLower();
    }

    public virtual ElementNode AppendChild(params Node[] childNodes)
    {
        this.childNodes.AddRange(childNodes);

        return this;
    }

    // Object initializater
    public void Add(Node node)
    {
        this.AppendChild(node);
    }

    public IEnumerator GetEnumerator()
    {
        return this.childNodes.GetEnumerator();
    }

    public override void Render()
    {
        Node.Indent();
        Node.Stack++;

        Node.Renderer.AppendFormat("<{0}>", this.TagName).AppendLine();

        this.childNodes.ForEach(node =>
            node.Render()
        );

        Node.Stack--;
        Node.Indent();

        Node.Renderer.AppendFormat("</{0}>", this.TagName).AppendLine();
    }
}
