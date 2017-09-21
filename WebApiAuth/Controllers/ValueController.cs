using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAuth.Filter;

namespace WebApiAuth.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ValueController : ApiController
    {
        // GET /api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        

    }
}
