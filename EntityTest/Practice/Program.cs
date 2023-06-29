using Microsoft.VisualBasic;
using Practice;
using System.Dynamic;
using System.Numerics;

namespace MyProgram
{
    class Program
    {
        static async Task Main()
        {
            await ExecuteAsync();
            
            Console.WriteLine("Waiting");

            Console.ReadKey();
        }

        static async Task ExecuteAsync()
        {
            int counter = 0;

            while (counter < 5)
            {
                Console.WriteLine($"Iteration {counter + 1}");
                await Task.Delay(1000); // Simulating an asynchronous operation with a delay of 1 second
                counter++;
            }

        }
    }
 

     
}
 