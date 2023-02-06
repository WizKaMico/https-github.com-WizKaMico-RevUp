using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace RevUp
{
    public partial class Reg_Information : System.Web.UI.Page
    {
        string server = "localhost";
        string username = "root";
        string password = "";
        string database = "turtle";
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["id"] != null)
            {
                String name = Session["id"].ToString();
                lblEmail.Text = name.ToUpper();
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }*/

            if (Request.QueryString["code"] != null)
            {
                string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
                MySqlConnection conn = new MySqlConnection(constring);
                conn.Open();

                String code = Request.QueryString["code"].ToString();
                lblCode.Text = code.ToUpper();

                string registran_specific = "SELECT * FROM registration WHERE code = '" + code + "'";
                MySqlCommand cmd = new MySqlCommand(registran_specific, conn);
                MySqlDataReader read = cmd.ExecuteReader();

                read.Read();

                String qr = read["qr"].ToString();
                Image1.ImageUrl = qr;
                String fname = read["fname"].ToString();
                TextBox1.Text = fname;
                String mname = read["mname"].ToString();
                TextBox2.Text = mname;
                String lname = read["lname"].ToString();
                TextBox3.Text = lname;



            }
            else
            {

            }
        }

            protected void Button1_Click(object sender, EventArgs e)
            {
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();

            String code = Request.QueryString["code"].ToString();
            String fname = TextBox1.Text;
            String mname = TextBox2.Text;
            String lname = TextBox3.Text; 

            string registran_specific = "UPDATE registration SET fname = '"+fname+"',mname='"+mname+"',lname='"+lname+"' WHERE code = '" + code + "'";
            MySqlCommand cmd = new MySqlCommand(registran_specific, conn);
            MySqlDataReader read = cmd.ExecuteReader();

        }
        
    }
}