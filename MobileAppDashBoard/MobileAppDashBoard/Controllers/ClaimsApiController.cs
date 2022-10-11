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
    public class ClaimsApiController : ControllerBase
    {
        ClaimService claimService;
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public ClaimsApiController(ClaimService ClaimService,QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;
            claimService = ClaimService;


        }
        // GET: api/<ClaimsApiController>
        [HttpGet]
        public IEnumerable<TbClaim> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstClaims = ctx.TbClaims.ToList();
            return model.lstClaims;
        }

        // GET api/<ClaimsApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClaimsApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClaimsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClaimsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
