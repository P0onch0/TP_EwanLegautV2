using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TP_EwanLegautV2.Models;
using Xamarin.Forms;

namespace TP_EwanLegautV2.ViewModels
{
    [QueryProperty(nameof(CredentielId), nameof(CredentielId))]
    public class CredentielDetailViewModel:BaseViewModel
    {
        private string credentielId;
        private string text;
        private string description;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string CredentielId
        {
            get
            {
                return credentielId;
            }
            set
            {
                credentielId = value;
                LoadCredentielId(value);
            }
        }

        public async void LoadCredentielId(string credentielId)
        {
            try
            {
                var credentiel = await DataStoreCredentiel.GetCredentielAsync(credentielId);
                Id = credentiel.id.ToString();
                Description = credentiel.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Credentiel");
            }
        }
    }
    
    
       
    
}
    

