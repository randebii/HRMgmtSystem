using HRMS.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HRMS.Core.Utility;

namespace HRMS.DAL.SQL
{
    public abstract class Repository<T> : IRepository<T> where T: class, new()
    {        
        private static string sqlCreateFormat;        
        private static string SQLCreateFormat
        {
            get
            {
                if (string.IsNullOrEmpty(sqlCreateFormat))
                {
                    T instance = new T();
                    var propertyInfos = Util.GetAllPropertiesForCreate(instance);
                    var sb = new StringBuilder();
                    sb.Append("INSERT INTO {0} (");
                    sb.Append(string.Join(", ", propertyInfos.Select(a => a.Name)));
                    sb.Append(") VALUES (");
                    sb.Append(string.Join(", ", propertyInfos.Select(a => "@" + a.Name)));
                    sb.Append(")");
                    sqlCreateFormat = sb.ToString();
                }

                return sqlCreateFormat;
            }
        }

        private static string sqlUpdateFormat;
        protected static string SQLUpdateFormat
        {
            get
            {
                if (string.IsNullOrEmpty(sqlUpdateFormat))
                {
                    T instance = new T();
                    var idPropInfos = Util.GetIdProperties(instance);
                    var propertyInfos = Util.GetAllPropertiesForUpdate(instance);
                    sqlUpdateFormat = string.Join(", ", propertyInfos.Select(a => a.Name + " = @" + a.Name));
                }

                return sqlUpdateFormat;
            }
        }

        
        public Repository(string table)
        {
            Table = table;
        }
        
        protected string Table { get; private set; }

        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        public T Create(T model)
        {
            throw new NotImplementedException();
        }

        public void Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
