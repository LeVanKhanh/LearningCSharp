using System;

namespace CSharp8.Indices_And_Ranges
{
    public static class IndicesAndRanges
    {
        private static readonly string[] words =
        {
                        // index from start    index from end
            "The",      // 0                   ^9
            "quick",    // 1                   ^8
            "brown",    // 2                   ^7
            "fox",      // 3                   ^6
            "jumped",   // 4                   ^5
            "over",     // 5                   ^4
            "the",      // 6                   ^3
            "lazy",     // 7                   ^2
            "dog"       // 8                   ^1
        };              // 9 (or words.Length) ^0

        public static void Print()
        {
            //You can retrieve the last word with the ^1 index
            Console.WriteLine($"The last word is {words[^1]}");

            //creates a subrange with the words "quick", "brown", and "fox".
            var quickBrownFox = words[1..4];
            Console.WriteLine("A subrange with the words 'quick', 'brown', and 'fox'");

            foreach (var word in quickBrownFox)
            {
                Console.Write("{0} ", word);
            }

            Console.WriteLine();
            //creates a subrange with "lazy" and "dog".
            var lazyDog = words[^2..^0];
            Console.WriteLine("a subrange with 'lazy' and 'dog'");

            foreach (var word in lazyDog)
            {
                Console.Write("{0} ", word);
            }

            Console.WriteLine();
            Range phrase = ..;
            var allWords = words[phrase]; // contains "The" through "dog".
            Console.WriteLine("'phrase = ..'contains 'The' through 'dog'.");
            foreach (var word in allWords)
            {
                Console.Write("{0} ", word);
            }

            Console.WriteLine();
            phrase = ..4;
            var firstPhrase = words[phrase]; // contains "The" through "fox"
            Console.WriteLine("'phrase = ..4' contains 'The' through 'fox'.");
            foreach (var word in firstPhrase)
            {
                Console.Write("{0} ", word);
            }

            Console.WriteLine();
            phrase = 6..;
            var lastPhrase = words[phrase]; // contains "the", "lazy" and "dog"
            Console.WriteLine("'phrase = 6..' contains 'The', 'lazy' and 'dog'.");
            foreach (var word in lastPhrase)
            {
                Console.Write("{0} ", word);
            }

            Console.WriteLine();
        }
    }
}
