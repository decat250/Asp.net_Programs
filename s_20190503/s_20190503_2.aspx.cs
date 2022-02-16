using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class s_20190503_2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //string sql = "INSERT INTO member (mem_id, mem_mane, phone, adress) VALUES (NULL, '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "');";

        string constr = "Data Source = localhost; port= 3306; Initial Catalog= s_20190503_member; " +
            "User Id = ambroselee; password = vuek70833123";

        using (MySqlConnection con = new MySqlConnection(constr))
        {
            string sql = "INSERT INTO member (mem_id, mem_mane, phone, adress) VALUES (NULL, '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "');";


            con.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            Response.Write("新增一筆資料成功....");
            con.Close();
        }
    }
}