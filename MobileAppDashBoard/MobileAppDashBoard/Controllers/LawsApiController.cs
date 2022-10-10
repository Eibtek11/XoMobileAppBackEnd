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
    public class LawsApiController : ControllerBase
    {
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public LawsApiController(QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService,QuestionService QuestionService,LevelService LevelService,LawService LawService,CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;


        }
        // GET: api/<LawsApiController>
        [HttpGet]
        public IEnumerable<VwLevelsAndLaws> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            return model.lstLevelsAndLaws;
        }

        // GET api/<LawsApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbQuestion> Get(Guid id)
        {
            return ctx.TbQuestions.Where(a=> a.LevelId == id).ToList();
        }

        // POST api/<LawsApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LawsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LawsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
