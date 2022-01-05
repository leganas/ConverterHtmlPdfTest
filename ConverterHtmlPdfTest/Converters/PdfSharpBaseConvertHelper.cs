using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.Core.Entities;

namespace ConverterHtmlPdfTest
{
    /// <summary>
    /// Реализация через библиотеку HtmlRenderer.PdfSharp
    /// Мультипоток не работает, падает с ошибкой конкуренции при формировании CSS коллекции в нутри библиотеки, ГАВНО
    /// Но работает быстро
    /// Бесплатная
    /// </summary>
    class PdfSharpBaseConvertHelper : HtmlToPdfConverterHelper
    {
        public override void ConvertToStream(string html, Stream outPdf)
        { 
            var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
            pdf.Save(outPdf);
        }

        public static void OnStylesheetLoad(object sender, HtmlStylesheetLoadEventArgs e)
        {
            e.SetStyleSheet = @"h1, h2, h3 { color: navy; font-weight:normal; }";
        }
    }
}
