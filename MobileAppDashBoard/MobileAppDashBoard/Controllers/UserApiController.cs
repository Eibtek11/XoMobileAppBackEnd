using BL;
using Microsoft.AspNetCore.Identity;
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
    public class UserApiController : ControllerBase
    {
        UserManager<ApplicationUser> usermanager;
        SignInManager<ApplicationUser> signInManager;
        ClaimService claimService;
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public UserApiController(SignInManager<ApplicationUser> SignInManager,UserManager<ApplicationUser> Usermanager,ClaimService ClaimService, QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;
            claimService = ClaimService;
            usermanager = Usermanager;
            signInManager = SignInManager;


        }
        // GET: api/<UserApiController>
        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            HomePageModel model = new HomePageModel();
          
            model.lstUsers = usermanager.Users;
            return model.lstUsers;
        }

        // GET api/<UserApiController>/5
        [HttpGet("{id}")]
        public async Task<ApplicationUser> GetAsync(Guid id)
        {
            string idString = id.ToString();
            var user = await usermanager.FindByIdAsync(idString);
            return user;
        }

        // POST api/<UserApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
