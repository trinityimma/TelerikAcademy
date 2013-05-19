using System;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public class Content : IContent
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public string Url { get; set; }

        public ContentType Type { get; set; }

        public string TextRepresentation
        {
            get { return this.ToString(); }
            set { throw new InvalidOperationException("Can not set TextRepresentation."); }
        }

        public Content(ContentType type, string title, string author, long size, string url)
        {
            this.Type = type;
            this.Title = title;
            this.Author = author;
            this.Size = size;
            this.Url = url;
        }

        public int CompareTo(IContent other)
        {
            int result = this.TextRepresentation.CompareTo(other.TextRepresentation);
            return result;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.AppendFormat("{0}: ", this.Type.ToString());
            info.AppendFormat(string.Join("; ", this.Title, this.Author, this.Size, this.Url));

            return info.ToString();
        }
    }
}
