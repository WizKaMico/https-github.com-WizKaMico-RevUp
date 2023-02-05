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
     
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string server = "localhost";
            string database = "turtle";
            string password = "";
            string username = "root";


            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();


            String email = TextBox1.Text;
            String pass = TextBox2.Text;
            var conf = "OFFLINE";
            var stat = "VALID";

            string validate_user_credentials = "SELECT * FROM admin_credentials LEFT JOIN admin_pass ON admin_credentials.user_id = admin_pass.user_id WHERE admin_credentials.email = '" + email + "' AND admin_pass.password = '" + pass + "' AND admin_pass.configuration = '" + conf + "' AND admin_credentials.status = '"+stat+"'";
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

                Session["id"] = TextBox1.Text;
                Response.Redirect("Verification.aspx");
                Session.RemoveAll(); 



            }
            else
            {
                
                string validate_user_existence = "SELECT * FROM admin_credentials WHERE email = '" + email + "'";
                MySqlCommand err = new MySqlCommand(validate_user_existence, conn);
                MySqlDataAdapter adp_err = new MySqlDataAdapter(err);
                DataTable dt_err = new DataTable();
                adp_err.Fill(dt_err);
                int check = err.ExecuteNonQuery();
                if (dt_err.Rows.Count > 0)
                {
                   
                    var date_err_check = DateTime.Now.ToString("yyyy-MM-dd");
                    string err_persistence = "SELECT *,COUNT(id) as total FROM err_checker WHERE email = '" + email + "' AND date = '" + date_err_check + "'";
                    MySqlCommand errcheck = new MySqlCommand(err_persistence, conn);
                    MySqlDataReader check_persistence = errcheck.ExecuteReader();
                   
                    check_persistence.Read(); 
                    int col = int.Parse(check_persistence["total"].ToString());
                    conn.Close();
                    conn.Open();
                    string check_status_cred = "SELECT * FROM admin_credentials WHERE email = '" + email + "'";
                    MySqlCommand sterr = new MySqlCommand(check_status_cred, conn);
                    MySqlDataReader readerrstat = sterr.ExecuteReader(); 
                    readerrstat.Read();
                    string check_status = readerrstat["status"].ToString();
                    conn.Close();
                    if (col >= 3 && check_status != "BLOCKED")
                    {
                        conn.Open();
                        var rstat = "BLOCKED";
                        string update_existing_cred = "UPDATE admin_credentials SET status = '" + rstat + "' WHERE email = '" + email + "'";
                        MySqlCommand cm_up = new MySqlCommand(update_existing_cred, conn);
                        MySqlDataReader cmup = cm_up.ExecuteReader();
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
                            message.Subject = "PUNTA FUEGO | RACE SYSTEM | ACCOUNT BLOCKED NOTIFICATION | TODAY " + date_err_check;
                            message.Body = "<h1>Gooday! <b>" + email + "</b></h1><br> <p> YOU MAY CONTACT US, IF YOU FEEL SOMEONE IS ACCESSING YOUR ACCOUNT WITHOUT YOUR PERMISSION : </p>";
                            message.IsBodyHtml = true;
                            client.Send(message);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        lblResponse.Text = "ACCOUNT BLOCKED";
                        conn.Close();

                    }
                    else if(col > 3 && check_status == "BLOCKED")
                    {

                        lblResponse.Text = "ACCOUNT BLOCKED | CONTACT SUPPORT";

                    }

                    else
                    {

                        conn.Open();
                        var date_err = DateTime.Now.ToString("yyyy-MM-dd");
                        string check_if_err = "INSERT INTO err_checker (email, date) VALUES ('" + email + "','" + date_err + "')";
                        MySqlCommand cmerr = new MySqlCommand(check_if_err, conn);
                        MySqlDataReader readerr = cmerr.ExecuteReader();

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
                            message.Subject = "PUNTA FUEGO | RACE SYSTEM | WRONG PASSWORD NOTIFICATION | TODAY " + date_err;
                            message.Body = "<h1>Gooday! <b>" + email + "</b></h1><br> <p> YOU MAY CONTACT US, IF YOU FEEL SOMEONE IS ACCESSING YOUR ACCOUNT WITHOUT YOUR PERMISSION : </p>";
                            message.IsBodyHtml = true;
                            client.Send(message);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        lblResponse.Text = "INCORRECT PASSWORD";
                    }
                    }
                

                else
                {

                    lblResponse.Text = "INCORRECT USERNAME AND PASSWORD COMBINATION";

                }


            }



        }
    }
}