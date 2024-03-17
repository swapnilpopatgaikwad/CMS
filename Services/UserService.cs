using CMS.Constants;
using CMS.Interfaces;

namespace CMS.Services
{
    public class UserService
    {
        private IDataBaseService _dataBaseService;

        public UserService(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<int> GetCurrentLoginUserId()
        {
            var loginUserId = await SecureStorage.GetAsync(ConstantRecord.LoginUserId).ConfigureAwait(false);
            if (int.TryParse(loginUserId, out int _loginUserId))
            {
                return _loginUserId;
            }
            return 0;
        }
    }
}
