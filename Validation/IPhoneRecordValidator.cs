using System.Globalization;
using Module003HW2.Models.PhoneRecord;

namespace Module003HW2.Validation
{
    /// <summary>
    /// Represents validator for <see cref="IPhoneRecord">.
    /// </summary>.
    internal interface IPhoneRecordValidator
    {
        /// <param name="name">Name to validate.</param>
        /// <summary>
        /// Validates <see cref="IPhoneRecord.Name">
        /// </summary>.
        /// <exception cref="ArgumentNullException">Is thown when name is null or empty.</exception>
        void ValidateName(string name);

        /// <param name="number">Number to validate.</param>
        /// <exception cref="ArgumentNullException">Is thrown when the parameter is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown when number does not match regex pattern.</exception>
        /// <summary>
        /// Validates <see cref="IPhoneRecord.PhoneNumber">.
        /// </summary>.
        void ValidatePhoneNumber(string number);

        /// <param name="supportedCultues">Array of supported arrays.</param>
        /// <exception cref="ArgumentNullException">Is thrown when argument is null.</exception>
        /// <exception cref="ArgumentException">Is thrown when culture is invalid.</exception>
        /// <summary>
        /// Validates <see cref="IPhoneRecord.Culture">.
        /// </summary>.
        void ValidateCulture(CultureInfo[] supportedCultues);

        /// <summary>
        /// Gets culture of the specific records.
        /// </summary>
        /// <returns>Culture of the record.</returns>
        public CultureInfo GetCulture();
    }
}
