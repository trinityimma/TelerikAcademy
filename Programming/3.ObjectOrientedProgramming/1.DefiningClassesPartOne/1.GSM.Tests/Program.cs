using System;
using GSM.Hardware;
using GSM.Software;
using GSM.Tests.Hardware;
using GSM.Tests.Software;

namespace GSM.Tests
{
    class Program
    {
        static void Main()
        {
            decimal price = .37M;

            Gsm[] gsms = new Gsm[2];

            // GSM 0
            {
                gsms[0] = Gsm.IPhone4S;
            }

            // GSM 1
            {
                Display display = new Display(480, 320);
                Battery battery = new Battery(Battery.Type.LiIon);

                gsms[1] = new Gsm("iPhone 5", "Apple", display: display, battery: battery);

                gsms[1].CallHistory.Add(new Call("123", new TimeSpan(0, 1, 10))); // Hours, Minutes, Seconds
                gsms[1].CallHistory.Add(new Call("456", new TimeSpan(0, 2, 20)));
                gsms[1].CallHistory.Add(new Call("123", new TimeSpan(0, 2, 0)));
                gsms[1].CallHistory.Add(new Call("456", new TimeSpan(0, 1, 0)));
            }

            foreach (Gsm gsm in gsms)
                GsmTest.Print(gsm);
            
            CallHistoryTest callHistoryTest = new CallHistoryTest(gsms[1].CallHistory);

            callHistoryTest.GetPrice(price);

            callHistoryTest.Remove(id: 2);

            callHistoryTest.GetPrice(price);

            callHistoryTest.RemoveLongestCall();

            callHistoryTest.GetPrice(price);

            callHistoryTest.ClearHistory();
        }
    }
}
