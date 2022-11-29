using System.Globalization;
using System.Text.RegularExpressions;

namespace Module003HW2.Validation
{
    internal class UkrainianPhoneRecordValidator : PhoneRecordValidator
    {
        private static UkrainianPhoneRecordValidator? instance;
        private static object? syncRoot;

        private UkrainianPhoneRecordValidator()
        {
            _culture = SupportedCultures.UkrainianCultureInfo;
            _phoneNumberRegexWithCountryCode = new Regex(@"^([\+]?380[-]?|[0])?[1-9][0-9]{8}$");
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

        public static UkrainianPhoneRecordValidator GetInstance()
        {
            if (instance == null)
            {
                syncRoot = new object();
                lock (syncRoot)
                {
                    instance = new UkrainianPhoneRecordValidator();
                }
            }

            return instance;
        }
    }
}
