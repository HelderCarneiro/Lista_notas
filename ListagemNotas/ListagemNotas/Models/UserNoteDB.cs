using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ListagemNotas.Models
{
    public class UserNoteDB
    {
        SQLiteConnection connection;

        public UserNoteDB()
        {
            connection = DependencyService.Get<IDBConnection>().GetDBConnection();
            connection.CreateTable<UserNote>();
        }
        
        public void AddNewNote(UserNote note)
        {
            var currentNote = connection.Table<UserNote>().Where(n=>n.Id==note.Id).FirstOrDefault();
            if (currentNote == null)
            {
                connection.Insert(note);
            }
            else connection.Update(note);
        }

        public void DeleteNote(UserNote note)
        {
            var currentNote = connection.Table<UserNote>().Where(n=> n.Id ==note.Id).FirstOrDefault();
            if (currentNote!= null)
            {
                connection.Delete(note);
            }
        }
        public List<UserNote> searchNotes (User user,string text)
        {
            return connection.Table<UserNote>()
                .Where(n => n.UserId == user.Id && (n.Title.ToLower().Contains(text.ToLower()) || n.Text.ToLower().Contains(text.ToLower()))).ToList();
        }

        public List<UserNote> getListNotes (User user)
        {
            return connection.Table<UserNote>().Where(n => n.UserId == user.Id).ToList();
        }
    }
}
