using System;
using System.Collections.Generic;
using System.Text;
using NullSoft;
using Newtonsoft.Json;
class UsersDAO
{


    public List<User> Deserialize()
    {

        string jsonString = File.ReadAllText("Users.json");
        if (jsonString != "")
        {
            return JsonConvert.DeserializeObject<List<User>>(jsonString);
        }

        return new List<User>();
    }

    public void SerializeUser(User user)
    {
        List<User> listAccounts = Deserialize();
        listAccounts.Add(user);
        using (FileStream createStream = File.Create("Users.json"))
        {
            createStream.DisposeAsync();
            File.WriteAllText("Users.json", JsonConvert.SerializeObject(listAccounts));
        }
    }

    public List<Playlist> DeserializePlaylists(User user)
    {
        
        List<User> listAccounts = Deserialize();
        foreach (var account in listAccounts)
        {
            if(account == user){
                return account.allPlaylists;
            }
        }
        return null;
    }
}