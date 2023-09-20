using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TP_EwanLegautV2.Models;
using TP_EwanLegautV2.Views;
using Xamarin.Forms;

namespace TP_EwanLegautV2.ViewModels
{
    public class CredentielViewModel : BaseViewModel
    {
        private Credentiel _selectedItem;

        public ObservableCollection<Credentiel> OBScredentiels { get; }
        public Command LoadCredentielCommand { get; }
        public Command AddCredentielCommand { get; }
        public Command<Credentiel> CredentielTapped { get; }

        public CredentielViewModel()
        {
            Title = "Browse";
            OBScredentiels = new ObservableCollection<Credentiel>();
            LoadCredentielCommand = new Command(async () => await ExecuteLoadCredentielCommand());

            CredentielTapped = new Command<Credentiel>(OnCredentielSelected);

            AddCredentielCommand = new Command(OnAddCredentiel);
        }

        async Task ExecuteLoadCredentielCommand()
        {
            IsBusy = true;

            try
            {
                OBScredentiels.Clear();
                var credentiel = await DataStoreCredentiel.GetCredentielAsync(true);
                foreach (var cred in credentiel)
                {
                    OBScredentiels.Add(cred);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Credentiel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnCredentielSelected(value);
            }
        }

        private async void OnAddCredentiel(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnCredentielSelected(Credentiel credentiel)
        {
            if (credentiel == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={credentiel.Id}");
        }
    }
}