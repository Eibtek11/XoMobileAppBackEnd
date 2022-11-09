using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
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
    public class CountryApiController : ControllerBase
    {
        CountryService countryService;
        MobileAppDbContext ctx;
        public CountryApiController(CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;

        }
        // GET: api/<CountryApiController>
        [HttpGet]
        
        public IEnumerable<TbCountry> Get()
        {
            var user = this.User;
            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            return model.lstCountries;
        }

       

        // POST api/<CountryApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
