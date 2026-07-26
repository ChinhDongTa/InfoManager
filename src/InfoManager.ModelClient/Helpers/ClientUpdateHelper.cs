namespace InfoManager.ModelClient.Helpers;

using KellermanSoftware.CompareNetObjects;

public static class ClientUpdateHelper
{
    private static readonly CompareLogic compareLogic;

    static ClientUpdateHelper()
    {
        var config = new ComparisonConfig
        {
            MaxDifferences = 100,
            TreatStringEmptyAndNullTheSame = true,
            IgnoreStringLeadingTrailingWhitespace = true,
            MembersToIgnore = ["Id"]
        };
        compareLogic = new CompareLogic(config);
    }

    /// <summary>
    /// Kiểm tra xem model hiện tại có khác với dữ liệu gốc hay không.
    /// </summary>
    public static bool HasChanges<T>(T current, T original) where T : class
    {
        if (current == null || original == null)
            return false;
        var result = compareLogic.Compare(current, original);
        return !result.AreEqual;
    }

    /// <summary>
    /// Trả về danh sách property khác nhau (nếu cần hiển thị chi tiết).
    /// </summary>
    public static IEnumerable<string> GetDifferences<T>(T current, T original) where T : class
    {
        if (current == null || original == null)
            return [];

        var result = compareLogic.Compare(current, original);
        return result.Differences.Select(d => $"{d.PropertyName}: {d.Object1Value} != {d.Object2Value}");
    }
}