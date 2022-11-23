using System;
using System.Collections.Generic;
using System.Text;
using Daos;
using Models;

namespace Models
{
    class Playlist
    {
        public string playListName { get; set; }
        public List<Song>? allSongs { get; }
        public Boolean privacity { get; set; }

        public Playlist(string name, Boolean privacity)
        {
            this.playListName = name;
            ChangePrivacity(privacity);
        }

        public Song getSongByName(string name)
        {
            
            return null;
        }

        public void AddSong(Song newSong)
        {

        }

        public void RemoveSong(Song songToRemove)
        {

        }

        public void ChangePrivacity(Boolean boo)
        {
            privacity = boo;
        }
    }
}