using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignatureCheck
{
    public partial class test : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShkarkoTestData_Click(Object sender, EventArgs e)
        {
            string filename;
            if (Session["culture"].ToString() == "en-US")
            {
                filename = "signed_document.pdf";
            }
            else
            {
                filename = "dokumenti_i_nenshkruar.pdf";
            } 
            string pathi = Server.MapPath("TestData") + "\\" + "db.pdf";
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename="+filename);
            Response.TransmitFile(pathi);
        }
    }
}