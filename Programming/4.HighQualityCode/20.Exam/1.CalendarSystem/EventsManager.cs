using System;
using System.Linq;
using System.Collections.Generic;

namespace CalendarSystem
{
    public class EventsManager : IEventsManager
    {
        private readonly List<Event> list = new List<Event>();

        public void AddEvent(Event eventItem)
        {
            this.list.Add(eventItem);
        }

        public int DeleteEventsByTitle(string title)
        {
            int numberOfDeletedEvents = this.list.RemoveAll(e =>
                e.Title.ToLowerInvariant() == title.ToLowerInvariant());

            return numberOfDeletedEvents;
        }

        public IEnumerable<Event> ListEvents(DateTime startDate, int count)
        {
            var selected = this.list.Where(@event =>
                @event.Date >= startDate
            );

            var sorted = selected.OrderBy(@event => @event);

            var limited = sorted.Take(count);
            return limited;
        }
    }
}
