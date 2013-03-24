using System;
using System.Collections.Generic;

class TextDocument : Document, IEditable
{
    public string Charset { get; set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
            this.Charset = value;

        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("charset", this.Charset));

        base.SaveAllProperties(output);
    }
}
