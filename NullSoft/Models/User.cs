using System;
using System.Collections.Generic;
using System.Text;
using Daos;
using Models;

namespace Models
{
    class User
    {
        public string number { get; }
        public string name { get; set; }
        private List<PlayList>? allPlayLists { get; }
        private string password/*{get; set;}*/;
        private int userNumberSeed = 1;

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
            this.number = userNumberSeed.ToString();
            userNumberSeed++;
        }

        public PlayList getPlayListByName(string name)
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
        public void removePlaylist(string listName)
        {
            UsersDAO uDao = new UsersDAO();
            List<PlayList> playLists = new List<PlayList>();
            foreach (var list in playLists)
            {
                if (listName == list.playListName)
                {
                    playLists.Remove(list);
                    Console.WriteLine(listName + " Deleted");
                }
            }

        }
        public List<PlayList> getAllPlayList()
        {
            UsersDAO uDao = new UsersDAO();
            return uDao.DeserializePlaylists(this);

        }

    }
}
