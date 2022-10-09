using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LawController : Controller
    {
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public LawController(LawService Lawservice, MobileAppDbContext context , CountryService CountryService)
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            foreach(var item in model.lstLaws)
            {
                item.UpdatedBy = ctx.TbLevels.Where(a => a.LawId == item.LawId).Count().ToString();
            }
            return View(model);


        }




        public async Task<IActionResult> Save(TbLaw ITEM, int id, List<IFormFile> files , List<IFormFile> filesImages)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            TbLaw oldItem = new TbLaw();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.LawId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.LawPdf = ImageName;
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

                lawService.Edit(ITEM);
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
                        ITEM.LawPdf = ImageName;
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


                lawService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();


            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbLaw oldItem = ctx.TbLaws.Where(a => a.LawId == id).FirstOrDefault();

            lawService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();


            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbLaw model = new TbLaw();
            model = ctx.TbLaws.Where(a => a.LawId == id).FirstOrDefault();
            ViewBag.Countries = countryService.getAll();
            return View(model);

           
        }


     
    }
}
