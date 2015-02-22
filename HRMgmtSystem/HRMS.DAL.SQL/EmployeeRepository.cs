using HRMS.Core.Contracts;
using HRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace HRMS.DAL.SQL
{
    public class EmployeeRepository : SingleIdRepository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository() : base("Employees") { }

        public IEnumerable<Employee> GetForListItems()
        {
            var retVal = new List<Employee>();

            using (IDbConnection conn = GetOpenConnection())
            {
                string sql = @"SELECT 
                            a.Id,      
                            a.LastName,
                            a.FirstName,
                            a.MiddleName,
                            a.Extension,
                            a.ContactNumber,
                            b.Id,
                            b.Abbreviation,
                            c.Id,
                            c.Name,
                            c.Type
                        FROM Employees a
                        INNER JOIN Departments b on a.DepartmentId = b.Id
                        INNER JOIN Positions c on a.PositionId = c.Id";

                retVal = conn.Query<Employee, Department, Position, Employee>(sql, 
                    (e, d, p) => 
                    { 
                        e.Department = d; 
                        e.Position = p; 
                        return e; 
                    }).ToList();
            }
                

            return retVal;
        }


        public Employee GetForProfile(int id)
        {
            Employee retVal = null;

            using (IDbConnection conn = GetOpenConnection())
            {
                string sql = @"SELECT *
                        FROM Employees a
                        INNER JOIN Departments b on a.DepartmentId = b.Id
                        INNER JOIN Positions c on a.PositionId = c.Id
                        WHERE a.Id = @id";

                retVal = conn.Query<Employee, Department, Position, Employee>(sql,
                    (e, d, p) =>
                    {
                        e.Department = d;
                        e.Position = p;
                        return e;
                    }, new { id }).FirstOrDefault();
            }

            return retVal;
        }
    }
}
