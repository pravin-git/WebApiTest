using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAuth.Filter;

namespace WebApiAuth.Controllers
{
    public class ValueController : ApiController
    {
        [Authorize(Roles = "Admin")]
        [Route("api/one")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize(Roles = "Worker")]
        [Route("api/anotherone")]
        [HttpGet]
        public IEnumerable<string> AnotherGet()
        {
            return new string[] { "value3", "value4" };
        }

    }
}
