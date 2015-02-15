using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HRMS.Core.Models;
using HRMS.Core.Enums;
using HRMS.Core.Contracts;
using HRMS.Framework;

namespace HRMS.UnitTests.SQLRepositoryTests
{
    [TestClass]
    public class EmployeeTest : TestBase
    {
        [TestInitialize]
        public override void Init()
        {
            base.Init();
            conn.Execute("INSERT INTO Departments VALUES (@Name, @Abbreviation)", testObjects.GetDepartment());
            conn.Execute("INSERT INTO Positions VALUES (@Name, @Type, @MonthsBeforePromotion)", testObjects.GetPosition());
        }

        [TestMethod]
        public void CreateEmployeeRequiredPropsOnly()
        {
            // Arrange
            var repo = Ioc.Get<IEmployeeRepository>();
            Employee employee = testObjects.GetEmployee();
            Employee resultFromCreate = null;
            Employee resultFromSelect = null;

            // Act
            resultFromCreate = repo.Create(employee);
            resultFromSelect = conn.Query<Employee>("SELECT TOP 1 * FROM Employees").FirstOrDefault();

            // Assert
            Assert.IsNotNull(resultFromCreate);
            Assert.AreNotSame(0, resultFromCreate.Id);
            Assert.IsNotNull(resultFromSelect);
            Assert.AreEqual(resultFromCreate.Id, resultFromSelect.Id);
            Assert.AreEqual(resultFromCreate.FirstName, resultFromSelect.FirstName);
            Assert.AreEqual(resultFromCreate.LastName, resultFromCreate.LastName);
            Assert.AreEqual(resultFromCreate.Gender, resultFromCreate.Gender);
            Assert.AreEqual(resultFromCreate.BirthDate, resultFromSelect.BirthDate);
            Assert.AreEqual(resultFromCreate.DepartmentId, resultFromSelect.DepartmentId);
            Assert.AreEqual(resultFromCreate.PositionId, resultFromSelect.PositionId);
            Assert.AreEqual(resultFromCreate.CivilStatus, resultFromSelect.CivilStatus);
            Assert.AreEqual(resultFromCreate.HiringDate.Date, resultFromSelect.HiringDate);
        }

        [TestMethod]
        public void UpdateEmployee()
        {
            // Arrange
            var repo = Ioc.Get<IEmployeeRepository>();
            Employee employee = testObjects.GetEmployee();

            // create employee an employee to update later
            employee = repo.Create(employee);

            // property values to update
            const string firstname = "Mary Mundeline";
            const string lastname = "Cadiente";
            const Gender gender = Gender.Female;
            DateTime dob = new DateTime(1991, 9, 18);

            Employee employeeToUpdate = null;
            Employee updatedEmployee = null;

            // Act
            employeeToUpdate = conn.Query<Employee>("SELECT TOP 1 * FROM Employees").FirstOrDefault();
            employeeToUpdate.FirstName = firstname;
            employeeToUpdate.LastName = lastname;
            employeeToUpdate.Gender = gender;
            employeeToUpdate.BirthDate = dob;
            repo.Update(employeeToUpdate);

            updatedEmployee = conn.Query<Employee>("SELECT TOP 1 * FROM Employees").FirstOrDefault();

            // Assert
            Assert.IsNotNull(updatedEmployee);
            Assert.AreEqual(employeeToUpdate.Id, updatedEmployee.Id);
            Assert.AreEqual(firstname, updatedEmployee.FirstName);
            Assert.AreEqual(lastname, updatedEmployee.LastName);
            Assert.AreEqual(gender, updatedEmployee.Gender);
            Assert.AreEqual(dob, updatedEmployee.BirthDate);
        }

        [TestMethod]
        public void GetByIdEmployee()
        {
            // Arrange
            var repo = Ioc.Get<IEmployeeRepository>();
            Employee employee = testObjects.GetEmployee();

            // create employee to test the get by id
            repo.Create(employee);

            // expected id
            const int id = 1;
            Employee resultFromGet = null;

            // Act
            resultFromGet = repo.GetById(id);

            // Assert
            Assert.IsNotNull(resultFromGet);
            Assert.AreEqual(id, resultFromGet.Id);
        }

        [TestMethod]
        public void GetAllEmployee()
        {
            // Arrange
            var repo = Ioc.Get<IEmployeeRepository>();

            // create n employees
            const int employeeCnt = 5;
            for (int i = 0; i < employeeCnt; i++)
            {
                repo.Create(testObjects.GetEmployee());
            }
            
            IEnumerable<Employee> resultFromGet = null;

            // Act
            resultFromGet = repo.Get();

            // Assert
            Assert.IsNotNull(resultFromGet);
            Assert.AreEqual(employeeCnt, resultFromGet.Count());
        }

        [TestMethod]
        public void DeleteEmployee()
        {
            // Arrange
            var repo = Ioc.Get<IEmployeeRepository>();
            Employee employee = testObjects.GetEmployee();

            // create employee to delete
            repo.Create(employee);

            // expected id of new employee to delete
            const int id = 1;
            int resultCountBefore = -1;
            int resultCountAfter = -1;

            // Act
            resultCountBefore = conn.Query<int>("SELECT COUNT(*) FROM Employees").First();
            repo.Delete(id);
            resultCountAfter = conn.Query<int>("SELECT COUNT(*) FROM Employees").First();

            // Assert
            Assert.AreEqual(1, resultCountBefore);
            Assert.AreEqual(0, resultCountAfter);
        }
    }
}
