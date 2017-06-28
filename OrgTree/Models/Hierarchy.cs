using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgTree.Models
{
    public class EmployeeHierarchy
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Level { get; set; }
    }

    public class Hierarchy
    {
        public static List<EmployeeHierarchy> ProcessEmployeeList(List<Employee> empList)
        {
            List<EmployeeHierarchy> result = new List<EmployeeHierarchy>();

            #region AnonymousMethods
            // Inline function to create a new EmployeeHierarchy object from Employee object
            Func<Employee, int, EmployeeHierarchy> empToHierarchy = (emp, level) =>
            {
                return new EmployeeHierarchy() {
                    EmployeeId = emp.EmployeeId,
                    EmployeeName = emp.EmployeeName,
                    Level = level };
            };

            // Declare anonymous method for determining hierarchy
            Action<int, int> findEmployee = null;

            // Define the anonymous method that traverses the employee list by calling itself recursively
            findEmployee = (manager, position) =>
            {
                // Get the list of employees with the given manager id
                foreach (var e in empList.Where(x => x.Manager == manager))
                {
                    // Add the employee to the list with the current level
                    result.Add(empToHierarchy(e, position));
                    // Find employees whose manager id will be the current employee
                    findEmployee(e.EmployeeId, position+1);
                }
            };
            #endregion

            // Find the top level employee i.e., CEO
            var ceo = GetCEO(empList);

            if (ceo != null)
            {
                // Add CEO to the result set
                result.Add(empToHierarchy(ceo, 1));
                // Call the anonymous function that adds employees to the list
                findEmployee(ceo.EmployeeId, 2);
            }

            // Return the result set
            return result;
        }

        public static Employee GetCEO(List<Employee> employeeList)
        {
            Employee result = null;
            var managers = employeeList.GroupBy(x => x.Manager)
                .Select(y => new { ManagerId = y.Key, Count = y.Count() })
                .Where(m => m.Count > 0); // Select only managers where count of employees > 0

            if (managers != null)
            {
                result = employeeList.Where(x => managers.Any(y => y.ManagerId.Equals(x.EmployeeId)) && x.Manager <= 0)
                    .FirstOrDefault();
            }

            return result;
        }
    }
}