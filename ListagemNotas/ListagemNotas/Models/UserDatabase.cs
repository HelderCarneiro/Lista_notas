using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ListagemNotas.Models
{
    public class userDatabase
    {
        SQLiteConnection connection;

        public userDatabase()
        {
            connection = DependencyService.Get<IDBConnection>().GetDBConnection();
            connection.CreateTable<User>();
        }
        public void UpdatePassword(int id, string new_password)
        {
            var allUsers = connection.Table<User>();
            var findUser = allUsers.Where(u => u.Id == id).FirstOrDefault();
            if (findUser != null)
            {
                findUser.Password = new_password;
                connection.Update(findUser);
            }
        }

        public bool CreateNewUser(User user)
        {
            var allUsers = connection.Table<User>();
            var findUser = allUsers.Where(u => u.Email == user.Email).FirstOrDefault();
            if (findUser==null)
            {
                connection.Insert(user);
                return true;

            }
            else
            {
                return false;
            }
        }
        public User Checkuser (string email, string pass )
        {
            var allUsers = connection.Table<User>();
            var findUser = allUsers.Where(u => u.Email == email && u.Password==pass).FirstOrDefault();
            return findUser;
        
        }
        public User ValidateUserEmail (string email)
        {
            var allUsers = connection.Table<User>();
            var findemail = allUsers.Where(u => u.Email == email).FirstOrDefault();
            return findemail;
        }

        public List<User> ListUsers()
        {
            List<User> UsersList = new List<User>();
            UsersList = connection.Table<User>().ToList();
            return UsersList;
        }
    }
}
