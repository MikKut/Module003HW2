using System.Globalization;

namespace Module003HW2.Models.PhoneRecord
{
    public interface IPhoneRecord : IComparable<IPhoneRecord>
    {
        /// <summary>
        /// Gets name of the contact.
        /// </summary>
        /// <value>
        /// Name of the contact. Can be only initialized.
        /// </value>
        string Name { get; init; }

        /// <summary>
        /// Gets phone number of the contact. Can be only initialized.
        /// </summary>
        /// <value>
        /// Phone number of the contact. Can be only initialized.
        /// </value>
        string PhoneNumber { get; init; }

        /// <summary>
        /// Gets culture of the record.
        /// </summary>
        /// <value>
        /// Culture of the record.
        /// </value>
        CultureInfo Culture { get; init; }

        /// <summary>
        /// Returns string representation of the record.
        /// </summary>
        /// <returns>String representation of the record.</returns>
        string ToString();
    }
}
