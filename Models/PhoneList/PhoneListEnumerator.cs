using System.Collections;
using Module003HW2.Models.PhoneRecord;

namespace Module003HW2.Models.PhoneList
{
    internal partial class PhoneList<T> : IPhoneList<T>, IEnumerable<T>
        where T : IPhoneRecord
    {
        private class PhoneListEnumerator<TI> : IEnumerator<TI>
            where TI : IPhoneRecord
        {
            private TI[] _collection;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            private int _position = -1;

            /// <summary>
            /// Initializes a new instance of the <see cref=" PhoneListEnumerator{TI}"/> class.
            /// </summary>
            /// <param name="list">Collection to iterate.</param>
            public PhoneListEnumerator(TI[] list)
            {
                _collection = list;
            }

            TI IEnumerator<TI>.Current
            {
                get
                {
                    try
                    {
                        return _collection[_position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object? IEnumerator.Current
            {
                get
                {
                    try
                    {
                        return _collection[_position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            // object IEnumerator.Current => IEnumerator<TI>.Current;
            public IEnumerator GetEnumerator()
            {
                return this;
            }

            public bool MoveNext()
            {
                _position++;
                return _position < _collection.Length;
            }

            public void Reset()
            {
                _position = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
