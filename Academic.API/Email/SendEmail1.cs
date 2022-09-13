using System;
using System.Net.Mail;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.Configuration;

/// <summary>
/// Summary description for SendEmail1
/// </summary>
public class SendEmail1
{
	public SendEmail1()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool SendEmail(string pTo, string pSubject, string pBody, string cc = null, string attachement = null)
    {
        try
        {
            var emailSender = ConfigurationManager.AppSettings["emailSender"].ToString();
            var senderEmail = ConfigurationManager.AppSettings["SenderEmail"].ToString();
            var senderPassword = ConfigurationManager.AppSettings["SenderPassword"].ToString();
            var smtpServer = ConfigurationManager.AppSettings["SmtpServer"].ToString();
            var logon = ConfigurationManager.AppSettings["logon"].ToString();
            var logonPassword = ConfigurationManager.AppSettings["logonPassword"].ToString();

            SmtpClient SmtpServer = new SmtpClient();
            MailMessage mail = new MailMessage();
            System.Text.StringBuilder mailbody = new System.Text.StringBuilder();
            SmtpServer.Port = 25;
            // SmtpServer.Host = "smtp.office365.com";
            SmtpServer.Host = smtpServer;
            //  SmtpServer.Credentials = new NetworkCredential("smtp.office365.com\\application1@sun.edu.ng", "Xdirsun202034");
            SmtpServer.Credentials = new NetworkCredential(senderEmail, senderPassword);
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            //SmtpServer.EnableSsl = true;
            SmtpServer.EnableSsl = false;
            mail.From = new MailAddress(senderEmail,emailSender);
            //mail.From = new MailAddress("info@valaprime.com");
            mail.To.Add(pTo);
            mail.Subject = pSubject;
            if (cc != null)
            {
                var ccs = cc.Split(',');
                foreach (var ccc in ccs)
                {
                    mail.Bcc.Add(ccc);
                }
            }
            mail.IsBodyHtml = true;
            mailbody.Append(pBody);
            mail.Body = mailbody.ToString();
            if (attachement != null)
            {
                mail.Attachments.Add(new Attachment(attachement));
                // mail.Attachments.Dispose(); 
            }
            SmtpServer.Send(mail);

            //Delete file from directory
            //if (File.Exists(attachement))
            //{
            //    File.Delete(attachement);
            //}


            return true;
        }
        catch (Exception ex)
        {
            //throw ex.InnerException;
            return false;
        }
    }

}