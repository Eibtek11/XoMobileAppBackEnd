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
    public class UserQestionAnswersApiController : ControllerBase
    {
        UserQuestionAnswerService userQuestionAnswerService;
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public UserQestionAnswersApiController(UserQuestionAnswerService UserQuestionAnswerService,QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;
            userQuestionAnswerService = UserQuestionAnswerService;


        }
        [HttpPost("addAnswer")]
        public  IActionResult addAnswer([FromBody] TbUserQestionAnswer answerModel)
        {
            bool result = userQuestionAnswerService.Add(answerModel);

            if (result)
            {
                return Ok(result);
            }

            return Unauthorized();
        }
        // GET: api/<UserQestionAnswersApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost("getGrade")]
        public string getGrade([FromForm] TbUserQestionAnswer answerModel)
        {
            List<CalculateUserGrade> list = ctx.CalculateUserGrades.Where(a => a.Id == answerModel.Id).ToList();
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
        // GET api/<UserQestionAnswersApiController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            List<CalculateUserGrade> list = ctx.CalculateUserGrades.Where(a => a.Id == id).ToList();
            int grade = 0;
            string result = "";
            foreach (var i in list)
            {
                if(i.CreatedBy == i.UserAnswer)
                {
                    grade += 100;
                }

            }

            if (grade == 100)
            {
                result = "Good";
            }
            else if(grade == 200)
            {
                result = "Very Good";
            }
            else if(grade >=300)
            {
                result = "Excellent";

            }
            else
            {
                result = "bad";
            }
            return result;


        }

        // POST api/<UserQestionAnswersApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserQestionAnswersApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserQestionAnswersApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
