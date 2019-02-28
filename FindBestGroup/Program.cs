using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FindBestGroup
{
    class Program
    {
        private static int[,] array = { { 10, 3 }, { 10, 4 }, { 19, 9 }, { 11, 6 }, { 14, 8 }, { 12, 7 }
        , { 21, 13 }, { 20, 13 }, { 6, 4 }, { 24, 18 }, { 16, 13 }, { 16, 16 }, { 8, 8 }, { 4, 4 }
            , { 19, 20 }, { 14, 16 }, { 9, 14 }, { 4, 13 }, { 16, 13 }};

        private static int MaxVl = 0;

        static void Main(string[] args)
        {
            List<int[,]> ListCombination = PermutationAndCombination<int>.GetCombination(array, 13);

            List<int> array0 = new List<int>();
            List<int> array1 = new List<int>();

            int[,] result = new int[13, 2];
            foreach (var el in ListCombination)
            {
                array0.Clear();
                array1.Clear();
                int i = 0;
                foreach (var ell in el)
                {
                    if (i % 2 == 0)
                        array0.Add(ell);
                    else
                        array1.Add(ell);
                    i++;
                }

                int sum0 = array0.Sum();
                int sum1 = array1.Sum();
                if (sum1 <= 110)
                {
                    if (sum0 > MaxVl)
                    {
                        MaxVl = sum0;
                        result = el;
                    }
                }
            }

            int j = 0;
            foreach (var ell in result)
            {
                if (j % 2 == 0)
                    Console.Write(ell.ToString() + ',');
                else
                    Console.WriteLine(ell);
                j++;
            }
            Console.ReadLine();
        }
    }
}
