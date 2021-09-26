using FluentAssertions;
using MeterReadingStorage.API;
using MeterReadingStorage.DataAccessLayer;
using NUnit.Framework;
using System;

namespace MeterReadingStorage.API.Test
{
    public class MeterReadingCsvParserTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void MeterReadingCsvParser_FromCsv_WithHugeReading_Should_ThrowExcepiton()
        {
            Assert.Throws<FormatException>(() => MeterReadingCsvParser.FromCsv("2346,22/04/2019 12:25,999999"));
        }

        [Test]
        public void MeterReadingCsvParser_FromCsv_WithHugeNegativeReading_Should_ThrowExcepiton()
        {
            Assert.Throws<FormatException>(() => MeterReadingCsvParser.FromCsv("2346,22/04/2019 12:25,-999999"));
        }

        [Test]
        public void MeterReadingCsvParser_FromCsv_WithValidReading_Should_ReturnMeterReading()
        {
            var meterReading = MeterReadingCsvParser.FromCsv("2345,22/04/2019 12:25,45522");

            meterReading.Should().BeEquivalentTo(new MeterReading()
            {
                AccountId = 2345,
                MeterReadingDateTime = new DateTime(2019, 04, 22, 12, 25, 0),
                MeterReadingValue = 45522
            });
        }


    }
}