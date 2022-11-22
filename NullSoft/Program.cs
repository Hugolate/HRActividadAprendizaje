using System;
using System.Threading;

namespace NullSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is PlaySoft");
            Thread.Sleep(2000);
            Boolean bucle = false;
            while (!bucle)
            {
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                //Console.WriteLine("3. Search Songs");
                Console.WriteLine("3. Exit");
                int opcion = 0;
                while (opcion < 1 || opcion > 3)
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion < 1 || opcion > 3)
                    {
                        Console.WriteLine("Invalid option");
                    }
                }
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine(" _________________");
                        Console.WriteLine("|  Register menu  |");
                        Console.WriteLine("|-----------------|");
                        Console.WriteLine("|    Username     |");
                        Console.WriteLine("|    ________     |");
                        Console.WriteLine("|                 |");
                        Console.WriteLine("|    Password     |");
                        Console.WriteLine("|    ________     |");
                        Console.WriteLine("|_________________|");
                        Console.WriteLine("Write your username: ");
                        String username = Console.ReadLine();
                        Console.WriteLine(" _________________ ");
                        Console.WriteLine("|  Register menu  |");
                        Console.WriteLine("|-----------------|");
                        Console.WriteLine("|    Username     |");
                        Console.WriteLine($"|    {username.PadRight(13)}|");
                        Console.WriteLine("|                 |");
                        Console.WriteLine("|    Password     |");
                        Console.WriteLine("|    ________     |");
                        Console.WriteLine("|_________________|");
                        Console.WriteLine("Write your password: ");
                        var password = string.Empty;
                        ConsoleKey key;
                        do
                        {
                            var keyInfo = Console.ReadKey(intercept: true);
                            key = keyInfo.Key;


                            if (key == ConsoleKey.Backspace && password.Length > 0)
                            {
                                Console.Write("\b \b");
                                password = password[0..^1];
                            }
                            else if (!char.IsControl(keyInfo.KeyChar))
                            {
                                Console.Write("*");
                                password += keyInfo.KeyChar;
                            }
                        } while (key != ConsoleKey.Enter);
                        Console.WriteLine(" ");
                        Console.WriteLine(" _________________ ");
                        Console.WriteLine("|  Register menu  |");
                        Console.WriteLine("|-----------------|");
                        Console.WriteLine("|    Username     |");
                        Console.WriteLine($"|    {username.PadRight(13)}|");
                        Console.WriteLine("|                 |");
                        Console.WriteLine("|    Password     |");
                        Console.WriteLine("|    ********     |");
                        Console.WriteLine("|_________________|");
                        Console.WriteLine($"Account created for {username}");
                        break;
                    case 2:
                        Console.WriteLine("Username: ");
                        username = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        password = string.Empty;
                        do
                        {
                            var keyInfo = Console.ReadKey(intercept: true);
                            key = keyInfo.Key;

                            if (key == ConsoleKey.Backspace && password.Length > 0)
                            {
                                Console.Write("\b \b");
                                password = password[0..^1];
                            }
                            else if (!char.IsControl(keyInfo.KeyChar))
                            {
                                Console.Write("*");
                                password += keyInfo.KeyChar;
                            }
                        } while (key != ConsoleKey.Enter);

                        Console.WriteLine(" ");
                        Console.WriteLine(" _________________");
                        Console.WriteLine("|  Register menu  |");
                        Console.WriteLine("|-----------------|");
                        Console.WriteLine("|    Username     |");
                        Console.WriteLine($"|    {username.PadRight(13)}|");
                        Thread.Sleep(1500);
                        Console.WriteLine("|                 |");
                        Console.WriteLine("|    Password     |");
                        Console.WriteLine("|    ********     |");
                        Thread.Sleep(1500);
                        Console.WriteLine("|_________________|");
                        Console.WriteLine($"Welcome, {username}");

                        //If VALIDARLOGIN = true
                        Boolean bucleUser = false;
                        while (!bucleUser)
                        {
                            Console.WriteLine("Menu: ");
                            Console.WriteLine("1. Search song");
                            Console.WriteLine("2. Create playlist");
                            Console.WriteLine("3. Remove playlist");
                            Console.WriteLine("3. Search playlist");
                            Console.WriteLine("4. View playlist");
                            Console.WriteLine("5. Exit");

                            opcion = 0;
                            while (opcion < 1 || opcion > 5)
                            {
                                opcion = Convert.ToInt32(Console.ReadLine());
                                if (opcion < 1 || opcion > 5)
                                {
                                    Console.WriteLine("Invalid option");
                                }
                            }
                            switch (opcion)
                            {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    bucle = true;
                                    break;
                            }
                        }

                        break;
                    case 3:
                        Console.WriteLine("Stay soft");
                        bucle = true;
                        break;
                }
            }
        }
    }
}