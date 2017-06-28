using OrgTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgTree.ViewModels
{
    public class EmployeeListViewModel
    {
        public string FileName { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public Error Error { get; set; }
    }
}