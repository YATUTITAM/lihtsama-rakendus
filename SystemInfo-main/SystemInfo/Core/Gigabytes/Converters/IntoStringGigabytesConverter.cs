namespace SystemInfo.Core.Gigabytes.Converters
{
    public sealed class IntoStringGigabytesConverter
    {
        public static string Convert(Int64 value)
        {
            int mag = (int)Math.Log(value, 1024);

            decimal adjustedSize = (decimal)value / (1L << (mag * 10));
            if (Math.Round(adjustedSize, 1) >= 1000)
            {
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + 1 + "} {1}", adjustedSize, "GB");
        }
    }
}
