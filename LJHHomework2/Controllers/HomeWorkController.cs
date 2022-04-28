using LJHHomework2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LJHHomework2.Controllers
{
    public class HomeWorkController : Controller
    {
        public IActionResult FoodApp()
        {
            AppJsonData appData = new AppJsonData();
            ViewBag.foodAppData = appData.GetJsonData(appData.GetFoodList());
            return View();
        }
    }
}
