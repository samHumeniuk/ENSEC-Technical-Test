using System;
using System.ComponentModel.DataAnnotations;

namespace MeterReadingStorage.DataAccessLayer
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
