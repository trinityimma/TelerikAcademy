using System;
using System.Collections.Generic;

class VideoDocument : MultimediaDocument
{
    public int? FrameRate { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
            this.FrameRate = int.Parse(value);

        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));

        base.SaveAllProperties(output);
    }
}
