using System;
using System.Collections.Generic;

namespace GSM.Software
{
    public class Call : IComparable<Call>, IEquatable<long>
    {
        // Private Fields
        private static long idCounter = 0; // TODO: typedef
        private string dialedPhone = null;
        private TimeSpan duration = TimeSpan.Zero;

        // Public Properties
        public long Id { get; private set; }
        public DateTime Time { get; private set; }

        public string DialedPhone
        {
            get { return this.dialedPhone; }

            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Dialed phone can't be null!");

                this.dialedPhone = value;
            }
        }

        public TimeSpan Duration
        {
            get { return this.duration; }

            private set
            {
                if (value.Equals(TimeSpan.Zero))
                    throw new ArgumentNullException("Duration can't be zero!");

                this.duration = value;
            }
        }

        // Constructors
        public Call(string dialedPhone, TimeSpan duration)
        {
            this.DialedPhone = dialedPhone;
            this.Duration = duration;

            this.Id = Call.idCounter++;
            this.Time = DateTime.Now;
        }

        // Methods
        public bool Equals(long otherId)
        {
            return this.Id == otherId;
        }

        public bool Equals(Call other)
        {
            return this.Id == other.Id;
        }

        public int CompareTo(Call other)
        {
            return (int)(this.Duration - other.Duration).TotalSeconds;
        }

        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add("ID: " + this.Id);
            info.Add("Time: " + this.Time);
            info.Add("Dialed Phone: " + this.DialedPhone);
            info.Add("Duration: " + this.Duration);

            return String.Join(", ", info);
        }
    }
}
