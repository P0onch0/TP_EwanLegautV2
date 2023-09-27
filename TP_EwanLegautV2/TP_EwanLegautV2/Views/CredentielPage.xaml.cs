using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using TP_EwanLegautV2.ViewModels;
using TP_EwanLegautV2.Services;

namespace TP_EwanLegautV2.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CredentielPage : ContentPage
    {
        CredentielViewModel _viewModel;
        public CredentielPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CredentielViewModel();
         
        }
        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            
        }
    }
}