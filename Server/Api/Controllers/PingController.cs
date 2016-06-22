using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/ping")]
    public class PingController : ApiController
    {
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("")]
        public void Post([FromBody]string value)
        {
        }

        [Route("")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("")]
        public void Delete(int id)
        {
        }
    }
}
