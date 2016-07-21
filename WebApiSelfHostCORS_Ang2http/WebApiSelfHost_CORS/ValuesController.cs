using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiSelfHost_CORS
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        //public HttpResponseMessage Options()
        //{
        //    return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK };
        //}

        // GET api/values 
        public IEnumerable<Customer> Get()
        {
            return new Customer[] {
                new Customer() { Id = 1, Name = "Jacek" },
                new Customer() { Id = 2, Name = "Placek"}
            };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody]ValueDTO valueDTO)
        {
            Console.WriteLine(string.Format("POST executed {0}", valueDTO.Value));
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
