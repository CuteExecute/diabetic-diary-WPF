using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows;

namespace SweetControl_2._0
{
    class JsonFileWorker
    {
        event Action FileWriteNotify;
        event Action FileReadNotify;

        List<WrapperResult> ResultCollection = new List<WrapperResult>(); 

        // Класс который заворачивает данные в обертку

        // асинхронная запись в файл
        public async void WriteToFile()
        {
            using (FileStream fs = new FileStream("results.json", FileMode.Append))
            {
                WrapperResult myRes = new Result(7.5, 1);
                await JsonSerializer.SerializeAsync<WrapperResult>(fs, myRes);

                byte[] array = System.Text.Encoding.Default.GetBytes("\n");
                fs.Write(array, 0, array.Length);

                if (FileWriteNotify != null)
                    FileWriteNotify.Invoke();
            }
        }

        // асинхронное чтение из файла
        public async void ReadingFromFile()
        {
            ResultCollection.Clear();
            WrapperResult restoreRes = new WrapperResult();

            using (FileStream fs = new FileStream("results.json", FileMode.OpenOrCreate))
            {
                string line;
                using (var f = new StreamReader(fs))
                {
                    while ((line = f.ReadLine()) != null)
                    {
                        // что-нибудь делаем с прочитанной строкой line например десириализуем и запихиваем в список
                        restoreRes = JsonSerializer.Deserialize<WrapperResult>(line);
                        ResultCollection.Add(restoreRes);
                    }
                }
                //WrapperResult restoreRes = await JsonSerializer.DeserializeAsync<WrapperResult>(fs);
                //ResultCollection.Add((Result)restoreRes);

                if (FileReadNotify != null)
                    FileReadNotify.Invoke();
            }

            //MessageBox.Show(ResultCollection[1].Time); // OK B)
        }

        //static WrapperResult myRes = new Result(7.5, 1);
        //public static string json = JsonSerializer.Serialize<WrapperResult>(myRes);
        //public static WrapperResult restoreRes = JsonSerializer.Deserialize<WrapperResult>(json);
    }
}
