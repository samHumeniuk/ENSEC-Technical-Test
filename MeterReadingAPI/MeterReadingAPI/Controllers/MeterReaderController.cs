using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeterReadingAPI.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class MeterReaderController : ControllerBase
    {

        private readonly ILogger<MeterReaderController> _logger;

        public MeterReaderController(ILogger<MeterReaderController> logger)
        {
            _logger = logger;
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
                while(!streamReader.EndOfStream)
                {
                    var csvLine = streamReader.ReadLine();
                    try
                    {
                        meterReadings.Add(MeterReadingCsvParser.FromCsv(csvLine));
                        successfulReadings++;
                    }
                    //TODO: catch a specific type of exception
                    catch(Exception)
                    {
                        unsuccessfulReadings++;
                    }
                }

                //TODO: save to database

                return new MeterReadingSuccessStatistic()
                {
                    SuccessfullMeterReadings = successfulReadings,
                    UnsuccessfullMeterReadings = unsuccessfulReadings
                };
            }
        }
    }
}
