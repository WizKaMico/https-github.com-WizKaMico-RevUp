using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RevUp
{
    public partial class Verification : System.Web.UI.Page
    {
        string server = "localhost";
        string database = "turtle";
        string username = "root";
        string password = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                lblEmail.Text = Session["id"].ToString();
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();

            String email = Session["id"].ToString();
            String code = TextBox1.Text;
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var status = "VALID"; 
            string check_code_verif_for_today = "SELECT * FROM client_security WHERE email = '" + email + "' AND code = '"+code+"' AND date = '"+date+"' AND status = '"+status+"'";
            MySqlCommand cmd = new MySqlCommand(check_code_verif_for_today, conn); 
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int i = cmd.ExecuteNonQuery();
            if (dt.Rows.Count > 0)
            {
                var stat = "USED";
                string update_the_code = "UPDATE client_security SET status = '" + stat + "' WHERE code = '"+code+"'";
                MySqlCommand ucode = new MySqlCommand(update_the_code, conn);
                MySqlDataReader readupdate = ucode.ExecuteReader();
                try
                {
                    SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    System.Net.NetworkCredential credential = new System.Net.NetworkCredential("gmfacistol@outlook.com", "@Light101213");
                    client.EnableSsl = true;
                    client.Credentials = credential;

                    MailMessage message = new MailMessage("gmfacistol@outlook.com", email);
                    message.Subject = "PUNTA FUEGO | RACE SYSTEM | LOGIN SUCCESFULLY | TODAY " + date;
                    message.Body = "<h1>Gooday! <b>" + email + "</b></h1><br> <p> YOUR ACCOUNT HAS BEEN LOGGED IN SUCCESFULLY </p>";
                    message.IsBodyHtml = true;
                    client.Send(message);
                }
                catch (Exception)
                {
                    throw;
                }
                Session["id"] = Session["id"].ToString();
                Response.Redirect("Terms.aspx");
                Session.RemoveAll();
                
            }
            else
            {
                lblResponse.Text = "WRONG CODE, TRY AGAIN"; 
            }
        }
    }
}