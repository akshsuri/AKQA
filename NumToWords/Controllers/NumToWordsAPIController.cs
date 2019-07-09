using Services.Interface;
using Services.Services;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;

namespace NumToWords.Controllers
{
    public class NumToWordsAPIController : ApiController
    {
        private readonly IConvertToWords service;

        public NumToWordsAPIController()
        {
            service = new ConvertToWordsService();
        }
        [HttpGet]
        [Route("conversion/{number}")]
        [ResponseType(typeof(string))]
        public IHttpActionResult convert(string number)
        {
            return Ok(service.CheckNumber(number));
        }
    }
}
