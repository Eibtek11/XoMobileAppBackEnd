using BL;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobileAppDashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsApiController : ControllerBase
    {
        logInHistoryService lgHistory;
        MobileAppDbContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;
        private readonly IConfiguration _configuration;
        public UserDetailsApiController(logInHistoryService LgHistory, IConfiguration configuration, MobileAppDbContext ctx, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Usermanager = usermanager;
            SignInManager = signInManager;
            Ctx = ctx;
            _configuration = configuration;
            lgHistory = LgHistory;

        }
        // GET: api/<UserDetailsApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserDetailsApiController>/5
        [HttpGet("{id}")]
        public ApplicationUser Get(string id)
        {
            return Usermanager.Users.Where(a => a.Id == id).FirstOrDefault();
        }

        // POST api/<UserDetailsApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserDetailsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserDetailsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
