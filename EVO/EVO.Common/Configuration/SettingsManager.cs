using Microsoft.Extensions.Configuration;

namespace EVO.Common.Configuration;

public static class SettingsManger
{
    private static readonly string EVO_DB_COON = "EVO_DB_COON";

    public static string? GetDatabaseConnectionString()
    {
        return !String.IsNullOrEmpty(Environment.GetEnvironmentVariable(EVO_DB_COON)) ? Environment.GetEnvironmentVariable(EVO_DB_COON) : String.Empty;
    }

}
