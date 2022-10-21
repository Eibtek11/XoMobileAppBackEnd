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
    public class CollectAllQuestionsApiController : ControllerBase
    {
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public CollectAllQuestionsApiController(QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;


        }
        // GET: api/<CollectAllQuestionsApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CollectAllQuestionsApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<VwOneApiCollectQuestions> Get(Guid id)
        {
            List<VwOneApiCollectQuestions> allQuestionsAndAnswers = new List<VwOneApiCollectQuestions>();
            List<VwOneApiCollectQuestions> allQuestions = new List<VwOneApiCollectQuestions> ();
            List<VwOneApiCollectQuestions> questionMcqAnswers = new List<VwOneApiCollectQuestions>();
            List<VwOneApiCollectQuestions> allView = new List<VwOneApiCollectQuestions>();
            allView = ctx.VwOneApiCollectQuestions.ToList();
            allQuestions = ctx.VwOneApiCollectQuestions.Where(a => a.LevelId == id).ToList();
            questionMcqAnswers = ctx.VwOneApiCollectQuestions.Where(a =>a.QuestionId == a.LevelId).ToList();
            foreach (var i in allQuestions)
            {
                allQuestionsAndAnswers.Add(i);
            }
            foreach (var i in allView)
            {
                foreach(var ii in allView)
                {
                    if(i.QuestionId == ii.LevelId)
                    {
                        allQuestionsAndAnswers.Add(ii);
                    } 

                }
               
            }

            return allQuestionsAndAnswers;
        }

        // POST api/<CollectAllQuestionsApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CollectAllQuestionsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CollectAllQuestionsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
