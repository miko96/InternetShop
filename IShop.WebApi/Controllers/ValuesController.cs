using System.Collections.Generic;
using System.Linq;
using IShop.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace IShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ShopContext _context;

        public ValuesController(ShopContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var a = _context.TestTables.Select(x=>x).FirstOrDefault();
            var b =_context.TestTables.Select(x=>x);
            return new string[] { a.Id.ToString(), a.Value };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
