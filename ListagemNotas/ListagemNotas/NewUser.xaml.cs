using ListagemNotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListagemNotas
{
    
    public partial class NewUser : ContentPage
    {
        public NewUser()
        {
            InitializeComponent();
            FillSafetyQuestionsPicker();
        }
        void FillSafetyQuestionsPicker()
        {
            List<string> safetyQuestionslist = new List<string>();
            safetyQuestionslist.Add("Qual o seu ano de nascimento?");
            safetyQuestionslist.Add("Quantos irmãos tem o seu pai?");
            safetyQuestionslist.Add("Quantos países já visitou?");

            safetyQuestionPicker.ItemsSource = safetyQuestionslist;
        }
        async void SignUp (object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(Name.Text)) || (string.IsNullOrWhiteSpace(email.Text)) || (string.IsNullOrWhiteSpace(password.Text)))
            {
                await DisplayAlert("Adicionar", "os", "campos necessários");
            }

            else if (!string.Equals(password.Text, repassword.Text))
            {
                warningLabel.Text = "Password errada";
                password.Text = string.Empty;
                repassword.Text = string.Empty;
                warningLabel.IsVisible = true;
            }
            else
            {
                User user = new User()
                {
                    Nome = Name.Text,
                    Email = email.Text,
                    Password = password.Text,
                    SafetyQuestion=safetyQuestionPicker.SelectedItem.ToString(),
                    SafetyAnswer=safetyAnswerEntry.Text
                };

                userDatabase userDatabase = new userDatabase();

                var returnvalue = userDatabase.CreateNewUser(user);
                if (returnvalue == true)
                {
                    await DisplayAlert("Utilizador inserido", "com sucesso", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Adicionar utilizador", "Já existe um utilizador com esse email", "OK");
                    Name.Text = string.Empty;
                    email.Text = string.Empty;
                    password.Text = string.Empty;
                }
            }
        }      
    }
}