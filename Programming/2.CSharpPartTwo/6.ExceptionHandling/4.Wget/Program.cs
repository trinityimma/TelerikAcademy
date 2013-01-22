using System;
using System.Net;

class Program
{
    static void Main()
    {
        using (WebClient webClient = new WebClient())
        {
            try
            {
                webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "/../../logo.jpg");
            }

            catch (WebException)
            {
                Console.WriteLine("The address is invalid.");
            }

            catch (NotSupportedException)
            {
                Console.WriteLine("The method has been called simultaneously on multiple threads.");
            }
        }
    }
}
