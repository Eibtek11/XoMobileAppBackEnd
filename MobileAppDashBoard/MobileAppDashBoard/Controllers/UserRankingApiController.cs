using BL;
using Domains;
using Microsoft.AspNetCore.Identity;
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
    public class UserRankingApiController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        UserCountryLawService userCountryLawService;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;
        UserQuestionAnswerService userQuestionAnswerService;
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public UserRankingApiController(IAccountRepository accountRepository,UserCountryLawService UserCountryLawService,UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager , UserQuestionAnswerService UserQuestionAnswerService, QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
        {

            userCountryLawService = UserCountryLawService;
            Usermanager = usermanager;
            SignInManager = signInManager;
            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;
            userQuestionAnswerService = UserQuestionAnswerService;
            _accountRepository = accountRepository;


        }
        // GET: api/<UserRankingApiController>
        [HttpPost("addRecord")]
        public async Task<List<TbTrUserCountryLaw>>  addRecord([FromForm] string id)
        {
            var result = await _accountRepository.aaRecord(id);
            
            return result;
            
        }
        [HttpPost("addRecordOneUser")]
        public async Task<TbTrUserCountryLaw> addRecordOneUser([FromForm] string id)
        {
            var result = await _accountRepository.addRecordOneUser(id);

            return result;

        }

        // GET api/<UserRankingApiController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            List<CalculateUserGrade> list = ctx.CalculateUserGrades.Where(a => a.Id == id).ToList();
            int grade = 0;
            string result = "";
            foreach (var i in list)
            {
                if (i.CreatedBy == i.UserAnswer)
                {
                    grade += 100;
                }

            }

            if (grade == 100)
            {
                result = "Good";
            }
            else if (grade == 200)
            {
                result = "Very Good";
            }
            else if (grade >= 300)
            {
                result = "Excellent";

            }
            else
            {
                result = "bad";
            }
            return result;


        }

        // POST api/<UserRankingApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserRankingApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserRankingApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
