using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using TP_EwanLegautV2.ViewModels;

namespace TP_EwanLegautV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CredentielPage : ContentPage
    {
        public CredentielPage()
        {
            InitializeComponent();
            this.BindingContext = new CredentielViewModel();

        }
    }
}