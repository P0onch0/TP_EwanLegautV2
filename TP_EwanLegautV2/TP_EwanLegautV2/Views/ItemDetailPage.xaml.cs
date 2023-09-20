using System.ComponentModel;
using TP_EwanLegautV2.ViewModels;
using Xamarin.Forms;

namespace TP_EwanLegautV2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}