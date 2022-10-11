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
    public class LawsDetalisApiController : ControllerBase
    {
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public LawsDetalisApiController(QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;


        }
        // GET: api/<LawsDetalisApiController>
        [HttpGet]
        public IEnumerable<TbLaw> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstLaws = ctx.TbLaws.ToList();
            return model.lstLaws;
        }

        // GET api/<LawsDetalisApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LawsDetalisApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LawsDetalisApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LawsDetalisApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
