using System;
using System.Linq;
using System.Collections.Generic;

namespace GSM.Software
{
    public class CallHistory
    {
        // Private Fields
        private readonly List<Call> callHistory = new List<Call>();

        // Public Properties
        public int Count
        {
            get{ return this.callHistory.Count; }
        }

        // Methods
        public void Add(Call call)
        {
            this.callHistory.Add(call);
        }

        public void Remove(long id)
        {
            this.callHistory.RemoveAll(call => call.Equals(id));
        }

        public void Remove(Call call)
        {
            this.callHistory.Remove(call);
        }

        public void Clear()
        {
            this.callHistory.Clear();
        }

        public Call Get(long id)
        {
            return this.callHistory.Find(call => call.Equals(id));
        }

        public Call GetLongestCall()
        {
            return this.callHistory.Max();
        }

        public int GetStartedMinutes()
        {
            return (int)(this.callHistory.Sum(
                call => Math.Ceiling(call.Duration.TotalSeconds / 60.0)
            ));
        }

        public decimal CalculatePrice(decimal pricePerMinute)
        {
            return GetStartedMinutes() * pricePerMinute;
        }

        public override string ToString()
        {
            if (this.callHistory.Count == 0)
                return "No history available.";

            List<string> info = new List<string>();

            for (int i = 0; i < this.callHistory.Count; i++)
                info.Add(String.Format("Call {0}: {1}", i, this.callHistory[i]));

            return String.Join(Environment.NewLine, info);
        }
    }
}
