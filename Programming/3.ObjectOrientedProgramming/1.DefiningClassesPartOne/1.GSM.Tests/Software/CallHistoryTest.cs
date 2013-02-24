using System;
using System.Collections.Generic;
using GSM.Software;

namespace GSM.Tests.Software
{
    public class CallHistoryTest : Test
    {
        // Private Fields
        private readonly CallHistory callHistory = null;

        // Constructors
        public CallHistoryTest(CallHistory callHistory)
        {
            this.callHistory = callHistory;
        }

        // Methods
        public void GetPrice(decimal price)
        {
            List<string> info = new List<string>();

            info.Add(String.Format("Minutes: {0}", this.callHistory.GetStartedMinutes()));
            info.Add(String.Format("Price {0}: {1}", price, this.callHistory.CalculatePrice(price)));

            Print("Calculating price", String.Join(Environment.NewLine, info));
        }

        public void Remove(long id)
        {
            List<string> info = new List<string>();

            info.Add(String.Format("Removed: {0}", this.callHistory.Get(id).ToString()));
            this.callHistory.Remove(id);

            info.Add("Remaining:");
            info.Add(this.callHistory.ToString());

            Print("Removing a call ID", String.Join(Environment.NewLine, info));
        }

        public void RemoveLongestCall()
        {
            Call longestCall = this.callHistory.GetLongestCall();

            this.callHistory.Remove(longestCall);

            Print("Remove longest call", longestCall.ToString());
        }

        public void ClearHistory()
        {
            this.callHistory.Clear();

            Print("Clear history", this.callHistory.ToString());
        }
    }
}
