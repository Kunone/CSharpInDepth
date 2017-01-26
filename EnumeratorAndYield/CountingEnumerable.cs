using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorAndYield
{
    class CountingEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new CountingEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class CountingEnumerator : IEnumerator<int>
    {
        int _current = -1;

        public int Current
        {
            get
            {
                return _current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            _current++;
            return _current < 10;
        }

        public void Reset()
        {
            _current = -1;
        }
    }
}
