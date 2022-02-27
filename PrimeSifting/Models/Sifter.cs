using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeSifting.Models
{
  public class Sifter
  {
    public static int Sift(int input)
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

      return primes.Count;
    }

    public static int Sift2(int input)
    {
      List<int> primes = Enumerable.Range(2, input-1).ToList();
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
      return primes.Count;
    }

    public static int Sift3(int input)
    {
      int z = input;
      List<int> primes = new List<int>() { 2 };

      for (int x = 3; x <= z; x++)
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

      return primes.Count;
    }

    public static int Sift4a(int input)
    {
      int y = 3;
      int z = input;
      List<int> primes = new List<int>() { 2 };

      while (y <= z)
      {
        primes.Add(y);
        y += 2;
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

      return primes.Count;
    }

    public static int Sift4b(int input)
    {
      int y = 3;
      int z = input;
      List<int> primes = new List<int>() { 2 };

      while (y <= z)
      {
        primes.Add(y);
        y += 2;
      }

      int x = 3;
      while (x <= z)
      {
        int i = x;
        while (i <= z)
        {
          if (i % x == 0 && i != x)
          {
            primes.Remove(i);
          }
          i++;
        }
        x++;
        z = primes.Last();
      }

      return primes.Count;
    }

    public static int Sift5(int input)
    {
      bool[] primes = new bool[input+1];
      Array.Fill(primes, true);

      for (int x = 0; x <= input; x++)
      {
        if (x == 0 || x == 1)
        {
          primes[x] = false;
          continue;
        }

        for (int i = x; i <= input; i++)
        {
          if (i % x == 0 && x != i)
          {
            primes[i] = false;
          }
        }
      }

      return Array.FindAll(primes, x => x).Length;
    }

    public static int Sift6(int input)
    {
      int primes = input;

      for (int x = input; x >= 2; x--)
      {
        for (int i = 2; i <= primes; i++)
        {
          if (x % i == 0 && x != i)
          {
            primes -= 1;
            break;
          }
        }
      }
      
      // A prime of 1 does not count :)
      return primes - 1;
    }

    public static int Sift7(int input)
    {
      List<int> primes = Enumerable.Range(2, input-1).ToList();
      int z = input;

      for (int x = input; x >= 2; x--, z = primes.Last())
      {
        for (int i = 2; i <= z; i++)
        {
          if (x % i == 0 && x != i)
          {
            primes.Remove(x);
            break;
          }
        }
      }
      return primes.Count;
    }
  }
}
