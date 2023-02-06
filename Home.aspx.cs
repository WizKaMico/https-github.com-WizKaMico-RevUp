using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RevUp
{
    public partial class Home : System.Web.UI.Page
    {
        string server = "localhost";
        string database = "turtle";
        string username = "root";
        string password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
         /*   if (Session["id"] != null)
            {
                String name = Session["id"].ToString();
                lblEmail.Text = name.ToUpper();
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }*/

            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();

            string registrant = "SELECT code,fname,mname,lname,email,qr FROM registration";
            MySqlCommand cmd = new MySqlCommand(registrant, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            int i = cmd.ExecuteNonQuery();
            GridView1.DataSource = dt;
            GridView1.DataBind(); 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();

            String code = TextBox1.Text;

            string registrant = "SELECT code,fname,mname,lname,email,qr FROM registration WHERE code = '"+code+"'";
            MySqlCommand cmd = new MySqlCommand(registrant, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            int i = cmd.ExecuteNonQuery();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();

            string notify_mail = "SELECT * FROM registration";
            MySqlCommand cmd = new MySqlCommand(notify_mail, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                String email = read.GetString("email");
                var date = DateTime.Now.ToString("yyyy-MM-dd");
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
                    message.Subject = "PUNTA FUEGO | RACE SYSTEM | NOTIFICATION | TODAY " + date;
                    message.Body = "<h1>Gooday! <b>" + email + "</b></h1><br> BE READY  <p></p>";
                    message.IsBodyHtml = true;
                    client.Send(message);
                }
                catch (Exception)
                {
                    throw;
                }

                lblMailResponse.Text = "SUCCESFFULLY NOTIFIED MAIL";
            }
        }

    }
}