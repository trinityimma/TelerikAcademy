using System;
using System.Collections.Generic;

class PDFDocument : EncryptableBinaryDocument
{
    public int? Pages { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
            this.Pages = int.Parse(value);

        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.Pages));

        base.SaveAllProperties(output);
    }
}
