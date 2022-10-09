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
    public class QuestionMCQController : Controller
    {
        QuestionMCQService questionMCQService;
        QuestionService questionService;
        LevelService levelService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public QuestionMCQController(QuestionMCQService QuestionMCQService,QuestionService QuestionService, LawService Lawservice, MobileAppDbContext context, CountryService CountryService, LevelService LevelService)
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            levelService = LevelService;
            questionService = QuestionService;
            questionMCQService = QuestionMCQService;
        }
        
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstLevels = levelService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            model.lstQuestions = questionService.getAll();
            model.lstLevelsAndLawsAndQuestions = ctx.VwLevelsAndLawsAndQuestionss.ToList();
            model.lstQuestionMCQs = questionMCQService.getAll();
            model.lstLevelsAndLawsAndQuestionMCQ = ctx.VwLevelsAndLawsAndQuestionMCQs.ToList();
            return View(model);


        }




        public async Task<IActionResult> Save(TbQuestionsMCQ ITEM, int id)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbLevel oldItem = new TbLevel();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.QuestionId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                questionMCQService.Edit(ITEM);
            }
            else
            {





                questionMCQService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLevels = levelService.getAll();
            model.lstLaws = lawService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            model.lstQuestions = questionService.getAll();
            model.lstLevelsAndLawsAndQuestions = ctx.VwLevelsAndLawsAndQuestionss.ToList();
            model.lstQuestionMCQs = questionMCQService.getAll();
            model.lstLevelsAndLawsAndQuestionMCQ = ctx.VwLevelsAndLawsAndQuestionMCQs.ToList();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbQuestionsMCQ oldItem = ctx.TbQuestionsMCQS.Where(a => a.QuestionId == id).FirstOrDefault();

            questionMCQService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLevels = levelService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            model.lstQuestions = questionService.getAll();
            model.lstLevelsAndLawsAndQuestions = ctx.VwLevelsAndLawsAndQuestionss.ToList();
            model.lstQuestionMCQs = questionMCQService.getAll();
            model.lstLevelsAndLawsAndQuestionMCQ = ctx.VwLevelsAndLawsAndQuestionMCQs.ToList();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbQuestionsMCQ model = new TbQuestionsMCQ();
            model.LevelId = id;
            ViewBag.Countries = id;
            return View(model);


        }
        public IActionResult FormEdit(Guid? id, Guid? levelid)
        {
            TbQuestionsMCQ model = new TbQuestionsMCQ();
            model = ctx.TbQuestionsMCQS.Where(a => a.QuestionId == id).FirstOrDefault();
            model.LevelId = levelid;
            ViewBag.Countries = countryService.getAll();
            return View(model);


        }
    }
}
