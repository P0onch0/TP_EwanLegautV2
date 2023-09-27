using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP_EwanLegautV2.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;

namespace TP_EwanLegautV2.Services{

    public class dao_credentiel : ICredentielStore<Credentiel>
    {
       
        // readonly List<Credentiel> credentiels;
        public List<Credentiel> credentiels;
      //  public List<Test> tests;
        private readonly string _baseApiUrl = "http://ewan.alwaysdata.net";
        HttpClient _httpClient;

        public dao_credentiel()
        {
            
            credentiels = new List<Credentiel>();
           // tests = new List<Test>();
            //credentiels = new List<Credentiel>()
            //{
            //    new Credentiel { Id = Guid.NewGuid().ToString(), Name = "Instagram", Description="ewan_lgt", Login="Ewan", Email="ewan.legaut@gmail.com", Category="Social", Password="pwd"},
            //    new Credentiel { Id = Guid.NewGuid().ToString(), Name = "", Description="This is an item description." },
            //    new Credentiel { Id = Guid.NewGuid().ToString(), Name = "Third item", Description="This is an item description." },
            //    new Credentiel { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description="This is an item description." },
            //    new Credentiel { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description="This is an item description." },
            //    new Credentiel { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description="This is an item description." }
            //};
        }
        public async Task<List<Credentiel>> GetPasswordAsync()
        {
            _httpClient = new HttpClient();
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/getAllInfo_Client");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Credentiel>>(jsonResponse);
            }
            else
            {
                throw new Exception($"Erreur lors de la récupération des données. Statut : {response.StatusCode}");
            }
        }



        public async Task<bool> AddCredentielAsync(Credentiel credentiel)
        {
            credentiels.Add(credentiel);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCredentielAsync(Credentiel credentiel)
        {
            var oldCredentiel = credentiels.Where((Credentiel arg) => arg.id == credentiel.id).FirstOrDefault();
            credentiels.Remove(oldCredentiel);
            credentiels.Add(credentiel);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCredentielAsync(string id)
        {
            int idAsInt; // Déclarer une variable pour stocker la conversion de id en int

            if (int.TryParse(id, out idAsInt))
            {
                // Conversion réussie, maintenant nous pouvons comparer les deux entiers
                var oldCredentiel = credentiels.Where((Credentiel arg) => arg.id == idAsInt).FirstOrDefault();
                if (oldCredentiel != null)
                {
                    credentiels.Remove(oldCredentiel);
                }
            }

            return await Task.FromResult(true);
        }

        public async Task<Credentiel> GetCredentielAsync(string id)
        {
            int idAsInt; // Déclarer une variable pour stocker la conversion de id en int

            if (int.TryParse(id, out idAsInt))
            {
                // Conversion réussie, maintenant nous pouvons comparer les deux entiers
                return await Task.FromResult(credentiels.FirstOrDefault(s => s.id == idAsInt));
            }
            else
            {
                // La conversion a échoué, gérer cette situation selon vos besoins
                // Par exemple, vous pouvez renvoyer null ou générer une exception
                return null;
            }
        }
        public async Task<IEnumerable<Credentiel>> GetCredentielAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(credentiels);
        }
    }
}
