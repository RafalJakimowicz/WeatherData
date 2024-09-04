using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WeatherData
{
    public class Interafce_CSV
    {
        public Interafce_CSV() { }

        /// <summary>
        /// list od data structures
        /// </summary>
        public List<CSV_Data> Data { get; set; }

        /// <summary>
        /// Read from file passed in parameter
        /// </summary>
        /// <param name="_path">path to csv file</param>
        /// <returns>List of CSV_Data objects in list </returns>
        public List<CSV_Data> GetDataFromFile(string _path)
        {
            List<CSV_Data> _data = new List<CSV_Data>();
            string[] lines = File.ReadAllLines(_path);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                CSV_Data csvd = new CSV_Data();
                csvd.TimeString = data[0];
                csvd.Temperature = float.Parse(data[1]);
                csvd.Humidity = float.Parse(data[2]);
                csvd.DustDensity = float.Parse(data[3]);
                _data.Add(csvd);
            }
            return _data;
        }

        /// <summary>
        /// writes CSV_Data list to file
        /// </summary>
        /// <param name="_data">List of CSV_Data structures</param>
        /// <param name="_path">Path to file</param>
        public void writeToFile(List<CSV_Data> _data, string _path)
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                foreach (CSV_Data csvd in _data)
                {
                    string line = $"{csvd.TimeString},{csvd.Temperature},{csvd.Humidity},{csvd.DustDensity}";
                    sw.WriteLine(line);
                }
            }
        }
    }

    /// <summary>
    /// Data structure that have labeled data of csv file
    /// </summary>
    public struct CSV_Data
    {
        /// <summary>
        /// Time string in format dd/mm/yyyy HH/MM
        /// </summary>
        public string TimeString { get; set; }
        /// <summary>
        /// float containts Temparature has 1 floatng point
        /// </summary>
        public float Temperature { get; set; }
        /// <summary>
        /// float contains humidity has one floating point
        /// </summary>
        public float Humidity { get; set; }
        /// <summary>
        /// float has humidity has one floating point represents ug/m3
        /// </summary>
        public float DustDensity { get; set; }
    }
}
