using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TP_EwanLegautV2.Models;
using TP_EwanLegautV2.Views;
using Xamarin.Forms;
using TP_EwanLegautV2.Services;

namespace TP_EwanLegautV2.ViewModels
{
    public class CredentielViewModel : BaseViewModel
    {
        private Credentiel _selectedCredentiel;
        private dao_credentiel daoCredentiel;
        public ObservableCollection<Credentiel> OBScredentiels { get; }
        public Command LoadCredentielCommand { get; }
        public Command AddCredentielCommand { get; }
        public Command<Credentiel> CredentielTapped { get; }

        public CredentielViewModel()
        {
            Title = "Browse";
            daoCredentiel = new dao_credentiel();
            OBScredentiels = new ObservableCollection<Credentiel>();
            LoadCredentielCommand = new Command(async () => await ExecuteLoadCredentielCommand());

            CredentielTapped = new Command<Credentiel>(OnCredentielSelected);
            AddCredentielCommand = new Command(OnAddCredentiel);


        }
      

        //public async void RefreshData()

        //{
        //    IsBusy = true;

        //    OBScredentiels.Clear();

        //    var credentials = await daoCredentiel.GetPasswordAsync();

        //    foreach (var credential in credentials)

        //    {

        //        OBScredentiels.Add(credential);

        //    }

        //}

        async Task ExecuteLoadCredentielCommand()
        {
            IsBusy = true;

            try
            {
                OBScredentiels.Clear();
                var credentiel = await DataStoreCredentiel.GetCredentielAsync(true);

                var credentials = await daoCredentiel.GetPasswordAsync();
                foreach (var cred in credentials)
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
            SelectedCredentiel = null;
        }

        public Credentiel SelectedCredentiel
        {
            get => _selectedCredentiel;
            set
            {
                SetProperty(ref _selectedCredentiel, value);
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
           await Shell.Current.GoToAsync($"{nameof(CredentielDetailPage)}?{nameof(CredentielDetailViewModel.CredentielId)}={credentiel.id}");
          //  await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}