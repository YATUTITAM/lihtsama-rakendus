using SystemInfo.Core.Gigabytes.Converters;

namespace SystemInfo.Core.Gigabytes.Extensions
{
    public static class DoubleToGigabyteExtension
    {
        public static string ConvertItToGigabytes(this double source) 
            => IntoStringGigabytesConverter.Convert((long)source);
    }
}
