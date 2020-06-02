using System;
using System.IO;
using Xamarin.Forms;
using ListagemNotas.Models;

namespace ListagemNotas
{
    
    public partial class NoteNewInsert : ContentPage
    {
        public UserNoteDB userNoteDB2;
        public NoteNewInsert()
        {
            InitializeComponent();
            userNoteDB2 = new UserNoteDB();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (UserNote)BindingContext;
            note.UserId = App.CurrentUser.Id;
            userNoteDB2.AddNewNote(note);
            await Navigation.PopAsync();

        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (UserNote)BindingContext;
            note.UserId = App.CurrentUser.Id;
            userNoteDB2.DeleteNote(note);
            await Navigation.PopAsync();
        }


    }
}