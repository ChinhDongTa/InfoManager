using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfoManager.Infrastructure.Data.Converters;

/// <summary>
/// EF Core value converter that ensures all DateTimeOffset values are converted to UTC
/// before being sent to the database. This is necessary for PostgreSQL compatibility,
/// as PostgreSQL's 'timestamp with time zone' only accepts UTC offset (offset 0).
/// </summary>
public class DateTimeOffsetUtcConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    public DateTimeOffsetUtcConverter() : base(
        // Convert to UTC when writing to database
        v => v.ToUniversalTime(),
        // Keep as UTC when reading from database
        v => v,
        new ConverterMappingHints(size: 35)) // PostgreSQL timestamp size
    {
    }
}

/// <summary>
/// EF Core value converter for nullable DateTimeOffset values.
/// Ensures all DateTimeOffset values are converted to UTC before being sent to the database.
/// </summary>
public class NullableDateTimeOffsetUtcConverter : ValueConverter<DateTimeOffset?, DateTimeOffset?>
{
    public NullableDateTimeOffsetUtcConverter() : base(
        // Convert to UTC when writing to database, handle null
        v => v.HasValue ? v.Value.ToUniversalTime() : null,
        // Keep as UTC when reading from database, handle null
        v => v,
        new ConverterMappingHints(size: 35)) // PostgreSQL timestamp size
    {
    }
}
