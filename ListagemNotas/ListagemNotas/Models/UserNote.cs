using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListagemNotas.Models
{
    [Table("UserNotes")]
    public class UserNote
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
