using System;

class TextLine : GameObject
{
    public TextLine(String text, Coordinates position)
        : base(new char[1, text.Length], Color.Gray, position)
    {
        for (int i = 0; i < text.Length; i++)
            this.Image[0, i] = text[i];
    }
}
