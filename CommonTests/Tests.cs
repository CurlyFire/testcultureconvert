using System;
using System.Collections.Generic;
using System.Globalization;

namespace CommonTests
{
    public class Tests
    {
        private const string CULTURE_NAME = "fr-CA";
        public void TryDifferentConvertMethods()
        {

            try
            {
                ConvertDatetimeFromStringAndBackAgainUsingDefaultThreadCulture();
                Console.WriteLine("WORKED!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"FAILED: {e.Message}");
            }

            try
            {
                ConvertDatetimeFromStringAndBackAgainUsingArgument();
                Console.WriteLine("WORKED!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"FAILED!: {e.Message}");
            }

        }

        private void ConvertDatetimeFromStringAndBackAgainUsingDefaultThreadCulture()
        {
            var cultureInfo = CultureInfo.GetCultureInfo(CULTURE_NAME);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            var stringRepresentation = DateTime.Now.ToString();
            Console.WriteLine($"Trying to convert {stringRepresentation} using CultureInfo.DefaultThreadCurrentCulture and CultureInfo.DefaultThreadCurrentUICulture...");
            var date = DateTime.Parse(stringRepresentation);
        }

        private void ConvertDatetimeFromStringAndBackAgainUsingArgument()
        {
            var cultureInfo = CultureInfo.GetCultureInfo(CULTURE_NAME);

            var stringRepresentation = DateTime.Now.ToString(cultureInfo);
            Console.WriteLine($"Trying to convert {stringRepresentation} using cultureInfo as an argument to ToString and Parse...");
            var date = DateTime.Parse(stringRepresentation, cultureInfo);
        }
        
        private void PrintCultures(string title, Dictionary<CultureInfo, string> cultures)
        {
            Console.WriteLine(title);
            foreach (var culture in cultures)
            {
                Console.WriteLine($"\t{culture.Key}:{culture.Value}");
            }
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
    }
}