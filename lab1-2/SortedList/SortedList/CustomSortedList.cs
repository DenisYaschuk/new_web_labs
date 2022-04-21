using System;
using System.Collections;
using System.Collections.Generic;

namespace SortedList
{
    public delegate void CustomSortedListDelegate();

    public class CustomSortedList<T> : IEnumerable<T>, IComparable<CustomSortedList<T>>
        where T : IComparable
    {
        public event CustomSortedListDelegate addedElement = delegate { };
        public event CustomSortedListDelegate removedElement = delegate { };
        public event CustomSortedListDelegate clearedCollection = delegate { };
        public event CustomSortedListDelegate resizedCollection = delegate { };


        private T[] values;
        private int size = 0;
        private int capacity;

        public CustomSortedList(int initialCapacity = 8)
        {
            if (initialCapacity < 1) initialCapacity = 1;
            this.capacity = initialCapacity;
            values = new T[initialCapacity];
        }

        public int Size { get { return size; } }
        public bool IsEmpty { get { return size == 0; } }

        public T this[int index]
        {
            get
            {
                ThrowIfIndexOutOfRange(index);
                return values[index];
            }
        }

        public void DeleteAt(int index)
        {
            ThrowIfArgumentOutOfRange(index);
            CustomSortedListDelegate removedEvent = removedElement;
            if (removedEvent != null)
            {
                removedElement();
            }
            
            for (int i = index; i < size - 1; i++)
            {
                values[i] = values[i + 1];
            }

            values[size - 1] = default(T);
            size--;
            
        }

        public void Delete(T value)
        {
            CustomSortedListDelegate removedEvent = removedElement;
            if (removedEvent != null)
            {
                removedElement();
            }
            int index = -1;

            for (int i = 0; i < size; i++)
            {
                if (value.CompareTo(values[i]) == 0)
                {
                    index = i;
                }
            }
            if (index == -1)
            {
                ThrowIfValueNotInList();
            }
            for (int i = index; i < size - 1; i++)
            {
                values[i] = values[i + 1];
            }

            values[size - 1] = default(T);
            size--;

        }

        public void Add(T newValue)
        {
            CustomSortedListDelegate addedEvent = addedElement;
            if (addedEvent != null)
            {
                addedElement();
            }
            if (size == capacity)
            {
                Resize();
            }

            int insertPosition = size;
            for (int i = 0; i < size; i++)
            {
                if(newValue.CompareTo(values[i]) <= 0)
                {
                    insertPosition = i;
                    break;
                }
            }
            for (int i = size; i > insertPosition; i--)
            {
                values[i] = values[i - 1];
            }

            values[insertPosition] = newValue;

            size++;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < size; i++)
            {
                T currentValue = values[i];
                if (currentValue.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            CustomSortedListDelegate clearedEvent = clearedCollection;
            if (clearedEvent != null)
            {
                clearedCollection();
            }

            values = new T[capacity];
            size = 0;
        }

        private void Resize()
        {
            resizedCollection();
            T[] resizedValues = new T[capacity * 2];
            for (int i = 0; i < capacity; i++)
            {
                resizedValues[i] = values[i];
            }
            values = resizedValues;
            capacity = capacity * 2;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CompareTo(CustomSortedList<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }
            if(other.Size == 0 && Size != 0)
            {
                return -1;
            }
            if (other.Size != 0 && Size == 0)
            {
                return 1;
            }

            for (int i = 0; i < size; i++)
            {
                if(values[i].CompareTo(other.values[i]) != 0)
                {
                    return values[i].CompareTo(other.values[i]);
                }
            }
            return 0;
        }
        private void ThrowIfArgumentOutOfRange(int index)
        {
            if (index > size - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(String.Format("The current size of the array is {0}", size));
            }
        }
        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index > size - 1 || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format("The current size of the array is {0}", size));
            }
        }
        private void ThrowIfValueNotInList()
        {
            throw new Exception("Value is not present in the list");
        }

    }
}