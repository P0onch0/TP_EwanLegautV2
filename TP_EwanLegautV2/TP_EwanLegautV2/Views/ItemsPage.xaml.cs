using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_EwanLegautV2.Models;
using TP_EwanLegautV2.ViewModels;
using TP_EwanLegautV2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP_EwanLegautV2.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}