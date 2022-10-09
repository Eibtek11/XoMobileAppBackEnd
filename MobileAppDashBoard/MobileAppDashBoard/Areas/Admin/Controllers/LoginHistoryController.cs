using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class LoginHistoryController : Controller
    {
        logInHistoryService logInHistoryService;
        replyToCommentService replyToCommentService;
        questionUserAnswerService questionUserAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public LoginHistoryController(logInHistoryService LogInHistoryService,replyToCommentService ReplyToCommentService, questionUserAnswerService QuestionUserAnswerService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionUserAnswerService = QuestionUserAnswerService;
            replyToCommentService = ReplyToCommentService;
            logInHistoryService = LogInHistoryService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstquestionUserAnswer = questionUserAnswerService.getAll();
            model.lstReplyToComments = replyToCommentService.getAll();
            model.lstLogInHistories = logInHistoryService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbLoginHistory ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.LogInId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                logInHistoryService.Add(ITEM);


            }
            else
            {




                logInHistoryService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstReplyToComments = replyToCommentService.getAll();
            model.lstLogInHistories = logInHistoryService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbLoginHistory oldItem = ctx.TbLoginHistories.Where(a => a.LogInId == id).FirstOrDefault();

            logInHistoryService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstquestionUserAnswer = questionUserAnswerService.getAll();
            model.lstReplyToComments = replyToCommentService.getAll();
            model.lstLogInHistories = logInHistoryService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbLoginHistory oUserQestionAnswer = new TbLoginHistory();
            oUserQestionAnswer = ctx.TbLoginHistories.Where(a => a.LogInId == id).FirstOrDefault();
            return View(oUserQestionAnswer);
        }
    }
}
