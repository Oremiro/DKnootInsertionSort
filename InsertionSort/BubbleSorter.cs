using System;

namespace InsertionSort
{
    public class BubbleSorter: ISorter
    {
        public int[] Sort(int[] a)
        {
            int length = a.Length;

            int[] array = new int[length];
            Array.Copy(a, array, length);

            for (int i = 0; i < length; i++)
            {
                for (int j = i+1; j < length; j++)
                {
                    if (array[i] > array[j])
                    {
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                }
            }

            return array;        
        }
    }
}