using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Serilog;
using SmartServe.Common.Models;
using SmartServe.Domain.Constants;

namespace SmartServeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //public virtual ILazyLoader<IHttpSession> HttpSession;
        //private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController()
        {
     //       _logger = logger;
        }

        private static readonly string[] Summaries =
        [
            "Freezing", "Bracijng", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var log = HttpContext.Items["RequestLog"] as RequestLogContext;
            
            try
            {
                throw new Exception();
                //_logger.LogInformation("Billing started for Order {OrderId}");

                //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                //{
                //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                //    TemperatureC = Random.Shared.Next(-20, 55),
                //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                //})
                //.ToArray();
            }
            catch (Exception ex)
            {
                log.ResultCode = ResultCodes.Error;
                log.ResultMessage = ResultMessages.Error;
                //CreateAnnotation(Annotations.ResultCode, ResultCodes.Error);
                //CreateAnnotation(Annotations.ResultCode, ResultCodes.Error);

                // _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
            }


        }

        //private void CreateAnnotation(string annotation, string value)
        //{
        //    if (string.IsNullOrWhiteSpace(annotation))
        //        throw new ArgumentNullException();
        //    if (!string.IsNullOrWhiteSpace(value))
        //    {
        //        HttpSession?.Value?.CreateAnnotation(annotation, value);
        //    }
        //}
    }
}
