namespace Principes.Dependency_Inversion.Correct
{
    public class MyService
    {
        private readonly ILogger _fileLogger;
        // This class is depend on ILogger instead of any concreate Logger as: FileLogger, DbLogger or WindowLogger
        // We can inject any kind of ILogger into this class
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
