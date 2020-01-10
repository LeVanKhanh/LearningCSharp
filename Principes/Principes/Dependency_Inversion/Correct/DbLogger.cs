using System;

namespace Principes.Dependency_Inversion.Correct
{
    public class DbLogger: ILogger
    {
        public void Infor(string message)
        {
            Console.WriteLine($"DbLogger - Infor: {message}");
        }

        public void Error(Exception exception)
        {
            Console.WriteLine($"DbLogger - LogInfor: {exception.Message}");
        }

        public void Warning(string message)
        {
            Console.WriteLine($"DbLogger - Warning: {message}");
        }
    }
}
