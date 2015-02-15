using HRMS.Core.Contracts;
using HRMS.DAL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Framework
{
    public class App
    {
        public virtual void Init()
        {
            TinyIoC.TinyIoCContainer ioc = TinyIoC.TinyIoCContainer.Current;
            ioc.Register<IDailyTimeRecordRepository, DailyTimeRecordRepository>().AsMultiInstance();
            ioc.Register<IDepartmentRepository, DepartmentRepository>().AsMultiInstance();
            ioc.Register<IEducationalBackgroundRepository, EducationalBackgroundRepository>().AsMultiInstance();
            ioc.Register<IEmployeeLeaveRepository, EmployeeLeaveRepository>().AsMultiInstance();
            ioc.Register<IEmployeeRepository, EmployeeRepository>().AsMultiInstance();
            ioc.Register<IEmploymentHistoryRepository, EmploymentHistoryRepository>().AsMultiInstance();
            ioc.Register<IGlobalRuleRepository, GlobalRuleRepository>().AsMultiInstance();
            ioc.Register<ILeaveEntitledRepository, LeaveEntitledRepository>().AsMultiInstance();
            ioc.Register<ILeaveRepository, LeaveRepository>().AsMultiInstance();
            ioc.Register<IPositionRepository, PositionRepository>().AsMultiInstance();
            ioc.Register<ISchoolYearRepository, SchoolYearRepository>().AsMultiInstance();
            ioc.Register<IUserRepository, UserRepository>().AsMultiInstance();
        }
    }
}
