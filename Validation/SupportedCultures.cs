using System;
using System.Globalization;

namespace Module003HW2.Validation
{
    internal static class SupportedCultures
    {
        private static readonly CultureInfo _ukrainianCultureInfo;
        private static readonly CultureInfo _englishCultureInfo;
        static SupportedCultures()
        {
            _ukrainianCultureInfo = CultureInfo.CreateSpecificCulture("uk-UA");
            _englishCultureInfo = CultureInfo.CreateSpecificCulture("en-GB");
        }

        public static CultureInfo UkrainianCultureInfo { get => _ukrainianCultureInfo; }
        public static CultureInfo EnglishCultureInfo { get => _englishCultureInfo; }

        public static CultureInfo[] GetArrayOfSupportedCultures()
        {
            return new CultureInfo[] { UkrainianCultureInfo, EnglishCultureInfo };
        }
    }
}
