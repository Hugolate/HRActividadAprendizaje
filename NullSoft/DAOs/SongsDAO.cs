using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Newtonsoft.Json;
class SongsDao
{

    
    public List<Song> Deserialize()
    {
       
        string jsonString = File.ReadAllText("Songs.json");
        if (jsonString != "")
        {
            return JsonConvert.DeserializeObject<List<Song>>(jsonString);
        }

        return new List<Song>();
    }
}