using System.IO;

namespace MeterReadingDataAccessLayer
{
    public class MeterReadingDbSeeder
    {
        private MeterReadingDbContext _meterReadingDbContext;
        public MeterReadingDbSeeder(MeterReadingDbContext meterReadingDbContext)
        {
            _meterReadingDbContext = meterReadingDbContext;
        }

        public void SeedData()
        {
            string[] csvLines = File.ReadAllLines(@".\Seed Data\Test_Accounts.csv");

            bool isFirstLine = true;
            foreach (string csvLine in csvLines)
            {
                if(!isFirstLine)
                {
                    var account = AccountCsvParser.FromCsv(csvLine);
                    _meterReadingDbContext.Accounts.Add(account);
                    _meterReadingDbContext.SaveChanges();
                }
                else
                {
                    isFirstLine = false;
                }

            }
        }

    }
}
