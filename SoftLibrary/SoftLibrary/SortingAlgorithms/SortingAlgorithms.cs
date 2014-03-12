namespace SoftLibrary.SortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class SortingAlgorithms<T> where T : IComparable<T>
    {
        public static void SelectionSort(IList<T> collection)
        {
            var n = collection.Count;

            for (int i = 0; i < n - 1; i++)
            {
                var minInd = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (collection[j].CompareTo(collection[minInd]) < 0)
                    {
                        minInd = j;
                    }
                }

                if (minInd != i)
                {
                    var temp = collection[minInd];
                    collection[minInd] = collection[i];
                    collection[i] = temp;
                }
            }
        }

        public static void BubbleSort(IList<T> collection)
        {
            int n = collection.Count; // < ---- optimization Part 1
            while (true)
            {
                int newN = 0;  // < ---- optimization Part 2
                bool swap = false;
                for (int i = 1; i <= n - 1; i++)
                {
                    if (collection[i - 1].CompareTo(collection[i]) > 0)
                    {
                        var temp = collection[i - 1];
                        collection[i - 1] = collection[i];
                        collection[i] = temp;
                        swap = true;
                        newN = i;  // < ---- optimization Part 3
                    }
                }

                n = newN; // // < ---- optimization Part 4
                if (!swap)
                {
                    break;
                }
            }
        }

        public static void InsertionSort(IList<T> collection)
        {
            var n = collection.Count;
            for (int i = 1; i <= n - 1; i++)
            {
                var value = collection[i];
                var pos = i;

                while (pos > 0 && value.CompareTo(collection[pos - 1]) < 0)
                {
                    collection[pos] = collection[pos - 1];
                    pos = pos - 1;
                }

                collection[pos] = value;
            }
        }

        public static IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            var pivot = (collection.Count - 1) / 2;
            var pivotElement = collection[pivot];

            var less = new List<T>();
            var greater = new List<T>();

            foreach (var element in collection)
            {
                if (element.CompareTo(pivotElement) == 0)
                {
                    continue;
                }
                else if (element.CompareTo(pivotElement) < 0)
                {
                    less.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }

            var firstPart = QuickSort(less);
            var secondPart = QuickSort(greater);

            return firstPart.Concat(new T[] { pivotElement }.Concat(secondPart)).ToList();
        }

        #region Merge - Sort Algorithm
        public static IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();
            var middle = collection.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = middle; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static IList<T> Merge(IList<T> left, IList<T> right)
        {
            var result = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) <= 0)
                    {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            return result;
        }
        #endregion

        #region Heap - Sort Algorithm
        public static void HeapSort(IList<T> collection, bool sortInDescOrder)
        {
            Heapify(collection, sortInDescOrder);
            var end = collection.Count - 1;

            while (end > 0)
            {
                var temp = collection[end];
                collection[end] = collection[0];
                collection[0] = temp;
                end--;
                ShiftDown(collection, 0, end, sortInDescOrder);
            }
        }

        // method puts the elements of the collection in a heap order, with biggest element at root position
        internal static void Heapify(IList<T> collection, bool heapifyInAscOrder)
        {
            var start = (collection.Count - 2) / 2;

            while (start >= 0)
            {
                ShiftDown(collection, start, collection.Count - 1, heapifyInAscOrder);
                start--;
            }
        }

        public static void ShiftDown(IList<T> collection, int start, int end, bool heapifyInAscOrder)
        {
            var root = start;

            while ((root * 2) + 1 <= end)
            {
                var child = (root * 2) + 1;
                var swap = root;

                if (!heapifyInAscOrder)
                {
                    if (collection[swap].CompareTo(collection[child]) < 0)
                    {
                        swap = child;
                    }

                    if (child + 1 <= end && collection[swap].CompareTo(collection[child + 1]) < 0)
                    {
                        swap = child + 1;
                    }
                }
                else
                {
                    if (collection[swap].CompareTo(collection[child]) > 0)
                    {
                        swap = child;
                    }

                    if (child + 1 <= end && collection[swap].CompareTo(collection[child + 1]) > 0)
                    {
                        swap = child + 1;
                    }
                }

                if (swap != root)
                {
                    var temp = collection[swap];
                    collection[swap] = collection[root];
                    collection[root] = temp;
                    root = swap;
                }
                else
                {
                    break;
                }
            }
        }

        #endregion
    }
}
