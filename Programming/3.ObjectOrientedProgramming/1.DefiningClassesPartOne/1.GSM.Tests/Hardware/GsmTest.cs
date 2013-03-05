using System;
using GSM.Hardware;

namespace GSM.Tests.Hardware
{
    class GsmTest : Test
    {
        public static void Print(Gsm gsm)
        {
            Print("GSM", gsm.ToString());
        }
    }
}
