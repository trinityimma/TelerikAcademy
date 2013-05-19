using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreeContentCatalog.Tests
{
    [TestClass]
    public class ICatalogTests
    {
        [TestMethod]
        public void CatalogTest()
        {
            string input = @"Find: One; 3
Add application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org 
Add book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info
Add song: One; Metallica; 8771120; http://goo.gl/dIkth7gs
Add movie: The Secret; Drew Heriot, Sean Byrne & others (2006); 832763834; http://t.co/dNV4d
Find: One; 1
Add movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/
Find: One; 10
Update: http://www.introprogramming.info; http://introprograming.info/en/
Find: Intro C#; 1
Update: http://nakov.com; sftp://www.nakov.com
End";

            string expected = @"No items found
Application added
Book added
Song added
Movie added
Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs
Movie added
Movie: One; James Wong (2001); 969763002; http://www.imdb.com/title/tt0267804/
Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs
1 items updated
Book: Intro C#; S.Nakov; 12763892; http://introprograming.info/en/
0 items updated";

            Console.SetIn(new StringReader(input));
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            Program.Main();

            string actual = output.ToString().TrimEnd();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddEmpty()
        {
            Catalog catalog = new Catalog();

            int expected = 0;
            int actual = catalog.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddSingle()
        {
            Catalog catalog = new Catalog();

            catalog.Add(new Content(
                ContentType.Application, "C#", "Nakov", 7, "http://nakov.com/"
            ));

            int expected = 1;
            int actual = catalog.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddDuplicateValue()
        {
            Catalog catalog = new Catalog();

            catalog.Add(new Content(
                ContentType.Application, "C#", "Nakov", 7, "http://nakov.com/"
            ));
            catalog.Add(new Content(
                ContentType.Application, "C#", "Nakov", 7, "http://nakov.com/"
            ));

            int expected = 2;
            int actual = catalog.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddDuplicateReference()
        {
            Catalog catalog = new Catalog();

            Content content = new Content(ContentType.Application, "C#", "Nakov", 7, "http://nakov.com/");
            catalog.Add(content);
            catalog.Add(content);

            int expected = 2;
            int actual = catalog.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddSingleAndDuplicate()
        {
            Catalog catalog = new Catalog();

            catalog.Add(new Content(
                ContentType.Application, "Java", "Pesho", 5, "http://pesho.com/"
            ));

            catalog.Add(new Content(
                ContentType.Application, "C#", "Nakov", 7, "http://nakov.com/"
            ));
            catalog.Add(new Content(
                ContentType.Application, "C#", "Nakov", 7, "http://nakov.com/"
            ));

            Content content = new Content(ContentType.Application, "Python", "Gosho", 12, "http://gosho.com/");
            catalog.Add(content);
            catalog.Add(content);

            int expected = 5;
            int actual = catalog.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetEmpty()
        {
            Catalog catalog = new Catalog();

            int expected = 0;
            int actual = catalog.GetListContent("Java", 1).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSingle()
        {
            Catalog catalog = new Catalog();

            catalog.Add(new Content(
                ContentType.Application, "Java", "Pesho", 5, "http://pesho.com/"
            ));

            int expected = 1;
            int actual = catalog.GetListContent("Java", 1).Count();

            Assert.AreEqual(expected, actual);
        }

        // TODO: ...
    }
}
