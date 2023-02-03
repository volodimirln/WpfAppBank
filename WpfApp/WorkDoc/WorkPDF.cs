using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.IO;
using System.Text;


namespace WpfApp.WorkDoc
{
    class ClassWorkPDF
    {
        public void createPDF()
        {
            Document document = new Document();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            BaseFont baseFont = BaseFont.CreateFont("Fonts\\Montserrat-Black.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont mainfont = BaseFont.CreateFont("Fonts\\Montserrat-Medium.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 35f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font mfont = new iTextSharp.text.Font(mainfont, 12f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font m2font = new iTextSharp.text.Font(mainfont, 18f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font m3font = new iTextSharp.text.Font(mainfont, 22f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font m4font = new iTextSharp.text.Font(baseFont, 16f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font m5font = new iTextSharp.text.Font(mainfont, 16f, iTextSharp.text.Font.NORMAL);
            using (FileStream stream = new FileStream(@"Report.pdf", FileMode.Create))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                String phrase = "Отчет";
                String date = "Время формирования отчета: " + DateTime.Now.ToString();

                String empty = " ";

                String name = "Для - Администратор";
                String line1 = new string('\u2500', 140);

                document.Add(new iTextSharp.text.Paragraph(phrase, font));
                document.Add(new iTextSharp.text.Paragraph(empty, mfont));
                document.Add(new iTextSharp.text.Paragraph("Plantagenet", mfont));
                document.Add(new iTextSharp.text.Paragraph("Системный отчет №01", mfont));
                document.Add(new iTextSharp.text.Paragraph(name, mfont));
                document.Add(new iTextSharp.text.Paragraph(date, mfont));


                document.Add(new iTextSharp.text.Paragraph(empty, mfont));
                document.Add(new iTextSharp.text.Paragraph(empty, mfont));

                document.Add(new iTextSharp.text.Paragraph("Статистика", m3font));
                document.Add(new iTextSharp.text.Paragraph("Кратко и по делy", m2font));
                document.Add(new iTextSharp.text.Paragraph("Траты за месяц - 15 943,00 ₽", m4font));
                document.Add(new iTextSharp.text.Paragraph("Выручка за месяц - 18 754,00 ₽", m4font));
                document.Add(new iTextSharp.text.Paragraph(empty, mfont));
                document.Add(new iTextSharp.text.Paragraph("Исходящие платежи", m2font));
                document.Add(new iTextSharp.text.Paragraph("__________________________________________________________", m2font));
                document.Add(new iTextSharp.text.Paragraph(empty, mfont));
                document.Add(new iTextSharp.text.Paragraph("OOO 'КанцПлюс' - Бумага                                    1000,00 ₽", m5font));
                document.Add(new iTextSharp.text.Paragraph("OOO 'КанцПлюс' - Бумага                                    1000,00 ₽", m5font));
                document.Add(new iTextSharp.text.Paragraph("__________________________________________________________", m2font));
                document.Add(new iTextSharp.text.Paragraph(empty, mfont));
                document.Add(new iTextSharp.text.Paragraph(empty, mfont));
                document.Add(new iTextSharp.text.Paragraph("Входящие платежи", m2font));
                document.Add(new iTextSharp.text.Paragraph("__________________________________________________________", m2font));
                document.Add(new iTextSharp.text.Paragraph(empty, mfont));
                document.Add(new iTextSharp.text.Paragraph("OOO 'КанцПлюс' - Бумага                                    1000,00 ₽", m5font));
                document.Add(new iTextSharp.text.Paragraph("OOO 'КанцПлюс' - Бумага                                    1000,00 ₽", m5font));
                document.Add(new iTextSharp.text.Paragraph("__________________________________________________________", m2font));
                document.Add(new iTextSharp.text.Paragraph(empty, mfont));
                document.Add(new iTextSharp.text.Paragraph("Баланс - 5000,00 ₽", m4font));

                document.Close();


            }
        }
    }
}
