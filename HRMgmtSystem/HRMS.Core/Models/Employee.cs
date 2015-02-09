using HRMS.Core.Attributes;
using HRMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Models
{
    public class Employee
    {
        [Id(IdType.DatabaseGenerated)]
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Extension { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public CivilStatus CivilStatus { get; set; }
        public string Religion { get; set; }
        public BloodType BloodType { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string ContactNumber { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonNumber { get; set; }
        public string ContactPersonAddress { get; set; }
        public string SSS { get; set; }
        public string TIN { get; set; }
        public string Pagibig { get; set; }
        public string PhilHealth { get; set; }
        public string PRCLicenseNumber { get; set; }
        public string EmployeeIdNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime? RegularizationDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? BasicPay { get; set; }
        public bool TOR { get; set; }
        public bool Resume { get; set; }
        public bool GoodMoralCert { get; set; }
        public bool Diploma { get; set; }
        public bool BirthCert { get; set; }
        public bool MarriageCert { get; set; }
        public bool BaptismalCert { get; set; }
        public bool PoliceClearance { get; set; }
        public bool NBIClearance { get; set; }
        public bool BrgyClearance { get; set; }
        public bool LicensureCert { get; set; }
        public bool QualifiedDependents { get; set; }
        public bool BirthCertDependents { get; set; }
        public bool Urinalysis { get; set; }
        public bool DentalExam { get; set; }
        public bool ChestXRay { get; set; }
        public bool CBC { get; set; }
        public bool Fecalysis { get; set; }
        
        public Department Department { get; set; }
        public Position Position { get; set; }
        public IList<EmploymentHistory> EmploymentHistory { get; set; }
        public IList<EducationalBackground> EducationalBackground { get; set; }
        public IEnumerable<EmployeeLeave> LeavesTaken { get; set; }
    }
}
