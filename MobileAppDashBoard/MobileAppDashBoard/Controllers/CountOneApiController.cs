using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobileAppDashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountOneApiController : ControllerBase
    {
        CountryService countryService;
        MobileAppDbContext ctx;
        public CountOneApiController(CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;

        }
        // GET: api/<CountOneApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

      
       
       
        // GET api/<CountOneApiController>/5
        [HttpGet("{id}")]
        public TbCountry Get(Guid id)
        {
            return ctx.TbCountries.Where(a => a.CountryId == id).FirstOrDefault();
        }

        // POST api/<CountOneApiController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountOneApiController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountOneApiController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
