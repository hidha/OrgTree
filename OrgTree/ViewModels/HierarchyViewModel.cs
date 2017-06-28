using OrgTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgTree.ViewModels
{
    public class HierarchyViewModel
    {
        public List<EmployeeHierarchy> EmployeeHierachyList { get; set; }
        public int MaxLevel { get; set; }
        public Error Error { get; set; }
    }
}