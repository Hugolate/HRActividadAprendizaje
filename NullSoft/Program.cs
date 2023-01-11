using System;
using System.Threading;
using Spectre.Console;


namespace NullSoft
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Language/Idioma (es/en)");
            try
            {
                Menu.allMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}