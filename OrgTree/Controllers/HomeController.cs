using Newtonsoft.Json;
using OrgTree.Models;
using OrgTree.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrgTree.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string path = Request.Form["fileLocation"];

            if (path == null)
            {
                path = "~/Models/EmployeeList.json";
            }

            EmployeeListViewModel viewModel = new EmployeeListViewModel() { FileName = path };
            try
            {
                using (StreamReader sr = new StreamReader(Server.MapPath(path)))
                {
                    var empList = JsonConvert.DeserializeObject<List<Employee>>(sr.ReadToEnd());
                    viewModel.EmployeeList = empList;
                }
            }
            catch (FileNotFoundException ex)
            {
                viewModel.Error = new Error() { Message = ex.Message };
            }
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}