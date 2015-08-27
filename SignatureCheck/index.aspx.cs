using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignatureCheck
{
    public partial class index : System.Web.UI.Page
    {
        private string mesazhi = "";
        protected Dokument dokumenti;
        protected string rezultatiVerifikimit;
        protected string img;

        protected void Page_Load(object sender, EventArgs e)
        {
            uploadFile.Visible = true;
            Rezultati.Visible = false;

            if (IsPostBack)
            {
                if ((fileUpload.PostedFile != null) && (fileUpload.PostedFile.ContentLength > 0))
                {
                    IDokumentLexues lexuesi = new DokumentLexues();
                    IVerifikues verifikuesi = new Verifikues();
                    
                    string extension = System.IO.Path.GetExtension(fileUpload.PostedFile.FileName);

                    if (extension == ".pdf")
                    {
                        try
                        {
                            dokumenti = lexuesi.MerrDokumentInfo(fileUpload.PostedFile.FileName, fileUpload.PostedFile.InputStream, verifikuesi);
                            RezultatiVerfikimit(dokumenti);
                            Nenshkrim ne = new Nenshkrim();
                            ne.Nenshkruesi = "db";
                            ne.Emri = "d";
                            ne.Mbiemri = "b";
                            ne.IssuerC = "US";
                            //dokumenti.Nenshkrimet.Add(ne);

                            uploadFile.Visible = false;
                            Rezultati.Visible = true;

                            Session["info"] = dokumenti;
                        }
                        catch (Exception)
                        {
                            mesazhi = "Ka ndodhur nje gabim!";
                        }
                    }
                    else
                    {
                        mesazhi = "Verifikimi vlen vetem per pdf dokumente!";
                    }

                }
                else
                {
                    mesazhi = "Ju lutem zgjedheni dokumentin per verifikim!";
                }
            }
        }

        protected string GetMessage()
        {
            return mesazhi;
        }

        protected void RezultatiVerfikimit(Dokument dokumenti)
        {

            if (dokumenti.Nenshkrimet.Count == 0)
            {
                rezultatiVerifikimit = "Nuk ekziston nenshkrim digjital ne kete dokument.";
                img = "<img src='img/not.png' />";
            }
            else if (dokumenti.Nenshkrimet.All(nenshkrim => nenshkrim.Valid))
            {
                rezultatiVerifikimit = "Nenshkrimi u verifikua me sukses.";
                img = "<img src='img/ok.png' />";
            }
            else
            {
                rezultatiVerifikimit = "Nuk u verifikua nenshkrimi digjital.";
                img = "<img src='img/not.png' />";
            }
        }

        protected void ShkarkoButton_Click(Object sender, EventArgs e)
        {
            ICreatePDF PDFkrijuesi = new CreatePDF(Server.MapPath("img") + "/ok.png", Server.MapPath("img") + "/not.png", Server.MapPath("img") + "/logo.png");
            var ms = PDFkrijuesi.KrijoPdf((Dokument)Session["info"]);
            byte[] bytes = ms.ToArray();
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Raporti i nenshkrimit.pdf");
            Response.BinaryWrite(bytes);
            Response.End();
        }

        protected void ShkarkoCertifikaten_Click(Object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void VerifikoDocTjeter_Click(Object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        
    }
}