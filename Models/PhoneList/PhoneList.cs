using System.Collections;
using System.Data.SqlTypes;
using System.Globalization;
using Module003HW2.Models.PhoneRecord;

namespace Module003HW2.Models.PhoneList
{
    /// <summary>
    /// Phone list.
    /// </summary>
    /// <typeparam name="T">Type of phone list.</typeparam>
    internal partial class PhoneList<T> : IPhoneList<T>
        where T : IPhoneRecord
    {
        private const char SymbolOfTheRestLanguages = '#';
        private const char SymbolForAllNumberss = '1';

        /// <summary>
        /// Dictionary of certain cultures(languages) where key is culture, value - dictionary of <see cref="IPhoneRecord">s, where key is first letter of the <see cref="IPhoneRecord.Name"> and key is the <see cref="IPhoneRecord">.
        /// </summary>
        private Dictionary<CultureInfo, Dictionary<char, List<T>>> _phoneListCollection;

        public PhoneList()
        {
            /// TODO: must be only supported dictionaries(from <see cref="SupportedCultures">)
            _phoneListCollection = new Dictionary<CultureInfo, Dictionary<char, List<T>>>();
        }

        /// <inheritdoc />
        public void Add(T record)
        {
            InitializePlaceForRecordIfNeeded(record);
            if (char.IsDigit(record.Name[0]))
            {
                _phoneListCollection[record.Culture][SymbolForAllNumberss].Add(record);
            }
            else
            {
                _phoneListCollection[record.Culture][record.Name[0]].Add(record);
            }
        }

        /// <inheritdoc />
        public T? GetRecordByNumberOrReturnDefault(string number)
        {
            foreach (var collectonContact in GetAll())
            {
                if (number == collectonContact.PhoneNumber)
                {
                    return collectonContact;
                }
            }

            return default(T);
        }

        /// <inheritdoc />
        public T? GetRecordByNameOrReturnDefault(string name)
        {
            foreach (var collectonContact in GetAll())
            {
                if (name == collectonContact.Name)
                {
                    return collectonContact;
                }
            }

            return default(T);
        }

        /// <inheritdoc />
        public bool Delete(T record)
        {
            if (!CheckForExistenceOfTheCulture(record.Culture))
            {
                return false;
            }

            if (char.IsDigit(record.Name[0]))
            {
                if (!_phoneListCollection[record.Culture].ContainsKey(SymbolForAllNumberss))
                {
                    return false;
                }

                _phoneListCollection[record.Culture][SymbolForAllNumberss].Remove(record);
                return true;
            }

            if (_phoneListCollection[record.Culture].ContainsKey(record.Name[0]))
            {
                return _phoneListCollection[record.Culture][record.Name[0]].Remove(record);
            }

            return false;
        }

        /// <inheritdoc />
        public Dictionary<char, List<T>> GetRecordsOfTheLanguage(CultureInfo culture)
        {
            Dictionary<char, List<T>> resultDictionary;

            if (_phoneListCollection.ContainsKey(culture))
            {
                resultDictionary = _phoneListCollection[culture];
            }
            else
            {
                resultDictionary = new ();
            }

            if (!resultDictionary.ContainsKey(SymbolOfTheRestLanguages))
            {
                resultDictionary[SymbolOfTheRestLanguages] = new List<T>();
            }

            var sortedArrayOfCulturesExceptCurrent = GetArrayOfAllRecordsExceptLanguage(culture);
            Array.Sort(sortedArrayOfCulturesExceptCurrent);
            resultDictionary[SymbolOfTheRestLanguages].AddRange(sortedArrayOfCulturesExceptCurrent);
            return resultDictionary;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new PhoneListEnumerator<T>(GetAll());
        }

        private T[] GetAll()
        {
            var array = GetListOfAllRecords().ToArray();
            Array.Sort(array);
            return array;
        }

        private void InitializePlaceForRecordIfNeeded(T record)
        {
            if (!_phoneListCollection.ContainsKey(record.Culture))
            {
                _phoneListCollection[record.Culture] = new Dictionary<char, List<T>>();
            }

            if (char.IsDigit(record.Name[0]))
            {
                if (!_phoneListCollection[record.Culture].ContainsKey(SymbolForAllNumberss))
                {
                    _phoneListCollection[record.Culture][SymbolForAllNumberss] = new List<T>();
                }
            }
            else if (!_phoneListCollection[record.Culture].ContainsKey(record.Name[0]))
            {
                _phoneListCollection[record.Culture][record.Name[0]] = new List<T>();
            }
        }

        private bool CheckForExistenceOfTheCulture(CultureInfo culture)
        {
            if (!_phoneListCollection.ContainsKey(culture))
            {
                return false;
            }

            return true;
        }

        private List<T> GetListOfAllRecords()
        {
            var finalList = new List<T>();
            foreach (var languageList in _phoneListCollection)
            {
                foreach (var listOfRecords in languageList.Value)
                {
                    finalList.AddRange(listOfRecords.Value);
                }
            }

            return finalList;
        }

        private T[] GetArrayOfAllRecordsExceptLanguage(CultureInfo culture)
        {
            var finalList = new List<T>();
            foreach (var languageList in _phoneListCollection)
            {
                if (languageList.Key == culture)
                {
                    continue;
                }

                foreach (var listOfRecords in languageList.Value)
                {
                    finalList.AddRange(listOfRecords.Value);
                }
            }

            return finalList.ToArray();
        }
    }
}
