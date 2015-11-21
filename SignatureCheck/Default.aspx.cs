using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignatureCheck
{
    public partial class index : Page
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

                            uploadFile.Visible = false;
                            Rezultati.Visible = true;

                            Session["info"] = dokumenti;
                        }
                        catch (Exception)
                        {
                            if (Session["culture"].ToString() == "en-US")
                            {
                                mesazhi = "Error!";
                            }
                            else
                            {
                                mesazhi = "Ka ndodhur nje gabim!";
                            }   
                        }
                    }
                    else
                    {
                        if (Session["culture"].ToString() == "en-US")
                        {
                            mesazhi = "Available only for pdf document!";
                        }
                        else
                        {
                            mesazhi = "Verifikimi vlen vetem per pdf dokumente!";
                        }  
                    }

                }
                else
                {
                    if (Session["culture"].ToString() == "en-US")
                    {
                        mesazhi = "Please select file for verification!";
                    }
                    else
                    {
                        mesazhi = "Ju lutem zgjedheni dokumentin per verifikim!";
                    }   
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
                if (Session["culture"].ToString() == "en-US")
                {
                    rezultatiVerifikimit = "This file does not have digital signature.";
                }
                else
                {
                    rezultatiVerifikimit = "Nuk ekziston nenshkrim digjital ne kete dokument.";
                } 
                
                img = "<img src='img/not.png' />";
            }
            else if (dokumenti.Nenshkrimet.All(nenshkrim => nenshkrim.Valid))
            {
                if (Session["culture"].ToString() == "en-US")
                {
                    rezultatiVerifikimit = "Signature verification successful.";
                }
                else
                {
                    rezultatiVerifikimit = "Nenshkrimi u verifikua me sukses.";
                } 
                
                img = "<img src='img/ok.png' />";
            }
            else
            {
                if (Session["culture"].ToString() == "en-US")
                {
                    rezultatiVerifikimit = "Signature verification failed.";
                }
                else
                {
                    rezultatiVerifikimit = "Nuk u verifikua nenshkrimi digjital.";
                } 
                
                img = "<img src='img/not.png' />";
            }
        }

        protected void ShkarkoButton_Click(Object sender, EventArgs e)
        {
            ICreatePDF PDFkrijuesi = new CreatePDF(Server.MapPath("img") + "/ok.png", Server.MapPath("img") + "/not.png", Server.MapPath("img") + "/logo.png");
            var ms = new MemoryStream();
            string filename;

            if (Session["culture"].ToString() == "en-US")
            {
                ms = PDFkrijuesi.CreateReport((Dokument)Session["info"]);
                filename = "Verification report.pdf";
            }
            else
            {
                ms = PDFkrijuesi.KrijoRaportin((Dokument)Session["info"]);
                filename = "Raporti i nenshkrimit.pdf";
            } 
            
            byte[] bytes = ms.ToArray();
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename="+filename);
            Response.BinaryWrite(bytes);
            Response.End();
        }

        protected void VerifikoDocTjeter_Click(Object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        
    }
}