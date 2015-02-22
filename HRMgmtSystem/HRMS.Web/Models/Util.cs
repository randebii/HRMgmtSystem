using HRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Web.Models
{
    public static class Util
    {
        public static IEnumerable<SelectListItem> GetSelectList<TEnum>(TEnum? selectedValue = null) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var type = typeof(TEnum);
            if (!type.IsEnum)
                throw new ArgumentException("T must be an Enum");

            List<SelectListItem> retVal = new List<SelectListItem>();
            foreach(var item in Enum.GetNames(typeof(TEnum)))
            {
                retVal.Add(new SelectListItem()
                {
                    Text = item,
                    Value = item,
                    Selected = (selectedValue.HasValue && selectedValue.Value.ToString() == item)
                });
            }
            return retVal;
        }

        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<IdValuePair<T>> collection, T selectedValue = default(T)) where T: struct
        {
            if (collection == null)
                throw new ArgumentException("Id value pair collection cannot be null");

            return collection
                .Select(a =>
                {
                    return new SelectListItem() 
                    { 
                        Text = a.Value,
                        Value = a.Id.ToString(),
                        Selected = selectedValue.Equals(a.Id)
                    };
                })
                .ToList();
        }
    }
}