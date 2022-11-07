using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System.Collections.Generic;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LawLevelTwoController : Controller
    {
        LawLevelTwoService lawLevelTwoService;
        LawLevelOneService lawLevelOneService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public LawLevelTwoController(LawLevelTwoService LawLevelTwoService,LawLevelOneService LawLevelOneService, LawService Lawservice, MobileAppDbContext context, CountryService CountryService)
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            lawLevelOneService = LawLevelOneService;
            lawLevelTwoService = LawLevelTwoService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLawLevelTwoS = lawLevelTwoService.getAll();
           
            return View(model);


        }




        public async Task<IActionResult> Save(TbLawLevelTwo ITEM, int id, List<IFormFile> files, List<IFormFile> filesImages)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            TbLaw oldItem = new TbLaw();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.LawLevelTwoId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {


                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".pdf";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.LawLevelTwoPdf = ImageName;
                    }
                }
                foreach (var file in filesImages)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.CreatedBy = ImageName;
                    }
                }
                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                lawLevelTwoService.Edit(ITEM);
            }
            else
            {


                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".pdf";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.LawLevelTwoPdf = ImageName;
                    }
                }
                foreach (var file in filesImages)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.CreatedBy = ImageName;
                    }
                }


                lawLevelTwoService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstLawLevelOneS = lawLevelOneService.getAll();
            model.lstLawLevelTwoS = lawLevelTwoService.getAll();


            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbLawLevelTwo oldItem = ctx.TbLawLevelTwos.Where(a => a.LawLevelTwoId == id).FirstOrDefault();

            lawLevelTwoService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstLawLevelOneS = lawLevelOneService.getAll();
            model.lstLawLevelTwoS = lawLevelTwoService.getAll();

            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbLawLevelTwo model = new TbLawLevelTwo();
            model = ctx.TbLawLevelTwos.Where(a => a.LawLevelTwoId == id).FirstOrDefault();
            ViewBag.Countries = lawLevelOneService.getAll();
            return View(model);


        }
        public IActionResult Form2(Guid id)
        {
            TbLawLevelTwo model = new TbLawLevelTwo();
            model.LawLevelOneId = id;
            ViewBag.Countries = lawLevelOneService.getAll();

            return View(model);


        }
    }
}
