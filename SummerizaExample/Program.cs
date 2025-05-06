using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerizaExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Configure CSV mapping  
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                // Handling quotes in CSV  
                Mode = CsvMode.RFC4180,
                // Corrected: Removed 'EscapeSequence' as it does not exist in CsvConfiguration  
                Escape = '"', // Use the 'Escape' property instead  
            };

            try
            {
                using var reader = new StreamReader("C:\\Users\\user\\Desktop\\Hackathon\\data\\extract_fraude.csv");
                using var csv = new CsvReader(reader, config);

                // Map custom column names if needed  
                csv.Context.RegisterClassMap<CourtCaseMap>();

                // Read all records  
                var records = csv.GetRecords<CourtCase>().ToList();

                // Print the results to verify  
                foreach (var record in records)
                {
                    Console.WriteLine($"Case Number: {record.CaseNumber}");
                    Console.WriteLine($"Search Case Number: {record.SearchCaseNumber}");
                    Console.WriteLine($"Date: {record.Date:yyyy-MM-dd}");
                    Console.WriteLine($"Case Title: {record.CaseTitle}");
                    Console.WriteLine($"Text Length: {record.Text.Length} characters");
                    Console.WriteLine(new string('-', 50));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.Read();
        }
    }
}
