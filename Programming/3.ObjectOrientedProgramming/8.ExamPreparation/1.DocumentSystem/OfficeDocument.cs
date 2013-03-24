using System;
using System.Collections.Generic;

abstract class OfficeDocument : EncryptableBinaryDocument
{
    public string Version { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "version")
            this.Version = value;
        
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("version", this.Version));

        base.SaveAllProperties(output);
    }
}
