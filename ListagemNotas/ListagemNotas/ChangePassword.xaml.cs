using ListagemNotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListagemNotas
{
    
    public partial class ChangePassword : ContentPage
    {
        public userDatabase UserDatabase;
        public User userEmail;

        public ChangePassword()
        {
            InitializeComponent();
            UserDatabase = new userDatabase();
        }
        async void Ok1ButtonClicked (object sender, EventArgs e)
        {
            
            User user = UserDatabase.ValidateUserEmail(emailEntry.Text);
            if (user != null)
            {
                userEmail = user;

                emailEntry.IsVisible = false;
                emaillabel.IsVisible = false;
                ok1.IsVisible = false;

                safetyquestionlabel.Text = user.SafetyQuestion;
                safetyquestionlabel.IsVisible = true;
                safeAnswerEntry.IsVisible = true;
                ok2.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Erro", "Não existe nenhum utilizador com esse email", "OK");
            }
        }
        async void ok2ButtonClicked (object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(safeAnswerEntry.Text))
            {
                await DisplayAlert("Aviso", "Preencher os campos pedidos", "OK");
            }
            else
            {
                if (safeAnswerEntry.Text == userEmail.SafetyAnswer)
                {
                    safetyquestionlabel.IsVisible = false;
                    safeAnswerEntry.IsVisible = false;
                    ok2.IsVisible = false;

                    passwordlabel.IsVisible = true;
                    passwordEntry.IsVisible = true;
                    confirmPasswordLabel.IsVisible = true;
                    confirmPasswordEntry.IsVisible = true;
                    changePasswordGrid.IsVisible = true;
                }
                else
                {
                    await DisplayAlert("Aviso", "A sua resposta está errada", "OK");
                }
            }
        }
        async void confirmButtonClicked (object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(passwordEntry.Text)) || (string.IsNullOrWhiteSpace(confirmPasswordEntry.Text)))
            {
                await DisplayAlert("Adicionar", "os", "campos necessários");
            }
            else if(!string.Equals(passwordEntry.Text, confirmPasswordEntry.Text))
            {
                await DisplayAlert("Erro", "introduza a mesma password", "OK");
                passwordEntry.Text = string.Empty;
                confirmPasswordEntry.Text = string.Empty;
            }
            else
            {
                UserDatabase.UpdatePassword(userEmail.Id, passwordEntry.Text);
                await DisplayAlert("Sucesso", "alteração bem sucedida", "OK");
                await Navigation.PopAsync();
            }
        }
        async void cancelButtonClicked (object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}