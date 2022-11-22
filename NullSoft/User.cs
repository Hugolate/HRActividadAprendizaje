using System;
using System.Collections.Generic;
using System.Text;

namespace NullSoft
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
            return null;
        }

        public void createPlayList(string listName, Boolean privacity)
        {

        }
        public void removePlaylist(string listName, Boolean privacity)
        {

        }
        public void getAllPlayList(string listName, Boolean privacity)
        {

        }

    }
}
