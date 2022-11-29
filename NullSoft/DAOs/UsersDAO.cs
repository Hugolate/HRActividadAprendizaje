using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Newtonsoft.Json;

namespace Daos
{


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
            user.number = getNextNumber(user);
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
                if (account == user)
                {
                    return account.allPlayLists;
                }
            }
            return null;
        }

        public int getNextNumber(User user)
        {
            List<User> listAccounts = Deserialize();
            int nextNumber = 0;
            foreach (var item in listAccounts)
            {
                if (nextNumber <= item.number)
                {
                    nextNumber = item.number + 1;
                }
            }
            return nextNumber;
        }
    }
}