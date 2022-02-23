using System;
using System.Collections.Generic;
using PrimeSifting.Models;

namespace PrimeSifting
{
  public class Program
  {
    public static void Main()
    {
      Action<string> cwl = Console.WriteLine;
      Action<string> cw = Console.Write;

      cw("Enter your number: ");
      int userNumber = int.Parse(Console.ReadLine());
      List<int> primes = Sifter.Sift(userNumber);
      cwl("New Sequence: ");
      foreach (int i in primes)
      {
        cw($"{i} ");
      }
    }
  }
}