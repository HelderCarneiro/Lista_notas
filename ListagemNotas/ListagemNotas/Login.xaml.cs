using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using ListagemNotas.Models;

namespace ListagemNotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private userDatabase userDatabase2;
        public Login()
        {
            InitializeComponent();
            userDatabase2 = new userDatabase();
            TapGestureRecognizer ForgetPasswordClick = new TapGestureRecognizer();
            ForgetPasswordClick.Tapped += ForgetPassword_Tapped;
            passforget.GestureRecognizers.Add(ForgetPasswordClick);
        }

        async void newuserbutton (object sender, EventArgs e)
        {         
            await Navigation.PushAsync(new NewUser());
        }
        async void userLogin(object sender, EventArgs e)
        {
            var Admin = "Gestor";
            var PassAdmin = "Gestor";
            
            if ((string.IsNullOrWhiteSpace(Username.Text) || (string.IsNullOrWhiteSpace(userpass.Text))))
            {
                await DisplayAlert("Aviso","Preencher os Campos", "OK");
            }
            else
            {              
                var finduser = userDatabase2.Checkuser(Username.Text,userpass.Text);
                if (finduser != null)
                {
                    App.IsUserLoggedIn = true;
                    App.CurrentUser = finduser;
                    Navigation.InsertPageBefore(new MainPage(),this);
                    await Navigation.PopAsync();

                }    
                else
                {
                    await DisplayAlert("Aviso","Dados Estão Errados", "OK");
                }
            }
            
        }
        private async void ForgetPassword_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePassword());
        }
      
    }
}