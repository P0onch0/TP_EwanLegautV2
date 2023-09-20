using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP_EwanLegautV2.Models;

namespace TP_EwanLegautV2.Services
{
    public class dao_credentiel : ICredentielStore<Credentiel>
    {
        readonly List<Credentiel> credentiels;

        public dao_credentiel()
        {
            credentiels = new List<Credentiel>()
            {
                new Credentiel { Id = Guid.NewGuid().ToString(), Name = "Instagram", Description="ewan_lgt", Login="Ewan", Email="ewan.legaut@gmail.com", Category="Social", Password="pwd"},
                new Credentiel { Id = Guid.NewGuid().ToString(), Name = "", Description="This is an item description." },
                new Credentiel { Id = Guid.NewGuid().ToString(), Name = "Third item", Description="This is an item description." },
                new Credentiel { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description="This is an item description." },
                new Credentiel { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description="This is an item description." },
                new Credentiel { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description="This is an item description." }
            };
        }


        public async Task<bool> AddCredentielAsync(Credentiel credentiel)
        {
            credentiels.Add(credentiel);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCredentielAsync(Credentiel credentiel)
        {
            var oldCredentiel = credentiels.Where((Credentiel arg) => arg.Id == credentiel.Id).FirstOrDefault();
            credentiels.Remove(oldCredentiel);
            credentiels.Add(credentiel);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCredentielAsync(string id)
        {
            var oldCredentiel = credentiels.Where((Credentiel arg) => arg.Id == id).FirstOrDefault();
            credentiels.Remove(oldCredentiel);

            return await Task.FromResult(true);
        }

        public async Task<Credentiel> GetCredentielAsync(string id)
        {
            return await Task.FromResult(credentiels.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Credentiel>> GetCredentielAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(credentiels);
        }
    }
}
