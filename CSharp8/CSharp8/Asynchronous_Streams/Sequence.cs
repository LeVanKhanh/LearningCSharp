using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp8.Asynchronous_Streams
{
    public static class Sequence
    {
        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

        public static async void PrintSequence()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }
        }
    }
}
