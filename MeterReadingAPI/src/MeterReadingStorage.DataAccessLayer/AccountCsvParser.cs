
using System;

namespace MeterReadingStorage.DataAccessLayer
{
    public static class AccountCsvParser
    {
        public static Account FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            var account = new Account();
            account.AccountId = Convert.ToInt32(values[0]);
            account.FirstName = values[1];
            account.LastName = values[2];
            return account;
        }
    }
}
