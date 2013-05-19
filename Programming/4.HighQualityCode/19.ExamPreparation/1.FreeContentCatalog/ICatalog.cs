using System;
using System.Collections.Generic;

namespace FreeContentCatalog
{
    public interface ICatalog
    {
        // TODO: Documentation
        void Add(IContent content);

        IEnumerable<IContent> GetListContent(string title, int count);

        int UpdateContent(string oldUrl, string newUrl);
    }
}
