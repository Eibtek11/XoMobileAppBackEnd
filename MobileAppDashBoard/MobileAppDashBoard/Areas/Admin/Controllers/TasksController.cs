using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class TasksController : Controller
    {
        taskService taskService;
        ClaimService claimService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        UserManager<ApplicationUser> Usermanager;
        public TasksController(UserManager<ApplicationUser> usermanager,taskService TaskService, ClaimService ClaimService, LawService Lawservice, MobileAppDbContext context, CountryService CountryService)
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            claimService = ClaimService;
            taskService = TaskService;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();
            model.lstTasks = taskService.getAll();
            model.lstTasksAndUses = ctx.VwTasksAndUserss.ToList();
            return View(model);


        }




        public async Task<IActionResult> Save(TbTask ITEM, int id, List<IFormFile> files, List<IFormFile> filesImages)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();


            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.TaskId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {


             

                taskService.Edit(ITEM);
            }
            else
            {


                


                taskService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();
            model.lstTasks = taskService.getAll();
            model.lstTasksAndUses = ctx.VwTasksAndUserss.ToList();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbTask oldItem = ctx.TbTasks.Where(a => a.TaskId == id).FirstOrDefault();

            taskService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();
            model.lstTasks = taskService.getAll();
            model.lstTasksAndUses = ctx.VwTasksAndUserss.ToList();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbTask model = new TbTask();
            model = ctx.TbTasks.Where(a => a.TaskId == id).FirstOrDefault();
            ViewBag.Countries = Usermanager.Users;
            return View(model);


        }
    }
}
