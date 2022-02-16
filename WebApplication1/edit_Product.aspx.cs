using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class edit_Product : System.Web.UI.Page
    {
        string constr = "Data Source = localhost; port= 3306; Initial Catalog= asp;" +
                 "User Id = aaa; password = aaa";
        string[] UserData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userdata"] != null)
            {
                UserData = Session["UserData"] as string[];         
                HttpCookie getshopsession = Request.Cookies[UserData[0]]; //把SESSION資料取出，去做ID疊加
                if (getshopsession != null)
                {
                    string word1 = HttpUtility.UrlDecode(getshopsession.Values["ID"]);
                    string[] shoplist = word1.Split(',').Distinct().ToArray();
                    shoplist = shoplist.Where(val => val != "0").ToArray();
                    Literal1.Text = shoplist.Length.ToString();
                }
                else
                {
                    Literal1.Text = "0";
                }
            }
            else
            {
                Literal1.Text = "0";
            }

            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            String Productid = Request.QueryString["Proid"];
            String isNew = Request.QueryString["New"];
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

            if (isNew == "Yes")
            {
                Button3.Visible = false;
                Button4.Visible = true;
                Button5.Visible = false;
            }
            else
            {
                Button3.Visible = true;
                Button4.Visible = false;
                Button5.Visible = true;
            }

            if (!IsPostBack)
            {
                if (isNew == "Yes") //新增商品模式
                {
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        con.Open();
                        string comm = "SELECT Max(`Pro_ID`) from product";
                        MySqlCommand cmd = new MySqlCommand(comm);
                        cmd.Connection = con;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["Max(`Pro_ID`)"].ToString() !="")
                                {
                                    int proid = int.Parse(reader["Max(`Pro_ID`)"].ToString()) + 1;
                                    TextBox8.Text = proid.ToString();
                                }
                                else
                                {
                                    TextBox8.Text = "1";
                                }                              
                            }
                        }
                        con.Close();
                    }
                }
                else //修改商品模式
                {
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        con.Open();
                        string comm = "SELECT * FROM product where  `Pro_ID` ='" + Productid + "'";
                        MySqlCommand cmd = new MySqlCommand(comm);
                        cmd.Connection = con;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TextBox8.Text = reader["Pro_ID"].ToString();
                                TextBox9.Text = reader["Pro_Name"].ToString();
                                TextBox10.Text = reader["Pro_Name_1"].ToString();
                                TextBox11.Text = reader["Pro_Count"].ToString();
                                TextBox12.Text = reader["Pro_Price"].ToString();
                                Txt1.Text = reader["Pro_Description"].ToString();
                            }

                        }
                        con.Close();
                    }
                }

            }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e) //登出
        {

            Session["UserData"] = null;
            Response.Redirect("index.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e) //登入帳號
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

        protected void Button3_Click(object sender, EventArgs e) //更新商品資料
        {
            Directory.CreateDirectory(Server.MapPath("~/images/product/" + TextBox8.Text + "/"));
            if (FileUpload1.HasFiles)
            {
                if (!Directory.Exists(@"~/images/product/" + TextBox8.Text))
                {
                    string path = Server.MapPath("~/images/product/") + TextBox8.Text;
                    System.IO.Directory.CreateDirectory(path);
                }
                String fileName = "main.jpg";
                String savePath = Server.MapPath("~/images/product/" + TextBox8.Text + "/");
                String saveResult = savePath + fileName;
                FileUpload1.SaveAs(saveResult);
            }
            else
            {
                String savePath = Server.MapPath("~/images/No_Image.jpg");
                String savePath2 = Server.MapPath("~/images/product/" + TextBox8.Text + "/main.jpg");     
                if (!File.Exists(@"~/images/product/"+TextBox8.Text+"/main.jpg"))
                {

                    File.Copy(@savePath, @savePath2,true);
                }
   

            }
            if (FileUpload2.HasFiles)
            {
                if (!Directory.Exists(@"~/images/product/" + TextBox8.Text))
                {
                    string path = Server.MapPath("~/images/product/") + TextBox8.Text;
                    System.IO.Directory.CreateDirectory(path);
                }
                String fileName = "m1.jpg";
                String savePath = Server.MapPath("~/images/product/" + TextBox8.Text + "/");
                String saveResult = savePath + fileName;
                FileUpload2.SaveAs(saveResult);
            }
            else
            {
                String savePath = Server.MapPath("~/images/No_Image.jpg");
                String savePath2 = Server.MapPath("~/images/product/" + TextBox8.Text + "/m1.jpg");
                if (!File.Exists(@"~/images/product/" + TextBox8.Text + "/m1.jpg"))
                {

                    File.Copy(@savePath, @savePath2, true);
                }
            }
            if (FileUpload3.HasFiles)
            {
                if (!Directory.Exists(@"~/images/product/" + TextBox8.Text))
                {
                    string path = Server.MapPath("~/images/product/") + TextBox8.Text;
                    System.IO.Directory.CreateDirectory(path);
                }
                String fileName = "m2.jpg";
                String savePath = Server.MapPath("~/images/product/" + TextBox8.Text + "/");
                String saveResult = savePath + fileName;
                FileUpload3.SaveAs(saveResult);
            }
            else
            {
                String savePath = Server.MapPath("~/images/No_Image.jpg");
                String savePath2 = Server.MapPath("~/images/product/" + TextBox8.Text + "/m2.jpg");
                if (!File.Exists(@"~/images/product/" + TextBox8.Text + "/m2.jpg"))
                {

                    File.Copy(@savePath, @savePath2, true);
                }
            }
            if (FileUpload4.HasFiles)
            {
                if (!Directory.Exists(@"~/images/product/" + TextBox8.Text))
                {
                    string path = Server.MapPath("~/images/product/") + TextBox8.Text;
                    System.IO.Directory.CreateDirectory(path);
                }
                String fileName = "m3.jpg";
                String savePath = Server.MapPath("~/images/product/" + TextBox8.Text + "/");
                String saveResult = savePath + fileName;
                FileUpload4.SaveAs(saveResult);
            }
            else
            {
                String savePath = Server.MapPath("~/images/No_Image.jpg");
                String savePath2 = Server.MapPath("~/images/product/" + TextBox8.Text + "/m3.jpg");
                if (!File.Exists(@"~/images/product/" + TextBox8.Text + "/m3.jpg"))
                {

                    File.Copy(@savePath, @savePath2, true);
                }
            }
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string sql = "UPDATE  `product`  SET  `Pro_Name` ='"+ TextBox9.Text+ "',Pro_Name_1='" +TextBox10.Text+ "',Pro_Count='" + TextBox11.Text+"',Pro_Price='"+TextBox12.Text+ "',Pro_Description='" +Txt1.Text+ "' where Pro_ID='" + TextBox8.Text+"'";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql))
                {
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                con.Close();
            }
            Response.Write("<SCRIPT LANGUAGE='JavaScript'>window.alert('更新成功');window.location.href='index.aspx';</SCRIPT >");

        }


        protected void Button4_Click1(object sender, EventArgs e)//新增商品資料
        {
            Directory.CreateDirectory(Server.MapPath("~/images/product/" + TextBox8.Text + "/"));

            if (FileUpload1.HasFiles)
            {
                if (!Directory.Exists(@"~/images/product/" + TextBox8.Text))
                {
                    string path = Server.MapPath("~/images/product/") + TextBox8.Text;
                    System.IO.Directory.CreateDirectory(path);
                }
                String fileName = "main.jpg";
                String savePath = Server.MapPath("~/images/product/" + TextBox8.Text + "/");
                String saveResult = savePath + fileName;
                FileUpload1.SaveAs(saveResult);
            }
            else
            {
                String savePath = Server.MapPath("~/images/No_Image.jpg");
                String savePath2 = Server.MapPath("~/images/product/" + TextBox8.Text + "/main.jpg");
                if (!File.Exists(@"~/images/product/" + TextBox8.Text + "/main.jpg"))
                {

                    File.Copy(@savePath, @savePath2, true);
                }
            }
            if (FileUpload2.HasFiles)
            {
                if (!Directory.Exists(@"~/images/product/" + TextBox8.Text))
                {
                    string path = Server.MapPath("~/images/product/") + TextBox8.Text;
                    System.IO.Directory.CreateDirectory(path);
                }
                String fileName = "m1.jpg";
                String savePath = Server.MapPath("~/images/product/" + TextBox8.Text + "/");
                String saveResult = savePath + fileName;
                FileUpload2.SaveAs(saveResult);
            }
            else
            {
                String savePath = Server.MapPath("~/images/No_Image.jpg");
                String savePath2 = Server.MapPath("~/images/product/" + TextBox8.Text + "/m1.jpg");
                if (!File.Exists(@"~/images/product/" + TextBox8.Text + "/m1.jpg"))
                {

                    File.Copy(@savePath, @savePath2, true);
                }
            }
            if (FileUpload3.HasFiles)
            {
                if (!Directory.Exists(@"~/images/product/" + TextBox8.Text))
                {
                    string path = Server.MapPath("~/images/product/") + TextBox8.Text;
                    System.IO.Directory.CreateDirectory(path);
                }
                String fileName = "m2.jpg";
                String savePath = Server.MapPath("~/images/product/" + TextBox8.Text + "/");
                String saveResult = savePath + fileName;
                FileUpload3.SaveAs(saveResult);
            }
            else
            {
                String savePath = Server.MapPath("~/images/No_Image.jpg");
                String savePath2 = Server.MapPath("~/images/product/" + TextBox8.Text + "/m2.jpg");
                if (!File.Exists(@"~/images/product/" + TextBox8.Text + "/m2.jpg"))
                {

                    File.Copy(@savePath, @savePath2, true);
                }
            }
            if (FileUpload4.HasFiles)
            {
                if (!Directory.Exists(@"~/images/product/" + TextBox8.Text))
                {
                    string path = Server.MapPath("~/images/product/") + TextBox8.Text;
                    System.IO.Directory.CreateDirectory(path);
                }
                String fileName = "m3.jpg";
                String savePath = Server.MapPath("~/images/product/" + TextBox8.Text + "/");
                String saveResult = savePath + fileName;
                FileUpload4.SaveAs(saveResult);
            }


            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string sql = "INSERT INTO `product` (`Pro_ID`, `Pro_Name`, `Pro_Name_1`, `Pro_Count`, `Pro_Price`,  `Pro_Description`) VALUES ("+TextBox8.Text+", '" + TextBox9.Text + "', '" + TextBox10.Text + "', '" + TextBox11.Text + "', '" + TextBox12.Text + "', '" + Txt1.Text + "')";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql))
                {
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    
                }
                con.Close();
            }
            Response.Write("<SCRIPT LANGUAGE='JavaScript'>window.alert('商品新增成功');window.location.href='index.aspx';</SCRIPT >");

        }

        protected void Button5_Click(object sender, EventArgs e) //刪除資料
        {
            Directory.Delete(Server.MapPath("~/images/product/" + TextBox8.Text + "/"),true);
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string sql = "DELETE FROM `product` WHERE `product`.`Pro_ID` = '"+ TextBox8.Text+"'";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql))
                {
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>window.alert('商品刪除成功');window.location.href='index.aspx';</SCRIPT >");

                }
                con.Close();
            }
        }
    }
}
