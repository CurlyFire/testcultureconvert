using CommonTests;
using NUnit.Framework;

namespace NUnitEntryPoint
{
    public class UnitTest1
    {
        [Test]
        public void Test1()
        {
            var tests = new Tests();
            tests.TryDifferentConvertMethods();
        }
    }
}