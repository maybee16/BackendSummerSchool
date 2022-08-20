using System;

namespace WritelineLibrary
{
    public static class ColorMessage
    {
        public static void Get(string s, ConsoleColor consoleColor)
        {
            Console.WriteLine();
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
