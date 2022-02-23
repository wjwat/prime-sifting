using System.Collections.Generic;
using System.Linq;

namespace PrimeSifting.Models
{
  public class Sifter
  {
    public static List<int> Sift(int input)
    {
      List<int> primes = Enumerable.Range(2, input - 1).ToList();
      List<int> seq = Enumerable.Range(2, input - 1).ToList();

      foreach (int item in seq)
      {
        int[] check = new int[] { 2, 3, 5, 7 };

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
  }
}