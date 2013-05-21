using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void RunnerSample()
        {
            string input =
@"AddEvent 2012-01-21T20:00:00 | party Viki | home
AddEvent 2012-03-26T09:00:00 | C# exam
AddEvent 2012-03-26T09:00:00 | C# exam
AddEvent 2012-03-26T08:00:00 | C# exam
AddEvent 2012-03-07T22:30:00 | party | Vitosha
ListEvents 2012-03-07T08:00:00 | 3
DeleteEvents c# exam
DeleteEvents My granny's bushes
ListEvents 2013-11-27T08:30:25 | 25
AddEvent 2012-03-07T22:30:00 | party | Club XXX
ListEvents 2012-01-07T20:00:00 | 10
AddEvent 2012-03-07T22:30:00 | Party | Club XXX
ListEvents 2012-03-07T22:30:00 | 3
End";

            string expected =
@"Event added
Event added
Event added
Event added
Event added
2012-03-07T22:30:00 | party | Vitosha
2012-03-26T08:00:00 | C# exam
2012-03-26T09:00:00 | C# exam
3 events deleted
No events found
No events found
Event added
2012-01-21T20:00:00 | party Viki | home
2012-03-07T22:30:00 | party | Club XXX
2012-03-07T22:30:00 | party | Vitosha
Event added
2012-03-07T22:30:00 | party | Club XXX
2012-03-07T22:30:00 | party | Vitosha
2012-03-07T22:30:00 | Party | Club XXX";

            Console.SetIn(new StringReader(input));
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            Example.Main();

            string actual = output.ToString().TrimEnd();
            Assert.AreEqual(expected, actual);
        }

        // TODO: Extract constants and variables
        [TestMethod]
        public void RunnerLight()
        {
            for (int i = 1; i <= 8; i++)
            {
                string input = File.ReadAllText("../../Tests/test." + i.ToString().PadLeft(3, '0') + ".in.txt");
                string expected = File.ReadAllText("../../Tests/test." + i.ToString().PadLeft(3, '0') + ".out.txt");

                Console.SetIn(new StringReader(input));
                StringWriter output = new StringWriter();
                Console.SetOut(output);

                Example.Main();

                string actual = output.ToString();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        //[Ignore]
        public void TestRunnerHard()
        {
            // Some tests run in about 1+ minute, so please wait
            // They pass for about 6 minutes - look at the screenshot
            for (int i = 9; i <= 16; i++)
            {
                string input = File.ReadAllText("../../Tests/test." + i.ToString().PadLeft(3, '0') + ".in.txt");
                string expected = File.ReadAllText("../../Tests/test." + i.ToString().PadLeft(3, '0') + ".out.txt");

                Console.SetIn(new StringReader(input));
                StringWriter output = new StringWriter();
                Console.SetOut(output);

                Example.Main();

                string actual = output.ToString();
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
