using System;
using System.Collections.Concurrent;
using static System.Console;

namespace SortExamplesAss7
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n, choice;
            int[] a = new int[20];

            WriteLine("Enter the number of elements: ");
            n = Convert.ToInt32(ReadLine());

            for(i=0; i<n; i++)
            {
                Write("Enter element " + (i + 1) + ": ");
                a[i] = Convert.ToInt32(ReadLine());
            }

            WriteLine("What type of sort would you like to do?");
            WriteLine("1. Bubble Sort");
            WriteLine("2. Quick Sort");
            WriteLine("Enter Choice(1/2): ");

            choice = Convert.ToInt32(ReadLine());

            if(choice == 1)
            {
                BubbleSort(a, n);

            } else if (choice == 2)
            {
                QuickSort(a, n);
            }

            WriteLine("Sorted array: ");
            for(i=0; i<n; i++)
            {
                Write( a[i]+" ");
                
            }
            Console.WriteLine();

        }

        public static void BubbleSort(int[] a, int n)
        {
            int x, j, temp;
            for(x = n-2; x >= 0; x--)
            {
                for(j = 0; j <= x; j++)
                {
                    if(a[j] > a[ j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
        }

        public static void QuickSort(int[] a, int n)
        {
            QuickSort(a, 0, n - 1);
        }

        public static void QuickSort(int[] a, int low, int up)
        {
            if( low>= up ) /*Term Condition : zero or one elemnt in sublist*/
            {
                return;
            }
            int p = Partition(a, low, up);
            QuickSort(a, low, p - 1); //Sort left sublist
            QuickSort(a, p + 1, up);

        }

        private static int Partition(int[] a, int low, int up)
        {
            int temp, i, j, pivot;

            pivot = a[low];

            i = low + 1; // moves from left to right
            j = up; //right to left
            while ( i <= j)
            {
                while( a[i] < pivot && i < up)
                {
                    i++;
                }
                while (a[j] > pivot)
                {
                    j--;
                }

                if (i < j) // swaps a[i] and a[j]
                {
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                    j--;
                }
                else //found right place for pivot
                    break;
            }

            //Proper place for pivot is j
            a[low] = a[j];
            a[j] = pivot;
            return j;
        }

    }
}
