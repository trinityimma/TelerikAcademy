using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace FreeContentCatalog
{
    public class CommandExecutor : ICommandExecutor
    {
        private static readonly Dictionary<CommandType, Action<ICatalog, ICommand, StringBuilder>> commandAction =
            new Dictionary<CommandType, Action<ICatalog, ICommand, StringBuilder>>()
        {
            {
                CommandType.AddBook, (catalog, command, output) =>
                {
                    catalog.Add(new Content(
                        ContentType.Book,
                        title: command.Parameters[0], author: command.Parameters[1],
                        size: long.Parse(command.Parameters[2]), url: command.Parameters[3])
                    );

                    output.AppendLine("Book added");
                }
            },

            {
                CommandType.AddMovie, (catalog, command, output) =>
                {
                    catalog.Add(new Content(
                        ContentType.Movie,
                        title: command.Parameters[0], author: command.Parameters[1],
                        size: long.Parse(command.Parameters[2]), url: command.Parameters[3])
                    );

                    output.AppendLine("Movie added");
                }
            },

            {
                CommandType.AddSong, (catalog, command, output) =>
                {
                    catalog.Add(new Content(
                        ContentType.Song,
                        title: command.Parameters[0], author: command.Parameters[1],
                        size: long.Parse(command.Parameters[2]), url: command.Parameters[3])
                    );

                    output.AppendLine("Song added");
                }
            },

            {
                CommandType.AddApplication, (catalog, command, output) =>
                {
                    catalog.Add(new Content(
                        ContentType.Application,
                        title: command.Parameters[0], author: command.Parameters[1],
                        size: long.Parse(command.Parameters[2]), url: command.Parameters[3])
                    );

                    output.AppendLine("Application added");
                }
            },

            {
                CommandType.Update, (catalog, command, output) =>
                {
                    int numberOfItemsUpdated = catalog.UpdateContent(
                        oldUrl: command.Parameters[0], newUrl: command.Parameters[1]
                    );

                    output.AppendLine(string.Format("{0} items updated", numberOfItemsUpdated));
                }
            },

            {
                CommandType.Find, (catalog, command, output) =>
                {
                    IEnumerable<IContent> foundContent = catalog.GetListContent(
                        title: command.Parameters[0], numberOfContentElementsToList: int.Parse(command.Parameters[1])
                    );

                    if (foundContent.Count() == 0)
                    {
                        output.AppendLine("No items found");
                        return;
                    }
                 
                    foreach (IContent content in foundContent)
                    {
                        output.AppendLine(content.TextRepresentation);
                    }
                }
            }
        };

        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            commandAction[command.Type](catalog, command, output);
        }
    }
}
