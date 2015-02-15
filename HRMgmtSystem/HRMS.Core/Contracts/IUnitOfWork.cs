using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Contracts
{
    public interface IUnitOfWork
    {
        IDailyTimeRecordRepository DailyTimeRecord { get; }
        IDepartmentRepository Department { get; }
        IEducationalBackgroundRepository EducationalBackground { get; }
        IEmployeeLeaveRepository EmployeeLeave { get; }
        IEmployeeRepository Employee { get; }
        IEmploymentHistoryRepository EmploymentHistory { get; }
        IGlobalRuleRepository GlobalRule { get; }
        ILeaveEntitledRepository LeaveEntitled { get; }
        ILeaveRepository Leave { get; }
        IPositionRepository Position { get; }
        ISchoolYearRepository SchoolYear { get; }
        IUserRepository User { get; }
    }
}
