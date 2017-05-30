using System;
using System.Collections.Generic;
using System.Linq;

namespace AandDS_Lab_4
{
    class Program
    {
        /* Существует два варианта: least significant digit (LSD) и most significant digit (MSD). 
        При LSD сортировке, сначала сортируются младшие разряды, затем старшие. При MSD сортировке все наоборот. 
        При LSD сортировке получается следующий порядок: короткие ключи идут раньше длинных, ключи одного размера 
        сортируются по алфавиту. При MSD сортировке получается алфавитный порядок, который подходит для сортировки строк. 
        Например «b, c, d, e, f, g, h, i, j, ba» отсортируется как «b, ba, c, d, e, f, g, h, i, j» */
        static string charactersForTickets = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        static Random r = new Random();

        static void Main(string[] args)
        {
            int countOfTickets = 100;
            int lenghtOfTicket = 8;
            List<string> listOfTickets = GenerateTicketsList(countOfTickets, lenghtOfTicket);
            List<string> listOfTicketsSorted = RadixSort(listOfTickets);

            for (int i = 0; i < countOfTickets; i++)
            {
                Console.WriteLine(
                    $"{((i + 1).ToString() + ')').PadLeft(countOfTickets.ToString().Length + 1)} {listOfTickets[i]} {listOfTicketsSorted[i]} ({i+1}");
            }
            Console.Write("\n\n");
            //-------------------rearrange---------------------//

           int n, m;
            Console.Write("n(number of elements):".PadRight("n(number of elements):".Length+1));
            n = int.Parse(Console.ReadLine());
            Console.Write("m(range of elements:".PadRight("n(number of elements):".Length + 1));
            m = int.Parse(Console.ReadLine());
            int pad = m.ToString().Length + 1;
            int[] array = IntArrayGenerator(n, m);
            int[] countKeysEqual = CountKeysEqual(array, n, m);
            int[] countKeysLess = CountKeysLess(countKeysEqual, m);
            int[] rearengment = Rearengment(array, countKeysLess, n, m);

            Console.WriteLine("array");
            OutputIntArray(array, pad);
            Console.WriteLine("countKeysEqual");
            OutputIntArray(countKeysEqual, pad);
            Console.WriteLine("countKeysLess");
            OutputIntArray(countKeysLess, pad);
            Console.WriteLine("rearengment");
            OutputIntArray(rearengment, pad);
        }

        static List<string> GenerateTicketsList(int lenghtOfList, int lenghtOfTicket)
        {
            List<string> listOfTickets = new List<string>();
            for (int i = 0; i < lenghtOfList; i++)
            {
                listOfTickets.Add(GenerateTicket(lenghtOfTicket));
            }
            return listOfTickets;
        }

        static string GenerateTicket(int l)
        {
            string ticket = "";
            for (int i = 0; i < l; i++)
            {
                ticket += charactersForTickets[r.Next(charactersForTickets.Length)];
            }
            return ticket;
        }

        static List<string> RadixSort(List<string> unsortedList)
        {
            List<List<string>> tempList = new List<List<string>>(unsortedList[0].Length);
            List<string> sortedList = new List<string>();
            List<string> copyOfSortedList = new List<string>(unsortedList);
            for (int i = unsortedList[0].Length - 1; i >= 0; i--)
            {
                if (i != unsortedList[0].Length - 1) copyOfSortedList = sortedList;
                tempList.Clear();
                for (int j = 0; j < charactersForTickets.Length; j++)
                {
                    tempList.Add(new List<string>());
                }

                for (int j = 0; j < charactersForTickets.Length; j++)
                {
                    for (int k = 0; k < copyOfSortedList.Count; k++)
                    {
                        if (copyOfSortedList[k][i] == charactersForTickets[j])
                        {
                            tempList[j].Add(copyOfSortedList[k]);
                        }
                    }
                }

                sortedList = tempList.SelectMany(x => x).ToList();
            }

            return sortedList;
        }

        //-------------------rearrange---------------------//


            /*rearrange для чисел разбивает по битам, а для строк посимовльно */
        static int[] IntArrayGenerator(int n, int m)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = r.Next(m + 1);
            }
            return array;
        }

        static int[] CountKeysEqual(int[] array, int n, int m)
        {
            int[] equal = new int[m + 1];

            Array.Clear(equal, 0, m);

            for (int i = 0; i < n; i++)
            {
                equal[array[i]]++;
            }

            return equal;
        }

        static int[] CountKeysLess(int[] array, int m)
        {
            int[] less = new int[m + 1];

            Array.Clear(less, 0, m);

            for (int i = 1; i <= m; i++)
            {
                less[i] = less[i - 1] + array[i - 1];
            }

            return less;
        }

        static int[] Rearengment(int[] array, int[] lessKeysArray, int n, int m)
        {
            int[] next = new int[m + 1];
            int[] sorted = new int[n];

            for (int i = 0; i <= m; i++)
            {
                next[i] = lessKeysArray[i] + 1;
            }

            for (int i = 0; i < n; i++)
            {
                int key = array[i];
                int index = next[key];
                sorted[index - 1] = array[i];
                next[key]++;
            }

            return sorted;
        }

        static void OutputIntArray(int[] array, int pad)
        {
            //int maxValue = array.OrderByDescending(x => x).First();
            foreach (int i in array)
            {
                Console.Write($"{i.ToString().PadLeft(pad)} ");
                //Console.Write($"{i.ToString().PadLeft(maxValue.ToString().Length+1)} ");
            }
            Console.WriteLine();
        }
    }
}