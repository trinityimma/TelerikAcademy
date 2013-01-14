using System;

class Program
{
    static void Main()
    {
        Console.Write("name: ");
        string name = Console.ReadLine();

        Console.Write("address: ");
        string address = Console.ReadLine();

        Console.Write("phoneNumber: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("faxNumber: ");
        string faxNumber = Console.ReadLine();

        Console.Write("webSite: ");
        string webSite = Console.ReadLine();

        Console.Write("managerFirstName: ");
        string managerFirstName = Console.ReadLine();

        Console.Write("managerLastName: ");
        string managerLastName = Console.ReadLine();

        Console.Write("managerAge: ");
        string managerAge = Console.ReadLine();

        Console.Write("managerPhoneNumber: ");
        string managerPhoneNumber = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine("name: " + name);
        Console.WriteLine("address: " + address);
        Console.WriteLine("phoneNumber: " + phoneNumber);
        Console.WriteLine("faxNumber: " + faxNumber);
        Console.WriteLine("webSite: " + webSite);
        Console.WriteLine("managerFirstName: " + managerFirstName);
        Console.WriteLine("managerLastName: " + managerLastName);
        Console.WriteLine("managerAge: " + managerAge);
        Console.WriteLine("managerPhoneNumber: " + managerPhoneNumber);
    }
}
