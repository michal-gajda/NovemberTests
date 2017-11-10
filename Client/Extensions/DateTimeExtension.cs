namespace Gajda.NovemberTests.Client.Extensions
{
    using System;

    public static class DateTimeExtension
    {
        public static int YearsBetweenNow(this DateTime source)
        {
            return DateTime.Now.Year - source.Year - 1 + (DateTime.Now.Month > source.Month
                                                          || DateTime.Now.Month == source.Month
                                                          && DateTime.Now.Day >= source.Day ? 1 : 0);
        }
    }
}