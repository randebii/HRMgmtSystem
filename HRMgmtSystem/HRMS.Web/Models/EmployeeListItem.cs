using HRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.Models
{
    public class EmployeeListItem
    {
        public EmployeeListItem() { }
        public EmployeeListItem(Employee emp)
        {
            if (emp != null)
            {
                Id = emp.Id;

                string name = string.Format("{0}, {1}", emp.LastName, emp.FirstName);
                if (!string.IsNullOrWhiteSpace(emp.Extension))
                {
                    name += " " + emp.Extension;
                }
                if (!string.IsNullOrWhiteSpace(emp.MiddleName))
                {
                    name += " " + emp.MiddleName[0].ToString() + ".";
                }
                Name = name;

                if (emp.Department != null)
                {
                    Department = emp.Department.Abbreviation;
                }

                if (emp.Position != null)
                {
                    Position = emp.Position.Name + " - " + emp.Position.Type.ToString();
                }

                ContactNumber = emp.ContactNumber ?? "None";
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string ContactNumber { get; set; }
    }
}