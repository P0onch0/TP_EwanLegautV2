using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TP_EwanLegautV2.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
    public interface ICredentielStore<T>
    {
        Task<bool> AddCredentielAsync(T Credentiel);
        Task<bool> UpdateCredentielAsync(T Credentiel);
        Task<bool> DeleteCredentielAsync(string id);
        Task<T> GetCredentielAsync(string id);
        Task<IEnumerable<T>> GetCredentielAsync(bool forceRefresh = false);
    }
}
