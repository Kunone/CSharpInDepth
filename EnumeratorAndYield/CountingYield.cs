using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorAndYield
{
    class CountingYield : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < 10; i++)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
