using System;
using System.Collections.Generic;

class ExcelDocument : OfficeDocument
{
    public int? Rows { get; set; }
    public int? Cols { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
            this.Rows = int.Parse(value);
        
        if (key == "cols")
            this.Cols = int.Parse(value);
        
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        output.Add(new KeyValuePair<string, object>("cols", this.Cols));

        base.SaveAllProperties(output);
    }
}
