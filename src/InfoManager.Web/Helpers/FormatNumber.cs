namespace InfoManager.Web.Helpers;

public static class FormatNumber
{
    public static string FormatDecimal(decimal? value)
        => value.HasValue ? value.Value.ToString("0.##") : "-";
}
