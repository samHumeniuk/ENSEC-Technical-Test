using System;
using System.Runtime.Serialization;

namespace MeterReadingStorage.DataAccessLayer
{
    [Serializable]
    public class MeterReadingAlreadyAddedException : BaseMeterReadingStorageException
    {
        public MeterReadingAlreadyAddedException(int accountId, DateTime meterReadingDateTime)
            :base($"A meter reading already exists for the account with id {accountId} on {meterReadingDateTime} ")
        {
        }

    }
}