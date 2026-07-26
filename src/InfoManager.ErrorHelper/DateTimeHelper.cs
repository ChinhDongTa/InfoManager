namespace InfoManager.Helper;

public static class DateTimeHelper
{
    public static DateOnly ToDateOnly(this DateTime dateTime)
    {
        return new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
    }

    public static DateOnly? ToDateOnly(this DateTime? dateTime)
    {
        return dateTime.HasValue ? dateTime.Value.ToDateOnly() : null;
    }

    public static DateTime ToDateTime(this DateOnly dateOnly)
    {
        return new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);
    }

    public static DateTime? ToDateTime(this DateOnly? dateOnly)
    {
        return dateOnly.HasValue ? dateOnly.Value.ToDateTime() : null;
    }

    // Chuyển DateTime? sang DateTimeOffset? giữ nguyên giờ
    public static DateTimeOffset? ToUtcOffset(this DateTime? dateTime)
        => !dateTime.HasValue ? null : ToUtcOffset(dateTime.Value);

    // Chuyển DateTime sang DateTimeOffset giữ nguyên giờ
    public static DateTimeOffset ToUtcOffset(this DateTime dt)
    {
        if (dt.Kind == DateTimeKind.Utc)
            return new DateTimeOffset(dt); // 05:11Z -> 05:11+00
                                           // treat Unspecified as Local
        if (dt.Kind == DateTimeKind.Unspecified)
            dt = DateTime.SpecifyKind(dt, DateTimeKind.Local);

        var offset = TimeZoneInfo.Local.GetUtcOffset(dt);
        return new DateTimeOffset(dt, offset); // e.g. 05:11+07
    }

    public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.LocalDateTime;
    }
    public static DateTime? ToLocalDateTime(this DateTimeOffset? dateTimeOffset)
    {
        return dateTimeOffset?.LocalDateTime;
    }
}