namespace InfoManager.Application.Extensions;

public static class NumberExtension
{
    public static int[] GetMonthsRange(int startMonth, int numMonths)
    {
        var months = new List<int>();
        for (int i = 0; i <= numMonths; i++)
        {
            int month = ((startMonth - 1 + i) % 12) + 1;
            months.Add(month);
        }
        return [.. months];
    }
}