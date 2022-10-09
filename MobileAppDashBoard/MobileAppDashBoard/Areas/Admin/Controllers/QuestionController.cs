using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class QuestionController : Controller
    {
        QuestionService questionService;
        LevelService levelService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public QuestionController(QuestionService QuestionService , LawService Lawservice, MobileAppDbContext context, CountryService CountryService, LevelService LevelService)
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            levelService = LevelService;
            questionService = QuestionService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstLevels = levelService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            model.lstQuestions = questionService.getAll();
            model.lstLevelsAndLawsAndQuestions = ctx.VwLevelsAndLawsAndQuestionss.ToList();
            return View(model);


        }




        public async Task<IActionResult> Save(TbQuestion ITEM, int id)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            TbLevel oldItem = new TbLevel();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.QuestionId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                questionService.Edit(ITEM);
            }
            else
            {





                questionService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLevels = levelService.getAll();
            model.lstLaws = lawService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            model.lstQuestions = questionService.getAll();
            model.lstLevelsAndLawsAndQuestions = ctx.VwLevelsAndLawsAndQuestionss.ToList();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbQuestion oldItem = ctx.TbQuestions.Where(a => a.QuestionId == id).FirstOrDefault();

            questionService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLevels = levelService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            model.lstQuestions = questionService.getAll();
            model.lstLevelsAndLawsAndQuestions = ctx.VwLevelsAndLawsAndQuestionss.ToList();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbQuestion model = new TbQuestion();
            model.LevelId = id;
            ViewBag.Countries = id;
            return View(model);


        }
        public IActionResult FormEdit(Guid? id, Guid? levelid)
        {
            TbQuestion model = new TbQuestion();
            model = ctx.TbQuestions.Where(a => a.QuestionId == id).FirstOrDefault();
            model.LevelId = levelid;
            ViewBag.Countries = countryService.getAll();
            return View(model);


        }


    }
}
