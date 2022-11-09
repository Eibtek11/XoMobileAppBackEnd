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
    public class ClaimLevelTwoApiController : ControllerBase
    {
        ClaimLevelTwoService claimLevelTwoService;
        ClaimLevelOneService claimLevelOneService;
        LawLevelOneService lawLevelOneService;
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public ClaimLevelTwoApiController(ClaimLevelTwoService ClaimLevelTwoService,ClaimLevelOneService ClaimLevelOneService, LawLevelOneService LawLevelOneService, QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
        {

            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;
            lawLevelOneService = LawLevelOneService;
            claimLevelOneService = ClaimLevelOneService;
            claimLevelTwoService = ClaimLevelTwoService;


        }
        // GET: api/<ClaimLevelTwoApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClaimLevelTwoApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbClaimLevelTwo> Get(Guid id)
        {
            return claimLevelTwoService.getAll().Where(a => a.ClaimLeveOneId == id);
        }

        // POST api/<ClaimLevelTwoApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClaimLevelTwoApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClaimLevelTwoApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
