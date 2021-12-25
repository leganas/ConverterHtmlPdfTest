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
//            var convertHelper = new PdfSharpBaseConvertHelper(); // Не потокобезопасен Гавно как оказалась, плюс глючит при конвертации
            // Бесплатная версия iText , нужно разбираться как реализовать конвертацию
            // В ней нет такого простого интерфейса как в uText7, т.к. это старая версия этой библиотеки
            // В те времена когда она еще была бесплатной полностью, НО , она как пишут полность работает
            // Я не нашёл примеров , нужно разбираться как реализовывалась там ранее конвертация
            // Судя по коду который лежит на Github , она до сих  пор поддерживается , и там есть весь нужный функционал
//            var convertHelper = new ITextSharp_LGPL_Helper();  
            var convertHelper = new iText7ConverterHelper(); // Работает хорошо но платная для комерческого использования, если узнают :) 
            convertHelper.ConvertMultiThread(files, @"D:\HTML_to_PDF\pdf");

        }
    }
}
