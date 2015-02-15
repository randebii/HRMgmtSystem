using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using HRMS.Core.Contracts;
using HRMS.Core.Utility;
using HRMS.Core.Attributes;
using HRMS.Core.Enums;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace HRMS.DAL.SQL
{
    public abstract class Repository<T> : IRepository<T> where T: class, new()
    {
        private string connectionString = ConfigurationManager.AppSettings["SQLConnectionString"];

        #region Static
        static Repository()
        {
            T instance = new T();
            IdPropInfos = GetIdProperties(instance);
            SqlCreateFormat = GenerateSqlCreateFormat(instance);
            SqlUpdateFormat = GenerateSqlUpdateFormat(instance, IdPropInfos);
            SqlGetByIdFormat = GenerateSQLGetByIdFormat(IdPropInfos);
            SqlDeleteFormat = GenerateSQLDeleteFormat(IdPropInfos);
        }

        protected static string SqlCreateFormat { get; private set; }
        protected static string SqlUpdateFormat { get; private set; }
        protected static string SqlGetByIdFormat { get; private set; }
        protected static string SqlDeleteFormat { get; private set; }
        protected static IEnumerable<PropertyInfo> IdPropInfos { get; private set; }

        private static string GenerateSqlCreateFormat(T instance)
        {
            string retVal = null;
            
            var propertyInfos = GetAllPropertiesForCreate(instance);

            var sb = new StringBuilder();
            sb.Append("INSERT INTO [{0}] (");
            sb.Append(string.Join(", ", propertyInfos.Select(a => "[" + a.Name + "]")));
            sb.Append(") VALUES (");
            sb.Append(string.Join(", ", propertyInfos.Select(a => "@" + a.Name)));
            sb.Append(")");
            retVal = sb.ToString();

            return retVal;
        }

        private static string GenerateSqlUpdateFormat(T instance, IEnumerable<PropertyInfo> idProps)
        {
            string retVal = null;

            var propertyInfos = GetAllPropertiesForUpdate(instance);

            var sb = new StringBuilder();
            sb.Append("UPDATE [{0}] SET ");
            sb.Append(string.Join(", ", propertyInfos.Select(a => "[" + a.Name + "] = @" + a.Name)));
            sb.Append(" " + GenerateSQLWhereClauseForId(idProps));
            retVal = sb.ToString();

            return retVal;
        }

        private static string GenerateSQLGetByIdFormat(IEnumerable<PropertyInfo> idProps)
        {
            string retVal = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [{0}] ");
            sb.Append(GenerateSQLWhereClauseForId(idProps));
            retVal = sb.ToString();

            return retVal;
        }

        private static string GenerateSQLDeleteFormat(IEnumerable<PropertyInfo> idProps)
        {
            string retVal = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM [{0}] ");
            sb.Append(GenerateSQLWhereClauseForId(idProps));
            retVal = sb.ToString();

            return retVal;
        }

        private static string GenerateSQLWhereClauseForId(IEnumerable<PropertyInfo> propInfos)
        {
            string retVal = string.Empty;

            if (propInfos != null && propInfos.Count() > 0)
            {
                var sb = new StringBuilder();
                sb.Append("WHERE ");
                int cnt = 0;
                int total = propInfos.Count();
                foreach (var item in propInfos)
                {
                    sb.Append("[" + item.Name + "] = @" + item.Name);

                    cnt++;
                    if (cnt < total)
                    {
                        sb.Append(" AND ");
                    }
                }

                retVal = sb.ToString();
            }

            return retVal;
        }
        
        private static IEnumerable<PropertyInfo> GetAllPropertiesForCreate(T obj)
        {
            var retVal = new List<PropertyInfo>();

            if (obj != null)
            {
                Type type = obj.GetType();
                PropertyInfo[] props = type.GetProperties();

                if (props != null)
                {
                    foreach (var prop in props)
                    {
                        var attributes = prop.GetCustomAttributes();

                        bool ignore = false;
                        foreach (var item in attributes)
                        {
                            if (item is DbIgnoreAttribute)
                            {
                                ignore = true;
                                break;
                            }

                            if (item is IdAttribute)
                            {
                                IdAttribute idAttr = item as IdAttribute;
                                if (idAttr.Type == IdType.DatabaseGenerated)
                                {
                                    ignore = true;
                                    break;
                                }
                            }
                        }

                        if (!ignore)
                        {
                            retVal.Add(prop);
                        }
                    }
                }
            }

            return retVal;
        }

        private static IEnumerable<PropertyInfo> GetAllPropertiesForUpdate(T obj)
        {
            var retVal = new List<PropertyInfo>();

            if (obj != null)
            {
                Type type = obj.GetType();
                PropertyInfo[] props = type.GetProperties();

                if (props != null)
                {
                    foreach (var prop in props)
                    {
                        var attributes = prop.GetCustomAttributes();

                        bool ignore = false;
                        foreach (var item in attributes)
                        {
                            if (item is DbIgnoreAttribute)
                            {
                                ignore = true;
                                break;
                            }

                            if (item is IdAttribute)
                            {
                                ignore = true;
                                break;
                            }
                        }

                        if (!ignore)
                        {
                            retVal.Add(prop);
                        }
                    }
                }
            }

            return retVal;
        }

        private static IEnumerable<PropertyInfo> GetIdProperties(T obj)
        {
            var retVal = new List<PropertyInfo>();

            if (obj != null)
            {
                Type type = obj.GetType();
                PropertyInfo[] props = type.GetProperties();

                if (props != null)
                {
                    var dict = new Dictionary<PropertyInfo, int>();
                    foreach (var prop in props)
                    {
                        var attributes = prop.GetCustomAttributes();

                        foreach (var item in attributes)
                        {
                            if (item is IdAttribute)
                            {
                                IdAttribute idAttr = item as IdAttribute;
                                dict.Add(prop, idAttr.Order);
                                break;
                            }
                        }
                    }

                    retVal = dict.OrderBy(a => a.Value).Select(a => a.Key).ToList();
                }
            }

            return retVal;
        }
        #endregion
        
        public Repository(string table)
        {
            Table = table;
        }
        
        public string Table { get; private set; }

        protected virtual IDbConnection GetOpenConnection()
        {
            var retVal = new SqlConnection(connectionString);
            retVal.Open();
            return retVal;
        }

        public virtual IEnumerable<T> Get()
        {
            IEnumerable<T> retVal = null;

            using (IDbConnection conn = GetOpenConnection())
            {
                string sql = string.Format("SELECT * FROM [{0}]", Table);
                retVal = conn.Query<T>(sql);
            }

            return retVal;
        }

        public virtual T Create(T model)
        {
             if (model != null)
             {
                 using (IDbConnection conn = GetOpenConnection())
                 {
                     string sql = string.Format(SqlCreateFormat, Table);
                     conn.Execute(sql, model);
                 }
             }

             return model;
        }

        public virtual void Update(T model)
        {
            if (model != null)
            {
                using (IDbConnection conn = GetOpenConnection())
                {
                    string sql = string.Format(SqlUpdateFormat, Table);
                    conn.Execute(sql, model);
                }
            }
        }
    }
}
