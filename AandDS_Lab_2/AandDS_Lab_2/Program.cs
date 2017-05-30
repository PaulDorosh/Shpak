using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

// merge - слияние. Кол - во: n = r - p + 1; p <= q < r; <====это типо индексы массива)
// есть 2 стопки карт и надо сравнивать их между собой 2 верхние и поместить в выходную колоду по возрастанию
namespace AandDS_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> n1 = new List<int> {1, 3, 3, 5, 7, 9, 11, 17, 18, 19, 29};
            List<int> n2 = new List<int> {2, 4, 6, 8, 10, 11, 12, 15, 20, 22, 25};

            List<int> result1 = new List<int>();
            int i1 = 0, i2 = 0;

            while (i1 < n1.Count || i2 < n2.Count)
            {
                if (i1 < n1.Count && i2 < n2.Count)
                {
                    if (n1[i1] < n2[i2])
                    {
                        //Console.WriteLine($"i1 {i1} {i2}    {n1[i1]}<{n2[i2]}");
                        result1.Add(n1[i1]);
                        i1++;
                    }
                    else
                    {
                        //Console.WriteLine($"i2 {i1} {i2}    {n1[i1]}>{n2[i2]}");
                        result1.Add(n2[i2]);
                        i2++;
                    }
                }
                else
                {
                    //Console.WriteLine($"{i1}  {n1.Count}    {i2}  {n2.Count}");
                    for (int i = i2; i < n2.Count; i++)
                    {
                        result1.Add(n2[i]);
                    }
                    for (int i = i1; i < n1.Count; i++)
                    {
                        result1.Add(n1[i]);
                    }

                    break;
                }
            }

            string resMessage = "result1: ";
            foreach (var i in result1)
            {
                resMessage += " " + i;
            }
            Console.WriteLine(resMessage);


            List<int> result2 = new List<int>();
            result2.AddRange(n1);
            result2.AddRange(n2);
            string resMessage2 = "result2: ";
            foreach (var i in QuickSort(result2, 0, result2.Count - 1))
            {
                resMessage2 += " " + i;
            }
            Console.WriteLine(resMessage2);
        }

        static List<int> QuickSort(List<int> a, int l, int r)
        {
            int temp;
            int x = a[l + (r - l) / 2];
            int i = l;
            int j = r;
            while (i <= j)
            {
                while (a[i] < x) i++;
                while (a[j] > x) j--;
                if (i <= j)
                {
                    temp = a[i];                          // сверяем и меняем местами если надо
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r)
                QuickSort(a, i, r);

            if (l < j)
                QuickSort(a, l, j);

            return a;
        }
    }
}