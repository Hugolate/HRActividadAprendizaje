using System;
using System.Text;
using Daos;
using Models;

namespace NullSoft
{

    class Menu
    {
        public StringBuilder menu { get; set; }
        public static User user;
        private static UsersDAO userDAO = new UsersDAO();
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
            String password = writePassw();
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
            userDAO.SerializeUser(new User(username, password));
            this.menu.AppendLine("Register succesfully");
            return this.menu;
        }

        public User showLogin()
        {
            menu = new StringBuilder();
            Console.WriteLine("Username: ");
            String username = Console.ReadLine();
            Console.WriteLine("Password: ");
            String password = writePassw();
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
            int contador = 0;
            foreach (var item in userDAO.Deserialize())
            {
                if (item.name == username && item.password == password)
                {
                    user = item;
                    contador++;
                }
            }
            if (contador == 1)
            {
                Console.WriteLine($"Welcome, {username}");
                return user;
            }
            else
            {
                return null;
            }
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

        public static void allMenu()
        {
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
                    User user = menu.showLogin();
                        if (user != null)
                        {
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
                                    //Crear playlist
                                        if (userDAO.DeserializePlaylists(user) != null)
                                        {
                                            Console.WriteLine("Playlist name:");
                                            string plName = Console.ReadLine();
                                            Console.WriteLine("Playlist privacity(1.public 2.private):");
                                            int privacity = 0;
                                            privacity = menu.bucleMenu(1, 2, privacity);
                                            Boolean priv;
                                            if (privacity == 1)
                                            {
                                                priv = true;
                                            }
                                            else
                                            {
                                                priv = false;
                                            }
                                            user.allPlayLists = userDAO.DeserializePlaylists(user);
                                            user.allPlayLists.Add(new Playlist(plName, priv));
                                        }
                                        break;
                                    case 3:
                                    //Borrar playlist
                                        Console.WriteLine("Playlist to remove:");
                                        string rmList = Console.ReadLine();
                                        user.removePlaylist(rmList);

                                        break;
                                    case 4:
                                    //Buscar playlist
                                        Console.WriteLine("Playlist name:");
                                        string listName = Console.ReadLine();
                                        Playlist list = user.getPlayListByName(listName);
                                        if (list == null)
                                        {
                                            Console.WriteLine("This playlist don't exist");
                                        }
                                        else
                                        {
                                            Console.WriteLine(list.allSongs + ", " + list.privacity);
                                        }

                                        break;
                                    case 5:
                                        List<Playlist> playlists = userDAO.DeserializePlaylists(user);
                                        foreach (var item in playlists)
                                        {
                                            Console.WriteLine(item.playListName + ", " + item.allSongs);
                                        }
                                        break;
                                    case 6:
                                        bucleDos = true;
                                        break;
                                }
                                //Serialize user
                                userDAO.SerializeUser(user);

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