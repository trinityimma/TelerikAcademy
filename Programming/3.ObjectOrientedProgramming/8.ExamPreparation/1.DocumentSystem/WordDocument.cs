using System;
using System.Collections.Generic;

class WordDocument : OfficeDocument, IEditable
{
    public int? Chars { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
            this.Chars = int.Parse(value);

        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.Chars));

        base.SaveAllProperties(output);
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
}
