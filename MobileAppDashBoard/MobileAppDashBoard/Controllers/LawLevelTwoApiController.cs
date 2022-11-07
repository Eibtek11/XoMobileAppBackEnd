using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobileAppDashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawLevelTwoApiController : ControllerBase
    {
        LawLevelTwoService lawLevelTwoService;
        LawLevelOneService lawLevelOneService;
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public LawLevelTwoApiController(LawLevelTwoService LawLevelTwoService,LawLevelOneService LawLevelOneService, QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;
            lawLevelOneService = LawLevelOneService;
            lawLevelTwoService = LawLevelTwoService;


        }
        // GET: api/<LawLevelTwoApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LawLevelTwoApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbLawLevelTwo> Get(Guid id)
        {
            return lawLevelTwoService.getAll().Where(a => a.LawLevelOneId == id);
        }

        // POST api/<LawLevelTwoApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LawLevelTwoApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LawLevelTwoApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
