using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace CalendarSystem
{
    public class EventsManagerFast : IEventsManager
    {
        private static readonly bool AllowDuplicateValues = true;

        private readonly MultiDictionary<string, Event> eventsByTitle =
            new MultiDictionary<string, Event>(AllowDuplicateValues);

        private readonly OrderedMultiDictionary<DateTime, Event> eventsByDate =
            new OrderedMultiDictionary<DateTime, Event>(AllowDuplicateValues);

        // TODO: Optimize
        public int Count
        {
            get { return this.ListEvents(DateTime.MinValue, int.MaxValue).Count(); }
        }

        public void AddEvent(Event eventItem)
        {
            string lowerCasedTitle = eventItem.Title.ToLowerInvariant();
            this.eventsByTitle.Add(lowerCasedTitle, eventItem);
            this.eventsByDate.Add(eventItem.Date, eventItem);
        }

        public int DeleteEventsByTitle(string title)
        {
            string lowerCasedTitle = title.ToLowerInvariant();
            var matchedEventsByTitle = this.eventsByTitle[lowerCasedTitle];

            foreach (Event eventByTitle in matchedEventsByTitle)
            {
                this.eventsByDate.Remove(eventByTitle.Date, eventByTitle);
            }

            int result = matchedEventsByTitle.Count;
            this.eventsByTitle.Remove(lowerCasedTitle);
            return result;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var selected = this.eventsByDate.RangeFrom(date, true).Values;

            var limited = selected.Take(count);
            return limited;
        }
    }
}
