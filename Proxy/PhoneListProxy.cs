using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Module003HW2.Models.PhoneRecord;
using Module003HW2.Models.PhoneList;
using Module003HW2.Validation;

namespace Module003HW2.Proxy
{
    /// <summary>
    /// Validation proxy for <see cref="PhoneList">.
    /// </summary>.
    internal class PhoneListProxy : IPhoneList<IPhoneRecord>
    {
        private IPhoneRecordValidator _validator;
        private IPhoneList<IPhoneRecord> _phoneList;
        public PhoneListProxy([DisallowNull]IPhoneList<IPhoneRecord> phoneList, [DisallowNull] IPhoneRecordValidator validator)
        {
            _phoneList = phoneList;
            _validator = validator;
        }

        public PhoneListProxy([DisallowNull] IPhoneRecordValidator validator)
        {
            _phoneList = new PhoneList<IPhoneRecord>();
            _validator = validator;
        }

        /// <inheritdoc />
        public void Add(IPhoneRecord record)
        {
            _validator.ValidateName(record.Name);
            _validator.ValidatePhoneNumber(record.PhoneNumber);
            if (_phoneList.GetRecordByNumberOrReturnDefault(record.PhoneNumber) != default(IPhoneRecord))
            {
                throw new ArgumentException($"There is already exist {nameof(record.PhoneNumber)} number");
            }

            _validator.ValidateCulture(SupportedCultures.GetArrayOfSupportedCultures());
            _phoneList.Add(record);
        }

        /// <inheritdoc />
        public bool Delete(IPhoneRecord record)
        {
            _validator.ValidateName(record.Name);
            _validator.ValidatePhoneNumber(record.PhoneNumber);
            _validator.ValidateCulture(SupportedCultures.GetArrayOfSupportedCultures());
            return _phoneList.Delete(record);
        }

        /// <inheritdoc />
        public IPhoneRecord? GetRecordByNameOrReturnDefault(string name)
        {
            _validator.ValidateName(name);
            return _phoneList.GetRecordByNameOrReturnDefault(name);
        }

        /// <inheritdoc />
        public IPhoneRecord? GetRecordByNumberOrReturnDefault(string number)
        {
            _validator.ValidatePhoneNumber(number);
            return _phoneList.GetRecordByNumberOrReturnDefault(number);
        }

        /// <inheritdoc />
        public Dictionary<char, List<IPhoneRecord>> GetRecordsOfTheLanguage(CultureInfo culture)
        {
            return _phoneList.GetRecordsOfTheLanguage(culture);
        }

        public IEnumerator<IPhoneRecord> GetEnumerator()
        {
            return _phoneList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _phoneList.GetEnumerator();
        }
    }
}
