using HRMS.Core.Enums;
using HRMS.Core.Models;
using HRMS.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.Models
{
    public class PositionDtl
    {
        public PositionDtl() { }
        public PositionDtl(Position pos)
        {
            if (pos != null)
            {
                pos.Convert<PositionDtl>(this);
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeType Type { get; set; }
        public int? MonthsBeforePromotion { get; set; }

        public Position ToModel()
        {
            return this.Convert<Position>();
        }
    }
}