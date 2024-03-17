using CMS.Interfaces;
using CMS.Model;
using CMS.Tables;

namespace CMS.Services
{
    public class MedicineService
    {
        public IDataBaseService DataBaseService { get; set; }
        public MedicineService(IDataBaseService dataBaseService)
        {
            DataBaseService = dataBaseService;
        }

        public async Task<IEnumerable<MedicineModel>> GetAllMedicinesOrByNameAsync(string filterText = "")
        {
            try
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    var query = $"SELECT * FROM {nameof(Medicine)} ";

                    var medicines = await DataBaseService.QueryAsync<Medicine>(query).ConfigureAwait(false);
                    return medicines.Select(x => x.ToMedicineModel()).ToList();
                }
                else
                {
                    var query = $"SELECT * FROM {nameof(Medicine)} where MedicineName LIKE '%{filterText}%' ";

                    var medicines = await DataBaseService.QueryAsync<Medicine>(query).ConfigureAwait(false);
                    return medicines.Select(x => x.ToMedicineModel()).ToList();
                }

            }
            catch (Exception ex)
            {
            }
            return new List<MedicineModel>();
        }
        
        public async Task<MedicineModel> GetMedicineByIdAsync(int medicineId)
        {
            try
            {
                if (medicineId > 0)
                {
                    var query = $"SELECT * FROM {nameof(Medicine)}  where Id = {medicineId}";

                    var medicines = await DataBaseService.QueryAsync<Medicine>(query).ConfigureAwait(false);
                    if (medicines.Count > 0)
                    {
                        return medicines.Select(x => x.ToMedicineModel()).FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<bool> AddOrUpdateMedicineAsync(Medicine medicine)
        {
            if (medicine.Id == 0)
            {
                var result = await DataBaseService.AddItemAsync<Medicine>(medicine).ConfigureAwait(false);
                if (result > 0)
                {
                    return true;
                }
            }
            else
            {
                var result = await DataBaseService.UpdateItemAsync<Medicine>(medicine).ConfigureAwait(false);
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteMedicineAsync(int medicineId)
        {
            var medicine = await DataBaseService.FindAsync<Medicine>(medicineId).ConfigureAwait(false);

            if (medicine != null)
            {
                var result = await DataBaseService.DeleteItemAsync<Medicine>(medicineId).ConfigureAwait(false);
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<int> FindTotalMedicinesAsync()
        {
            return await DataBaseService.CountAsync<Medicine>().ConfigureAwait(false);
        }
    }
}
