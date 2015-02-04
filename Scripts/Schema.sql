if exists(select * from sys.databases where name = 'HRMgmtSystem')
begin
	use master
	drop database HRMgmtSystem
end
go


create database HRMgmtSystem
go

use HRMgmtSystem
go

create table Departments
(
	Id int not null identity,
	Name nvarchar(300) not null,

	constraint PK_Departments primary key (Id)
)
go

create table Employees
(
	-- basic info
	Id int not null identity,
	DepartmentId int not null,
	LastName nvarchar(50) not null,
	FirstName nvarchar(100) not null,
	MiddleName nvarchar(50) null,
	Extension nvarchar(5) null,
	BirthDate datetime not null,
	Gender int not null, -- enum
	CivilStatus int not null, -- enum
	Religion nvarchar(100),
	BloodType int null, -- enum
	CurrentAddress nvarchar(500) null,
	PermanentAddress nvarchar(500) null,
	ContactNumber nvarchar(30) null,
	ContactPerson nvarchar(200) null,
	ContactPersonNumber nvarchar(30) null,
	ContactPersonAddress nvarchar(500) null,
	SSS nvarchar(50) null,
	TIN nvarchar(50) null,
	Pagibig nvarchar(50) null,
	PhilHealth nvarchar(50) null,
	PRCLicenseNumber nvarchar(50) null,
	EmployeeIdNumber nvarchar(20) null,

	-- employement history
	HiringDate datetime not null,
	RegularizationDate datetime null, -- optional, more specific date than computing HiringDate + 3 years
	EndDate datetime null,
	Position nvarchar(100) not null,
	EmploymentType int not null, -- enum [Regular, Probationary, PartTime]
	BasicPay decimal (10, 2) null,

	-- hiring requirements
	UpdatedTOR bit not null default 0, -- ?
	UpdatedResume bit not null default 0, -- ?
	GoodMoralCert bit not null default 0,
	Diploma bit not null default 0,
	BirthCert bit not null default 0,
	MarriageCert bit not null default 0,
	BaptismalCert bit not null default 0,
	PoliceClearance bit not null default 0,
	NBIClearance bit not null default 0,
	BrgyClearance bit not null default 0,
	LicensureCert bit not null default 0,
	QualifiedDependents bit not null default 0, -- ?
	BirthCertDependents bit not null default 0, -- ?

	-- medical exam req
	Urinalysis bit not null default 0,
	DentalExam bit not null default 0,
	ChestXRay bit not null default 0,
	CBC bit not null default 0,
	Fecalysis bit not null default 0

	constraint PK_Employees primary key (Id),
	constraint FK_Employees_DepartmentId foreign key (DepartmentId) references Departments(Id)
)
go

create table EducationalBackgrounds
(
	Id int not null identity,
	EmployeeId int not null,
	[Type] int not null, -- enum
	Name nvarchar(300) not null,
	[Address] nvarchar(500) null,
	YearAttended nvarchar(20) null,
	ContactNumber nvarchar(30) null

	constraint PK_EducationalBackgrounds primary key (Id),
	constraint FK_EducationalBackgrounds_EmployeeId foreign key (EmployeeId) references Employees(Id)
)
go

create table EmploymentHistory
(
	Id int not null identity,
	EmployeeId int not null,
	Employer nvarchar(300) not null,
	[Address] nvarchar(500) null,
	Position nvarchar(100) null,
	YearsOfService decimal(3, 1) not null

	constraint PK_EmploymentHistory primary key (Id),
	constraint FK_EmploymentHistory_EmployeeId foreign key (EmployeeId) references Employees(Id)
)
go

create table Leaves
(
	Id int not null identity,
	Name nvarchar(100) not null,
	[Days] int not null,

	constraint PK_Leaves primary key (Id)
)
go

create table LeavesTaken
(
	Id int not null identity,
	EmployeeId int not null,
	LeaveId int not null,
	DateFrom date not null,
	DateTo date not null,
	EquivalentDays int not null,
	Remarks nvarchar(300) null,

	constraint PK_LeavesTaken primary key (Id),
	constraint FK_LeavesTaken_EmployeeId foreign key (EmployeeId) references Employees(Id),
	constraint FK_LeavesTaken_LeaveId foreign key (LeaveId) references Leaves(Id)
)
go

create table DailyTimeRecords
(
	EmployeeId int not null,
	[Date] date not null,
	AMIn time not null,
	AMOut time not null,
	PMIn time not null,
	PMOut time not null,
	Late time null,
	IsAbsent bit not null default 0,

	constraint PK_DailyTimeRecords primary key (EmployeeId, [Date]),
	constraint FK_DailyTimeRecords_EmployeeId foreign key (EmployeeId) references Employees(Id)
)
go