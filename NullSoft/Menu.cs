using System;
using System.Text;
using Daos;
using Models;
using Spectre.Console;


namespace NullSoft
{


    class Menu
    {

        public StringBuilder menu { get; set; }
        public static User user;
        private static UsersDAO userDAO = new UsersDAO();


        public Menu()
        {
            var a = Environment.GetEnvironmentVariable("NAME");
            Console.WriteLine(Environment.GetEnvironmentVariable("NAME"));
            menu = new StringBuilder();
            /*
            try
            {
                if (Environment.GetEnvironmentVariable("LANGUAGE").Equals("en"))
                {
                    Menu.allMenu();
                }
                else
                {
                    Console.WriteLine("español");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */

        }

        public StringBuilder showMainMenu()
        {
            var table = new Table();
            table.Border = TableBorder.HeavyHead;

            table.AddColumn(new TableColumn("[purple4]Menu[/]").Centered()).Centered();
            table.Columns[0].Padding(4, 0);

            table.AddRow("1.Sign Up");
            table.AddRow("2.Sign In");
            table.AddRow("3.Exit");

            AnsiConsole.Write(table);

            return this.menu;
        }

        public StringBuilder showUserMenu()
        {

            var table = new Table();
            table.Border = TableBorder.HeavyHead;

            table.AddColumn(new TableColumn("[purple4]Menu[/]").Centered()).Centered();
            table.Columns[0].Padding(4, 0);

            table.AddRow("1.Create Playlist");
            table.AddRow("2.Remove Playlis");
            table.AddRow("3.Search Playlist");
            table.AddRow("4.View Playlist");
            table.AddRow("5.Modify Playlist");
            table.AddRow("6.Exit");

            AnsiConsole.Write(table);

            menu = new StringBuilder();
            return this.menu;

        }

        public StringBuilder showPlaylistOptions(Playlist playlist)
        {
            menu = new StringBuilder();

            var table = new Table();
            table.Border = TableBorder.HeavyHead;

            table.AddColumn(new TableColumn("[purple4]Menu[/]").Centered()).Centered();
            table.Columns[0].Padding(4, 0);

            table.AddRow(" 1.Add song");
            table.AddRow("2.Remove song ");
            table.AddRow("3.List all songs");
            table.AddRow("4.Change privacy ");
            table.AddRow("5.Exit");

            AnsiConsole.Write(table);

            return this.menu;

        }

        public int bucleMenu(int minimo, int maximo, int opcion)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return 0;
        }

        public StringBuilder RegisterMenu()
        {
            menu = new StringBuilder();

            var table = new Table();
            table.Border = TableBorder.HeavyHead;

            table.AddColumn(new TableColumn("[purple4]Register menu[/]").Centered()).Centered();
            table.Columns[0].Padding(4, 0);

            table.AddRow("Username");
            table.AddRow("________ ");
            table.AddRow("Password");
            table.AddRow("________");

            AnsiConsole.Write(table);

            Console.WriteLine("Write your username: ");
            String username = Console.ReadLine();

            Console.WriteLine("Write your password: ");
            String password = writePassw();

            var table2 = new Table();
            table2.Border = TableBorder.HeavyHead;

            table2.AddColumn(new TableColumn("[purple4]Register menu[/]").Centered()).Centered();
            table2.Columns[0].Padding(4, 0);

            table2.AddRow("Username");
            table2.AddRow($"{username}");
            table2.AddRow("Password");
            table2.AddRow("********");

            AnsiConsole.Write(table2);

            userDAO.SerializeUser(new User(username, password));
            Console.WriteLine("Register succesfully");
            return this.menu;
        }

