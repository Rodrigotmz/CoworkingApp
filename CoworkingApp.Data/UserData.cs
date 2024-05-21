using CoworkingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoworkingApp.Data.Tools;

namespace CoworkingApp.Data
{
    public class UserData
    {
        private JsonManager<User> jsManager;
        public UserData()
        {
            jsManager = new JsonManager<User>();
        }
        public bool CreateAdmin()
        {
            var userCollection = jsManager.GetCollection();
            if (!userCollection.Any(p => p.Name == "ADMIN" && p.LastName == "ADMIN" && p.Email == "ADMIN"))
            {
                try
                {
                    var adminUser = new User()
                    {
                        Name = "ADMIN",
                        LastName = "ADMIN",
                        Email = "ADMIN",
                        UserId = Guid.NewGuid(),
                        Password = EncryptData.EncryptText("4dmin!")
                    };
                    userCollection.Add(adminUser);
                    jsManager.SaveCollection(userCollection);
                }
                catch { return false; }
                return true;
            }
            return true;
        }
    }
}
