using Dapper;
using HRMS.Core.Contracts;
using HRMS.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using HRMS.Core.Attributes;
using HRMS.Core.Enums;

namespace HRMS.DAL.SQL
{
    public abstract class SingleIdRepository<T, Tid> : Repository<T>, ISingleIdRepository<T, Tid> where T: class, new()
    {
        #region Static
        private static bool idIsDbGenerated = false;

        static SingleIdRepository()
        {
            PropertyInfo idProp = IdPropInfos.ElementAt(0);
            foreach(var item in idProp.GetCustomAttributes())
            {
                if (item is IdAttribute)
                {
                    var attr = item as IdAttribute;
                    idIsDbGenerated = attr.Type == IdType.DatabaseGenerated;
                    break;
                }
            }
        }
        #endregion

        public SingleIdRepository(string table) : base(table) { }

        public override T Create(T model)
        {            
            if (idIsDbGenerated)
            {
                if (model != null)
                {
                    using (IDbConnection conn = GetOpenConnection())
                    {
                        string sql = string.Format(SqlCreateFormat, Table);
                        sql += " SELECT SCOPE_IDENTITY()";
                        int id = conn.Query<int>(sql, model).First();
                        IdPropInfos.ElementAt(0).SetValue(model, id); 
                    }
                }
            }
            else
            {
                base.Create(model);
            }

            return model;
        }

        public T GetById(Tid id)
        {
            T retVal = null;

            using (IDbConnection conn = GetOpenConnection())
            {
                string sql = string.Format(SqlGetByIdFormat, Table);
                var param = new DynamicParameters();
                param.Add(IdPropInfos.ElementAt(0).Name, id);
                retVal = conn.Query<T>(sql, param).FirstOrDefault();
            }

            return retVal;
        }

        public void Delete(Tid id)
        {
            using (IDbConnection conn = GetOpenConnection())
            {
                string sql = string.Format(SqlDeleteFormat, Table);
                var param = new DynamicParameters();
                param.Add(IdPropInfos.ElementAt(0).Name, id);
                conn.Execute(sql, param);
            }
        }
    }
}
