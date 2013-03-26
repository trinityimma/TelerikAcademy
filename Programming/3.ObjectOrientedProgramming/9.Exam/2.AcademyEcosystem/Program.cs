using System;

namespace AcademyEcosystem
{
    class Program
    {
        static Engine GetEngineInstance()
        {
            // Side effect
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../0.input.txt"));
#endif

            return new AdvancedEngine();
        }

        static void Main(string[] args)
        {
            Engine engine = GetEngineInstance();

            string command = Console.ReadLine();
            while (command != "end")
            {
                engine.ExecuteCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}
