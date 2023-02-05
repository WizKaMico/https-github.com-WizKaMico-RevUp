using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            if (Session["id"] != null)
            {
                String name = Session["id"].ToString();
                lblEmail.Text = name.ToUpper();
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }

            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();

            string registrant = "SELECT * FROM registration";
            MySqlCommand cmd = new MySqlCommand(registrant, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            int i = cmd.ExecuteNonQuery();
            GridView1.DataSource = dt;
            GridView1.DataBind(); 
        }
    }
}