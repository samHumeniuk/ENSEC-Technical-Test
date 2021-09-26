using MeterReadingStorage.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace MeterReadingStorage.DataAccessLayer.Test
{
    public class MeterReadingHelperTests
    {
        private MeterReadingHelper _meterReadingHelper;
        private MeterReadingDbContext _meterReadingDbContext;
        private MeterReading _meterReading;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MeterReadingDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());

            _meterReadingDbContext = new MeterReadingDbContext(optionsBuilder.Options);

            _meterReadingHelper = new MeterReadingHelper(_meterReadingDbContext);

            _meterReadingDbContext.Accounts.Add(new Account()
            {
                AccountId = 1,
                FirstName = "Sam",
                LastName = "Humeniuk",
            });

            _meterReading = new MeterReading()
            {
                AccountId = 1,
                MeterReadingDateTime = new DateTime(2021, 09, 26, 0, 0, 0),
                MeterReadingValue = 01234,
            };

            _meterReadingDbContext.MeterReadings.Add(_meterReading);

            _meterReadingDbContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _meterReadingDbContext.Dispose();
        }

        [Test]
        public void MeterReadingHelper_Validate_WithInvalidAccountCode_Should_ThrowException()
        {
            //arrange
            _meterReading.AccountId = 2; //an invalid accountId

            //assert
            Assert.Throws<AccountNotRecognisedException>(() => _meterReadingHelper.Validate(_meterReading));
        }

        [Test]
        public void MeterReadingHelper_Validate_WithDuplicateReading_Should_ThrowException()
        {
            //assert
            Assert.Throws<MeterReadingAlreadyAddedException>(() => _meterReadingHelper.Validate(_meterReading));
        }

        [Test]
        public void MeterReadingHelper_ValidateAndSave_WithValidReading_Should_Save()
        {
            var dateTime = DateTime.Now;

            //arrange
            _meterReading.MeterReadingDateTime = dateTime; //make sure it's not a duplicate record
            _meterReading.MeterReadingId = 0;

            //act
            _meterReadingHelper.ValidateAndSave(_meterReading);

            //assert
            Assert.AreEqual(2, _meterReadingDbContext.MeterReadings.Count());

        }
    }
}