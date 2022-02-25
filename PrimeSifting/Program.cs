using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PrimeSifting.Models;

namespace PrimeSifting
{
  public class Program
  {
    public static void Main()
    {
      const int ITERATIONS = 300;
      const int MAXPRIME = 10000;
      Func<int, List<int>>[] FUNCS = {
        Sifter.Sift,
        Sifter.Sift2,
        Sifter.Sift3,
      };

      CallSifter(ITERATIONS, MAXPRIME, FUNCS);
    }

    public static void CallSifter(
      int iterations,
      int maxPrime,
      Func<int, List<int>>[] f
    )
    {
      foreach(var siftCall in f)
      {
        List<int> primeCount = new List<int>();
        List<long> callCountAverage = new List<long>();
        int callCount = 0;

        Console.WriteLine($"{siftCall.Method.Name}:");

        for (int i = 0; i < iterations; i++)
        {
          var watch = new System.Diagnostics.Stopwatch();
          callCount += 1;

          Console.Write($"\tElapsed Time[{callCount}]: ");

          watch.Start();
          primeCount = siftCall(maxPrime);
          watch.Stop();

          Console.WriteLine($"{watch.ElapsedMilliseconds} ms");
          callCountAverage.Add(watch.ElapsedMilliseconds);
        }
        Console.WriteLine($"\tAverage Time: {callCountAverage.Sum() / callCount} ms");
        Console.WriteLine($"\tPrime Count: {primeCount.Count}");
      }
    }
  }
}