        public User showLogin()
        {
            menu = new StringBuilder();
            Console.WriteLine("Username: ");
            String username = Console.ReadLine();
            Console.WriteLine("Password: ");
            String password = writePassw();
            var table = new Table();
            table.Border = TableBorder.HeavyHead;

            table.AddColumn(new TableColumn("[purple4]Log-in menu[/]").Centered()).Centered();
            table.Columns[0].Padding(4, 0);

            table.AddRow("Username");
            table.AddRow($"{username}");
            table.AddRow("Password");
            table.AddRow("********");

            AnsiConsole.Write(table);
            Thread.Sleep(1500);

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

        public void addPLaylist()
        {
            if (userDAO.DeserializePlaylists(user) != null)
            {
                Console.WriteLine("Playlist name:");
                string plName = Console.ReadLine();
                Console.WriteLine("Playlist privacity(1.public 2.private):");
                int privacity = 0;
                try
                {
                    privacity = bucleMenu(1, 2, privacity);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
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
                                        //Crear playlist
                                        menu.addPLaylist();
                                        Console.WriteLine("Playlist created");
                                        break;
                                    case 2:
                                        //Borrar playlist
                                        Console.WriteLine("Playlist to remove:");
                                        string rmList = Console.ReadLine();
                                        user.removePlaylist(rmList);
                                        break;
                                    case 3:
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
                                            Console.WriteLine("This playlist exists :) ");
                                        }

                                        break;
                                    case 4:
                                        //ver todas las playlist
                                        List<Playlist> playlists = userDAO.DeserializePlaylists(user);
                                        foreach (var item in playlists)
                                        {
                                            Console.WriteLine(item.playListName);
                                        }
                                        break;
                                    case 5:
                                        //Modificar una playlist
                                        Console.WriteLine("Playlist name:");
                                        listName = Console.ReadLine();
                                        Boolean exist = false;
                                        List<Playlist> allUserPlaylists = userDAO.DeserializePlaylists(user);
                                        foreach (var userPLaylist in allUserPlaylists)
                                        {
                                            if (listName == userPLaylist.playListName)
                                            {

                                                exist = true;

                                                Boolean bucleTres = false;
                                                while (!bucleTres)
                                                {
                                                    Thread.Sleep(1500);
                                                    Console.WriteLine(menu.showPlaylistOptions(userPLaylist));
                                                    opcion = 0;
                                                    opcion = menu.bucleMenu(1, 5, opcion);
                                                    switch (opcion)
                                                    {
                                                        case 1:
                                                            //Añadir cancion a playlist
                                                            Console.WriteLine("Song name:");
                                                            String songName = Console.ReadLine();
                                                            userPLaylist.AddSong(songName);
                                                            user.removePlaylist(userPLaylist.playListName);
                                                            user.allPlayLists.Add(userPLaylist);

                                                            break;
                                                        case 2:
                                                            //Borrar cancion de playlist
                                                            if (user.allPlayLists != null)
                                                            {

                                                                Console.WriteLine("Song name:");
                                                                songName = Console.ReadLine();
                                                                userPLaylist.RemoveSong(songName);
                                                                user.removePlaylist(userPLaylist.playListName);
                                                                user.allPlayLists.Add(userPLaylist);
                                                            }
                                                            break;
                                                        case 3:
                                                            if (userPLaylist.allSongs != null)
                                                            {
                                                                foreach (var song in userPLaylist.allSongs)
                                                                {
                                                                    Console.WriteLine(song.songName);
                                                                }
                                                            }
                                                            break;
                                                        case 4:
                                                            Console.WriteLine("Playlist privacity(1.public 2.private):");
                                                            string privacy = Console.ReadLine();
                                                            if (privacy == "1")
                                                            {
                                                                userPLaylist.ChangePrivacity(true);
                                                            }
                                                            else
                                                            {
                                                                userPLaylist.ChangePrivacity(true);
                                                            }
                                                            Console.WriteLine("Privacy changed");
                                                            break;
                                                        case 5:
                                                            bucleTres = true;
                                                            break;
                                                    }
                                                    userDAO.SerializeUser(user);
                                                }
                                                if (!exist)
                                                {
                                                    Console.WriteLine("This playlist don't exist");
                                                }
                                            }
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