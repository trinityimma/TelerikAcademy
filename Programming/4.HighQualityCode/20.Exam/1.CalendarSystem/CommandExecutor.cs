using System;
using System.Linq;
using System.Globalization;

namespace CalendarSystem
{
    public class CommandExecutor
    {
        private readonly IEventsManager eventsManager = null;

        public IEventsManager EventsManager
        {
            get { return this.eventsManager; }
        }

        public CommandExecutor(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public string ProcessCommand(Command command)
        {
            switch (command.Name)
            {
                case "AddEvent":
                    return this.ProcessAddEvent(command);

                case "DeleteEvents":
                    return this.ProcessDeleteEvents(command);

                case "ListEvents":
                    return this.ProcessListEvents(command);

                default:
                    throw new ArgumentException("Invalid command: " + command);
            }
        }

        private string ProcessAddEvent(Command command)
        {
            if (!(command.Parameters.Count == 2 || command.Parameters.Count == 3))
            {
                throw new FormatException("Invalid number of parameters: " + command.Parameters.Count);
            }

            DateTime date = ParseDate(command.Parameters[0]);
            string title = command.Parameters[1];
            string location = (command.Parameters.Count == 3) ? command.Parameters[2] : null;

            Event @event = new Event(date, title, location);
            this.eventsManager.AddEvent(@event);
            return "Event added";
        }

        private string ProcessDeleteEvents(Command command)
        {
            if (!(command.Parameters.Count == 1))
            {
                throw new FormatException("Invalid number of parameters: " + command.Parameters.Count);
            }

            int numberOfDeletedEvents = this.eventsManager.DeleteEventsByTitle(command.Parameters[0]);

            if (numberOfDeletedEvents == 0)
            {
                return "No events found";
            }

            return numberOfDeletedEvents + " events deleted";
        }

        private string ProcessListEvents(Command command)
        {
            if (!(command.Parameters.Count == 2))
            {
                throw new FormatException("Invalid number of parameters: " + command.Parameters.Count);
            }

            DateTime startDate = ParseDate(command.Parameters[0]);
            int count = int.Parse(command.Parameters[1]);

            var events = this.eventsManager.ListEvents(startDate, count);

            if (!events.Any())
            {
                return "No events found";
            }

            string result = string.Join(Environment.NewLine, events);
            return result;
        }

        private static DateTime ParseDate(string date)
        {
            DateTime result = DateTime.ParseExact(date, Event.DateTimeFormat, CultureInfo.InvariantCulture);
            return result;
        }
    }
}
