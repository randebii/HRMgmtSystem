using HRMS.Core.Enums;
using HRMS.Core.Models;
using HRMS.Core.Utility;
using HRMS.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.UnitTests.UtilityTests
{
    [TestClass]
    public class CoreUtilityTest : TestBase
    {
        [TestMethod]
        public void ConvertFromCoreModelToViewModel()
        {
            // Arrange
            Employee objSource = testObjects.GetEmployee();
            EmployeeDtl objReturn = null;

            // Act
            objReturn = objSource.Convert<EmployeeDtl>();

            // Assert
            Assert.IsNotNull(objReturn);
            Assert.AreEqual(objSource.Id, objReturn.Id);
            Assert.AreEqual(objSource.LastName, objReturn.LastName);
            Assert.AreEqual(objSource.FirstName, objReturn.FirstName);
            Assert.AreEqual(objSource.BirthDate, objReturn.BirthDate);
            Assert.AreEqual(objSource.HiringDate, objReturn.HiringDate);
            Assert.AreEqual(objSource.Gender, objReturn.Gender);
            Assert.AreEqual(objSource.CivilStatus, objReturn.CivilStatus);
            Assert.AreEqual(objSource.DepartmentId, objReturn.DepartmentId);
            Assert.AreEqual(objSource.PositionId, objReturn.PositionId);
        }

        [TestMethod]
        public void ConvertFromViewModelToCoreModel()
        {
            // Arrange
            EmployeeDtl objSource = new EmployeeDtl()
            {
                Id = 1,
                DepartmentId = 2,
                PositionId = 3,
                FirstName = "Randolph",
                LastName = "Bangay",
                Gender = Gender.Male,
                CivilStatus = CivilStatus.Single,
                BirthDate = new DateTime(1990, 4, 6),
                HiringDate = DateTime.Now
            };
            Employee objReturn = null;

            // Act
            objReturn = objSource.Convert<Employee>();

            // Assert
            Assert.IsNotNull(objReturn);
            Assert.AreEqual(objSource.Id, objReturn.Id);
            Assert.AreEqual(objSource.LastName, objReturn.LastName);
            Assert.AreEqual(objSource.FirstName, objReturn.FirstName);
            Assert.AreEqual(objSource.BirthDate, objReturn.BirthDate);
            Assert.AreEqual(objSource.HiringDate, objReturn.HiringDate);
            Assert.AreEqual(objSource.Gender, objReturn.Gender);
            Assert.AreEqual(objSource.CivilStatus, objReturn.CivilStatus);
            Assert.AreEqual(objSource.DepartmentId, objReturn.DepartmentId);
            Assert.AreEqual(objSource.PositionId, objReturn.PositionId);
        }

        [TestMethod]
        public void ConvertFromCoreModelToViewModelReferenceTypeIgnored()
        {
            // Arrange
            Employee objSource = testObjects.GetEmployee();
            // reference types should be ignored, if not will throw error
            objSource.Department = testObjects.GetDepartment();
            objSource.Position = testObjects.GetPosition();
            EmployeeDtl objReturn = null;

            // Act
            objReturn = objSource.Convert<EmployeeDtl>();

            // Assert
            Assert.IsNotNull(objReturn);
            Assert.AreEqual(objSource.Id, objReturn.Id);
            Assert.AreEqual(objSource.LastName, objReturn.LastName);
            Assert.AreEqual(objSource.FirstName, objReturn.FirstName);
            Assert.AreEqual(objSource.BirthDate, objReturn.BirthDate);
            Assert.AreEqual(objSource.HiringDate, objReturn.HiringDate);
            Assert.AreEqual(objSource.Gender, objReturn.Gender);
            Assert.AreEqual(objSource.CivilStatus, objReturn.CivilStatus);
            Assert.AreEqual(objSource.DepartmentId, objReturn.DepartmentId);
            Assert.AreEqual(objSource.PositionId, objReturn.PositionId);            
        }

        [TestMethod]
        public void ConvertFromCoreModelToViewModelAsObjectArgument()
        {
            // Arrange
            Employee objSource = testObjects.GetEmployee();
            // return obj with different preset values
            EmployeeDtl objReturn = new EmployeeDtl()
            {
                Id = 9999,
                DepartmentId = 8888,
                PositionId = 7777,
                FirstName = "some other",
                LastName = "emp name",
                Gender = Gender.Female,
                CivilStatus = CivilStatus.Married,
                BirthDate = DateTime.MinValue,
                HiringDate = DateTime.MinValue
            };

            // Act
            objSource.Convert<EmployeeDtl>(objReturn);

            // Assert
            Assert.IsNotNull(objReturn);
            Assert.AreEqual(objSource.Id, objReturn.Id);
            Assert.AreEqual(objSource.LastName, objReturn.LastName);
            Assert.AreEqual(objSource.FirstName, objReturn.FirstName);
            Assert.AreEqual(objSource.BirthDate, objReturn.BirthDate);
            Assert.AreEqual(objSource.HiringDate, objReturn.HiringDate);
            Assert.AreEqual(objSource.Gender, objReturn.Gender);
            Assert.AreEqual(objSource.CivilStatus, objReturn.CivilStatus);
            Assert.AreEqual(objSource.DepartmentId, objReturn.DepartmentId);
            Assert.AreEqual(objSource.PositionId, objReturn.PositionId);
        }

        [TestMethod]
        public void ConvertFromViewModelToCoreModelAsObjectArgument()
        {
            // Arrange
            EmployeeDtl objSource = new EmployeeDtl()
            {
                Id = 1,
                DepartmentId = 2,
                PositionId = 3,
                FirstName = "Randolph",
                LastName = "Bangay",
                Gender = Gender.Male,
                CivilStatus = CivilStatus.Single,
                BirthDate = new DateTime(1990, 4, 6),
                HiringDate = DateTime.Now
            };
            // return obj with different preset values
            Employee objReturn = new Employee()
            {
                Id = 9999,
                DepartmentId = 8888,
                PositionId = 7777,
                FirstName = "some other",
                LastName = "emp name",
                Gender = Gender.Female,
                CivilStatus = CivilStatus.Married,
                BirthDate = DateTime.MinValue,
                HiringDate = DateTime.MinValue
            };

            // Act
            objSource.Convert<Employee>(objReturn);

            // Assert
            Assert.IsNotNull(objReturn);
            Assert.AreEqual(objSource.Id, objReturn.Id);
            Assert.AreEqual(objSource.LastName, objReturn.LastName);
            Assert.AreEqual(objSource.FirstName, objReturn.FirstName);
            Assert.AreEqual(objSource.BirthDate, objReturn.BirthDate);
            Assert.AreEqual(objSource.HiringDate, objReturn.HiringDate);
            Assert.AreEqual(objSource.Gender, objReturn.Gender);
            Assert.AreEqual(objSource.CivilStatus, objReturn.CivilStatus);
            Assert.AreEqual(objSource.DepartmentId, objReturn.DepartmentId);
            Assert.AreEqual(objSource.PositionId, objReturn.PositionId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertFromNonClassToModelThrowsException()
        {
            // Arrange
            int objSource = 0;
            EmployeeDtl objReturn = null;

            // Act
            objReturn = objSource.Convert<EmployeeDtl>();

            // throws excpetion because objSource is not a class
        }
    }
}
