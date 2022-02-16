using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class History : System.Web.UI.Page
    {
        string constr = "Data Source = localhost; port= 3306; Initial Catalog= asp;" +
                   "User Id = aaa; password = aaa";
        string[] shoplist;
        string[] UserData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userdata"] != null)
            {
                UserData = Session["UserData"] as string[];
                HttpCookie getshopsession = Request.Cookies[UserData[0]]; //把SESSION資料取出，將計算購物車商品數量
                if (getshopsession != null)
                {
                    string word1 = HttpUtility.UrlDecode(getshopsession.Values["ID"]);
                    shoplist = word1.Split(',').Distinct().ToArray();
                    shoplist = shoplist.Where(val => val != "0").ToArray();
                    Literal2.Text = shoplist.Length.ToString();
                }
                else
                {
                    Literal2.Text = "0";
                }
            }
           
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


            if (Session["UserData"] == null)
            {
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>window.alert('請先登入');window.location.href='index.aspx';</SCRIPT >");
                LinkButton2.Visible = false;
                LinkButton1.Visible = false;
                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
            }
            else
            {
                UserData = Session["UserData"] as string[];

                LinkButton2.Text = UserData[1] + "您好";
                LinkButton2.Visible = true;
                HyperLink1.Visible = false;
                HyperLink2.Visible = false;
                LinkButton1.Visible = true;
                LinkButton2.Font.Size = 13;
                
            }

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                if (Session["UserData"] != null)
                {
                    Literal1.Text = "";
                    UserData = Session["UserData"] as string[];
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `buy_history` where `User_ID`='" + UserData[0] + "'");
                    con.Open();
                    cmd.Connection = con;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Literal1.Text += "<tr>" +
                                "<td class='product-subtotal'>" + reader["Buy_Name"] + "</td>" +
                                 "<td class='product-subtotal'>" + reader["Buy_Phone"] + "</td>" +
                                "<td class='product-subtotal'>" + reader["Buy_Location"] + "</td>" +
                                "<td class='product-subtotal'>" + reader["Buy_Pick"] + "</td>" +
                                 "<td class='product-subtotal'>" + reader["Buy_Pay"] + "</td>" +
                                "<td class='product-subtotal'>" + reader["All_count"] + "</td>" +
                                "<td class='product-subtotal'>" + reader["State"] + "</td>"+
                                "<td class='product-subtotal'>" + reader["Buy_Item"] + "</td>" + "</tr>";
                        }
                        con.Close();
                    }
                }
              
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e) ///登出
        {

            Session["UserData"] = null;
            Response.Redirect(Request.Url.AbsoluteUri);
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
                        Session["UserData"] = new string[] { reader["ID"].ToString(), reader["Men_account"].ToString(), reader["Men_Name"].ToString(), reader["Men_Email"].ToString(), reader["Is_adm"].ToString() };
                        Response.Redirect(Request.Url.AbsoluteUri);
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