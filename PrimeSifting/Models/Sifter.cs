using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeSifting.Models
{
  public class Sifter
  {
    public static List<int> Sift(int input)
    {
      List<int> primes = Enumerable.Range(2, input - 1).ToList();
      List<int> seq = new List<int>(primes);
      int[] check = new int[] { 2, 3, 5, 7 };

      foreach (int item in seq)
      {
        for (int i = 0; i < check.Length; i++)
        {
          if (item % check[i] == 0 && item != check[i])
          {
            primes.Remove(item);
            break;
          }
        }
      }

      return primes;
    }

    public static List<int> Sift2(int input)
    {
      List<int> primes = Enumerable.Range(2, input).ToList();
      int z = input;

      for (int x = 2; x <= z; x++, z = primes.Last())
      {
        for (int i = x; i <= z; i++)
        {
          if (i % x == 0 && x != i)
          {
            primes.Remove(i);
          }
        }
      }
      return primes;
    }

    public static List<int> Sift3(int input)
    {
      int z = input;
      List<int> primes = new List<int>() { 2 };

      for (int x = 3; x < z; x++)
      {
        if (x % 2 != 0)
        {
          primes.Add(x);
        }
      }

      for (int x = 3; x <= z; x++, z = primes.Last())
      {
        for (int i = x; i <= z; i++)
        {
          if (i % x == 0 && x != i)
          {
            primes.Remove(i);
          }
        }
      }
      return primes;
    }
  }
}
