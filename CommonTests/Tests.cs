using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CommonTests
{
    public class Tests
    {
        private const string CULTURE_NAME = "fr-CA";

        private readonly TextWriter _output;

        public Tests(TextWriter output)
        {
            _output = output;
        }

        public bool TryConvertDatetimeFromStringAndBackAgainUsingDefaultThreadCulture()
        {
            var cultureInfo = CultureInfo.GetCultureInfo(CULTURE_NAME);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            var stringRepresentation = DateTime.Now.ToString();
            _output.WriteLine($"Trying to convert {stringRepresentation} using CultureInfo.DefaultThreadCurrentCulture and CultureInfo.DefaultThreadCurrentUICulture...");
            try
            {
                DateTime.Parse(stringRepresentation);
                _output.WriteLine("WORKED!");
                return true;
            }
            catch (Exception e)
            {
                _output.WriteLine($"FAILED: {e.Message}");
                return false;
            }
        }

        public bool TryConvertDatetimeFromStringAndBackAgainUsingArgument()
        {
            var cultureInfo = CultureInfo.GetCultureInfo(CULTURE_NAME);

            var stringRepresentation = DateTime.Now.ToString(cultureInfo);
            _output.WriteLine($"Trying to convert {stringRepresentation} using cultureInfo as an argument to ToString and Parse...");
            try
            {
                DateTime.Parse(stringRepresentation, cultureInfo);
                _output.WriteLine("WORKED!");
                return true;
            }
            catch (Exception e)
            {
                _output.WriteLine($"FAILED: {e.Message}");
                return false;
            }
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