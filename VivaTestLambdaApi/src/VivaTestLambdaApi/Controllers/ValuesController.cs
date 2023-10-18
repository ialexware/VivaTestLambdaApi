using Microsoft.AspNetCore.Mvc;

namespace VivaTestLambdaApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "Value3" };
        }

    }
}