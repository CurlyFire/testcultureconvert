using System;
using System.Collections.Generic;
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

        public void PrintWorkingAndNonWorking()
        {
            var working = new Dictionary<CultureInfo, string>();
            var notWorking = new Dictionary<CultureInfo, string>();
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (var culture in cultures)
            {
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;

                var stringRepresentation = DateTime.Now.ToString();
                if (DateTime.TryParse(stringRepresentation, out var result))
                {
                    working.Add(culture, stringRepresentation);
                }
                else
                {
                    notWorking.Add(culture, stringRepresentation);

                }

            }

            PrintCultures("WORKING!", working);
            PrintCultures("NOT WORKING!", notWorking);
        }
        
        private void PrintCultures(string title, Dictionary<CultureInfo, string> cultures)
        {
            Console.WriteLine(title);
            foreach (var culture in cultures)
            {
                Console.WriteLine($"\t{culture.Key}:{culture.Value}");
            }
        }
    }
}