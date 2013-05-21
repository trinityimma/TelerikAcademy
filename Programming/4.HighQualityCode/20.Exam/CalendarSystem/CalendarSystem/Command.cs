using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalendarSystem
{
    public class Command
    {
        private static Regex pattern = new Regex(@"(?<name>\S+) (?<parameters>.+)");

        public string Name { get; set; }

        public IList<string> Parameters { get; set; }

        public Command(string name, IList<string> parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }

        public static Command Parse(string s)
        {
            Match match = pattern.Match(s);
            if (!match.Success)
            {
                throw new FormatException("Invalid command: " + s);
            }

            string name = match.Groups["name"].Value;
            string parameters = match.Groups["parameters"].Value;

            // NOTE: There is an error (trailing whitespace) in "test.007.in.txt" at line 26, so I can't use this.
            //// string[] commandArguments = Regex.Split(args, Event.Separator);

            string[] commandArguments = Regex.Split(parameters, "\\u007c"); // " | "
            commandArguments = commandArguments.Select(parameter => parameter.Trim()).ToArray();

            Command command = new Command(name, commandArguments);
            return command;
        }

        public override bool Equals(Object obj)
        {
            Command other = obj as Command;

            if (other == null)
            {
                return false;
            }

            bool result = this.Name == other.Name &&
                this.Parameters.SequenceEqual(other.Parameters);

            return result;
        }
    }
}
