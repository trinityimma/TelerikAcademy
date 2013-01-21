using System;
using System.Net;

class Program
{
    static void Main()
    {
        WebClient webClient = new WebClient();

        try
        {
            webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", Environment.CurrentDirectory + @"\logo.jpg");
        }

        catch (WebException)
        {
            Console.WriteLine("The address is invalid.");
        }

        catch (NotSupportedException)
        {
            Console.WriteLine("The method has been called simultaneously on multiple threads.");
        }

        finally
        {
            webClient.Dispose();
        }
    }
}
