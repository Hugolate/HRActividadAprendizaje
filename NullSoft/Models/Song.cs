using System;
using System.Collections.Generic;
using System.Text;

namespace NullSoft
{
    class Song
    {
        public string songName { get; set; }
        public decimal duration { get; set; }
        public DateTime publicationDate { get; }
        private string songID { get; }
        private static int songIDSeed = 1;

        public Song(string songName, decimal duration, DateTime publicationDate)
        {
            this.songName = songName;
            this.duration = duration;
            this.publicationDate = publicationDate;
            this.songID = songIDSeed.ToString();
            songIDSeed++;
        }

    }
}