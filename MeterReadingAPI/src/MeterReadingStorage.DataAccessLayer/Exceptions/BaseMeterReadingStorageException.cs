using System;
using System.Runtime.Serialization;

namespace MeterReadingStorage.DataAccessLayer
{
    public class BaseMeterReadingStorageException : Exception
    {
        public BaseMeterReadingStorageException(string message) : base(message)
        {
        }
    }
}