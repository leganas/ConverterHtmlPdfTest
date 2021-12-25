using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterHtmlPdfTest
{
    abstract class HtmlToPdfConverterHelper
    {
        protected HtmlToPdfConverterHelper()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public byte[] ConvertToByteArray(Stream streamToHtml)
        {
            StreamReader reader = new StreamReader(streamToHtml, Encoding.UTF8);
            string html = reader.ReadToEnd();
            return ConvertToByteArray(html);
        }

        public byte[] ConvertToByteArray(string html)
        {
            byte[] result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                ConvertToStream(html, ms);
                result = ms.ToArray();
            }
            return result;
        }

        public MemoryStream ConvertStreamToStream(Stream input)
        {
            byte[] result = ConvertToByteArray(input);
            return new MemoryStream(result);
        }

        public String ConvertToFile(Stream input, String fileName) {
            Console.WriteLine("Запуск конвертации " + fileName);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (FileStream fileStream = File.Create(fileName))
            {
                try {
                    ConvertStreamToStream(input).WriteTo(fileStream);
                }
                catch (Exception e) {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ошибка конвертации : " + e.Message);
                    Console.ResetColor();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Конвертация " + fileName +" завешена за " + stopwatch.ElapsedMilliseconds / 1000 + " сек");
            return fileName + ".pdf";
        }

        public List<String> CovertAll(String[] files, String pathTo)
        {
            List<String> resultList = new List<String>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Task<String>> tasks = new List<Task<String>>();
            foreach (var item in files)
            {
                    FileStream stream = File.OpenRead(item);
                    string file = item.Split("\\").Last();
                    resultList.Add(ConvertToFile(stream, pathTo + "\\" + file + ".pdf")); 
            }
            stopwatch.Stop();
            Console.WriteLine("Конвертация всех файлов завершена за " + stopwatch.ElapsedMilliseconds / 1000 + " сек");
            return resultList;
        }

        public List<String> MultiThreadCovert(String[] files, String pathTo)
        {
            List<String> resultList = new List<String>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Task<String>> tasks = new List<Task<String>>();
            foreach (var item in files)
            {
                Task<String> taskConvert = new Task<String>(() => {
                    FileStream stream = File.OpenRead(item);
                    string file = item.Split("\\").Last();
                    return ConvertToFile(stream, pathTo + "\\"+file + ".pdf");
                });
                tasks.Add(taskConvert);
            }
            foreach (var task in tasks) task.Start();
            Task.WhenAll(tasks);
            foreach (var task in tasks) resultList.Add(task.Result);
            stopwatch.Stop();
            Console.WriteLine("Конвертация всех файлов завершена за " + stopwatch.ElapsedMilliseconds / 1000 + " сек");
            return resultList;
        }


        public abstract void ConvertToStream(String html, Stream outPdf);
    }
}
