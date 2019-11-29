using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static void BubbleSort(int[] list)
        {
            int len = list.Length;
            for (int i = 1; i < len - 1; i++)
            {
                for (int j = 1; j < len; j++)
                {
                    if (list[j] < list[j - 1])
                    {
                        int temp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = temp;
                    }
                }
            }

        }

        public static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1) 
                return unsorted;
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }

            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);

        }

        public static List<int> Merge(List<int> left, List<int> right)
        {
           List<int> result = new List<int>();

           while (left.Count >0 || right.Count >0)
           {
               if (left.Count > 0 && right.Count > 0)
               {
                   if (left.First() <= right.First())
                   {
                       result.Add(left.First());
                       left.Remove(left.First());
                   }
                   else
                   {
                       result.Add(right.First());
                       right.Remove(right.First());
                   }
               }
               else if (left.Count > 0)
               {
                   result.Add(left.First());
                   left.Remove(left.First());
               }
               else if (right.Count > 0)
               {
                   result.Add(right.First());
                   right.Remove(right.First());
               }
           }

           return result;
        }

        static void Main(string[] args)
        {
            int[] list = { 2, 3, 1, 6, 2, 9, 4, 1, 6, 7, 4 };
            Console.WriteLine("Before Sort");
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();

            BubbleSort(list);
            Console.WriteLine("After Sort");
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }

            Console.ReadLine();

            //Merge Sort
            List<int> unsorted = new List<int>(); 
            List<int> sorted;

            Random random = new Random();

            Console.WriteLine("Original array elements: ");
            for (int i = 0; i < 10; i++)
            {
                unsorted.Add(random.Next(0,100));
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();

            sorted = MergeSort(unsorted);
            
            Console.WriteLine("Sorted array elements: ");
            foreach (int x in sorted)
            {
                Console.Write(x+ " ");
            }
            Console.Write("\n");

        }
    }
}
