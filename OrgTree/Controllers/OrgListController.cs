using OrgTree.Models;
using OrgTree.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace OrgTree.Controllers
{
    public class OrgListController : Controller
    {
        public ActionResult Index(string FileName)
        {
            var result = new HierarchyViewModel();
            if (string.IsNullOrEmpty(FileName))
            {
                result.Error = new Error() { Message = "File not specified, Click <a href='/'>here</a> to continue" };
                return View(result);
            }

            try
            {
                using (StreamReader sr = new StreamReader(Server.MapPath(FileName)))
                {
                    var empList = JsonConvert.DeserializeObject<List<Employee>>(sr.ReadToEnd());
                    result.EmployeeHierachyList = Hierarchy.ProcessEmployeeList(empList);
                    result.MaxLevel = result.EmployeeHierachyList.Max(x => x.Level);
                }
            }
            catch(FileNotFoundException ex)
            {
                result.Error = new Error() { Message = ex.Message };
            }

            return View(result);
        }
    }
}