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
    public class TasksNumberApiController : ControllerBase
    {
        taskService taskService;
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public TasksNumberApiController(taskService TaskService, QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionMCQAnswerService = QuestionMCQAnswerService;
            questionMCQService = QuestionMCQService;
            questionService = QuestionService;
            levelService = LevelService;
            lawService = LawService;
            taskService = TaskService;

        }
        // GET: api/<TasksNumberApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TasksNumberApiController>/5
        [HttpGet("{id}")]
        public int Get(Guid id)
        {
            return ctx.TbTasks.Where(a => a.LawId == id).ToList().Count();
        }

        // POST api/<TasksNumberApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TasksNumberApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksNumberApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
