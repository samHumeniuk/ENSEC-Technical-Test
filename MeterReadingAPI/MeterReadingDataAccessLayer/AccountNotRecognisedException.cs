using System;
using System.Runtime.Serialization;

namespace MeterReadingDataAccessLayer
{
    [Serializable]
    internal class AccountNotRecognisedException : Exception
    {
        private int _accountId;

        public AccountNotRecognisedException(int accountId):
            base($"No account could be found with an accountId of {accountId}")
        {
            _accountId = accountId;
        }

    }
}