using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Employees
    {

        public string name { get; set; }
        public string contractTypeName { get; set; }
        public string roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public int hourlySalary { get; set; }
        public int monthlySalary { get; set; }
        public double Total { get; set; }
    }
}