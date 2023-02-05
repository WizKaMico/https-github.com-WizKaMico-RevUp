using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Discovery;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RevUp
{
    public partial class Terms : System.Web.UI.Page
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
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + ";USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();

            String click = "ACCEPTED TERMS";
            String email = Session["id"].ToString();
            var date = DateTime.Now.ToString("yyyy-MM-dd");

            string insert_transaction = "INSERT INTO add_logs (email, transaction, date) VALUES ('"+email+"','"+click+"','"+date+"')";
            MySqlCommand cmd = new MySqlCommand(insert_transaction, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            Session["id"] = Session["id"].ToString();
            Response.Redirect("Home.aspx");
            Session.RemoveAll(); 
        }
    }
}