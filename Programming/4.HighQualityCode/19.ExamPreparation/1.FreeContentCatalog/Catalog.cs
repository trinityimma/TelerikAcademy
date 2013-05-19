using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace FreeContentCatalog
{
    public class Catalog : ICatalog
    {
        private static readonly bool allowDuplicateValues = true;

        private readonly OrderedMultiDictionary<string, IContent> title =
            new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);

        private readonly MultiDictionary<string, IContent> url =
            new MultiDictionary<string, IContent>(allowDuplicateValues);

        public int Count
        {
            get { return this.title.Select(pair => pair.Value.Count).Sum(); }
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.Url, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int count)
        {
            var matchedElements = this.title[title];
            var result = matchedElements.Take(count);
            return result;
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            var matchedElements = this.url[oldUrl];

            foreach (Content content in matchedElements)
            {
                content.Url = newUrl;
            }

            this.url.Remove(oldUrl);
            this.url.AddMany(newUrl, matchedElements);

            return matchedElements.Count;
        }
    }
}
