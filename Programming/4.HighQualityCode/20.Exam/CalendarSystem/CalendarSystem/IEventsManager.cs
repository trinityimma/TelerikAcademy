using System;
using System.Collections.Generic;

namespace CalendarSystem
{
    public interface IEventsManager
    {
        /// <summary>
        /// Adds an <see cref="Event"/> to the current instance of the <see cref="IEventsManager"/>
        /// </summary>
        /// <param name="eventItem">The event to be added</param>
        /// <example>
        /// <code>
        ///     IEventsManager eventsManager = new EventsManager();
        ///     
        ///     eventsManager.add(new Event());
        /// </code>
        /// </example>
        void AddEvent(Event eventItem);

        /// <summary>
        /// Deletes all events that have the same title.
        /// </summary>
        /// <param name="title">The title to be compared against</param>
        /// <returns>Number of events deleted</returns>
        /// <example>
        /// <code>
        ///     IEventsManager eventsManager = new EventsManager();
        ///     
        ///     eventsManager.add(new Event("title 1"));
        ///     eventsManager.add(new Event("title 2"));
        ///     eventsManager.add(new Event("TITLE 2"));
        ///     eventsManager.add(new Event("tITLe 2"));
        ///     
        ///     eventsManager.DeleteEventsByTitle("title 2"); // 3
        ///     eventsManager.Count; // 1 - Only "title 1" left
        /// </code>
        /// </example>
        /// <remarks>This method is case insensitive.</remarks>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// Selects all events in the current list of events,
        /// sorts them by using <see cref="Event.CompareTo()"/>
        /// and returns only at maximum <c>count</c> elements.
        /// </summary>
        /// <param name="startDate">The start date of the range</param>
        /// <param name="count"></param>
        /// <returns>The matched events</returns>
        /// <example>
        /// <code>
        ///     IEventsManager eventsManager = new EventsManager();
        ///     
        ///     eventsManager.add(new Event(DateTime.MinValue, "title 1"));
        ///     eventsManager.add(new Event(DateTime.MinValue, "title 2"));
        ///     eventsManager.add(new Event(DateTime.MaxValue, "title 3"));
        ///     eventsManager.add(new Event(DateTime.MaxValue, "title 4"));
        ///     
        ///     var result = eventsManager.ListEvents(DateTime.MinValue, 3);
        ///     
        ///     // 0 -> title 1
        ///     // 1 -> title 2
        ///     // 2 -> title 3
        /// </code>
        /// </example>
        /// <remarks>The start date is inclusive</remarks>
        IEnumerable<Event> ListEvents(DateTime startDate, int count);
    }
}
