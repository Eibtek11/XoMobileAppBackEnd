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
    public class ValuesController : ControllerBase
    {
        CountryService countryService;
        MobileAppDbContext ctx;
        public ValuesController(CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TbQuestionsMCQLast> Get()
        {
            
            return ctx.TbQuestionsMCQLasts.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbQuestionsMCQLast> Get(Guid id)
        {
            return ctx.TbQuestionsMCQLasts.Where(a => a.LevelId == id).ToList();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
