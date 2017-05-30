using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AandDS_Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Бинарный поиск: мы ставим "указатель?" в середину массива. Если элемент больше -> идем вправо и наоборот.
               Так до тех пор, пока не останется один нужный элемент.
               Рекурсивный вызывает сам себя, а обычный идет циклом*/

            string[] ArrayString = {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "a", "b", "aa", "ab"};

            for (int i = 0; i < ArrayString.Length; i++)
            {
                Console.Write(ArrayString[i] + " ");
            }

            Console.WriteLine();
            Quicksort(ArrayString, 0, ArrayString.Length - 1);
            for (int i = 0; i < ArrayString.Length; i++)
            {
                Console.Write(ArrayString[i] + " ");
            }

            Console.WriteLine();
            Array.Sort<string>(ArrayString);

            for (int i = 0; i < ArrayString.Length; i++)
            {
                Console.Write(ArrayString[i] + " ");
            }
            Console.WriteLine();
            //string stringForSearch = "Sun";
            foreach (var VARIABLE in ArrayString)
            {
                Console.WriteLine(
                    $"IterativeBinarySearch({VARIABLE}): {IterativeBinarySearch(ArrayString, VARIABLE, 0, ArrayString.Length - 1) + 1}\n" +
                    $"RecursiveBinarySearch({VARIABLE}): {RecursiveBinarySearch(ArrayString, VARIABLE, 0, ArrayString.Length - 1) + 1}");
            }
            Console.WriteLine();
            //Console.WriteLine($"\nIterativeBinarySearch({stringForSearch}): {IterativeBinarySearch(ArrayString, stringForSearch, 0, ArrayString.Length-1)+1}\n" +
            //                  $"RecursiveBinarySearch({stringForSearch}): {RecursiveBinarySearch(ArrayString, stringForSearch, 0, ArrayString.Length - 1)+1}\n\n");


            List<int> ListInt = new List<int> {1, 4, 3, 2, 5, 8, 7, 6, 9};
            foreach (var i in ListInt)
            {
                Console.Write(i + " ");
            }
            QuickSort(ListInt, 0, ListInt.Count - 1);
            Console.WriteLine();
            foreach (var i in ListInt)
            {
                Console.Write(i + " ");
            }

            int intForSearch = 4;
            Console.WriteLine(
                $"\nIterativeBinarySearch({intForSearch}): {IterativeBinarySearch(ListInt, intForSearch, 0, ListInt.Count - 1) + 1}\n" +
                $"RecursiveBinarySearch({intForSearch}): {RecursiveBinarySearch(ListInt, intForSearch, 0, ListInt.Count - 1) + 1}\n");

            Console.WriteLine();
            List<double> ListDouble = new List<double> {1.5, 2.1, 2, 3.1, 4.2, 6.5, 6, 7.5, 8.3, 9};
            foreach (var i in ListDouble)
            {
                Console.Write(i + " ");
            }
            QuickSort(ListDouble, 0, ListDouble.Count - 1);
            Console.WriteLine();
            foreach (var i in ListDouble)
            {
                Console.Write(i + " ");
            }
            double doubleForSearch = 2.1;
            Console.WriteLine(
                $"\nIterativeBinarySearch({doubleForSearch}): {IterativeBinarySearch(ListDouble, doubleForSearch, 0, ListDouble.Count - 1) + 1}\n" +
                $"RecursiveBinarySearch({doubleForSearch}): {RecursiveBinarySearch(ListDouble, doubleForSearch, 0, ListDouble.Count - 1) + 1}\n");

            int a, b;
            do
            {
                Console.WriteLine("a: ");
                a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("b: ");
                b = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"gcd: {gcd(a, b)}\n");
            } while (a != -1 && b != -1);
        }

        //-----------------------------------gcd---------------------------
        public static int? gcd(int a, int b)
        {
            if (a == b) return a;

            if (a == 0 && b == 0) return 0;
            if (a < 0) a = -a;
            if (b < 0) b = -b;

            if (a % 2 == 0 && b % 2 == 0) return 2 * gcd(a / 2, b / 2);
            if (a % 2 == 1 && b % 2 == 0) return gcd(a, b / 2);

            if (a % 2 == 0 && b % 2 == 1) return gcd(a / 2, b);

            if (a % 2 == 1 && b % 2 == 1 && a > b) return gcd((a - b) / 2, b);
            if (a % 2 == 1 && b % 2 == 1 && a < b) return gcd(a, (b - a) / 2);
            return null;
            
        }

        //-----------------------------------string---------------------------
        public static int? IterativeBinarySearch(string[] source, string value, int left, int right)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (String.Compare(source[middle], value) == 0)
                    return middle;
                else if (String.Compare(source[middle], value) > 0)
                    right = middle - 1;
                else if (String.Compare(source[middle], value) < 0)
                    left = middle + 1;
            }
            return null;
        }

        public static int? RecursiveBinarySearch(string[] source, string value, int left, int right)
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;

                if (String.Compare(source[middle], value) == 0)
                    return middle;
                else if (String.Compare(source[middle], value) > 0)
                    return RecursiveBinarySearch(source, value, left, middle - 1);
                else if (String.Compare(source[middle], value) < 0)
                    return RecursiveBinarySearch(source, value, middle + 1, right);
            }
            return null;
        }

        public static int? IterativeBinarySearch(List<string> source, string value, int left, int right)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (String.Compare(source[middle], value) == 0)
                    return middle;
                else if (String.Compare(source[middle], value) == -1)
                    right = middle - 1;
                else if (String.Compare(source[middle], value) == 1)
                    left = middle + 1;
            }
            return null;
        }

        public static int? RecursiveBinarySearch(List<string> source, string value, int left, int right)
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;

                if (String.Compare(source[middle], value) == 0)
                    return middle;
                else if (String.Compare(source[middle], value) == -1)
                    return RecursiveBinarySearch(source, value, left, middle - 1);
                else if (String.Compare(source[middle], value) == 1)
                    return RecursiveBinarySearch(source, value, middle + 1, right);
            }
            return null;
        }


        //-----------------------------------int------------------------------
        public static int? IterativeBinarySearch(int[] source, int value, int left, int right)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (source[middle] == value)
                    return middle;
                else if (source[middle] > value)
                    right = middle - 1;
                else if (source[middle] < value)
                    left = middle + 1;
            }
            return null;
        }

        public static int? RecursiveBinarySearch(int[] source, int value, int left, int right)
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;

                if (source[middle] == value)
                    return middle;
                else if (source[middle] > value)
                    return RecursiveBinarySearch(source, value, left, middle - 1);
                else if (source[middle] < value)
                    return RecursiveBinarySearch(source, value, middle + 1, right);
            }
            return null;
        }

        public static int? IterativeBinarySearch(List<int> source, int value, int left, int right)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (source[middle] == value)
                    return middle;
                else if (source[middle] > value)
                    right = middle - 1;
                else if (source[middle] < value)
                    left = middle + 1;
            }
            return null;
        }

        public static int? RecursiveBinarySearch(List<int> source, int value, int left, int right)
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;

                if (source[middle] == value)
                    return middle;
                else if (source[middle] > value)
                    return RecursiveBinarySearch(source, value, left, middle - 1);
                else if (source[middle] < value)
                    return RecursiveBinarySearch(source, value, middle + 1, right);
            }
            return null;
        }


        //-----------------------------------double---------------------------
        public static int? IterativeBinarySearch(double[] source, double value, int left, int right)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (source[middle] == value)
                    return middle;
                else if (source[middle] > value)
                    right = middle - 1;
                else if (source[middle] < value)
                    left = middle + 1;
            }
            return null;
        }

        public static int? RecursiveBinarySearch(double[] source, double value, int left, int right)
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;

                if (source[middle] == value)
                    return middle;
                else if (source[middle] > value)
                    return RecursiveBinarySearch(source, value, left, middle - 1);
                else if (source[middle] < value)
                    return RecursiveBinarySearch(source, value, middle + 1, right);
            }
            return null;
        }

        public static int? IterativeBinarySearch(List<double> source, double value, int left, int right)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (source[middle] == value)
                    return middle;
                else if (source[middle] > value)
                    right = middle - 1;
                else if (source[middle] < value)
                    left = middle + 1;
            }
            return null;
        }

        public static int? RecursiveBinarySearch(List<double> source, double value, int left, int right)
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;

                if (source[middle] == value)
                    return middle;
                else if (source[middle] > value)
                    return RecursiveBinarySearch(source, value, left, middle - 1);
                else if (source[middle] < value)
                    return RecursiveBinarySearch(source, value, middle + 1, right);
            }
            return null;
        }

        //-----------------------------------QuickSort---------------------------

        public static void Quicksort(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }


        public static List<int> QuickSort(List<int> a, int l, int r)
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
                    temp = a[i];
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

        public static List<double> QuickSort(List<double> a, int l, int r)
        {
            double temp;
            double x = a[l + (r - l) / 2];
            int i = l;
            int j = r;
            while (i <= j)
            {
                while (a[i] < x) i++;
                while (a[j] > x) j--;
                if (i <= j)
                {
                    temp = a[i];
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