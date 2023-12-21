using System.Reflection;
using System.ComponentModel;

namespace EVO.Common.Helpers;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {

        if (value is null)
            return string.Empty;

        var type = value.GetType();

        var field = type.GetField(value.ToString());

        if (field is null)
            return string.Empty;

        var attribute = field.GetCustomAttribute<DescriptionAttribute>(false);

        return attribute != null ? attribute.Description : string.Empty;
    }
}

