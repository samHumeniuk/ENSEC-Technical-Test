using MeterReadingStorage.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeterReadingStorage.API.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class MeterReadingStorageController : ControllerBase
    {

        private readonly ILogger<MeterReadingStorageController> _logger;
        private readonly MeterReadingHelper _meterReadingHelper;

        public MeterReadingStorageController(ILogger<MeterReadingStorageController> logger, MeterReadingHelper meterReadingHelper)
        {
            _logger = logger;
            _meterReadingHelper = meterReadingHelper;
        }


        [HttpPost]
        public MeterReadingSuccessStatistic Post(IFormFile csvFile)
        {
            using (var fileStream = csvFile.OpenReadStream())
            //TODO: should this StreamReader() be injected using dependency injection?
            using (var streamReader = new StreamReader(fileStream))
            {
                IList<MeterReading> meterReadings = new List<MeterReading>();
                var successfulReadings = 0;
                var unsuccessfulReadings = 0;

                //ignore the first line of the csv since it should be headers.
                streamReader.ReadLine();

                while (!streamReader.EndOfStream)
                {
                    var csvLine = streamReader.ReadLine();
                    try
                    {
                        var meterReading = MeterReadingCsvParser.FromCsv(csvLine);
                        _meterReadingHelper.ValidateAndSave(meterReading);
                        successfulReadings++;
                    }
                    catch(BaseMeterReadingStorageException)
                    {
                        unsuccessfulReadings++;
                    }
                    catch(FormatException)
                    {
                        unsuccessfulReadings++;
                    }
                }

                return new MeterReadingSuccessStatistic()
                {
                    SuccessfullMeterReadings = successfulReadings,
                    UnsuccessfullMeterReadings = unsuccessfulReadings
                };
            }
        }
    }
}
