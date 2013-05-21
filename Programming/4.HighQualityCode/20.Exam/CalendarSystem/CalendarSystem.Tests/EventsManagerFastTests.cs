using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class EventsManagerFastTests
    {
        [TestMethod]
        public void AddSingle()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));

            int expected = 1;
            int actual = eventsManager.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddDuplicateValue()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));

            int expected = 2;
            int actual = eventsManager.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddDuplicateReference()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            Event @event = new Event(DateTime.MinValue, "party Viki");
            eventsManager.AddEvent(@event);
            eventsManager.AddEvent(@event);

            int expected = 2;
            int actual = eventsManager.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddSingleAndDuplicate()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));

            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));
            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));

            Event @event = new Event(DateTime.MinValue, "party Pesho");
            eventsManager.AddEvent(@event);
            eventsManager.AddEvent(@event);

            int expected = 5;
            int actual = eventsManager.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListEmpty()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            int expected = 0;
            int actual = eventsManager.ListEvents(DateTime.MinValue, 1).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListSingle()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));

            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));
            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));

            int expected = 1;
            int actual = eventsManager.ListEvents(DateTime.MinValue, 1).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListWithLessElements()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));

            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));
            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));

            int expected = 1;
            int actual = eventsManager.ListEvents(DateTime.MaxValue, 1).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListWithEqualElements()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));

            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));
            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));

            int expected = 2;
            int actual = eventsManager.ListEvents(DateTime.MaxValue, 2).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListWithMoreElements()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));

            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));
            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));

            int expected = 2;
            int actual = eventsManager.ListEvents(DateTime.MaxValue, 3).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListWithFilterNoElements()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));

            eventsManager.AddEvent(new Event(new DateTime(2010, 12, 10), "party Gosho"));
            eventsManager.AddEvent(new Event(new DateTime(2010, 12, 10), "party Gosho"));

            int expected = 0;
            int actual = eventsManager.ListEvents(DateTime.MaxValue, int.MaxValue).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListWithFilterSomeElements()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));

            eventsManager.AddEvent(new Event(new DateTime(2010, 12, 10), "party Gosho"));
            eventsManager.AddEvent(new Event(new DateTime(2010, 12, 10), "party Gosho"));

            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));
            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov"));

            int expected = 3;
            int actual = eventsManager.ListEvents(new DateTime(2010, 12, 10), 3).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListWithSortingByDate()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Viki"));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki"));

            var result = eventsManager.ListEvents(DateTime.MinValue, int.MaxValue);

            Assert.AreEqual(result.ElementAt(0).Date, DateTime.MinValue);
            Assert.AreEqual(result.ElementAt(1).Date, DateTime.MaxValue);
        }

        [TestMethod]
        public void ListWithSortingByTitle()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "b"));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "a"));

            var result = eventsManager.ListEvents(DateTime.MinValue, int.MaxValue);

            Assert.AreEqual(result.ElementAt(0).Title, "a");
            Assert.AreEqual(result.ElementAt(1).Title, "b");
        }

        [TestMethod]
        public void ListWithSortingByLocation()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "a", "b"));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "a", "a"));

            var result = eventsManager.ListEvents(DateTime.MinValue, int.MaxValue);

            Assert.AreEqual(result.ElementAt(0).Location, "a");
            Assert.AreEqual(result.ElementAt(1).Location, "b");
        }

        [TestMethod]
        public void ListWithSortingByMissingLocation()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "a"));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "a", "a"));

            var result = eventsManager.ListEvents(DateTime.MinValue, int.MaxValue);

            Assert.AreEqual(result.ElementAt(0).Location, null);
            Assert.AreEqual(result.ElementAt(1).Location, "a");
        }

        [TestMethod]
        public void ListComplex()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(new DateTime(2010, 12, 10), "party Gosho", null));
            eventsManager.AddEvent(new Event(new DateTime(2010, 12, 10), "party Gosho", "home"));

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki", null));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Viki", "work"));

            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov", null));
            eventsManager.AddEvent(new Event(DateTime.MaxValue, "party Nakov", "telerik"));

            var result = eventsManager.ListEvents(new DateTime(2010, 12, 10), 3);

            int expected = 3;
            int actual = result.Count();

            Assert.AreEqual(expected, actual);

            Assert.AreEqual(result.ElementAt(0).Location, null);
            Assert.AreEqual(result.ElementAt(1).Location, "home");
            Assert.AreEqual(result.ElementAt(2).Location, null);
        }

        [TestMethod]
        public void DeleteEmpty()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Gosho", null));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Gosho", null));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Gosho", null));

            int expected = 0;
            int actual = eventsManager.DeleteEventsByTitle("party Nakov");

            Assert.AreEqual(expected, actual);

            int expectedCount = 3;
            int actualCount = eventsManager.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void DeleteSingle()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Gosho", null));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Gosho", null));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Gosho", null));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Nakov", null));

            int expected = 1;
            int actual = eventsManager.DeleteEventsByTitle("party Nakov");

            Assert.AreEqual(expected, actual);

            int expectedCount = 3;
            int actualCount = eventsManager.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void DeleteMultiple()
        {
            EventsManagerFast eventsManager = new EventsManagerFast();

            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Gosho", null));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Gosho", null));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Gosho", null));
            
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Nakov", null));
            eventsManager.AddEvent(new Event(DateTime.MinValue, "party Nakov", null));

            int expected = 2;
            int actual = eventsManager.DeleteEventsByTitle("party Nakov");

            Assert.AreEqual(expected, actual);

            int expectedCount = 3;
            int actualCount = eventsManager.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
