using System;
using System.Collections.Generic;
using System.Text;

class Folder
{
    public string Name { get; private set; }
    public IList<File> Files { get; private set; }
    public IList<Folder> NestedFolders { get; private set; }

    public Folder(string name)
    {
        this.Name = name;

        this.Files = new List<File>();
        this.NestedFolders = new List<Folder>();
    }

    public void Add(File file)
    {
        this.Files.Add(file);
    }

    public void AddFolder(Folder folder)
    {
        this.NestedFolders.Add(folder);
    }

    public ulong GetSize()
    {
        ulong result = 0;

        foreach (var file in this.Files)
            result += file.Size;

        foreach (var folder in this.NestedFolders)
            result += folder.GetSize();

        return result;
    }

    public override string ToString()
    {
        var info = new StringBuilder();

        foreach (var file in this.Files)
            info.AppendLine(file.ToString());

        foreach (var folder in this.NestedFolders)
            info.AppendLine(folder.ToString());

        return info.ToString();
    }
}
