using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Drawing.Printing;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Printing;
using SautinSoft.Document;
using Section = SautinSoft.Document.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Annotations;
using Spire.Pdf.Widget;
using System.Drawing.Printing;
using System.Threading;
using RawPrint;


namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {


        public Statistics()
        {
            InitializeComponent();
        }
        private void createPDF()
        {
            Document document = new Document();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            BaseFont baseFont = BaseFont.CreateFont("C:\\Users\\Volodimirln\\Desktop\\SQLite\\WpfApp\\WpfApp\\Fonts\\Montserrat-Black.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont mainfont = BaseFont.CreateFont("C:\\Users\\Volodimirln\\Desktop\\SQLite\\WpfApp\\WpfApp\\Fonts\\Montserrat-Medium.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 35f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font mfont = new iTextSharp.text.Font(mainfont, 12f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font m2font = new iTextSharp.text.Font(mainfont, 18f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font m3font = new iTextSharp.text.Font(mainfont, 22f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font m4font = new iTextSharp.text.Font(baseFont, 16f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font m5font = new iTextSharp.text.Font(mainfont, 16f, iTextSharp.text.Font.NORMAL);
            using (FileStream stream = new FileStream(@"Test.pdf", FileMode.Create))
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

        private void NewPdf(object sender, RoutedEventArgs e)
        {
            createPDF();
            SendToPrinter();
        }
        private void SendToPrinter()
        {

            Spire.Pdf.PdfDocument doc1 = new Spire.Pdf.PdfDocument();
            doc1.LoadFromFile("Test.pdf");
            doc1.Print();


        }
    }
}
