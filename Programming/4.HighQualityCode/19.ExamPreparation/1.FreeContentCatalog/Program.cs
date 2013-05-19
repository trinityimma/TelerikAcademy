using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace FreeContentCatalog
{
    public static class Program
    {
        public static void Main()
        {
            Catalog catalog = new Catalog();

            ICommandExecutor commandExecutor = new CommandExecutor();
            StringBuilder output = new StringBuilder();

            foreach (ICommand command in ReadAllCommands())
            {
                commandExecutor.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output);
        }

        private static string ReadCommand()
        {
            string command = Console.ReadLine().Trim();
            return command;
        }

        private static IList<ICommand> ReadAllCommands()
        {
            IList<ICommand> commands = new List<ICommand>();

            for (string command = null; (command = ReadCommand()) != "End"; )
            {
                commands.Add(new Command(command));
            }

            return commands;
        }
    }
}
