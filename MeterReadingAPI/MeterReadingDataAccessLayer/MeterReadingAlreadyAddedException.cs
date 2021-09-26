using System;
using System.Runtime.Serialization;

namespace MeterReadingDataAccessLayer
{
    [Serializable]
    internal class MeterReadingAlreadyAddedException : Exception
    {
        public MeterReadingAlreadyAddedException(int accountId, DateTime meterReadingDateTime)
            :base($"A meter reading already exists for the account with id {accountId} on {meterReadingDateTime} ")
        {
        }

    }
}