using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CalendarSystem
{
    public class Example
    {
        public static void Main()
        {
            // Console.SetIn(new StreamReader("../../../CalendarSystem.Tests/Tests/test.010.in.txt"));
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
