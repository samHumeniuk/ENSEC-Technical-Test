using MeterReadingDataAccessLayer;
using System;
using System.Linq;

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

            var meterReadingAsString = values[2];
            if(!meterReadingAsString.All(char.IsDigit))
            {
                throw new FormatException($"The meter reading value of {meterReadingAsString} could not be converted to a number");
            }
            meterReading.MeterReadingValue = Convert.ToInt32(meterReadingAsString);

            return meterReading;
        }
    }
}
