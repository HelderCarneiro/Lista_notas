using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Sql;
using ListagemNotas.Droid;
using SQLite;

[assembly:Xamarin.Forms.Dependency(typeof(DBCconnection_Android))]
namespace ListagemNotas.Droid
{
    public class DBCconnection_Android:IDBConnection
    {
        public SQLiteConnection GetDBConnection()
        {
            var dbName = "UsersDB.db3";
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}