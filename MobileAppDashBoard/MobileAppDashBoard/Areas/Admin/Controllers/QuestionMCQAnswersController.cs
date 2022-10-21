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
    public class QuestionMCQAnswersController : Controller
    {
        QuestionMCQAnswerService questionMCQAnswersService;
        QuestionService questionService;
        LevelService levelService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public QuestionMCQAnswersController(QuestionMCQAnswerService QuestionMCQAnswersService ,QuestionService QuestionService, LawService Lawservice, MobileAppDbContext context, CountryService CountryService, LevelService LevelService)
        {
           
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            levelService = LevelService;
            questionService = QuestionService;
            questionMCQAnswersService = QuestionMCQAnswersService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstLevels = levelService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            model.lstQuestions = questionService.getAll();
            model.lstLevelsAndLawsAndQuestions = ctx.VwLevelsAndLawsAndQuestionss.ToList();
            model.lstQuestionMCQsAnswers = questionMCQAnswersService.getAll();
            foreach (var item in model.lstQuestionMCQsAnswers)
            {
                item.UpdatedBy = ctx.TbQuestionsMCQS.Where(a => a.QuestionId == item.QuestionId).FirstOrDefault().QestionSyntax;
            }
            return View(model);


        }




        public async Task<IActionResult> Save(TbQuestionsMcqAnswers ITEM, int id)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbLevel oldItem = new TbLevel();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.QuestionsMcqAnswerId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                questionMCQAnswersService.Edit(ITEM);
            }
            else
            {





                questionMCQAnswersService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLevels = levelService.getAll();
            model.lstLaws = lawService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            model.lstQuestions = questionService.getAll();
            model.lstLevelsAndLawsAndQuestions = ctx.VwLevelsAndLawsAndQuestionss.ToList();
            model.lstQuestionMCQsAnswers = questionMCQAnswersService.getAll();
            foreach (var item in model.lstQuestionMCQsAnswers)
            {
                item.UpdatedBy = ctx.TbQuestionsMCQS.Where(a => a.QuestionId == item.QuestionId).FirstOrDefault().QestionSyntax;
            }
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbQuestionsMcqAnswers oldItem = ctx.TbQuestionsMcqAnswerss.Where(a => a.QuestionsMcqAnswerId == id).FirstOrDefault();

            questionMCQAnswersService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLevels = levelService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            model.lstQuestions = questionService.getAll();
            model.lstLevelsAndLawsAndQuestions = ctx.VwLevelsAndLawsAndQuestionss.ToList();
            model.lstQuestionMCQsAnswers = questionMCQAnswersService.getAll();
            foreach (var item in model.lstQuestionMCQsAnswers)
            {
                item.UpdatedBy = ctx.TbQuestionsMCQS.Where(a => a.QuestionId == item.QuestionId).FirstOrDefault().QestionSyntax;
            }
            return View("Index", model);



        }




        public IActionResult Form(Guid id)
        {
            TbQuestionsMcqAnswers model = new TbQuestionsMcqAnswers();
            model.QuestionId = id;
            ViewBag.Countries = id;
            return View(model);


        }
        public IActionResult FormEdit(Guid? id, Guid? idd)
        {
            TbQuestionsMcqAnswers model = new TbQuestionsMcqAnswers();
            model = ctx.TbQuestionsMcqAnswerss.Where(a => a.QuestionsMcqAnswerId == id).FirstOrDefault();
            model.QuestionId = idd;
            ViewBag.Countries = countryService.getAll();
            return View(model);


        }
    }
}
