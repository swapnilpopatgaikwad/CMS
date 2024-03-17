using CMS.Interfaces;
using CMS.Tables;
using SQLite;

namespace CMS.Services
{
    public class ExpenceService
    {
        private IDataBaseService _dataBaseService;

        public ExpenceService(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<Expence>> GetExpDetailAsync(string filterText = "")
        {
            if (string.IsNullOrEmpty(filterText))
            {
                var query = $"SELECT * FROM {nameof(Expence)} ";

                var expences = await _dataBaseService.QueryAsync<Expence>(query).ConfigureAwait(false);
                return expences;
            }
            else
            {
                var query = $"SELECT * FROM {nameof(Expence)} where ExpenceName LIKE '%{filterText}%' ";

                var expences = await _dataBaseService.QueryAsync<Expence>(query).ConfigureAwait(false);
                return expences;
            }
        }

        public async Task<Expence> GetExpDetailById(int Id)
        {
            return await _dataBaseService.FindAsync<Expence>(Id).ConfigureAwait(false);
        }

        public async Task<bool> AddExpDetail(Expence expdetail)
        {
            if (expdetail != null)
            {
                var result = await _dataBaseService.AddItemAsync<Expence>(expdetail).ConfigureAwait(false);
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }
        
        public async Task<bool> AddManyExpence(List<Expence> expences)
        {
            if (expences != null && expences.Count > 0)
            {
                foreach(var expense in expences)
                {
                    var result = await _dataBaseService.AddItemAsync<Expence>(expense).ConfigureAwait(false);

                    if (result > 0)
                    {
                    }
                }

                return true;
            }
            return false;
        }

        public async Task<bool> EditExpDetail(Expence expInfo)
        {
            if (expInfo.Id == 0)
            {
                var result = await _dataBaseService.AddItemAsync<Expence>(expInfo).ConfigureAwait(false);
                if (result > 0)
                {
                    return true;
                }

            }
            else
            {
                var result = await _dataBaseService.UpdateItemAsync<Expence>(expInfo).ConfigureAwait(false);
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteExp(int Id)
        {
            var transData = await _dataBaseService.FindAsync<Expence>(Id).ConfigureAwait(false);

            if (transData != null)
            {
                var result = await _dataBaseService.DeleteItemAsync<Expence>(Id).ConfigureAwait(false);
                if (result > 0)
                {
                    return true;// "Transaction Deleted successfully.";
                }
            }
            return false;// "No transaction Id deleted";
        }

        public async Task<int> GetTotalProfits()
        {
            var result = await _dataBaseService.GetItemsAsync<Expence>().ConfigureAwait(false);
            if (result != null && result.Count > 0)
            {
                return result.Sum(s => Convert.ToInt32(s.Amount));
            }

            return 0;
        }
    }
}
