using System;
using System.Linq;

namespace MeterReadingDataAccessLayer
{
    public class MeterReadingHelper
    {
        private readonly MeterReadingDbContext _meterReadingDbContext;

        public MeterReadingHelper(MeterReadingDbContext meterReadingDbContext)
        {
            _meterReadingDbContext = meterReadingDbContext;
        }

        public void ValidateAndSave(MeterReading meterReading)
        {
            Validate(meterReading);
            Save(meterReading);
        }

        public void Validate(MeterReading meterReading)
        {
            var account = _meterReadingDbContext.Accounts.Find(meterReading.AccountId);

            if(account == null)
            {
                throw new AccountNotRecognisedException(meterReading.AccountId);
            }

            var existingMeterReadings = _meterReadingDbContext.MeterReadings
                .Where(x => x.MeterReadingDateTime == meterReading.MeterReadingDateTime && x.AccountId == meterReading.AccountId);

            if(existingMeterReadings.Any())
            {
                throw new MeterReadingAlreadyAddedException(meterReading.AccountId, meterReading.MeterReadingDateTime);
            }
        }

        public void Save(MeterReading meterReading)
        {
            _meterReadingDbContext.MeterReadings.Add(meterReading);
            _meterReadingDbContext.SaveChanges();
        }
    }
}
