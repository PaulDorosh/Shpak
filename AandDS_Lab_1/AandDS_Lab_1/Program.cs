using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AandDS_Lab_1
{
    class Program
    {
        static int linearSearch(List<int> A, int n, int x)
        {
            // просто бежим по порядку и ищем нужный элемент
            if (n < 0) return -1;
            if (A.Count < n) return -2;
            int position = -1;
            for (int i = 0; i < n; i++)
            {
                if (A[i] == x)
                    position = i;
            }
            return position;
        }

        static int betterLinearSearch(List<int> A, int n, int x)
        {
            if (n < 0) return -1;
            if (A.Count < n) return -2;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] == x)
                    return i;
            }
            return -1;
        }

        static int sentinelLinearSearch(List<int> A, int n, int x)
        {
            // мы заменяем последний элемент списка самим элементом поиска и запускаем цикл while,
            // чтобы увидеть, существует ли какая-либо копия элемента
            if (n < 0) return -1;
            if (A.Count < n) return -2;
            int last = A[A.Count - 1];
            A[A.Count - 1] = x;   
            int i = 0;
            while (A[i] != x)
            {
                i++;
            }
            A[n - 1] = last;
            if ((i < n - 1) || (x == A[n - 1]))
            {
                return i;
            }
            return -1;
        }

        static int recursiveLinearSearch(List<int> A, int x, int n, int i=0)
        {
            if (i >= x) return -1;
                if (n < 0) return -2;
                if (A[i] == n)
                {
                    return i;
                }
                i++;
                return recursiveLinearSearch(A, x, n, i);
            
          
        }

        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 45, 542, 324, 231, 123, 432, 23, 42 };
            int s = 42;
            Console.WriteLine("linearSearch: " + linearSearch(numbers, numbers.Count, s));
            Console.WriteLine("betterLinearSearch: " + betterLinearSearch(numbers, numbers.Count, s));
            Console.WriteLine("sentinelLinearSearch: " + sentinelLinearSearch(numbers, numbers.Count, s));
            Console.WriteLine("recursiveLinearSearch: " + recursiveLinearSearch(numbers, numbers.Count, s));
        }
    }
}
