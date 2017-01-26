using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorAndYield
{
    class Compare3Execution
    {
        static int Computation(int index)
        {
            return index * 2;
        }

        /// <summary>
        /// When the function is called Computation is executed maxIndex times
        /// GetEnumerator returns a new instance of the enumerator doing nothing more.
        /// Each call to MoveNext put the the value stored in the next Array cell in the Current member of the IEnumerator and that's all.
        /// Cost: Big upfront, Small during enumeration(only a copy)
        /// </summary>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        public static IEnumerable<int> ImmedicateExecution(int maxIndex)
        {
            var result = new int[maxIndex];
            for(int i=0;i<result.Length;i++)
            {
                result[i] = Computation(i);
            }
            return result;
        }

        /// <summary>
        /// When the function is called an instance of an auto generated class (called "enumerable object" in the spec) implementing IEnumerable is created and a copy of the argument (maxIndex) is stored in it.
        /// GetEnumerator returns a new instance of the enumerator doing nothing more.
        /// The first call to MoveNext executes maxIndex times the compute method, store the result in an array and Current will return the first value.
        /// Each subsequent call to MoveNext will put in Current a value stored in the array.
        /// Cost: nothing upfront, Big when the enumeration start, Small during enumeration (only a copy)
        /// </summary>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        public static IEnumerable<int> DeferredEager(int maxIndex)
        {
            var result = new int[maxIndex];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Computation(i);
            }
            foreach(var re in result)
            {
                yield return re;
            }
        }

        /// <summary>
        /// When the function is called the same thing as the lazy execution case happens.
        /// GetEnumerator returns a new instance of the enumerator doing nothing more.
        /// Each call to MoveNext execute once the Computation code, put the value in Current and let the caller immediately act on the result.
        /// Most of linq use deferred and lazy execution but some functions can't be so like sorting.
        /// Cost: nothing upfront, Moderate during enumeration (the computation is executed there)
        /// </summary>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        public static IEnumerable<int> DeferredLazy(int maxIndex)
        {
            var result = new int[maxIndex];
            for (int i = 0; i < result.Length; i++)
            {
                yield return Computation(i);
            }
        }
    }
}
