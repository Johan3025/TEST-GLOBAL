using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Data;
using Newtonsoft.Json.Linq;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TestController : Controller
    {
        public Employees Employee = new Employees(); 

        // GET: Test
        public ActionResult Index()
        {
            String baseUrl = "http://masglobaltestapi.azurewebsites.net/api/Employees";
            var json = new WebClient().DownloadString(baseUrl);

        

            JArray PersonArray = JArray.Parse(json);

            IList<Employees> persona = PersonArray.Select(p => new Employees
            {
                name = (string)p["name"],
                contractTypeName = (string)p["contractTypeName"],
                roleId = (string)p["roleId"],
                roleName = (string)p["roleName"],
                roleDescription = (string)p["roleDescription"],
                hourlySalary = (int)p["hourlySalary"],
                monthlySalary = (int)p["monthlySalary"]
                
            }).ToList();


            foreach (var item in persona)
            {
                if (item.contractTypeName == "HourlySalaryEmployee")
                {
                    item.Total = 120 * item.hourlySalary * 12;
                }
                else
                {
                    item.Total = item.monthlySalary * 12;
                }

            }
           
            return View(persona);
        }
    }
}
