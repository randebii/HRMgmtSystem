using HRMS.Core.Enums;
using HRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.UnitTests
{
    public class TestObjectFactory
    {
        public Position GetPosition()
        {
            return new Position()
            {
                Name = "Developer",
                Type = EmployeeType.Regular,
                MonthsBeforePromotion = 12
            };
        }
        public Department GetDepartment()
        {
            return new Department()
            {
                Name = "College of Test",
                Abbreviation = "CT"
            };
        }

        public Employee GetEmployee(bool allProps = false)
        {
            var retVal = new Employee()
            {
                DepartmentId = 1,
                PositionId = 1,
                FirstName = "Randolph",
                LastName = "Bangay",
                BirthDate = new DateTime(1990, 4, 6),
                Gender = Gender.Male,
                CivilStatus = CivilStatus.Single,
                HiringDate = DateTime.Now
            };

            if (allProps)
            {

            }

            return retVal;
        }
    }
}
