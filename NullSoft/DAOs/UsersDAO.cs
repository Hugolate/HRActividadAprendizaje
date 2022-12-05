using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Newtonsoft.Json;

namespace Daos
{


    class UsersDAO
    {

        private static string Path = "DDBB/Users.json";
        public List<User> Deserialize()
        {

            string jsonString = File.ReadAllText("DDBB/Users.json");
            if (jsonString != "")
            {
                return JsonConvert.DeserializeObject<List<User>>(jsonString);
            }

            return new List<User>();
        }

        public void SerializeUser(User user)
        {
            List<User> listAccounts = Deserialize();
            int contador = 0;
            int numMax = 0;
            for (int i = 0; i < listAccounts.Count(); i++)
            {
                if (listAccounts[i].name == user.name)
                {

                }
                else
                {
                    contador++;
                }
                if (numMax < listAccounts[i].number)
                {
                    numMax = listAccounts[i].number;
                }
            }

            if (contador == listAccounts.Count())
            {
                user.number = numMax + 1;
            }

            for (int i = 0; i < listAccounts.Count(); i++)
            {
                if (listAccounts[i].name == user.name)
                {
                    listAccounts.Remove(listAccounts[i]);
                }
            }

            listAccounts.Add(user);
            using (FileStream createStream = File.Create(Path))
            {
                createStream.DisposeAsync();
                File.WriteAllText(Path, JsonConvert.SerializeObject(listAccounts));
            }
        }

        public List<Playlist> DeserializePlaylists(User user)
        {

            List<User> listAccounts = Deserialize();
            foreach (var account in listAccounts)
            {
                if (account.number == user.number)
                {
                    return account.allPlayLists;
                }
            }
            return null;
        }


    }
}