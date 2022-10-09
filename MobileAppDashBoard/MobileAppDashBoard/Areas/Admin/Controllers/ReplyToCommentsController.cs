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
    public class ReplyToCommentsController : Controller
    {
        replyToCommentService replyToCommentService;
        questionUserAnswerService questionUserAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public ReplyToCommentsController(replyToCommentService ReplyToCommentService,questionUserAnswerService QuestionUserAnswerService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionUserAnswerService = QuestionUserAnswerService;
            replyToCommentService = ReplyToCommentService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstquestionUserAnswer = questionUserAnswerService.getAll();
            model.lstReplyToComments = replyToCommentService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbReplyToComment ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.CommentReplyId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                replyToCommentService.Add(ITEM);


            }
            else
            {




                replyToCommentService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstReplyToComments = replyToCommentService.getAll();

            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbReplyToComment oldItem = ctx.TbReplyToComments.Where(a => a.CommentReplyId == id).FirstOrDefault();

            replyToCommentService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstquestionUserAnswer = questionUserAnswerService.getAll();
            model.lstReplyToComments = replyToCommentService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbReplyToComment oUserQestionAnswer = new TbReplyToComment();
            oUserQestionAnswer = ctx.TbReplyToComments.Where(a => a.CommentReplyId == id).FirstOrDefault();
            return View(oUserQestionAnswer);
        }
    }
}
