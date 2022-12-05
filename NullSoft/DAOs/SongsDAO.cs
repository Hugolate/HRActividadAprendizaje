using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

class SongsDao
{

    
    public List<Song> Deserialize()
    {
       
        string jsonString = File.ReadAllText("DDBB/Songs.json");
        if (jsonString != "")
        {
            return JsonConvert.DeserializeObject<List<Song>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }

        return new List<Song>();
    }
}