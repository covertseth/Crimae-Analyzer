using System;
using System.Collections.Generic;
using System.IO;

namespace CrimeAnalyzer
{
    public static class CrimeStatsLoader
    {
        private static int NumItemsInRow = 8;

        public static List<CrimeStats> Load(string csvDataFilePath)
        {
            List<CrimeStats> crimeStatsList = new List<CrimeStats>();

            try
            {
                using (var reader = new StreamReader(csvDataFilePath))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;

                        var values = line.Split('\t');

                        if (values.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}.");
                        }
                        try
                        {
                            int Name = Int32.Parse(values[0]);
                            int Artist = Int32.Parse(values[1]);
                            int Album = Int32.Parse(values[2]);
                            int Genre = Int32.Parse(values[3]);
                            int Size = Int32.Parse(values[4]);
                            int Time = Int32.Parse(values[5]);
                            int Year = Int32.Parse(values[6]);
                            int Plays = Int32.Parse(values[7]);
                           
                           
                            CrimeStats crimeStats = new CrimeStats(Name, Artist, Album, Genre, Size, Time, Year, Plays
                            crimeStatsList.Add(crimeStats);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invalid data. ({e.Message})");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to open {csvDataFilePath} ({e.Message}).");
            }

            return crimeStatsList;
        }
    }
}
