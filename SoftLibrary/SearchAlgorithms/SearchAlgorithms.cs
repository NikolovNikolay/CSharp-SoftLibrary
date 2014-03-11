namespace SoftLibrary.SearchAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class SearchAlgorithms<T> where T : IComparable<T>
    {
        public static int LinearSearch(IList<T> collection, T value)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }

            return 0;
        }

        public static int BinarySearch(IList<T> collection, T value, int start, int end)
        {
            while (end >= start)
            {
                var mid = start + ((end - start) / 2);

                if (collection[mid].CompareTo(value) < 0)
                {
                    start = mid + 1;
                }
                else if(collection[mid].CompareTo(value) > 0)
                {
                    end = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return 0;
        }

        public static int BinarySearch(IList<T> collection, T value)
        {
            return BinarySearch(collection, value, 0, collection.Count - 1);
        }

        // TODO: Inerpolation search
    }
}
