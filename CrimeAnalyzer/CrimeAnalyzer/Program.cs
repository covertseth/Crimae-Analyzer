using System;
using System.Collections.Generic;
using System.Linq;

namespace CrimeAnalyzer
{
    class MainClass
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Welcome to the Crime Analyzer <CrimeData.csv> <report.txt>");
                Environment.Exit(1);
            }
            string csvDataFilePath = args[0];
            string reportFilePath = args[1];

            List<CrimeStats> crimeStatsList = null;
            try
            {
                crimeStatsList = CrimeStatsLoader.Load(csvDataFilePath);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var report = CrimeStatsReport.GenerateText(crimeStatsList);

            try
            {
                System.IO.File.WriteAllText(reportFilePath, report);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
        }
    }
}