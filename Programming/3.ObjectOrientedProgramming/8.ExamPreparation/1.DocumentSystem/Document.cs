using System;
using System.Linq;
using System.Collections.Generic;

abstract class Document : IDocument
{
    public string Name { get; set; }
    public string Content { get; set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
            this.Name = value;

        if (key == "content")
            this.Content = value;
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        var output = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(output);

        string attributes = String.Join(";", output
            .Where(
                prop => prop.Value != null
            )
            .OrderBy(
                prop => prop.Key
            )
            .Select(
                prop => prop.Key + "=" + prop.Value
            )
        );

        return this.ToStringHelper(attributes);
    }

    protected string ToStringHelper(string info)
    {
        return String.Format("{0}[{1}]", this.GetType(), info);
    }
}
