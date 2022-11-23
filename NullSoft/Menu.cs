using System;
using System.Text;

namespace NullSoft
{

    class Menu
    {
        public StringBuilder menu { get; set; }
        public Menu()
        {
            Console.WriteLine("Welcome to PlaySoft");
            menu = new StringBuilder();
        }

        public StringBuilder showMainMenu()
        {
            menu = new StringBuilder();
            this.menu.AppendLine(" ");
            this.menu.AppendLine(" __________________ ");
            this.menu.AppendLine("|       Menu       |");
            this.menu.AppendLine("|__________________|");
            this.menu.AppendLine("|                  |");
            this.menu.AppendLine("|     1.Sign Up    |");
            this.menu.AppendLine("|     2.Sign In    |");
            this.menu.AppendLine("|     3.Exit       |");
            this.menu.AppendLine("|__________________|");
            this.menu.AppendLine(" ");
            return this.menu;
        }

        public StringBuilder showUserMenu()
        {
            menu = new StringBuilder();
            this.menu.AppendLine(" __________________ ");
            this.menu.AppendLine("|       Menu       |");
            this.menu.AppendLine("|__________________|");
            this.menu.AppendLine("|                  |");
            this.menu.AppendLine("| 1.Search song    |");
            this.menu.AppendLine("| 2.Create Playlist|");
            this.menu.AppendLine("| 3.Remove Playlist|");
            this.menu.AppendLine("| 4.Search Playlist|");
            this.menu.AppendLine("| 5.View Playlist  |");
            this.menu.AppendLine("| 6.Exit           |");
            this.menu.AppendLine("|__________________|");
            return this.menu;

        }

        public int bucleMenu(int minimo, int maximo, int opcion)
        {
            while (opcion < minimo || opcion > maximo)
            {
                opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion < minimo || opcion > maximo)
                {
                    Console.WriteLine("Invalid option");
                }
            }
            return opcion;
        }

        public StringBuilder RegisterMenu()
        {
            menu = new StringBuilder();
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
            writePassw();
            Console.WriteLine(" ");
            this.menu.AppendLine(" _________________");
            this.menu.AppendLine("|  Register menu  |");
            this.menu.AppendLine("|-----------------|");
            this.menu.AppendLine("|    Username     |");
            this.menu.AppendLine($"|    {username.PadRight(13)}|");
            this.menu.AppendLine("|                 |");
            this.menu.AppendLine("|    Password     |");
            this.menu.AppendLine("|    ********     |");
            this.menu.AppendLine("|_________________|");
            this.menu.AppendLine("   ");
            this.menu.AppendLine("Register succesfully");
            return this.menu;
        }

        public StringBuilder showLogin()
        {
            menu = new StringBuilder();
            Console.WriteLine("Username: ");
            String username = Console.ReadLine();
            Console.WriteLine("Password: ");
            writePassw();
            Console.WriteLine(" ");
            Console.WriteLine(" _________________");
            Console.WriteLine("|   Log-in menu   |");
            Console.WriteLine("|-----------------|");
            Console.WriteLine("|    Username     |");
            Console.WriteLine($"|    {username.PadRight(13)}|");
            Thread.Sleep(1500);
            Console.WriteLine("|                 |");
            Console.WriteLine("|    Password     |");
            Console.WriteLine("|    ********     |");
            Thread.Sleep(1500);
            Console.WriteLine("|_________________|");
            Console.WriteLine("   ");
            Console.WriteLine($"Welcome, {username}");
            return this.menu;
        }

        public String writePassw()
        {
            String password = string.Empty;
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

            return password;
        }

        public static void allMenu(){
            Boolean bucle = false;
            Menu menu = new Menu();
            while (!bucle)
            {
                Thread.Sleep(1500);
                Console.WriteLine(menu.showMainMenu());
                int opcion = 0;
                opcion = menu.bucleMenu(1, 3, opcion);
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine(menu.RegisterMenu());
                        break;
                    case 2:
                        Console.WriteLine(menu.showLogin());
                        Boolean bucleDos = false;
                        while (!bucleDos)
                        {
                            Thread.Sleep(1500);
                            Console.WriteLine(menu.showUserMenu());
                            opcion = 0;
                            opcion = menu.bucleMenu(1, 6, opcion);
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
                                    break;
                                case 6:
                                    bucleDos = true;
                                    break;
                            }
                        }
                        break;
                    case 3:
                        bucle = true;
                        break;
                }

            }
        }

    }
}