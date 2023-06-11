﻿using System.ComponentModel;
using System.Reflection;

namespace Shared.Helpers;

public class Helper
{
    public static string GetEnumDescription(Enum value)
    {
        // Get the type of the enum
        Type type = value.GetType();

        // Get the field info for the enum value
        FieldInfo? fieldInfo = type.GetField(value.ToString());

        // Get the description attribute for the enum value
        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fieldInfo?.GetCustomAttributes(
                typeof(DescriptionAttribute), false)!;

        // Return the description if it exists, otherwise return the enum value
        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
}