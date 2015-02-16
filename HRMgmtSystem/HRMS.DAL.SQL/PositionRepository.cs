using HRMS.Core.Contracts;
using HRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL.SQL
{
    public class PositionRepository : SingleIdRepository<Position, int>, IPositionRepository
    {
        public PositionRepository() : base("Positions") { }

        public IEnumerable<IdValuePair<int>> GetIdValuePair()
        {
            var retVal = new List<IdValuePair<int>>();

            var positions = Get();
            if (positions != null)
            {
                foreach(var item in positions)
                {
                    retVal.Add(new IdValuePair<int>() 
                    { 
                        Id = item.Id, 
                        Value = item.Name + " - " + item.Type.ToString() 
                    });
                }
            }

            return retVal;
        }
    }
}
