namespace SoftLibrary.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SortingAlgorithms;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> elements;

        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Enque(T element)
        {
            this.elements.Add(element);

            int indexOfNewElement = this.Count - 1;
            int parentIndex = this.Count - 2;

            if (this.Count > 1)
            {
                while (indexOfNewElement >= 0)
                {
                    if (parentIndex < 0 || this.elements[indexOfNewElement].CompareTo(this.elements[parentIndex]) >= 0)
                    {
                        break;
                    }

                    T parElement = this.elements[parentIndex];
                    this.elements[parentIndex] = this.elements[indexOfNewElement];
                    this.elements[indexOfNewElement] = parElement;

                    indexOfNewElement--;
                    parentIndex--;
                }
            }
        }

        public T Deque()
        {
            T result = this.elements[0];

            this.elements[0] = this.elements[this.Count - 1];
            this.elements.RemoveAt(this.Count - 1);

            SortingAlgorithms<T>.Heapify(this.elements, false);
            if (this.elements.Count > 1)
            {
                var temp = this.elements[0];
                this.elements[0] = this.elements[this.Count - 1];
                this.elements[this.Count - 1] = temp;
            }

            #region Deprecated
            //while (true)
            //{
            //    int leftChildInd = (rootIndex * 2) + 1;
            //    int rightChildInd = (rootIndex * 2) + 2;

            //    if (leftChildInd > this.Count - 1)
            //    {
            //        break;
            //    }
            //    else if (rightChildInd > this.Count - 1)
            //    {
            //        minChild = leftChildInd;
            //    }
            //    else
            //    {
            //        if (this.elements[leftChildInd].CompareTo(this.elements[rightChildInd]) < 0)
            //        {
            //            minChild = leftChildInd;
            //        }
            //        else
            //        {
            //            minChild = rightChildInd;
            //        }
            //    }

            //    if (this.elements[minChild].CompareTo(this.elements[rootIndex]) < 0)
            //    {
            //        T swapValue = this.elements[rootIndex];
            //        this.elements[rootIndex] = this.elements[minChild];
            //        this.elements[minChild] = swapValue;

            //        rootIndex = minChild;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //} 
            #endregion

            return result;
        }

        public T Peek()
        {
            return this.elements[0];
        }
    }
}
