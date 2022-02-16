using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class product_details : System.Web.UI.Page
    {
        string constr = "Data Source = localhost; port= 3306; Initial Catalog= asp;" +
                "User Id = aaa; password = aaa";
        string[] UserData;

        protected void Page_Load(object sender, EventArgs e)
        {
            string Shoppingid = Request.QueryString["Shoppingid"]; //把購物ID加入購物車SESSION
            if (Shoppingid != null)
            {
                if ((Session["UserData"] != null))
                {
                    UserData = Session["UserData"] as string[];
                
                    HttpCookie shoplistsession = Request.Cookies[UserData[0]];
                    HttpCookie myCookie = new HttpCookie(UserData[0]);
                    if (shoplistsession != null) //有資料，將ID疊加寫入COOKIE
                    {
                        string word = HttpUtility.UrlDecode(shoplistsession.Values["ID"]);
                        word += "," + Shoppingid;
                        myCookie.Values.Add("ID", System.Web.HttpContext.Current.Server.UrlEncode(word));
                    }
                    else //沒資料，直接寫入COOKIE
                    {
                        myCookie.Values.Add("ID", System.Web.HttpContext.Current.Server.UrlEncode(Shoppingid));
                        myCookie.Expires = DateTime.Now.AddHours(1);
                    }
                    myCookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(myCookie);
                    Response.Redirect(Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf('&')));
                }
            }
            if ((Session["UserData"] != null))
            {
                UserData = Session["UserData"] as string[];
                HttpCookie getshopsession = Request.Cookies[UserData[0]]; //把SESSION資料取出，去做ID疊加
                if (getshopsession != null)
                {
                    string word1 = HttpUtility.UrlDecode(getshopsession.Values["ID"]);
                    string[] shoplist = word1.Split(',').Distinct().ToArray();
                    shoplist = shoplist.Where(val => val != "0").ToArray();
                    Literal11.Text = shoplist.Length.ToString();
                }
                else
                {
                    Literal11.Text = "0";
                }
            }
            else
            {
                Literal11.Text = "0";
            }

            String Productid = Request.QueryString["Proid"];
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                if (Session["UserData"] == null)
                {
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

                string comm = "SELECT * FROM `product` where Pro_ID='" + Productid+"'";
                MySqlCommand cmd = new MySqlCommand(comm);
                con.Open();
                cmd.Connection = con;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Literal1.Text = reader["Pro_Name"].ToString();
                        Literal2.Text = "$"+reader["Pro_Price"].ToString();
                        Literal3.Text=reader["Pro_Name_1"].ToString();
                        Literal4.Text= reader["Pro_Description"].ToString();
                        Literal5.Text = "<img src='images/product/" + Productid + "/m1.jpg' alt='full - image' height='510px' weight='677px'>";
                        Literal6.Text = "<img src='images/product/" + Productid + "/m2.jpg' alt='full - image' height='510px' weight='677px'>";
                        Literal7.Text = "<img src='images/product/" + Productid + "/m3.jpg' alt='full - image' height='510px' weight='677px'>";
                        Literal8.Text = "<img src='images/product/" + Productid + "/m1.jpg' alt='full - image' height='80px' weight='106px'>";
                        Literal9.Text = "<img src='images/product/" + Productid + "/m2.jpg' alt='full - image' height='80px' weight='106px'>";
                        Literal10.Text = "<img src='images/product/" + Productid + "/m3.jpg' alt='full - image' height='80px' weight='106px'>";
                        Literal12.Text = reader["Pro_Count"].ToString();
                        if (reader["Pro_Count"].ToString() != "0")
                        {
                            Literal13.Text = "<a class='fr__btn' href='" + Request.Url.AbsoluteUri + "&Shoppingid=" + Productid + "'>加入購物車</a>";
                        }
                        else
                        {
                            Literal13.Text = "<a class='fr__btn' href=#'" + Productid + "'>已售完</a>";
                        }


                    }
                   
                }
                con.Close();
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
