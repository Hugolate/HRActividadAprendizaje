using System;
using System.Collections.Generic;
using System.Text;
using Daos;
using Newtonsoft.Json;
using Models;

namespace Models
{
    class User
    {
        public int number { get; set; }
        public string name { get; set; }
        public List<Playlist>? allPlayLists { get; set; }
        public string password { get; set; }

        private UsersDAO dao = new UsersDAO();

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
            allPlayLists = new List<Playlist>();
        }
        [JsonConstructor]
        public User(string name, string password, int number)
        {
            this.name = name;
            this.password = password;
            this.number = number;
            allPlayLists = new List<Playlist>();
        }

        public Playlist getPlayListByName(string name)
        {
            UsersDAO uDao = new UsersDAO();
            foreach (var list in uDao.DeserializePlaylists(this))
            {
                if (name == list.playListName)
                {
                    return list;
                }
            }
            return null;
        }
        public Boolean removePlaylist(string listName)
        {
            UsersDAO uDao = new UsersDAO();
            allPlayLists = uDao.DeserializePlaylists(this);

            foreach (var list in allPlayLists)
            {
                if (listName == list.playListName)
                {
                    allPlayLists.Remove(list);
                    return true;
                }
            }
            Console.WriteLine("Playlist not exist");
            return false;
        }
    }
}
