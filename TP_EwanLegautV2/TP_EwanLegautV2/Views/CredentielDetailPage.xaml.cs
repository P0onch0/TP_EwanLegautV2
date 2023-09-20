using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TP_EwanLegautV2.ViewModels;

namespace TP_EwanLegautV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CredentielDetailPage : ContentPage
    {
        public CredentielDetailPage()
        {
            InitializeComponent();
            this.BindingContext = new CredentielDetailViewModel();
        }
    }
}