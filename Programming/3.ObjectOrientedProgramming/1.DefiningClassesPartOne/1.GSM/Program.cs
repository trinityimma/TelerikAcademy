using System;

class Program
{
    static void Main()
    {
        Display display = new Display(480, 320);
        Battery battery = new Battery(Battery.Type.LiIon);

        Gsm phone = new Gsm("iPhone 5", "Apple", display: display, battery: battery);

        Console.WriteLine(phone);
    }
}
