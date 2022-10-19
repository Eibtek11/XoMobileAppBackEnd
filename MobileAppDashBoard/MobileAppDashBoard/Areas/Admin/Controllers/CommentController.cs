using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        UserManager<ApplicationUser> Usermanager;
        CommentsService commentsService;
       replyToCommentService replyToCommentService;
        questionUserAnswerService questionUserAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public CommentController(UserManager<ApplicationUser> usermanager,CommentsService CommentsService,replyToCommentService ReplyToCommentService, questionUserAnswerService QuestionUserAnswerService, CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionUserAnswerService = QuestionUserAnswerService;
            replyToCommentService = ReplyToCommentService;
            commentsService = CommentsService;
            Usermanager = usermanager;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstquestionUserAnswer = questionUserAnswerService.getAll();
            model.lstReplyToComments = replyToCommentService.getAll();
            model.lstCommentS = commentsService.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            return View(model);


        }




        public async Task<IActionResult> Save(TbComment ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.CommentId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                commentsService.Add(ITEM);


            }
            else
            {




                commentsService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstReplyToComments = replyToCommentService.getAll();
            model.lstCommentS = commentsService.getAll();

            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbComment oldItem = ctx.TbComments.Where(a => a.CommentId == id).FirstOrDefault();

            commentsService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstquestionUserAnswer = questionUserAnswerService.getAll();
            model.lstReplyToComments = replyToCommentService.getAll();
            model.lstCommentS = commentsService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbComment oUserQestionAnswer = new TbComment();
            oUserQestionAnswer = ctx.TbComments.Where(a => a.CommentId == id).FirstOrDefault();
            return View(oUserQestionAnswer);
        }
    }
}
