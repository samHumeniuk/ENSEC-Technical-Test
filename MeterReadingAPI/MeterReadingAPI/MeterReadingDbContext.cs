using Microsoft.EntityFrameworkCore;
using System;

namespace MeterReadingAPI
{
    public class MeterReadingDbContext : DbContext
    {
        public MeterReadingDbContext(DbContextOptions<MeterReadingDbContext> options)
        : base(options) { }

        public DbSet<MeterReading> MeterReadings { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
