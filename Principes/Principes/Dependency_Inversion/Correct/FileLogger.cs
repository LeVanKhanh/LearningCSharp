using System;

namespace Principes.Dependency_Inversion.Correct
{
    public class FileLogger: ILogger
    {
        public void Infor(string message)
        {
            Console.WriteLine($"FileLogger - Infor: {message}");
        }

        public void Error(Exception exception)
        {
            Console.WriteLine($"FileLogger - LogInfor: {exception.Message}");
        }

        public void Warning(string message)
        {
            Console.WriteLine($"FileLogger - Warning: {message}");
        }
    }
}
