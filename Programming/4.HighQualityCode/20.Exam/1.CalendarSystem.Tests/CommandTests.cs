using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void ParseValid()
        {
            string commandStr = "AddEvent 2012-01-21T20:00:00 | Party Viki | home";
            Command expected = new Command("AddEvent", new string[] { "2012-01-21T20:00:00", "Party Viki", "home" });

            Command actual = Command.Parse(commandStr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseNull()
        {
            string commandStr = null;

            Command actual = Command.Parse(commandStr);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseEmpty()
        {
            string commandStr = String.Empty;

            Command actual = Command.Parse(commandStr);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseWithMissingArguments()
        {
            string commandStr = "AddEvent";

            Command actual = Command.Parse(commandStr);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseWithMissingArgumentsAndTrailingSpace()
        {
            string commandStr = "AddEvent ";

            Command actual = Command.Parse(commandStr);
        }

        [TestMethod]
        public void ParseWithOneArgument()
        {
            string commandStr = "AddEvent 2012-01-21T20:00:00";
            Command expected = new Command("AddEvent", new string[] { "2012-01-21T20:00:00" });

            Command actual = Command.Parse(commandStr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseWithManyArguments()
        {
            string commandStr = "AddEvent " + string.Join(Event.Separator, Enumerable.Range(0, 1000000));
            Command expected = new Command(
                "AddEvent",
                Enumerable.Range(0, 1000000).Select(n => n.ToString()).ToArray());

            Command actual = Command.Parse(commandStr);

            Assert.AreEqual(expected, actual);
        }
    }
}
