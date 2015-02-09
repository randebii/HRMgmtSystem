using HRMS.Core.Attributes;
using HRMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Utility
{
    public static class Util
    {
        public static IEnumerable<PropertyInfo> GetIdProperties<T>(T obj) where T : class
        {
            var retVal = new List<PropertyInfo>();

            if (obj != null)
            {
                Type type = obj.GetType();
                PropertyInfo[] props = type.GetProperties();
                
                if (props != null)
                {
                    var dict = new Dictionary<PropertyInfo, int>();
                    foreach(var prop in props)
                    {
                        var attributes = prop.GetCustomAttributes();

                        foreach(var item in attributes)
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
        public static IEnumerable<PropertyInfo> GetAllPropertiesForCreate<T>(T obj) where T : class
        {
            var retVal = new List<PropertyInfo>();

            if (obj != null)
            {
                Type type = obj.GetType();
                PropertyInfo[] props = type.GetProperties();

                if (props != null)
                {
                    foreach(var prop in props)
                    {
                        var attributes = prop.GetCustomAttributes();

                        bool ignore = false;
                        foreach(var item in attributes)
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

        public static IEnumerable<PropertyInfo> GetAllPropertiesForUpdate<T>(T obj) where T : class
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

        public static string GenerateSQLWhereClause(IEnumerable<PropertyInfo> propInfos)
        {
            string retVal = string.Empty;

            if (propInfos != null)
            {
                string logicalExpressions = string.Empty;
                foreach (var item in propInfos)
                {
                    if (item.PropertyType == typeof(string))
                    {

                    }
                }
            }

            return retVal;
        }
    }
}
