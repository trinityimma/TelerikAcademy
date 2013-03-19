interface IRenderer
{
    int Rows { get; }
    int Cols { get; }

    void Add(IDrawable obj);

    void Clear();

    void RenderAll();
}
