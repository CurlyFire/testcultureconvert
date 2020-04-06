using CommonTests;
using NUnit.Framework;

namespace NUnitEntryPoint
{
    public class UnitTest1
    {
        [Test]
        public void TryConvertDatetimeFromStringAndBackAgainUsingArgument()
        {
            var tests = new Tests(TestContext.Out);
            Assert.IsTrue(tests.TryConvertDatetimeFromStringAndBackAgainUsingArgument());
        }
        [Test]
        public void TryConvertDatetimeFromStringAndBackAgainUsingDefaultThreadCulture()
        {
            var tests = new Tests(TestContext.Out);
            Assert.IsTrue(tests.TryConvertDatetimeFromStringAndBackAgainUsingDefaultThreadCulture());
        }
    }
}