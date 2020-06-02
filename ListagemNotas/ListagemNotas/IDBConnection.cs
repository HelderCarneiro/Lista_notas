using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ListagemNotas
{
    public interface IDBConnection
    {
        SQLiteConnection GetDBConnection();
    }
}
