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
        public static int AsInt<TEnum>(this TEnum enumVal) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return Convert.ToInt32(enumVal);
        }

        public static IEnumerable<SelectListItem> GetSelectList<TEnum>(int selectedValue = 0) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var type = typeof(TEnum);
            if (!type.IsEnum)
                throw new ArgumentException("T must be an Enum");
                        
            return Enum.GetValues(type)
                .Cast<int>()
                .Select(a => 
                {                     
                    return new SelectListItem() 
                    { 
                        Text = Enum.GetName(type, a), 
                        Value = a.ToString(), 
                        Selected = a == selectedValue
                    }; 
                })
                .ToList();
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