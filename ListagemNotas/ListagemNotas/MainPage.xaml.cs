using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using ListagemNotas.Models;

namespace ListagemNotas
{
   
    public partial class MainPage : ContentPage
    {
        private UserNoteDB userNoteDB;
        public MainPage()
        {
            InitializeComponent();
            userNoteDB = new UserNoteDB();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listview.ItemsSource = userNoteDB.getListNotes(App.CurrentUser);
        }

        async void OnMore (object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            await Navigation.PushAsync(new NoteNewInsert { BindingContext = mi.CommandParameter as UserNote });
        }
        public void OnDelete (object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            userNoteDB.DeleteNote((UserNote)mi.CommandParameter);
            listview.ItemsSource = userNoteDB.getListNotes(App.CurrentUser);
        }
          void TextSearch (object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            listview.ItemsSource = userNoteDB.searchNotes(App.CurrentUser, searchBar.Text);
        }
        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteNewInsert
            {
                BindingContext = new UserNote()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteNewInsert
                {
                    BindingContext = e.SelectedItem as UserNote
                });
            }
        }
        async void logoutclick (object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            App.CurrentUser = null;
            await Navigation.PushAsync(new Login());
        }

    }



}

