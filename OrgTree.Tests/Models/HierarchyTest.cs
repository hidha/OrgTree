using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OrgTree.Models;

namespace OrgTree.Tests.Models
{
    [TestClass]
    public class HierarchyTest
    {
        [TestMethod]
        public void GetCEO_ReturnsTheCEORecordSuccessfully()
        {
            var empList = CreateTestSet1();
            var response = Hierarchy.GetCEO(empList);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.EmployeeId, 150);
        }

        [TestMethod]
        public void EmployeeListWithThreeLevels_ReturnsProcessedResult()
        {
            var empList = CreateTestSet1();

            var response = Hierarchy.ProcessEmployeeList(empList);
            Assert.AreEqual(response.Count, 6); // Returns all the employees in the processed list
            Assert.AreEqual(response[0].Level, 1); // The first record has level 1\
            Assert.AreEqual(response[5].Level, 3); // The max level is 3 
        }

        private List<Employee> CreateTestSet1()
        {
            List<Employee> employeeList = new List<Employee>()
            {
                new Employee() { EmployeeId = 100, EmployeeName = "Alan", Manager = 150 },
                new Employee() { EmployeeId = 220, EmployeeName = "Martin", Manager = 100 },
                new Employee() { EmployeeId = 150, EmployeeName = "Jamie" },
                new Employee() { EmployeeId = 275, EmployeeName = "Alex", Manager = 100 },
                new Employee() { EmployeeId = 400, EmployeeName = "Steve", Manager = 150 },
                new Employee() { EmployeeId = 190, EmployeeName = "David", Manager = 400 }
            };

            return employeeList;
        }
    }
}
