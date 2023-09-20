using System;
using System.Collections.Generic;
using System.Text;
using TP_EwanLegautV2.Views;
using Xamarin.Forms;
using System.ComponentModel;

namespace TP_EwanLegautV2.ViewModels
{
    public class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Command LoginCmd { get; }
        public string User { get; set; }
        public string Password { get; set; }
        public string MessageErreur { get; set; }
        public Xamarin.Forms.Thickness Margin { get; set; }


        public LoginViewModel()
        {
            LoginCmd = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {

            if (User == "Ewan" & Password == "pwd")
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            else
            {
                MessageErreur = "Votre Login ou Password est incorect";
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        }
    }
}
