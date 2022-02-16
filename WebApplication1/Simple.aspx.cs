using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Simple : System.Web.UI.Page
    {
        string constr = "Data Source = localhost; port= 3306; Initial Catalog= asp;" +
                "User Id = aaa; password = aaa";


        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {

                GetProduct("SELECT * FROM `product`");
            }
            if (Session["Login"] == null)
            {
                LinkButton2.Visible = false;
                LinkButton1.Visible = false;
                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
            }
            else
            {
                LinkButton2.Text = Session["Login"].ToString() + "您好";
                LinkButton2.Visible = true;
                HyperLink1.Visible = false;
                HyperLink2.Visible = false;
                LinkButton1.Visible = true;
                LinkButton2.Font.Size = 13;
            }


        }
        public void GetProduct(String productcomm)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                MySqlCommand cmd = new MySqlCommand(productcomm);
                con.Open();
                cmd.Connection = con;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        //

                    }
                    con.Close();
                }
            }



        }

        protected void LinkButton1_Click(object sender, EventArgs e) ///登出
        {

            Session["Login"] = null;
            Response.Redirect("index.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                string comm = "SELECT * FROM member where  Men_Email ='" + TextBox1.Text + "' and Men_Password = '" + TextBox2.Text + "'";
                MySqlCommand cmd = new MySqlCommand(comm);
                cmd.Connection = con;
                int a = 0;

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Response.Write("<Script language='JavaScript'>alert('登入失敗');</Script>");
                    }
                    else
                    {
                        Session["Login"] = reader["Men_Name"].ToString();
                        Response.Redirect("index.aspx");
                    };
                }
                con.Close();
            }
        }


        protected void Button2_Click1(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string sql = "INSERT INTO member VALUES (NULL, '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "','" + TextBox7.Text + "',0)";


                con.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql))
                {
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                Response.Write("<Script language='JavaScript'>alert('註冊成功');</Script>");
                con.Close();
            }
        }


    }
}
