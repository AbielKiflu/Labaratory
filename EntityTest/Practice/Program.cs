using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static int counter = 0;
    static Semaphore semaphore = new Semaphore(2, 2); // Allowing two concurrent operations

    static void Main()
    {
        // Create tasks for parallel execution
        Task[] tasks = new Task[5];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(WorkerMethod);
        }

        // Wait for all tasks to complete
        Task.WaitAll(tasks);
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Main thread");
         
        Console.WriteLine("All tasks have finished execution");
        Console.WriteLine("Counter value: " + counter);
        Console.ReadLine();
    }

    static void WorkerMethod()
    {
        semaphore.WaitOne(); // Acquire a semaphore slot
        try
        {
            // Simulating some work
            Console.WriteLine("Thread {0} started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000); // Simulating work by sleeping for 1 second
            Interlocked.Increment(ref counter); // Atomic increment operation
            Console.WriteLine("Thread {0} finished", Thread.CurrentThread.ManagedThreadId);
        }
        finally
        {
            semaphore.Release(); // Release the semaphore slot
        }
    }
}