using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class text : System.Web.UI.Page
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
                    Response.Redirect("index.aspx");
                }
                
            }
            if ((Session["UserData"] != null))
            {
                UserData = Session["UserData"] as string[];
                HttpCookie getshopsession = Request.Cookies[UserData[0]]; //網頁載入時，把SESSION資料取出，計算購物車商品數量
                if (getshopsession != null)
                {
                    string word1 = HttpUtility.UrlDecode(getshopsession.Values["ID"]);
                    string[] shoplist = word1.Split(',').Distinct().ToArray();
                    shoplist = shoplist.Where(val => val != "0").ToArray();
                    Literal3.Text = shoplist.Length.ToString();
                }
                else
                {
                    Literal3.Text = "0";
                }
            }
            else
            {
                Literal3.Text = "0";
            }
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
               
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("價格排序方式");
                DropDownList1.Items.Add("價格由高到低");
                DropDownList1.Items.Add("價格由低到高");
                GetProduct("SELECT * FROM `product`");
            }

            if (Session["UserData"] == null)
            {
                HyperLink3.Visible = false;
                LinkButton1.Visible = false;
                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
            }
            else
            {
                UserData = Session["UserData"] as string[];        
                HyperLink3.Text = UserData[1] + "您好";
                HyperLink3.Visible = true;
                HyperLink1.Visible = false;
                HyperLink2.Visible = false;
                LinkButton1.Visible = true;
                HyperLink3.Font.Size = 13;
                if (UserData[4] == "1")
                {
                    LinkButton3.Visible = true;
                }
            }
            
        }
        public void GetProduct(String productcomm) //取得商品目錄
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string text1 = ""; //分頁
                string text2 = ""; //分頁
                string text3 = ""; //加購購物車按鈕
                string price = ""; //
                Literal1.Text = "";
                int count = 0;
                string tt="";
                MySqlCommand cmd = new MySqlCommand(productcomm);
                con.Open();
                cmd.Connection = con;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count += 1;
                        if (Session["UserData"] != null)
                        {
                            UserData = Session["UserData"] as string[];
                            if (UserData[4] == "1") //管理員印出修改商品按鈕
                            {
                                tt = "<div class='send__btn'> <a class='fr__btn' href='edit_Product.aspx?Proid=" + reader["Pro_ID"] + "'>修改商品</a></div>";
                            }
                        }
                        if (Session["UserData"] !=null && reader["Pro_Count"].ToString() !="0") //當使用者有登入和商品總合為0時，印出加入購物車按鈕
                        {
                            text3 = " <li><a href='index.aspx?Shoppingid=" + reader["Pro_ID"] + "&ShoppingName=" + reader["Pro_Name"] + "&ShoppingPrice=" + reader["Pro_Price"] + "'><i class='icon-handbag icons'></i></a></li>"; //加入購物車按鈕，有登入才會顯示
                        }
                        else
                        {
                            text3 = "";
                        }
                        if (reader["Pro_Count"].ToString() != "0")
                        {
                            price = "$ "+reader["Pro_Price"].ToString();
                        }
                        else
                        {
                            price = "已售完";
                        }
                        if (count.ToString("00").Substring(1, 1) =="1")
                        {
                        text1= "<div class='jumbotron page' style='background-color:white' id='page"+ (int.Parse(count.ToString("00").Substring(0, 1)) + 1).ToString() + "'>";
                        }
                        else
                        {
                            text1 = "";
                        }
                        if (count.ToString("00").Substring(1, 1) == "0")
                        {
                            text2 = "</div>";
                        }
                        else
                        {
                            text2 = "";
                        }

                        Literal2.Text = ((count / 10) + 1).ToString();
                        //使用Literal1元件可以避免Label會出現Span標籤造成跑版
                        Literal1.Text += text1+
                             "<div class='col-md-3 col-lg-3 col-sm-6 col-xs-12' >" +
                            " <div class='category'>" +
                            "<div class='ht__cat__thumb'>" +
                            " <a href='product-details.aspx?Proid=" + reader["Pro_ID"] + "'>" +
                            "<img src='images/product/" + reader["Pro_ID"] + "/main.jpg' height='290' width='385' alt='" + reader["Pro_ID"]+"'>" +
                            "</a>" +
                            " </div>" +
                            "<div class='fr__hover__info'>" +
                            "<ul class='product__action'>" +
                            text3+
                            " </ul>" +
                            "</div>" +
                            "<div class='fr__product__inner'>" +
                            "<h4><a href='product-details.aspx?Proid="+reader["Pro_ID"] + "'>" + reader["Pro_Name"] +"</a></h4>" +
                            " <ul class='fr__pro__prize'>" +
                            "<li>"+price +"</li>" +
                            "</ul>" +
                            tt +
                            " </div>" +
                            "</div>" +
                            "</div>"
                            + text2;                   
                    }
                    con.Close();
                }
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e) ///登出
        {
            Session["UserData"] = null;
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Button1_Click1(object sender, EventArgs e) //登入
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                string comm = "SELECT * FROM member where  Men_account ='" + TextBox1.Text + "' and Men_Password = '" + TextBox2.Text + "'";
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


        protected void Button2_Click1(object sender, EventArgs e) //註冊
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
            if (DropDownList1.SelectedItem.ToString() == "價格由高到低")
            {
                GetProduct("SELECT * FROM `product` ORDER BY `product`.`Pro_Price` DESC");
            }
            if (DropDownList1.SelectedItem.ToString() == "價格由低到高")
            {
                GetProduct("SELECT * FROM `product` ORDER BY `product`.`Pro_Price` ASC");
            }

        }
    }
}  
    

