using Principes.Liskov_Substitution.Correct;
using Principes.Liskov_Substitution.Incorrect;
using System;

namespace Principes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lsp_Incorrect_Test test = new Lsp_Incorrect_Test();
            //test.Test();

            Lsp_Correct_Test test = new Lsp_Correct_Test();
            test.Test();

        }
    }
}
