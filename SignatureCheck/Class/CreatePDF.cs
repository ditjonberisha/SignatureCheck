using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Linq;

namespace SignatureCheck
{
    public class CreatePDF : ICreatePDF
    {
        public iTextSharp.text.Image ImgOK { get; set; }
        public iTextSharp.text.Image ImgNot { get; set; }

        public CreatePDF(string imgOK, string imgNot)
        {
            this.ImgOK = iTextSharp.text.Image.GetInstance(imgOK);
            this.ImgNot = iTextSharp.text.Image.GetInstance(imgNot);
        }

        private void CreateCell(PdfPTable tbl, string str, int colspan, int HorizontalAlignment, int bold, BaseColor color, iTextSharp.text.Image img = null)
        {
            PdfPCell cell;
            Font fonti;
            if (bold == 1)
            {
                fonti = new Font(Font.FontFamily.UNDEFINED, 11, Font.BOLD);
            }
            else
            {
                fonti = new Font(Font.FontFamily.UNDEFINED, 11, Font.NORMAL);
            }
            if (img == null)
            {
                cell = new PdfPCell(new Phrase(str, fonti));
            }
            else
            {
                cell = new PdfPCell(img);
            }

            cell.BorderColor = new BaseColor(66, 139, 202);
            cell.BorderWidth = 1;
            cell.HorizontalAlignment = HorizontalAlignment; //0=Left, 1=Centre, 2=Right
            cell.Padding = 7;
            cell.Colspan = colspan;
            cell.BackgroundColor = color;
            tbl.AddCell(cell);
        }

        public MemoryStream KrijoPdf(Dokument dokumenti)
        {
            var doc = new Document();

            var ms = new MemoryStream();
            PdfWriter.GetInstance(doc, ms);

            doc.Open();

            Paragraph header = new Paragraph("RAPORTI I VERIFIKIMIT");
            header.SpacingAfter = 20f;
            header.Alignment = 1;

            doc.Add(header);

            PdfPTable tblDokumenti = new PdfPTable(3);
            float[] widths = new float[] { 40f, 10f, 50f };
            tblDokumenti.SetWidths(widths);
            tblDokumenti.SpacingAfter = 20;

            CreateCell(tblDokumenti, "Dokumenti", 3, 1, 1, new BaseColor(66, 139, 202));

            CreateCell(tblDokumenti, "Nenshkrimi digjital", 1, 0, 1, new BaseColor(255, 255, 255));

            string rezultatiVerifikimit;
            iTextSharp.text.Image img;
            if(dokumenti.Nenshkrimet.Count() == 0)
            {
                rezultatiVerifikimit = "Nuk ekziston nenshkrim digjital ne kete dokument";
                img = ImgNot;
            }
            else if(dokumenti.Nenshkrimet.All(nenshkrim => nenshkrim.Valid))
            {
                rezultatiVerifikimit = "U verifikua me sukses";
                img = ImgOK;
            }
            else
            {
                rezultatiVerifikimit = "Nuk u verifikua nenshkrimi digjital";
                img = ImgNot;
            }

            img.ScaleAbsolute(25, 25);

            CreateCell(tblDokumenti, "", 1, 0, 0, new BaseColor(255, 255, 255), img);
            CreateCell(tblDokumenti, rezultatiVerifikimit, 1, 0, 0, new BaseColor(255, 255, 255));

            CreateCell(tblDokumenti, "Koha e verifikimit", 1, 0, 1, new BaseColor(255, 255, 255));
            CreateCell(tblDokumenti, dokumenti.KohaVerifikimit.ToString(), 2, 0, 0, new BaseColor(255, 255, 255));

            CreateCell(tblDokumenti, "Emri i dokumentit", 1, 0, 1, new BaseColor(255, 255, 255));
            CreateCell(tblDokumenti, dokumenti.Emri, 2, 0, 0, new BaseColor(255, 255, 255));

            CreateCell(tblDokumenti, "Vlera hash e dokumentit (SHA256)", 1, 0, 1, new BaseColor(255, 255, 255));
            CreateCell(tblDokumenti, dokumenti.VleraHashString, 2, 0, 0, new BaseColor(255, 255, 255));

            CreateCell(tblDokumenti, "Madhesia e dokumentit", 1, 0, 1, new BaseColor(255, 255, 255));
            CreateCell(tblDokumenti, dokumenti.Madhesia, 2, 0, 0, new BaseColor(255, 255, 255));

            doc.Add(tblDokumenti);

            foreach(Nenshkrim nenshkrimi in dokumenti.Nenshkrimet)
            {
                PdfPTable tblNenshkruesi = new PdfPTable(2);
                tblNenshkruesi.SpacingAfter = 20;

                CreateCell(tblNenshkruesi, "Te dhenat e nenshkruesit", 2, 1, 1, new BaseColor(66, 139, 202));

                CreateCell(tblNenshkruesi, "Nenshkruesi", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.Nenshkruesi, 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Emri", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.Emri, 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Mbiemri", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.Mbiemri, 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Data e nenshkrimit", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.DataNenshkrimit.ToString(), 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Algoritmi i Hashit", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.AlgoritmiHash, 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Algoritmi i Enkriptimit", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.AlgoritmiEnkriptimit, 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Certifikata valide prej", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.CertifikataValidePrej, 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Certifikata valide deri", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.CertifikataValideDeri, 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblNenshkruesi, "Numri serik i certifikates", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblNenshkruesi, nenshkrimi.SerialNumber, 1, 0, 0, new BaseColor(255, 255, 255));

                doc.Add(tblNenshkruesi);

                PdfPTable tblIssuer = new PdfPTable(2);                

                CreateCell(tblIssuer, "Te dhenat e leshuesit te certifikates", 2, 1, 1, new BaseColor(66, 139, 202));

                CreateCell(tblIssuer, "CN", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblIssuer, nenshkrimi.IssuerCN, 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblIssuer, "OU", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblIssuer, nenshkrimi.IssuerOU, 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblIssuer, "O", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblIssuer, nenshkrimi.IssuerO, 1, 0, 0, new BaseColor(255, 255, 255));

                CreateCell(tblIssuer, "C", 1, 0, 1, new BaseColor(255, 255, 255));
                CreateCell(tblIssuer, nenshkrimi.IssuerC, 1, 0, 0, new BaseColor(255, 255, 255));

                tblIssuer.SpacingAfter = 20;
                doc.Add(tblIssuer);
            }
                        
            doc.Close();

            return ms;
        }
    }
}
