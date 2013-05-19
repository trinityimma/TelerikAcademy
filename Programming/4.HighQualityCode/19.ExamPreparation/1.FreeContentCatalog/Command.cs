using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FreeContentCatalog
{
    public class Command : ICommand
    {
        private static readonly Dictionary<string, CommandType> command =
            new Dictionary<string, CommandType>()
        {
            { "Add book", CommandType.AddBook },
            { "Add movie", CommandType.AddMovie },
            { "Add song", CommandType.AddSong },
            { "Add application", CommandType.AddApplication },
            { "Update", CommandType.Update },
            { "Find", CommandType.Find }
        };

        private static readonly string paramsSeparators = "; ";
        private static readonly string commandEnd = ": ";

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        private int commandNameEndIndex = 0;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();

            this.Parse();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();

            this.Type = this.ParseCommandType(this.Name);
        }

        public CommandType ParseCommandType(string commandName)
        {
            return command[commandName];
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsStartIndex = this.commandNameEndIndex + 3;
            string paramsOriginalForm = this.OriginalForm.Substring(
                paramsStartIndex, this.OriginalForm.Length - paramsStartIndex);

            string[] parameters = Regex.Split(paramsOriginalForm, paramsSeparators);
            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(commandEnd) - 1;
            return endIndex;
        }

        //public override string ToString()
        //{
        //    StringBuilder info = new StringBuilder();

        //    info.AppendFormat("{0} ", this.Name);
        //    info.AppendFormat(string.Join(" ", this.Parameters));

        //    return info.ToString();
        //}
    }
}
