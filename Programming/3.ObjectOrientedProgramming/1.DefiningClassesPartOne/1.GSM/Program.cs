using System;

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

        // Print
        GsmTest.Print(gsms[0]);
        GsmTest.Print(gsms[1]);

        // CALL TEST
        CallHistoryTest callHistoryTest = new CallHistoryTest(gsms[1].CallHistory);

        // Calculate price
        callHistoryTest.GetPrice(price);

        // Remove call
        callHistoryTest.Remove(id: 2);

        // Calculate price
        callHistoryTest.GetPrice(price);

        // Remove longest call
        callHistoryTest.RemoveLongestCall();

        // Calculate price
        callHistoryTest.GetPrice(price);

        // Clear call history
        callHistoryTest.ClearHistory();
    }
}
