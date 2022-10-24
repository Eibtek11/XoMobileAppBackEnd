using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {

        ClaimService claimService;
        LawService lawService;
        LevelService levelService;
        QuestionService questionService;
        QuestionMCQService questionMCQService;
        QuestionMCQAnswerService questionMCQAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public BlogController(ClaimService ClaimService, QuestionMCQAnswerService QuestionMCQAnswerService, QuestionMCQService QuestionMCQService, QuestionService QuestionService, LevelService LevelService, LawService LawService, CountryService Countryservice, MobileAppDbContext context)
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
        public IActionResult Index()
        {
            List<TbQuestionsMCQLast> b = new List<TbQuestionsMCQLast>();
            b = ctx.TbQuestionsMCQLasts.ToList();
            
            return View(ctx);
        }
        [HttpGet]
        public IActionResult Create()
        {
          

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TbQuestionsMCQLast blog)
        {
            if (ModelState.IsValid)
            {
                blog.QuestionId = Guid.NewGuid();
                ctx.TbQuestionsMCQLasts.Add(blog);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TbQuestionsMCQLast blog)
        {
            if (ModelState.IsValid)
            {
                
                ctx.TbQuestionsMCQLasts.Update(blog);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }
        public IActionResult Form(Guid? id)
        {
            TbQuestionsMCQLast model = new TbQuestionsMCQLast();
            model.LevelId = id;
            ViewBag.Countries = id;
            return View(model);


        }
        public IActionResult FormEdit(Guid? id, Guid? levelid)
        {
            TbQuestionsMCQLast model = new TbQuestionsMCQLast();
            model = ctx.TbQuestionsMCQLasts.Where(a => a.QuestionId == id).FirstOrDefault();
            model.LevelId = levelid;
            ViewBag.Countries = countryService.getAll();
            return View(model);


        }
        public IActionResult Delete(Guid id)
        {

            TbQuestionsMCQLast oldItem = ctx.TbQuestionsMCQLasts.Where(a => a.QuestionId == id).FirstOrDefault();

            ctx.TbQuestionsMCQLasts.Remove(oldItem);
            ctx.SaveChanges();
            return RedirectToAction("Index");

            



        }


    }
}
