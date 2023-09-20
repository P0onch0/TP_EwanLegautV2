using System;
using System.Collections.Generic;
using System.ComponentModel;
using TP_EwanLegautV2.Models;
using TP_EwanLegautV2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP_EwanLegautV2.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}