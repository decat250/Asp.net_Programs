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
    public partial class Simple : System.Web.UI.Page
    {
        string constr = "Data Source = localhost; port= 3306; Initial Catalog= asp;" +
                "User Id = aaa; password = aaa";
        string[] shoplist;
        string comm;
        string[] UserData;

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                RadioButtonList1.Items.Add("面交");
                RadioButtonList1.Items.Add("郵寄");
                RadioButtonList2.Items.Add("匯款");
            }

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
            if ((Session["UserData"] != null))
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
                if (shoplist.Length ==0)
                {
                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>window.alert('購物車中沒有項目');window.location.href='index.aspx';</SCRIPT >");
                }
            }
            
            string deletesession = Request.QueryString["deleteid"];
            if (deletesession != null)
            {
                if ((Session["UserData"] != null))
                {
                    UserData = Session["UserData"] as string[];
                    HttpCookie shoplistc = Request.Cookies[UserData[0]];
                    string temp = (System.Web.HttpContext.Current.Server.UrlDecode(shoplistc.Values["ID"]));
                    shoplist = temp.Split(',');
                    shoplist = shoplist.Where(val => val != deletesession).ToArray();
                    string word = "";
                    for (int i = 0; i < shoplist.Count(); i++)
                    {
                        if (i == 0)
                        {
                            word += shoplist[i];
                        }
                        else
                        {
                            word += "," + shoplist[i];
                        }
                    }
                    HttpCookie myCookie = new HttpCookie(UserData[0]);

                    if (word == "")
                    {
                        myCookie.Values.Add("ID", System.Web.HttpContext.Current.Server.UrlEncode("0"));
                    }
                    else
                    {
                        myCookie.Values.Add("ID", System.Web.HttpContext.Current.Server.UrlEncode(word));
                    }
                    myCookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(myCookie);
                    Response.Redirect("checkout.aspx");
                }
                
            }

            if ((Session["UserData"] != null))
            {
                UserData = Session["UserData"] as string[];
                HttpCookie read = Request.Cookies[UserData[0]];
                if (read != null)
                {
                    HttpCookie shoplistc = Request.Cookies[UserData[0]];
                    string temp = (System.Web.HttpContext.Current.Server.UrlDecode(shoplistc.Values["ID"]));
                    shoplist = temp.Split(',');
                    for (int i = 0; i < shoplist.Count(); i++)
                    {
                        //Response.Write(shoplist[i]+"<br>");
                    }

                    if (shoplist.Count() == 1)
                    {
                        comm = "SELECT * FROM `product` WHERE `Pro_ID` =" + shoplist[0];
                        //Response.Write(comm);
                    }
                    else
                    {
                        comm = "SELECT * FROM `product` WHERE `Pro_ID` =" + shoplist[0];
                        for (int i = 1; i < shoplist.Count(); i++)
                        {
                            comm += " or `Pro_ID` = " + shoplist[i];
                        }
                    }
                }
                else
                {
                    comm = "SELECT * FROM `product` WHERE `Pro_ID` =0";
                }

                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    int countshpp = 0;
                    Literal1.Text = "";
                    MySqlCommand cmd = new MySqlCommand(comm);
                    con.Open();
                    cmd.Connection = con;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string countdrop = "";
                            countshpp += 1;

                            int count = int.Parse(reader["Pro_Count"].ToString());
                            for (int i = 1; i <= count; i++)
                            {
                                countdrop += "<option>" + i + "</option>";
                            }

                            Literal1.Text += "<tr>" +
                                "<td class=''product-remove''><a href='checkout.aspx?deleteid=" + reader["Pro_ID"] + "'>×</a></td>" +
                                "<td class=''product-thumbnail''><a href=''#''><img src='images/product/" + reader["Pro_ID"] + "/main.jpg' alt='' style='height:385;width:290;'></a></td>" +
                                "<td class=''product-name''><a href='product-details.aspx?Proid=" + reader["Pro_ID"]+"' >" + reader["Pro_Name"] + "</a></td>" +
                                "<td id='shopprice" + countshpp + "'>" + reader["Pro_Price"] + "</td>" +
                                " <td class=''product-stock-status''><span class='wishlist-in-stock '><select id='buyitem" + countshpp + "' onchange='runcallcount()' name='buyitem" + countshpp + "'  id='exampleFormControlSelect1'>" + countdrop + "</select></span></td>" +
                                "<input type='hidden' name='buyid" + countshpp + "' value='" + reader["Pro_ID"] + "'>" +
                                "</tr>";
                        }
                        con.Close();
                    }
                    string word = "";
                    for (int i = 1; i <= countshpp; i++)
                    {
                        Literal3.Text += "var item" + i + " = document.getElementById(\"shopprice" + i + "\").innerHTML;" +
                            "var temp" + i + " = document.getElementById(\"buyitem" + i + "\");" +
                            "var count" + i + " = temp" + i + ".options[temp" + i + ".selectedIndex].value;";

                        word += "parseInt(item" + i + ") * count" + i + "+";
                    }
                    if (word.Length > 0)
                    {
                        Literal4.Text = word.Substring(0, word.Length - 1);
                        Literal5.Text = word.Substring(0, word.Length - 1);


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

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["UserData"] !=null)
            {
                UserData = Session["UserData"] as string[];
                HttpCookie getshopsession = Request.Cookies[UserData[0]]; //把SESSION資料取出，將計算購物車商品數量
                string word1 = HttpUtility.UrlDecode(getshopsession.Values["ID"]);
                shoplist = word1.Split(',').Distinct().ToArray();
                shoplist = shoplist.Where(val => val != "0").ToArray();

                ArrayList myAL = new ArrayList(); //裝要減數量的商品ID
                for(int i=1;i<= shoplist.Length;i++)
                {
                    myAL.Add(Request.Form["buyid"+i]);
                }
                ArrayList myAL1 = new ArrayList(); //裝要減的數量
                for (int i = 1; i <= shoplist.Length; i++)
                {
                    myAL1.Add(Request.Form["buyitem" + i]);
                }

                string shoplistword = "";
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    for (int i = 0; i < myAL.Count; i++)
                    {
                        con.Open();
                        MySqlCommand getitemname = new MySqlCommand("select * from product where Pro_ID=" + myAL[i]);
                        getitemname.Connection = con;
                        using (var reader = getitemname.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                shoplistword += "商品名稱:" + reader["Pro_Name"] +"數量:"+ myAL1[i] + "<br>";
                            }
                        }
                        con.Close();
                        
                    }
                    Response.Write(shoplistword);

                    
                    for (int i = 0; i < myAL.Count;i++)
                    {
                            string sql = "UPDATE `product` SET `Pro_Count` = `Pro_Count`-"+ myAL1[i]+ " WHERE `product`.`Pro_ID` = "+myAL[i]+"";
                            con.Open();

                            using (MySqlCommand cmd = new MySqlCommand(sql))
                            {
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                            }
                            con.Close();
                      }

                        string newhistory = "INSERT INTO `buy_history` VALUES (NULL, '"+UserData[0]+"', '"+ Request.Form["name"] + "', '"+ Request.Form["phone"] + "', '"+ Request.Form["country"] + Request.Form["place1"] + "', '"+ Request.Form["pick"] + "', '"+ Request.Form["Money"] + "', '" + Request.Form["shopcount"] + "','未出貨','"+ shoplistword +"')";
                        con.Open();

                        using (MySqlCommand cmd = new MySqlCommand(newhistory))
                        {
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();

                        }
                        con.Close();
                       
                }
                HttpCookie myCookie = new HttpCookie(UserData[0]);
                myCookie.Values.Add("ID", "0");
                myCookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(myCookie);
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>window.alert('訂單送出成功');window.location.href='index.aspx';</SCRIPT >");





            }
        }
    }
}
