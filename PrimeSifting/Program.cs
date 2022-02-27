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
      const int ITERATIONS = 1;
      const int MAXPRIME = 100000;
      Func<int, int>[] FUNCS = {
        // Sifter.Sift,
        // Sifter.Sift2,
        // Sifter.Sift3,
        // Sifter.Sift4a,
        // Sifter.Sift4b,
        Sifter.Sift5,
        Sifter.Sift6,
        Sifter.Sift7,
      };

      CallSifter(ITERATIONS, MAXPRIME, FUNCS);
    }

    public static void CallSifter(
      int iterations,
      int maxPrime,
      Func<int, int>[] f
    )
    {
      Console.WriteLine("Count of Primes up to: {0}", maxPrime);
      foreach(var siftCall in f)
      {
        int primeCount = 0;
        List<long> callCountAverage = new List<long>();
        int callCount = 0;

        Console.WriteLine($"{siftCall.Method.Name}:");

        for (int i = 0; i < iterations; i++)
        {
          var watch = new System.Diagnostics.Stopwatch();
          callCount += 1;

          // Console.Write($"\tElapsed Time[{callCount}]: ");

          watch.Start();
          primeCount = siftCall(maxPrime);
          watch.Stop();

          // Console.WriteLine($"{watch.ElapsedMilliseconds} ms");
          callCountAverage.Add(watch.ElapsedMilliseconds);
        }
        Console.WriteLine($"\tAverage Time: {callCountAverage.Sum() / callCount} ms");
        Console.WriteLine($"\tPrime Count: {primeCount}");
      }
    }
  }
}
