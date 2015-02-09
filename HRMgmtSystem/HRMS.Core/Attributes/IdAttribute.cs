using HRMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IdAttribute : Attribute
    {
        public IdAttribute(IdType type)
        {
            Type = type;
        }

        public IdAttribute(IdType type, int order)
            : this(type)
        {
            Order = order;
        }

        public IdType Type { get; private set; }
        public int Order { get; private set; }
    }
}
