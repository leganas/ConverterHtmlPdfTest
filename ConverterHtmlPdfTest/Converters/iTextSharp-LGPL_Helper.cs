using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterHtmlPdfTest.Converters
{
    /// <summary>
    /// Бесплатная версия iText , до определённой версии он был на LGPL лицензии
    /// Нужно разбираться как тут конвертировать пока не реализовано
    /// </summary>
    class ITextSharp_LGPL_Helper : HtmlToPdfConverterHelper
    {
        public override void ConvertToStream(string html, Stream outPdf)
        {
            throw new NotImplementedException();
        }
    }
}
