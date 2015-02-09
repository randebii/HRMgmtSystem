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

-- TODO add returnee in Employee
-- TODO change dependents on Employee to list (Name, Relationship)
-- TODO update C# models to new changes

create table Users
(
	Id int not null identity,
	Username nvarchar(30) not null,
	[Password] nvarchar(50) not null,
	[Role] int not null,

	constraint PK_Users primary key (Id),
	constraint UQ_Users_Username unique (Username)
)
go

create table GlobalRules
(
	Id int not null,
	Name nvarchar (100),
	Value int not null,
		
	constraint PK_GlobalRules primary key (Id),
	constraint UQ_GlobalRules unique (Name)
)
go

create table SchoolYears
(
	Id nvarchar(9) not null,
	StartDate date not null,
	EndDate date null,

	constraint PK_SchoolYears primary key (Id)
)
go

create table Departments
(
	Id int not null identity,
	Name nvarchar(300) not null,
	Abbreviation nvarchar(10) null,

	constraint PK_Departments primary key (Id),
	constraint UQ_Departments_Name unique (Name)
)
go

create table Positions
(
	Id int not null identity,
	Name nvarchar(100) not null,
	[Type] int not null, -- enum [Regular, Probationary, PartTime]
	MonthsBeforePromotion int null, -- for Probationary

	constraint PK_Positions primary key (Id),
	constraint UQ_Positions_Name unique (Name)
)
go

create table Leaves
(
	Id int not null identity,
	Name nvarchar(100) not null

	constraint PK_Leaves primary key (Id)
)
go

create table LeavesEntitled
(
	PositionId int not null,
	LeaveId int not null,
	DaysEntitled int not null,

	constraint PK_LeavesEntitled primary key (PositionId, LeaveId),
	constraint FK_LeavesEntitled_PositionId foreign key (PositionId) references Positions(Id),
	constraint FK_LeavedEntitled_LeaveId foreign key (LeaveId) references Leaves(Id)
)
go

create table Employees
(
	-- basic info
	Id int not null identity,
	DepartmentId int not null,
	PositionId int not null,
	LastName nvarchar(50) not null,
	FirstName nvarchar(100) not null,
	MiddleName nvarchar(50) null,
	Extension nvarchar(5) null,
	BirthDate date not null,
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
	HiringDate date not null,
	RegularizationDate date null, -- optional, more specific date than computing HiringDate + 3 years
	EndDate date null,	
	BasicPay decimal (10, 2) null,

	-- hiring requirements
	TOR bit not null default 0, -- ?
	[Resume] bit not null default 0, -- ?
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
	constraint FK_Employees_DepartmentId foreign key (DepartmentId) references Departments(Id),
	constraint FK_Employees_PositionId foreign key (PositionId) references Positions(Id)
)
go

create table EducationalBackgrounds
(
	Id int not null identity,
	EmployeeId int not null,
	DateSubmitted date null, -- for updates to TOR
	[Type] int not null, -- enum
	Name nvarchar(300) not null,
	Degree nvarchar(200) null,
	[Address] nvarchar(500) null,
	YearAttended nvarchar(20) null,
	ContactNumber nvarchar(30) null,

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

create table EmployeeLeaves
(
	Id int not null identity,
	EmployeeId int not null,
	LeaveId int not null,
	DateFrom date not null,
	DateTo date not null,
	EquivalentDays int not null,
	Remarks nvarchar(300) null,

	constraint PK_EmployeeLeaves primary key (Id),
	constraint FK_EmployeeLeaves_EmployeeId foreign key (EmployeeId) references Employees(Id),
	constraint FK_EmployeeLeaves_LeaveId foreign key (LeaveId) references Leaves(Id)
)
go

create table DailyTimeRecords
(
	EmployeeId int not null,
	[Date] date not null,
	AMIn time null,
	AMOut time null,
	PMIn time null,
	PMOut time null,
	AbsentType int null,

	constraint PK_DailyTimeRecords primary key (EmployeeId, [Date]),
	constraint FK_DailyTimeRecords_EmployeeId foreign key (EmployeeId) references Employees(Id)
)
go