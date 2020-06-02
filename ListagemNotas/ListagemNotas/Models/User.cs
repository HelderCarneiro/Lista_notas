using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListagemNotas.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string Nome { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SafetyQuestion { get; set; }
        public string SafetyAnswer { get; set; }
        
    }
}
