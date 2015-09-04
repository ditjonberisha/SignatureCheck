using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace SignatureCheck
{
    public partial class kontakti : Page
    {
        private MailAddress fromAddress = new MailAddress("signaturecheckks@gmail.com");
        private string fromPassword = "signaturecheck";
        private MailAddress toAddress = new MailAddress("signaturecheckks@gmail.com");
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        protected void DergoEmail_Click(Object sender, EventArgs e)
        {
           if(Emri.Value == "" || Mbiemri.Value == "" || Email.Value == "" || Pytja.Value == "")
           {
               if (Session["culture"].ToString() == "en-US")
               {
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please complete all fields marked with *.')", true);
               }
               else
               {
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ju lutem plotesoni te gjitha fushat e shenuar me *.')", true);
               }     
           }
           else
           {
               MailMessage mail = new MailMessage();
               mail.To.Add(toAddress);
               mail.From = new MailAddress(Email.Value.ToString(), "Signature Check", System.Text.Encoding.UTF8);
               if(Subject.Value == "")
               {
                   mail.Subject = "Email i derguar nga webfaqja Signature Check";
               }
               else
               {
                   mail.Subject = Subject.Value;
               }

               StringBuilder mesazhi = new StringBuilder();
               mesazhi.Append("Emri: " + Emri.Value.ToString() + "<br />");
               mesazhi.Append("Mbiemri: " + Mbiemri.Value.ToString() + "<br />");
               mesazhi.Append("Tel: " + Tel.Value.ToString() + "<br />");
               mesazhi.Append("Email: " + Email.Value.ToString() + "<br /><br />");
               mesazhi.Append(Pytja.Value.ToString());

               mail.Body = mesazhi.ToString();

               mail.IsBodyHtml = true;

               System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
               {
                   Host = "smtp.gmail.com",
                   Port = 587,
                   EnableSsl = true,
                   DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                   UseDefaultCredentials = false,
                   Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
               };

               try
               {
                   smtp.Send(mail);

                   Emri.Value = "";
                   Mbiemri.Value = "";
                   Tel.Value = "";
                   Email.Value = "";
                   Subject.Value = "";
                   Pytja.Value = "";

                   if (Session["culture"].ToString() == "en-US")
                   {
                       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email sent successfully.')", true);
                   }
                   else
                   {
                       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email u dergua me sukses.')", true);
                   } 
                   
               }
               catch (Exception ex)
               {
                   if (Session["culture"].ToString() == "en-US")
                   {
                       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('E-mail was not sent successfully.')", true);
                   }
                   else
                   {
                       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email nuk u dergua me sukses.')", true);
                   } 
                   
               }
           }
        }
    }
}