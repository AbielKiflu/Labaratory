//using ThreadSafeUI;

namespace WinFormsApp1
{

    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>


        [STAThread]
        static  void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,

            ApplicationConfiguration.Initialize();
            //int fib = await new HeaveyTask().fibno(5);
            //Console.WriteLine( fib);
            //Console.ReadKey();
            Application.Run(new Form1());
        }
    }





}