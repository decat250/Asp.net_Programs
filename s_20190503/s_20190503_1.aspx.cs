using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class s_20190503_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = "Data Source = localhost; port= 3306; Initial Catalog= s_20190503_member; " +
            "User Id = ambroselee; password = vuek70833123";
        /*
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM member"))
            {
                using (MySqlDataAdapter da = new MySqlDataAdapter())
                {
                     用GridView顯示
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    
                    //自己做表格顯示

                }
            }
        }
        */
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM member");
            cmd.Connection = con;
            int a = 0;
            using (var reader = cmd.ExecuteReader())
            {
                Response.Write("<TABLE border=\"1\"");
                Response.Write("<TR>");
                    Response.Write("<TD>NAME");
                    Response.Write("</TD>");
                    Response.Write("<TD>PHONE");
                    Response.Write("</TD>");
                Response.Write("</TR>");

                while (reader.Read())
                {
                    Response.Write("<TR>");
                    Response.Write("<TD>" + reader["mem_mane"]);
                    Response.Write("</TD>");
                    Response.Write("<TD>" + reader["phone"]);
                    Response.Write("</TD>");
                    Response.Write("</TR>");
                }

                Response.Write("</TABLE>");
            }
            con.Close();

        }
    }
}