using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows;
using SweetControl_2._0.Models;
using System.Text.RegularExpressions;

namespace SweetControl_2._0
{
    class JsonFileWorker
    {
        /// <summary>
        /// Singleton for using in another classes
        /// </summary>
        private static JsonFileWorker instance;
        public static JsonFileWorker getInstance()
        {
            if (instance == null)
                instance = new JsonFileWorker();
            return instance;
        }

        // Events that can be used for notification (not currently used)
        event Action fileWriteNotify;
        event Action fileReadNotify;
        event Action fileRemoveLineNotify;

        // Async writing a new result to file
        public async void WriteToFile(string Resultation, int CurrentDayIndex)
        {
            using (FileStream fs = new FileStream("results.json", FileMode.Append))
            {
                Result myRes = new Result(Math.Round(decimal.Parse(Resultation), 1), CurrentDayIndex);
                await JsonSerializer.SerializeAsync<Result>(fs, myRes);

                byte[] array = System.Text.Encoding.Default.GetBytes("\n");
                fs.Write(array, 0, array.Length);

                if (fileWriteNotify != null)
                    fileWriteNotify.Invoke();
            }
        }

        // Delete selected result in file
        public void RemoveFileLine(string date, string time, string dayIndex, decimal result)
        {
            var tempFile = Path.GetTempFileName();
            
            // remove the unnecessary line
            var linesToKeep = File.ReadLines("results.json").Where(l => l != $"{{\"Date\":\"{date}\",\"Time\":\"{time}\",\"CurrentDayIndex\":{dayIndex},\"Resultation\":{result}}}");

            // overwriting the file
            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete("results.json");
            File.Move(tempFile, "results.json");

            if (fileRemoveLineNotify != null)
                fileRemoveLineNotify.Invoke();
            else
            {

            }
        }

        // Dlete empty lines in file
        public void RemoveEmptyLine()
        {
            var tempFile = Path.GetTempFileName();
    
            var linesToKeep = File.ReadLines("results.json").Where(l => !string.IsNullOrWhiteSpace(l));

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete("results.json");
            File.Move(tempFile, "results.json");

            if (fileRemoveLineNotify != null)
                fileRemoveLineNotify.Invoke();
            else
                MessageBox.Show("Delete Error");
        }

        // Edit result in file
        public void EditResultFileLine(string date, string time, string dayIndex, decimal result, decimal newResult)
        {
            string filename = @"results.json";
            StringBuilder resultStr = new StringBuilder();

            if (System.IO.File.Exists(filename))
            {
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        // search the required string
                        if (line == $"{{\"Date\":\"{date}\",\"Time\":\"{time}\",\"CurrentDayIndex\":{dayIndex},\"Resultation\":{result}}}")
                        {
                            string newLine = String.Concat(line, Environment.NewLine);

                            // Divide the string and work with the desired part
                            // so that other numbers do not change (for example, date)
                            string[] words = newLine.Split(',');
                            words[3] = words[3].Replace($"{result}", $"{newResult}");
                            string resultReplace = "";

                            // Merge the string back
                            for (int i = 0;  i < words.Length; i++)
                            {
                                if ( i == words.Length - 1)
                                    resultReplace += $"{words[i]}";
                                else
                                    resultReplace += $"{words[i]},";
                            }
                            newLine = resultReplace;

                            resultStr.Append(newLine);
                        }
                    }
                }
            }

            StreamReader reader = new StreamReader("results.json");
            string content = reader.ReadToEnd();
            reader.Close();

            // replace old line with new 
            content = Regex.Replace(content, $"{{\"Date\":\"{date}\",\"Time\":\"{time}\",\"CurrentDayIndex\":{dayIndex},\"Resultation\":{result}}}",
                resultStr.ToString());

            StreamWriter writer = new StreamWriter("results.json");
            writer.Write(content);
            writer.Close();

            // Dlete empty lines in file
            RemoveEmptyLine();
        }

        // Reading all results from file
        public Result[] ReadingFromFile()
        {
            List<Result> resultCollection = new List<Result>();

            resultCollection.Clear();
            Result restoreRes = new Result();
    
            using (FileStream fs = new FileStream("results.json", FileMode.OpenOrCreate))
            {
                string line;
                using (var f = new StreamReader(fs))
                {
                    while ((line = f.ReadLine()) != null)
                    {
                        // deserialize and add to list
                        restoreRes = JsonSerializer.Deserialize<Result>(line);
                        resultCollection.Add(restoreRes);
                    }
                }
                if (fileReadNotify != null)
                    fileReadNotify.Invoke();
            }

            return resultCollection.ToArray();
        }

    }
}
