using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CalendarSystem
{
    /*
     * # Problem 5: Performance Bottlenecks
     * 
     * Using StringBuilder for buffering, a custom hash function,
     * removed all ToList() and using only IEnumerable.
     * At EventManagerFast - line 88 - Allready sorted by date, but I don't know how to use it
     * It is also slow, because there is a lot of LINQ and regular expressions.
     * 
     * Tests 009-016 are valid and work, but take 30+ seconds.
     */

    public class Example
    {
        public static void Main()
        {
            Console.SetIn(new StreamReader("../../../CalendarSystem.Tests/Tests/test.010.in.txt"));
            // Console.SetIn(new StreamReader("../../input.txt"));

            // IEventsManager eventsManager = new EventsManager();
            IEventsManager eventsManager = new EventsManagerFast();

            CommandExecutor commandExecutor = new CommandExecutor(eventsManager);
            StringBuilder output = new StringBuilder();

            for (string line = null; (line = ReadCommand()) != "End"; )
            {
                Command command = Command.Parse(line);
                string result = commandExecutor.ProcessCommand(command);
                output.AppendLine(result);
                // Console.WriteLine(result);
            }

            Console.Write(output);
        }

        private static string ReadCommand()
        {
            return Console.ReadLine().Trim();
        }
    }
}
