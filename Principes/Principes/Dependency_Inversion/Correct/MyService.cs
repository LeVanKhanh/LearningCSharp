namespace Principes.Dependency_Inversion.Correct
{
    public class MyService
    {
        private readonly ILogger _fileLogger;
        // This class is tightly coupled with FileLogger
        public MyService(ILogger fileLogger)
        {
            _fileLogger = fileLogger;
        }

        public void DoSomething()
        {
            _fileLogger.Infor("MyService do something");
        }
    }
}
