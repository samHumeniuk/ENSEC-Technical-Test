using System;

namespace MeterReadingAPI
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
            //TODO
        }

        public void Save(MeterReading meterReading)
        {
            _meterReadingDbContext.MeterReadings.Add(meterReading);
            _meterReadingDbContext.SaveChanges();
        }
    }
}
