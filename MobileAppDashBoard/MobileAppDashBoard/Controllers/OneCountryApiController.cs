using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobileAppDashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneCountryApiController : ControllerBase
    {
        CountryService countryService;
        MobileAppDbContext ctx;
        public OneCountryApiController(CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;

        }
        // GET: api/<OneCountryApiController>
        [HttpGet]
        public IEnumerable<TbCountry> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            return model.lstCountries;
        }

        // GET api/<OneCountryApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OneCountryApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OneCountryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OneCountryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
