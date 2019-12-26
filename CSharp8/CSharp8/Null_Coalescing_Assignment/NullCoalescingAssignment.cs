using System;
using System.Collections.Generic;

namespace CSharp8.Null_Coalescing_Assignment
{
    public static class NullCoalescingAssignment
    {
        public static void Print()
        {
            List<int>? numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);// Set i = 17
            numbers.Add(i ??= 20);// i == 17

            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
            Console.WriteLine(i);  // output: 17
        }
    }
}
