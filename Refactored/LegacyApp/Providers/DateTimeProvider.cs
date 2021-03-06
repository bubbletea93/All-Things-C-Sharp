namespace LegacyApp.Providers
{
    using System;

    class DateTimeProvider : IDateTimeProvider
    {
        public DateTime DateTime => DateTime.UtcNow;
    }
}
