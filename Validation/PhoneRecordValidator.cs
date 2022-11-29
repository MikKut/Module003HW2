using System.Globalization;
using System.Text.RegularExpressions;

namespace Module003HW2.Validation
{
    /// <summary>
    /// Abstract class that implements <see cref="IPhoneRecordValidator">.
    /// </summary>.
    internal abstract class PhoneRecordValidator : IPhoneRecordValidator
    {
#pragma warning disable SA1401 // Fields should be private
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        protected CultureInfo _culture;
        protected Regex _phoneNumberRegexWithCountryCode;

        /// <summary>
        /// Gets or sets current culture if the phone validation.
        /// </summary>
        /// <value>
        /// Current culture if the phone validation.
        /// </value>
        public virtual CultureInfo Culture
        {
            get => _culture;
            protected set => _culture = value;
        }

        /// <summary>
        /// Gets or sets regex pattern for number validation.
        /// </summary>
        /// <value>
        /// Regex pattern for number validation.
        /// </value>
        public virtual Regex PhoneNumberRegexWithCountryCode
        {
            get => _phoneNumberRegexWithCountryCode;
            protected set => _phoneNumberRegexWithCountryCode = value;
        }

        /// <inheritdoc />
        public virtual void ValidateName(string name)
        {
            if (name == null || name == string.Empty)
            {
                throw new ArgumentNullException($"Argument \"{nameof(name)}\" is null");
            }
        }

        /// <inheritdoc />.
        public virtual void ValidatePhoneNumber(string number)
        {
            if (number == null || number == string.Empty)
            {
                throw new ArgumentNullException($"{nameof(number)} is null");
            }

            if (!_phoneNumberRegexWithCountryCode.IsMatch(number))
            {
                throw new ArgumentOutOfRangeException($"Argument \"{nameof(number)}\"");
            }
        }

        /// <inheritdoc />
        public virtual void ValidateCulture(CultureInfo[] supportedCultues)
        {
            if (supportedCultues == null)
            {
                throw new ArgumentNullException($"Argument {nameof(supportedCultues)} is null");
            }

            foreach (var cult in supportedCultues)
            {
                if (cult == _culture)
                {
                    return;
                }
            }

            throw new ArgumentException("Invalid culture");
        }

        /// <inheritdoc />
        public CultureInfo GetCulture() => Culture;
    }
}
