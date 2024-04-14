using System;
using System.Collections.Generic;

public static class ValidationHelper
{
    public static bool IsValidName(this string name)
    {
        return !string.IsNullOrWhiteSpace(name) && char.IsUpper(name[0]) && name.Split(' ').Length == 1 && name.Length >= 3;
    }

    public static bool IsValidClassName(this string className)
    {
        return className.Length == 5 && char.IsUpper(className[0]) && char.IsUpper(className[1]) &&
               char.IsDigit(className[2]) && char.IsDigit(className[3]) && char.IsDigit(className[4]);
    }
}