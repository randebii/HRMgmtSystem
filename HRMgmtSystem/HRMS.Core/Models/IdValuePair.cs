using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Models
{
    public class IdValuePair<T> where T: struct
    {
        public T Id { get; set; }
        public string Value { get; set; }
    }
}
