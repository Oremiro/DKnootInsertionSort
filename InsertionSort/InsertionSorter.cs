using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace InsertionSort
{
    public class InsertionSorter : ISorter
    {
        public int[] Sort(int[] data)
        {
            int n = data.Length;
            var R = new int[n + 1];
            data.CopyTo(R, 1);
            if (n > 1)
            {
                int[] L = new int[n + 1];
                L[n] = 0;
                L[0] = n;

                for (int j = n - 1; j > 0; --j)
                {
                    int p = L[0];
                    int q = 0;
                    R[0] = R[j];

                    L3:
                    if (R[0] > R[p])
                    {
                        q = p;
                        p = L[q];
                        if (p > 0)
                        {
                            goto L3;
                        }
                    }
                    L[q] = j;
                    L[j] = p;
                }

                var resultArray = swapArrayValues(R, L);
                return resultArray.Skip(1).ToArray();
            }


            return data;
        }

        private int[] swapArrayValues(int[] R, int[] L)
        {
            for (int i = 0; i < L.Length - 1; ++i)
            {
                var swapper1 = R[L[i]];
                var swapper2 = L[L[i]];
                if (swapper2 == 0) break;
                R[L[i]] = R[i + 1];
                L[L[i]] = L[i + 1];
                R[i + 1] = swapper1;
                L[i + 1] = swapper2;
                for (int j = i + 1; j < L.Length; ++j)
                {
                    if (L[j] == i + 1)
                    {
                        L[j] = L[i];
                        break;
                    }
                }
            }

            return R;
        }
    }
}