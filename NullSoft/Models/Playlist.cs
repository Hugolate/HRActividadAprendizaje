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
            allSongs = new List<Song>();
            this.playListName = name;
            ChangePrivacity(privacity);
        }

        public Song getSongByName(string name)
        {

            return null;
        }

        public void AddSong(string songName)
        {
            SongsDao DAO = new SongsDao();

            foreach (var song in DAO.Deserialize())
            {
                if (song.songName == songName)
                {
                    allSongs.Add(song);
                    Console.WriteLine("Song added");
                    return;
                }
            }
            Console.WriteLine("This song doesn't exist");
        }

        public void RemoveSong(string songToRemove)
        {
            SongsDao DAO = new SongsDao();
            if (allSongs != null)
            {
                foreach (var song in allSongs)
                {
                    if (song.songName == songToRemove)
                    {
                        allSongs.Remove(song);
                        Console.WriteLine("Song deleted");
                        return;
                    }
                }
                Console.WriteLine("This song is not in the playlist");
            }
        }

        public void ChangePrivacity(Boolean boo)
        {
            privacity = boo;
        }
    }
}