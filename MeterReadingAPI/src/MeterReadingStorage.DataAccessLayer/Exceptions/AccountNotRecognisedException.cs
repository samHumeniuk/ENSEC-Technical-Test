using System;
using System.Runtime.Serialization;

namespace MeterReadingStorage.DataAccessLayer
{
    [Serializable]
    public class AccountNotRecognisedException : BaseMeterReadingStorageException
    {
        private int _accountId;

        public AccountNotRecognisedException(int accountId):
            base($"No account could be found with an accountId of {accountId}")
        {
            _accountId = accountId;
        }

    }
}