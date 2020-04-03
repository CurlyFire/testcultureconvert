using CommonTests;

namespace ConsoleEntryPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests = new Tests();
            tests.PrintWorkingAndNonWorking();
        }
    }
}