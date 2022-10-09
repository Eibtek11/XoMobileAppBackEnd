﻿using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class QuestionUserAnswerController : Controller
    {
        questionUserAnswerService questionUserAnswerService;
        CountryService countryService;
        MobileAppDbContext ctx;
        public QuestionUserAnswerController(questionUserAnswerService QuestionUserAnswerService,CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;
            questionUserAnswerService = QuestionUserAnswerService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstquestionUserAnswer = questionUserAnswerService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbUserQestionAnswer ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.UserQuestionAnswerId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
               



                questionUserAnswerService.Add(ITEM);


            }
            else
            {


               

                questionUserAnswerService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();


            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbUserQestionAnswer oldItem = ctx.TbUserQestionAnswers.Where(a => a.UserQuestionAnswerId == id).FirstOrDefault();

            questionUserAnswerService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            model.lstquestionUserAnswer = questionUserAnswerService.getAll();

            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbUserQestionAnswer oUserQestionAnswer = new TbUserQestionAnswer();
            oUserQestionAnswer = ctx.TbUserQestionAnswers.Where(a => a.UserQuestionAnswerId == id).FirstOrDefault();
            return View(oUserQestionAnswer);
        }
    }
}
