using System;
using System.Globalization;

namespace CommonTests
{
    public class Tests
    {
        public void ConvertDatetimeFromStringAndBackAgain()
        {
            var cultureInfo = CultureInfo.GetCultureInfo("fr-CA");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            var stringRepresentation = DateTime.Now.ToString();
            var date = DateTime.Parse(stringRepresentation);
        }
    }
}