using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterReadingAPI
{
    public class MeterReading
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeterReadingId {get; set;}
        //TODO: add primary key to this table
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }

        public int MeterReadingValue { get; set; }

        [NotMapped]
        public Account Account { get; set; }

    }
}
