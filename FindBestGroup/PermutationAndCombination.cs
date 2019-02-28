using System;
using System.Collections.Generic;
using System.Text;

namespace FindBestGroup
{
    class PermutationAndCombination<T>
    {
        /// <summary>
        /// 交换两个变量
        /// </summary>
        /// <param name="a">变量1</param>
        /// <param name="b">变量2</param>
        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// 递归算法求数组的组合(私有成员)
        /// </summary>
        /// <param name="list">返回的范型</param>
        /// <param name="t">所求数组</param>
        /// <param name="n">辅助变量</param>
        /// <param name="m">辅助变量</param>
        /// <param name="b">辅助数组</param>
        /// <param name="M">辅助变量M</param>
        private static void GetCombination(ref List<T[,]> list, T[,] t, int n, int m, int[,] b, int M)
        {
            for (int i = n; i >= m; i--)
            {
                b[m - 1, 1] = i - 1;
                if (m > 1)
                {
                    GetCombination(ref list, t, i - 1, m - 1, b, M);
                }
                else
                {
                    if (list == null)
                    {
                        list = new List<T[,]>();
                    }
                    T[,] temp = new T[M, 2];
                    for (int j = 0; j < b.GetLength(0); j++)
                    {
                        temp[j, 0] = t[b[j, 1], 0];
                        temp[j, 1] = t[b[j, 1], 1];
                    }
                    list.Add(temp);
                }
            }
        }

        /// <summary>
        /// 求数组中n个元素的组合
        /// </summary>
        /// <param name="t">所求数组</param>
        /// <param name="n">元素个数</param>
        /// <returns>数组中n个元素的组合的范型</returns>
        public static List<T[,]> GetCombination(T[,] t,  int n)
        {
            int length = t.GetLength(0);
            if (length < n)
            {
                return null;
            }
            int[,] temp = new int[n, 2];
            List<T[,]> list = new List<T[,]>();
            GetCombination(ref list, t, length, n, temp, n);
            return list;
        }
    }
}
