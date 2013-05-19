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

            for (string command = null; (command = Console.ReadLine().Trim()) != "End"; )
            {
                commandExecutor.ExecuteCommand(catalog, new Command(command), output);
            }

            Console.Write(output);
        }
    }
}
