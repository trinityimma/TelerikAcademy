using System;

class TextNode : Node
{
    public string Data { get; private set; }

    public TextNode(string data)
    {
        this.Data = data;
    }

    public override void Render()
    {
        Node.Indent();

        Node.Renderer.AppendLine(this.Data);
    }
}
