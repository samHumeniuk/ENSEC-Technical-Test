using MeterReadingStorage.DataAccessLayer;
using System;
using System.Linq;

namespace MeterReadingStorage.API
{
    public static class MeterReadingCsvParser
    {
        public static MeterReading FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            var meterReading = new MeterReading();
            meterReading.AccountId = Convert.ToInt32(values[0]);
            meterReading.MeterReadingDateTime = Convert.ToDateTime(values[1]);

            var meterReadingValueAsString = values[2];
            if(!meterReadingValueAsString.All(char.IsDigit))
            {
                throw new FormatException($"The meter reading value of {meterReadingValueAsString} could not be converted to a number");
            }
            var meterReadingValue = Convert.ToInt32(meterReadingValueAsString);

            if (meterReadingValue > 99999 || meterReadingValue < -99999)
            {
                throw new FormatException($"The meter reading value of {meterReadingValueAsString} was greater than 5 digits long");
            }

            meterReading.MeterReadingValue = meterReadingValue;

            return meterReading;
        }
    }
}
