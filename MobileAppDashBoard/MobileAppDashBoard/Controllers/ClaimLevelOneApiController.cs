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
    public class ClaimLevelOneApiController : ControllerBase
    {
        ClaimLevelOneService claimLevelOneService;
        LawLevelOneService lawLevelOneService;
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public ClaimLevelOneApiController(ClaimLevelOneService ClaimLevelOneService ,LawLevelOneService LawLevelOneService, QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
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


        }
        // GET: api/<ClaimLevelOneApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClaimLevelOneApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbClaimLeveOne> Get(Guid id)
        {
            return claimLevelOneService.getAll().Where(a => a.ClaimId == id);
        }

        // POST api/<ClaimLevelOneApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClaimLevelOneApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClaimLevelOneApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
