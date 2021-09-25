using MeterReadingDataAccessLayer;
using System;

namespace MeterReadingAPI
{
    public static class MeterReadingCsvParser
    {
        public static MeterReading FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            var meterReading = new MeterReading();
            meterReading.AccountId = Convert.ToInt32(values[0]);
            meterReading.MeterReadingDateTime = Convert.ToDateTime(values[1]);
            meterReading.MeterReadingValue = Convert.ToInt32(values[2]);
            return meterReading;
        }
    }
}
