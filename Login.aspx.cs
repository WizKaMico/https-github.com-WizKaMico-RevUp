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
    public partial class Login : System.Web.UI.Page
    {
        string server = "localhost";
        string database = "turtle";
        string password = "";
        string username = "root"; 
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring); 
            conn.Open();


            String email = TextBox1.Text;
            String pass = TextBox2.Text;
            String conf = "ONLINE";

            string validate_user_credentials = "SELECT * FROM admin_credentials LEFT JOIN admin_pass ON admin_credentials.user_id = admin_pass.user_id WHERE admin_credentials.email = '" + email + "' AND admin_pass = '" + pass + "' AND configuration = '" + conf + "'";
            MySqlCommand cmd = new MySqlCommand(validate_user_credentials, conn); 
            MySqlDataAdapter adp_pass_validation = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp_pass_validation.Fill(dt);
            int i = cmd.ExecuteNonQuery();

            if (dt.Rows.Count > 0)
            {
                Random rn = new Random();
                var code = rn.Next(6666,9999);
                var date = DateTime.Now.ToString("yyyy-MM-dd");
                var status = "VALID";

                string insert_code_security = "INSERT INTO client_security (email, code, status, date) VALUES ('"+email+"','"+code+"','"+status+"','"+date+"') ";
                MySqlCommand insert = new MySqlCommand(insert_code_security, conn);
                MySqlDataReader read = insert.ExecuteReader();

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
                    message.Subject = "PUNTA FUEGO | RACE SYSTEM | 4-DIGIT VALIDATION CODE | TODAY " + date;
                    message.Body = "<h1>Gooday! <b>" + email + "</b></h1><br> <p>4-DIGIT CODE : " + code + "</p>";
                    message.IsBodyHtml = true;
                    client.Send(message);
                }
                catch (Exception)
                {
                    throw;
                }





            }
            else
            {
                
            }



        }
    }
}