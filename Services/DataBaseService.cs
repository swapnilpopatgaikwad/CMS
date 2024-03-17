using CMS.Constants;
using CMS.Interfaces;
using CMS.Tables;
using SQLite;

namespace CMS.Services
{
    public partial class DataBaseService: IDataBaseService
    {
        private readonly SQLiteAsyncConnection database;
        public DataBaseService()
        {
            database = new SQLiteAsyncConnection(ConstantRecord.DatabasePath, ConstantRecord.Flags, false);
            database.CreateTableAsync<Login>();
            database.CreateTableAsync<Patient>();
            database.CreateTableAsync<Treatment>();
            database.CreateTableAsync<Prescription>();
            database.CreateTableAsync<Expence>();
            database.CreateTableAsync<Medicine>();
        }
        
        // Read All Data
        public async Task<List<T>> GetItemsAsync<T>() where T : BaseTable, new()
        {
            return await database.Table<T>().ToListAsync();
        }

        // Read Query String Data
        public async Task<List<T>> QueryAsync<T>(string queryString) where T : BaseTable, new()
        {
            return await database.QueryAsync<T>(queryString);
        }

        // Read particular data
        public async Task<T> FindAsync<T>(int id) where T : BaseTable, new()
        {
            return await database.FindAsync<T>(id);
        }

        // Add data
        public async Task<int> AddItemAsync<T>(T item)
        {
            if (item is BaseTable obj)
            {
                if (obj != null && obj.CreatedDate == DateTime.MinValue)
                {
                    obj.CreatedDate = DateTime.Now;
                    obj.LastModifyDate = DateTime.Now;
                }
            }
            return await database.InsertAsync(item);
        }

        // Remove data
        public Task<int> DeleteItemAsync<T>(int id)
        {
            var itemType = typeof(T);
            var deleteQuery = $"DELETE FROM {itemType.Name} WHERE Id = ?";
            return database.ExecuteAsync(deleteQuery, id);
        }

        // Update data
        public async Task<int> UpdateItemAsync<T>(T item)
        {
            var itemType = typeof(T);
            var primaryKey = itemType.GetProperty("Id").GetValue(item);

            var obj = item as BaseTable;

            if ((int)primaryKey != 0)
            {
                if (obj != null && obj.CreatedDate == DateTime.MinValue)
                    obj.LastModifyDate = DateTime.Now;

                return await database.UpdateAsync(item);
            }
            else
            {
                if (obj != null && obj.CreatedDate == DateTime.MinValue)
                {
                    obj.CreatedDate = DateTime.Now;
                    obj.LastModifyDate = DateTime.Now;
                }

                return await database.InsertAsync(item);
            }
        }

        public async Task<int> CountAsync<T>(string queryString = "") where T : BaseTable, new()
        {
            if (string.IsNullOrEmpty(queryString))
            {
                return await database.Table<T>().CountAsync();
            }
            else
            {
                return await database.ExecuteScalarAsync<int>(queryString);
            }
        }
    }
}
