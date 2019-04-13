namespace Proxy.Value
{
    public static class PercentageExtensions
    {
        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0);
        }

        public static Percentage Percent(this double value)
        {
            return new Percentage(value / 100.0);
        }
    }
}