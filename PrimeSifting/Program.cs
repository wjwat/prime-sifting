using System;
using System.Collections.Generic;
using System.Diagnostics;
using PrimeSifting.Models;

namespace PrimeSifting
{
  public class Program
  {
    public static void Main()
    {
      for (int i = 0; i < 3; i++)
      {
        int test = 100000;
        var watch = new System.Diagnostics.Stopwatch();
        var watch2 = new System.Diagnostics.Stopwatch();

        watch.Start();
        List<int> x = Sifter.Sift(test);
        watch.Stop();

        Console.WriteLine($"{x.Count}");
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

        watch2.Start();
        List<int> y = Sifter.Sift2(test);
        watch2.Stop();

        Console.WriteLine($"{y.Count}");
        Console.WriteLine($"Execution Time: {watch2.ElapsedMilliseconds} ms");
      }
    }
  }
}
