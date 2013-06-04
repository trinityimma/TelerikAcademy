using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Traverse(string root)
    {
        var folder = new Folder(root);

        foreach (string file in Directory.GetFiles(root))
            folder.Add(new File(file, File));

        foreach (string directory in Directory.GetDirectories(root))
            Traverse(directory);
    }

    static void Main()
    {
        File

        Traverse(@"C:\Program Files\");
    }
}
