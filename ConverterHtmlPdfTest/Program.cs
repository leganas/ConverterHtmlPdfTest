using ConverterHtmlPdfTest.Converters;
using System;
using System.IO;

namespace ConverterHtmlPdfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"D:\HTML_to_PDF\html", "*.html");
//            var convertHelper = new PdfSharpBaseConvertHelper(); // Не потокобезопасен
//            var convertHelper = new ITextSharp_LGPL_Helper();  // Бесплатная версия iText , нужно разбираться как реализовать конвертацию
            var convertHelper = new iText7ConverterHelper(); // Работает хорошо но платный для комерческого использования
            convertHelper.MultiThreadCovert(files, @"D:\HTML_to_PDF\html");

        }
    }
}
