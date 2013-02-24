using System;
using System.Collections.Generic;

namespace GSM.Software
{
    public class Call : IComparable<Call>, IEquatable<long>
    {
        // Private Fields
        private static long idCounter = 0; // TODO: typedef
        private string dialedPhone = null;
        private TimeSpan duration;

        // Public Properties
        public readonly long Id = 0;
        public readonly DateTime Time = DateTime.MinValue;

        public string DialedPhone
        {
            get { return this.dialedPhone; }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Dialed phone can't be null!");

                dialedPhone = value;
            }
        }

        public TimeSpan Duration
        {
            get { return this.duration; }
   
            set
            {
                if (value.Equals(TimeSpan.Zero))
                    throw new ArgumentNullException("Duration can't be zero!");

                this.duration = value;
            }
        }
        
        // Constructors
        public Call(string dialedPhone, TimeSpan duration)
        {
            this.Id = Call.idCounter++;
            this.Time = DateTime.Now;

            this.DialedPhone = dialedPhone;
            this.Duration = duration;
        }

        // Methods
        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add("ID: " + this.Id);
            info.Add("Time: " + this.Time);
            info.Add("Dialed Phone: " + this.DialedPhone);
            info.Add("Duration: " + this.Duration);

            return String.Join(", ", info);
        }

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
    }
}
