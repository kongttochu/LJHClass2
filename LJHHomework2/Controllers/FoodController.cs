using LJHHomework2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LJHHomework2.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            // 1. ViewBag.UserName = Request.Query["UserName"] == null ? "" : Request.Query["UserNamwe"];
            // 2-1. ViewBag.UserName = string.IsNullOrEmpty(Request.Query["UserName"]);
            // 2-2. ViewBag.UserName = string.IsNullOrWhiteSpace(Request.Query["UserName"]);
            // 3. ViewBag.UserName = Request.Query["UserName"] ?? ""; : 1번 축약형 default값
            ViewBag.UserName = Request.Query["UserName"];
            ViewBag.UserAge = Request.Query["UserAge"];

            return View();
        }

        public IActionResult Detail()
        {

            return View();
        }

        public JsonResult Test(string code, string user, int age)
        {
            TestData test = new TestData
            {
                code = code
                ,user = user
                ,age = age
            };
            return Json(test);
        }
    }
}
