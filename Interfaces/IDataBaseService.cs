using CMS.Tables;
using SQLite;

namespace CMS.Interfaces
{
    public interface IDataBaseService
    {
        Task<List<T>> GetItemsAsync<T>() where T : BaseTable, new();
        Task<List<T>> QueryAsync<T>(string queryString) where T : BaseTable, new();
        Task<T> FindAsync<T>(int id) where T : BaseTable, new();
        Task<int> AddItemAsync<T>(T item);
        Task<int> DeleteItemAsync<T>(int id);
        Task<int> UpdateItemAsync<T>(T item);
        Task<int> CountAsync<T>(string queryString = "") where T : BaseTable, new();
    }
}
