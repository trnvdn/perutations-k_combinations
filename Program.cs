using System;
using System.Diagnostics;

namespace testing;

internal class Program
{
    static void Main(string[] args)
    {
        // Сreate instances 
        Stopwatch stopwatch = new Stopwatch();
        Stopwatch maintimer = new Stopwatch();
        List<string> set = new List<string>();
        int index = 0;
        int m = 0;
        // Catch index of max element for permutations
        Console.WriteLine("Enter index for permutations.Example: '4' 1 2 3 4, '3' 1 2 3 , '2' 1 2");
        index = Pars(index);
        Console.WriteLine("Enter index for k-combinations");
        m = Pars(m);

        
        // Checking this index for data type
     
        // Add elements to list 
        for (int i = 1; i <= index;i++)
        {
            set.Add(Convert.ToString(i));
        }
        // Start the general timer
        maintimer.Start();
        // Start the timer for the permutation algorithm 
        stopwatch.Start();
        // Call a permutation method and gives him arguments
        Permutations(set," ",index,index);
        // Stop the 
        stopwatch.Stop();
        Console.WriteLine("Time for generation permutations: " + stopwatch.Elapsed);
        stopwatch.Reset();
        stopwatch.Start();
        Combinations(set," ",index,m);
        stopwatch.Stop();
        maintimer.Stop();
        Console.WriteLine("Time for calculating k-combinations: " + stopwatch.Elapsed);
        Console.WriteLine("Total time: "+maintimer.Elapsed);
        void Permutations(List<string> sets, string prefix, int n, int length)
        {
            if (length == 1)
            {
                
                for (int j = 0; j < n; j++)
                {
                    string p = prefix + set[j];
                    string[] elems = p.Split(" ");
                    int newindex = elems.Distinct().ToArray().Length - 1;
                    if (elems.Length - 1 == newindex)
                    {
                        Console.WriteLine(p);
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    string p = set[i] + prefix;
                    string[] elems = p.Split(" ");
                    int newindex = elems.Distinct().ToArray().Length - 1;
                    if (elems.Length-1 == newindex)
                    {
                        Permutations(set, prefix + set[i] + " ", n, length - 1);
                    }
                }
            }
            
        }
        void Combinations(List<string> set, string prefix, int n, int m)
        {
            stopwatch.Start();
            int answ = Factorial(n + m - 1) / (Factorial(m) * Factorial(n - 1));
            Console.WriteLine("\nNumber of combinations:");
            Console.WriteLine(answ);
        }
        int Factorial(int i)
        {
            if (i > 1)
            {
                return i * Factorial(i - 1);
            }
            else
            {
                return i;
            }
        }

        int Pars(int x)
        {
            bool succes = int.TryParse(Console.ReadLine(), out x);
            while (!succes)
            {
                Console.WriteLine("Enter a num!");
                succes = int.TryParse(Console.ReadLine(), out x);
            }

            return x;
        }
    }
}