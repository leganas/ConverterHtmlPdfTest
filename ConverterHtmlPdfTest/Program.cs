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
//            var convertHelper = new PdfSharpBaseConvertHelper(); // Не потокобезопасен Гавно как оказалась, можно скачать исходники и сделать синхронизацию , но это кусок работы
//            var convertHelper = new ITextSharp_LGPL_Helper();  // Бесплатная версия iText , нужно разбираться как реализовать конвертацию
            var convertHelper = new iText7ConverterHelper(); // Работает хорошо но платная для комерческого использования, если узнают :) 
            convertHelper.ConvertMultiThread(files, @"D:\HTML_to_PDF\pdf");

        }
    }
}
