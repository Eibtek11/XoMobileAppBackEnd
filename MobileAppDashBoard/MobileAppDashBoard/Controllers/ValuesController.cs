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
    public class ValuesController : ControllerBase
    {
        CountryService countryService;
        MobileAppDbContext ctx;
        public ValuesController(CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TbQuestionsMCQLast> Get()
        {
            
            return ctx.TbQuestionsMCQLasts.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpPost("levelComplete")]
        public IActionResult levelComplete([FromForm] LevelComplete level)
        {
            List<TbUserQestionAnswer> LstUserQestionAnswer = ctx.TbUserQestionAnswers.Where(a => a.Id == level.id).ToList();
            List<TbQuestionsMCQLast> LstQuestionsMCQLast = new List<TbQuestionsMCQLast>();
            LstQuestionsMCQLast = ctx.TbQuestionsMCQLasts.Where(a => a.LevelId == level.LevelId).ToList();
            int count = LstQuestionsMCQLast.Count;
            int countQ = 0;
           
            foreach (var item in LstQuestionsMCQLast)
            {
                foreach(var element in LstUserQestionAnswer)
                {
                    if (item.QuestionId == element.QuestionId  )
                    {
                        countQ++;
                    }

                }
              
              
            }
            if (countQ < count)
            {
                var result = ctx.TbQuestionsMCQLasts.Where(a => a.LevelId == level.LevelId).ToList();
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost("getLevelQuestions")]
        public IEnumerable<TbQuestionsMCQLast> getLevelQuestions([FromForm] Guid id)
        {

            return ctx.TbQuestionsMCQLasts.Where(a => a.LevelId == id).ToList();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
