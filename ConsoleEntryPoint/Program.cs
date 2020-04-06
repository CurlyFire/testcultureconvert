using System;
using CommonTests;

namespace ConsoleEntryPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests = new Tests(Console.Out);
            tests.TryConvertDatetimeFromStringAndBackAgainUsingArgument();
            tests.TryConvertDatetimeFromStringAndBackAgainUsingDefaultThreadCulture();
        }
    }
}