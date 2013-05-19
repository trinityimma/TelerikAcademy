using System;
using System.Collections.Generic;

namespace FreeContentCatalog
{
    public interface ICatalog
    {
        /// <summary>
        /// Adds a content to the current catalog.
        /// </summary>
        /// <param name="content">The content to be added.</param>
        void Add(IContent content);

        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        int UpdateContent(string oldUrl, string newUrl);
    }
}
