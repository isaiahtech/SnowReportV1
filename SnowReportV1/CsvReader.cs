using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SnowReportV1
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public Mountain[] ReadFirstNMountains(int nMountains)
        {
            Mountain[] mountains = new Mountain[nMountains];

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                // read header line
                sr.ReadLine();

                for (int i = 0; i < nMountains; i++)
                {
                    string csvLine = sr.ReadLine();
                    mountains[i] = ReadMountainFromCsvLine(csvLine);
                }
            }
            
            return mountains;
        }

        public Mountain ReadMountainFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(new char[] { ',' });

            string name = parts[0];
            string state = parts[1];
            //int snow = parts[2];

            return new Mountain(name, state);
        }
    }
}
