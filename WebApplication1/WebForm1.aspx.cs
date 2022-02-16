using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
   
    public partial class WebForm1 : System.Web.UI.Page
    {
        string constr = "Data Source = localhost; port= 3306; Initial Catalog= asp;" +
             "User Id = aaa; password = aaa";
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //Literal1.Text = "";
                con.Open();
                string comm = "SELECT * FROM `product`";
                MySqlCommand cmd = new MySqlCommand(comm);
                cmd.Connection = con;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //使用Literal1元件可以避免Label會出現Span標籤造成跑版
                        Literal1.Text = Literal1.Text + " <div class='col-md-4 col-lg-3 col-sm-4 col-xs-12'>" +
                            "<div class='category'>" +
                            " <div class='ht__cat__thumb'>" +
                            "<a href='product-details.html'>" +
                            "<img src='images/product/" + reader["Pro_ID"] + ".jpg' alt='product images'>" +
                            "</a>" +
                            "</div>" +
                            "<div class='fr__hover__info'>" +
                            "<ul class='product__action'>" +
                            "<li><a href='wishlist.html'><i class='icon-heart icons'></i></a></li>" +
                            "<li><a href='cart.html'><i class='icon-handbag icons'></i></a></li>" +
                            "<li><a href='#'><i class='icon-shuffle icons'></i></a></li>" +
                            "</ul>" +
                            "</div>" +
                            "<div class='fr__product__inner'>" +
                            "<h4><a href='product-details.html'>"+reader["Pro_Name"] +"</a></h4>" +
                            "<ul class='fr__pro__prize'>" +
                            "<li class='old__prize'>"+ reader["Pro_Price"] + "</li>" +
                            "<li>$25.9</li>" +
                            "</ul>" +
                            "</div>" +
                            "</div>" +
                            "</div>";
                            Literal2.Text = Literal2.Text + "<div class='ht__list__product'>" +
                            "<div class='ht__list__thumb'>" +
                            "<a href='product-details.html'><img src='images/product-2/pro-1/1.jpg' alt='product images'></a>" +
                            " </div>" +
                            "<div class='htc__list__details'>" +
                            "<h2><a href='product-details.html'>"+ reader["Pro_Name"] + "</a></h2>" +
                            " <ul  class='pro__prize'>" +
                            "<li class='old__prize'>$82.5</li>" +
                            "<li>$75.2</li>" +
                            " </ul>" +
                            
                            " </ul>" +
                            " <p>Lorem ipsum dolor sit amet, consectetur adipisLorem ipsum dolor sit amet, consec adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqul Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>" +
                            "<div class='fr__list__btn'>" +
                            "<a class='fr__btn' href='cart.html'>Add To Cart</a>" +
                            "  </div>" +
                            " </div>" +
                            "</div>";
                    }
                }
                con.Close();
            }
        }

  

        
    }
}