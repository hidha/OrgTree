using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgTree.Models
{
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Description{ get; set; }
    }
}