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
    public class LawsAndItsLevelsApiController : ControllerBase
    {
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public LawsAndItsLevelsApiController(QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;


        }
        // GET: api/<LawsAndItsLevelsApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LawsAndItsLevelsApiController>/5
        [HttpPost("Check")]
        public IEnumerable<VwLevelsAndLaws> Check([FromForm] LevelComplete level)
        {
            HomePageModel model = new HomePageModel();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.Where(a => a.LawId == level.LevelId).ToList();
            string result = "false";
            foreach(var i in model.lstLevelsAndLaws)
            {
            List<TbUserQestionAnswer> LstUserQestionAnswer = ctx.TbUserQestionAnswers.Where(a => a.Id == level.id).ToList();
            List<TbQuestionsMCQLast> LstQuestionsMCQLast = new List<TbQuestionsMCQLast>();
            LstQuestionsMCQLast = ctx.TbQuestionsMCQLasts.Where(a => a.LevelId == i.LevelId).ToList();
            int count = LstQuestionsMCQLast.Count;
            int countQ = 0;

            foreach (var item in LstQuestionsMCQLast)
            {
                foreach (var element in LstUserQestionAnswer)
                {
                    if (item.QuestionId == element.QuestionId)
                    {
                        countQ++;
                    }

                }


            }
            if (countQ < count)
            {
                 result = "false";
                    i.CreatedBy = result;
               
            }
            else
            {
                result = "true";
                i.CreatedBy = result;
                }

            }
           
           
            return model.lstLevelsAndLaws;
        }

        // POST api/<LawsAndItsLevelsApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LawsAndItsLevelsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LawsAndItsLevelsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
