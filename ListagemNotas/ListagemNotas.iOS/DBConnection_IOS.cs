using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite;
using ListagemNotas.iOS;
using System.IO;

[assembly:Xamarin.Forms.Dependency(typeof(DBConnection_IOS))]
namespace ListagemNotas.iOS
{
    public class DBConnection_IOS:IDBConnection
    {
        public SQLiteConnection GetDBConnection()
        {
            var dbName = "UsersDB.db3";
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}