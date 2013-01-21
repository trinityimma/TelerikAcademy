using System;
using System.Net;

class Program
{
    static void Main()
    {
        string address = "http://www.devbg.org/img/Logo-BASD.jpg";

        WebClient webClient = new WebClient();

        try
        {
        
            webClient.DownloadFile(address, Environment.CurrentDirectory + @"\Logo-BASD.jpg");
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
