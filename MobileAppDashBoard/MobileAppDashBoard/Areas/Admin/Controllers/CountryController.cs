using BL;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        CountryService countryService;
        MobileAppDbContext ctx;
        public CountryController(CountryService Countryservice, MobileAppDbContext context)
        {
            countryService = Countryservice;
            ctx = context;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();
            return View(model);

          
        }
       



        public async Task<IActionResult> Save(TbCountry ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.CountryId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.CountryImageName = ImageName;
                    }
                }



                countryService.Add(ITEM);

                
            }
            else
            {


                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.CountryImageName = ImageName;
                    }
                }
                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                countryService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();


            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbCountry oldItem = ctx.TbCountries.Where(a => a.CountryId == id).FirstOrDefault();

            countryService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstCountries = countryService.getAll();


            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            HomePageModel model = new HomePageModel();
            model.item = ctx.TbCountries.Where(a => a.CountryId == id).FirstOrDefault();

            return View(model);
        }
    }
}
