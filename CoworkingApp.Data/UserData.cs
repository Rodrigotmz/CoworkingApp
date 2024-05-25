using CoworkingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoworkingApp.Data.Tools;
using CoworkingApp.Data.Methods;

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
        public bool Login(string User, string Password, bool isAdmin = false)
        {
            var userCollection = jsManager.GetCollection();
            var passwordEncript = EncryptData.EncryptText(Password);
            if (isAdmin) User = "ADMIN";
            var userFound = userCollection.FirstOrDefault(p => p.Email == User && p.Password == passwordEncript);
            if(userFound != null) return true;
            return false;
        }

        public (string, bool) CreateUser(User newUser)
        {
            try
            {
                newUser.Password = EncryptData.EncryptText(newUser.Password);
                var userCollection = jsManager.GetCollection();
                userCollection.Add(newUser);
                jsManager.SaveCollection(userCollection);
                return ("Usuario creado exitosamente",true);
            }
            catch
            {
                return ("No se pudo crear el usuario, por favor intente más tarde",false);
            }
        }
        public User FindUser(string email)
        {
            var userCollection = jsManager.GetCollection();
            return userCollection.FirstOrDefault(p => p.Email == email);
        }
        public (string, bool) EditUser(User editUser)
        {
            try
            {
                editUser.Password = EncryptData.EncryptText(editUser.Password);
                var userCollection = jsManager.GetCollection();
                var indexUser = userCollection.FindIndex(p => p.UserId == editUser.UserId);
                userCollection[indexUser] = editUser;
                jsManager.SaveCollection(userCollection);
                return ("Cambios realizados con exito", true);
            }
            catch
            {
                return ("No se pudo editar el usuario seleccionado, por favor intente más tarde", false);
            }
        }
        public (string,bool) RemoveUser(Guid userId)
        {
            try
            {
                var userCollection = jsManager.GetCollection();
                var idUser = userCollection.Find(p => p.UserId == userId);
                userCollection.Remove(idUser);
                jsManager.SaveCollection(userCollection);
                return ("Usuario removido con exito", true);
            }
            catch
            {
                return ("El usuario no se pudo remover", false);
            }
        }
    }
}
