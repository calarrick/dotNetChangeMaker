using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChangeMaker.Controllers
{
    public class ChangeCalcAJAXController : ApiController
    {
        // GET: api/ChangeCalcAJAX
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ChangeCalcAJAX/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ChangeCalcAJAX
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ChangeCalcAJAX/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ChangeCalcAJAX/5
        public void Delete(int id)
        {
        }
    }
}
