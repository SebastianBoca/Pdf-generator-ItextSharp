using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_rendering
{
    class Program
    {
        static void Main(string[] args)
        {
            Paragraph emptyRow = new Paragraph(" ");
            int index = 0;

            FileStream fs = new FileStream("Transaction.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            /// Title
            Paragraph pr = new Paragraph("Nota de intrare");
            pr.IndentationLeft = 250f;
            doc.Add(pr);
            doc.Add(emptyRow);

            /// Operation parties
            Paragraph initiatingAccount = new Paragraph("Initiating account:    Company one");
            initiatingAccount.IndentationLeft = 50f;
            doc.Add(initiatingAccount);

            Paragraph toAccount = new Paragraph("To account:    Company two");
            toAccount.IndentationLeft = 50f;
            doc.Add(toAccount);

            Paragraph typeOfTransaction = new Paragraph("Type of transaction:    Inventory");
            typeOfTransaction.IndentationLeft = 50f;
            doc.Add(typeOfTransaction);

            doc.Add(emptyRow);

            /// Product table
            PdfPTable myTable = new PdfPTable(3);

            PdfPCell cell;
            cell = new PdfPCell(new Phrase("Name"));
            cell.HorizontalAlignment = 1;
            myTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Description"));
            cell.HorizontalAlignment = 1;
            myTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("Quantity"));
            cell.HorizontalAlignment = 1;
            myTable.AddCell(cell);

            List<Product> productList = new Products().GetProducts();

            foreach(Product p in productList)
            {
                index++;
                cell = new PdfPCell(new Phrase(p.name));
                myTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(p.description));
                myTable.AddCell(cell);

                cell = new PdfPCell(new Phrase(index.ToString()));
                cell.HorizontalAlignment = 1;
                myTable.AddCell(cell); 
            }

            doc.Add(myTable);

            doc.Add(emptyRow);

            PdfPTable final = new PdfPTable(2);
            cell = new PdfPCell(new Phrase(DateTime.Now.ToString()));
            cell.BorderColor = Color.WHITE;
            final.AddCell(cell);

            cell = new PdfPCell(new Phrase("Signature"));
            cell.BorderColor = Color.WHITE;
            cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            final.AddCell(cell);

            
            doc.Add(final);

            doc.Close();
        }
    }
}
