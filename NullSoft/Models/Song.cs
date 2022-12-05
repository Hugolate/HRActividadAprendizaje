using System;
using System.Collections.Generic;
using System.Text;
using Daos;
using Models;

namespace Models
{
    class Song
    {
        public string songName { get; set; }
        public decimal duration { get; set; }
        public DateTime publicationDate { get; }
        public string songID { get; }


        public Song(string songName, decimal duration, DateTime publicationDate, string songID)
        {
            this.songName = songName;
            this.duration = duration;
            this.publicationDate = publicationDate;
            this.songID = songID;
        }

    }
}