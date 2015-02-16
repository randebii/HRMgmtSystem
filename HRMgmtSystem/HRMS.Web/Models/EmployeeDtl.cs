﻿using HRMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.Web.Models
{
    public class EmployeeDtl
    {
        public int Id { get; set; }
        [Required, Display(Name = "*Department")]
        public int DepartmentId { get; set; }
        [Required, Display(Name = "*Position")]
        public int PositionId { get; set; }
        [Required, Display(Name = "*Last name")]
        public string LastName { get; set; }
        [Required, Display(Name = "*First name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }
        [Display(Name = "Extension (Jr, Sr, II, etc.)")]
        public string Extension { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "*Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required, Display(Name = "*Gender")]
        public Gender Gender { get; set; }
        [Required, Display(Name = "*Civil Status")]
        public CivilStatus CivilStatus { get; set; }
        public string Religion { get; set; }
        [Display(Name = "Blood Type")]
        public BloodType? BloodType { get; set; }
        [Display(Name = "Current Address")]
        public string CurrentAddress { get; set; }
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [Display(Name = "Name")]
        public string ContactPerson { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactPersonNumber { get; set; }
        [Display(Name = "Address")]
        public string ContactPersonAddress { get; set; }
        public string SSS { get; set; }
        public string TIN { get; set; }
        public string Pagibig { get; set; }
        public string PhilHealth { get; set; }
        [Display(Name = "PRC License")]
        public string PRCLicenseNumber { get; set; }
        [Display(Name = "SPUD Employee ID")]
        public string EmployeeIdNumber { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "*Hired On")]
        public DateTime HiringDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Regularized On")]
        public DateTime? RegularizationDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Tenure Ended On")]
        public DateTime? EndDate { get; set; }
        [DataType(DataType.Currency), Display(Name = "Basic Pay")]
        public decimal? BasicPay { get; set; }
        [Display(Name = "Transcript Of Records")]
        public bool TOR { get; set; }
        [Display(Name = "Resuḿe")]
        public bool Resume { get; set; }
        [Display(Name = "Good Moral Cert.")]
        public bool GoodMoralCert { get; set; }
        public bool Diploma { get; set; }
        [Display(Name = "Birth Cert.")]
        public bool BirthCert { get; set; }
        [Display(Name = "Marriage Cert. (if applicable)")]
        public bool MarriageCert { get; set; }
        [Display(Name = "Baptismal Cert.")]
        public bool BaptismalCert { get; set; }
        [Display(Name = "Police Clearance")]
        public bool PoliceClearance { get; set; }
        [Display(Name = "NBI Clearance")]
        public bool NBIClearance { get; set; }
        [Display(Name = "Brgy Clearance")]
        public bool BrgyClearance { get; set; }
        [Display(Name = "Licensure Cert (if applicable)")]
        public bool LicensureCert { get; set; }
        public bool QualifiedDependents { get; set; }
        public bool BirthCertDependents { get; set; }
        public bool Urinalysis { get; set; }
        [Display(Name = "Dental Exam")]
        public bool DentalExam { get; set; }
        [Display(Name = "Chest X-ray")]
        public bool ChestXRay { get; set; }
        public bool CBC { get; set; }
        public bool Fecalysis { get; set; }
    }
}