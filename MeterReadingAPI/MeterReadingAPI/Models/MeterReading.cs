using System;

namespace MeterReadingAPI
{
    public class MeterReading
    {
        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }

        public int MeterReadingValue { get; set; }

    }
}
