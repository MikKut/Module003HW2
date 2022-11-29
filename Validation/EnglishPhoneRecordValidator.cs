using System.Globalization;
using System.Text.RegularExpressions;

namespace Module003HW2.Validation
{
    internal class EnglishPhoneRecordValidator : PhoneRecordValidator
    {
        private static EnglishPhoneRecordValidator? instance;
        private static object? syncRoot;

        private EnglishPhoneRecordValidator()
        {
            _culture = SupportedCultures.EnglishCultureInfo;
            _phoneNumberRegexWithCountryCode = new Regex(@"^([\+]?447[-]?|[0])?[1-9][0-9]{8}$");
        }

        public override CultureInfo Culture
        {
            get => _culture;
            protected set => _culture = value;
        }

        public override Regex PhoneNumberRegexWithCountryCode
        {
            get => _phoneNumberRegexWithCountryCode;
            protected set => _phoneNumberRegexWithCountryCode = value;
        }

        public static EnglishPhoneRecordValidator GetInstance()
        {
            if (instance == null)
            {
                syncRoot = new object();
                lock (syncRoot)
                {
                    instance = new EnglishPhoneRecordValidator();
                }
            }

            return instance;
        }
    }
}
