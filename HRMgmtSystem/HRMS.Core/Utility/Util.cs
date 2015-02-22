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
        public static TReturn Convert<TReturn>(this object src, TReturn ret = null) where TReturn : class, new()
        {
            TReturn retVal = null;

            if (src != null)
            {
                Type tSrc = src.GetType();
                if (!tSrc.IsClass)
                {
                    throw new ArgumentException("Source object to convert must be a class");
                }

                retVal = ret ?? new TReturn();
                Type tRet = retVal.GetType();
                PropertyInfo[] tRetProps = tRet.GetProperties();
                PropertyInfo[] tSrcProps = tSrc.GetProperties();

                foreach (var propRet in tRetProps.Where(a => a.CanWrite))
                {
                    var propSrc = tSrcProps.FirstOrDefault(a => a.Name == propRet.Name && a.PropertyType == propRet.PropertyType);
                    if (propSrc != null)
                    {
                        propRet.SetValue(retVal, propSrc.GetValue(src));
                    }
                }
            }

            return retVal;
        }
    }
}
