using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Collections.Generic;
using Airport.ViewModels;
using Airport.Models.Customer;

namespace Airport.Handlers
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
        public static T GetEnumObjectByValue<T>(int valueId)
        {
            return (T)Enum.ToObject(typeof(T), valueId);
        }

        public static List<EnumList> GetEnumList(string enumName)
        {
            var result = new List<EnumList>();
            switch (enumName)
            {
                case "Age":
                    foreach (var item in Enum.GetValues(typeof(Age)))
                    {
                        result.Add(new EnumList
                        {
                            Value = Convert.ToInt32(item),
                            Name = EnumExtensions.GetDisplayName((Age)item)
                        });
                    }
                    break;
                case "Gender":
                    foreach (var item in Enum.GetValues(typeof(Gender)))
                    {
                        result.Add(new EnumList
                        {
                            Value = Convert.ToInt32(item),
                            Name = EnumExtensions.GetDisplayName((Gender)item)
                        });
                    }
                    break;
                case "Document":
                    foreach (var item in Enum.GetValues(typeof(DocumentType)))
                    {
                        result.Add(new EnumList
                        {
                            Value = Convert.ToInt32(item),
                            Name = EnumExtensions.GetDisplayName((DocumentType)item)
                        });
                    }
                    break;
            }

            return result;
        }
    }
}
