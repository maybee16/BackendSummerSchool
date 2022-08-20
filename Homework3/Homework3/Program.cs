using System;
using ConsoleLibrary;
using WritelineLibrary;


namespace Homework3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu menu = new();
                menu.Run();
            }
            catch (Exception ex)
            {
                ColorMessage.Get(ex.Message, ConsoleColor.Red);
            }
        }
    }
}
