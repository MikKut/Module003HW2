using System.Globalization;

namespace Module003HW2.Models.PhoneRecord
{
    public class PhoneRecord : IPhoneRecord
    {
        public PhoneRecord(string name, string phoneNumber, CultureInfo culture)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Culture = culture;
        }

        /// <inheritdoc />
        public string Name { get; init; }

        /// <inheritdoc />
        public string PhoneNumber { get; init; }

        /// <inheritdoc />
        public CultureInfo Culture { get; init; }

        public int CompareTo(IPhoneRecord? obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"{Name} cannot be compared to the {obj} because the last is null");
            }

            return Name.CompareTo(obj.Name);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Name} {PhoneNumber} {Culture.ToString()}";
        }
    }
}
