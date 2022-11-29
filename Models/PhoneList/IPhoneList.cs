using System.Data.SqlTypes;
using System.Globalization;
using Module003HW2.Models.PhoneRecord;

namespace Module003HW2.Models.PhoneList
{
    internal interface IPhoneList<T> : IEnumerable<T>
        where T : IPhoneRecord
    {
        /// <param name="record">Record to add.</param>
        /// <summary>
        ///  Adds <see cref="T"> or its inheritor to the collection.
        /// </summary>.
        public void Add(T record);

        /// <param name="record">Record to delete.</param>
        /// <returns>Result of deletion(true if successful).</returns>
        /// <summary>
        /// Deletes <see cref="T"> or its inheritor to the collection.
        /// </summary>.
        /// <returns>Result of deletion(true if successful).</returns>
        public bool Delete(T record);

        /// <summary>
        /// Gets record based on certain culture.
        /// </summary>
        /// <param name="culture">Supported culture.</param>
        /// <returns>Dictionary of records.</returns>
        public Dictionary<char, List<T>> GetRecordsOfTheLanguage(CultureInfo culture);

        /// <param name="number">The number to look for.</param>
        /// <returns>Record or null.</returns>
        /// <summary>
        /// Gets <see cref="T"> by number.
        /// </summary>.
        public T? GetRecordByNumberOrReturnDefault(string number);

        /// <param name="name">The name to look for.</param>
        /// <returns>Record or null.</returns>
        /// <summary>
        /// Gets <see cref="T"> by name.
        /// </summary>.
        public T? GetRecordByNameOrReturnDefault(string name);
    }
}
