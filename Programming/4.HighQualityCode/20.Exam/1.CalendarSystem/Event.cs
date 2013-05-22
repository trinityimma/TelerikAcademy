using System;
using System.Linq;
using System.Collections.Generic;

namespace CalendarSystem
{
    public class Event : IComparable<Event>
    {
        public static readonly string Separator = " | ";

        public static readonly string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public Event(DateTime date, string title, string location = null)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public int CompareTo(Event other)
        {
            int comparedByDate = DateTime.Compare(this.Date, other.Date);
            if (comparedByDate != 0)
            {
                return comparedByDate;
            }

            int comparedByTitle = string.Compare(this.Title, other.Title, StringComparison.InvariantCulture);
            if (comparedByTitle != 0)
            {
                return comparedByTitle;
            }

            // No need for null checking, it is sorted at the top automatically
            int comparedByLocation = string.Compare(this.Location, other.Location, StringComparison.InvariantCulture);
            return comparedByLocation;
        }

        public override bool Equals(object obj)
        {
            Event other = obj as Event;

            if (other == null)
            {
                return false;
            }

            bool result = this.CompareTo(other) == 0;
            return result;
        }

        public override int GetHashCode()
        {
            int result = this.Title.GetHashCode() ^ this.Date.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add(this.Date.ToString(Event.DateTimeFormat));
            info.Add(this.Title);

            if (this.Location != null)
            {
                info.Add(this.Location);
            }

            string result = string.Join(Event.Separator, info);
            return result;
        }
    }
}
