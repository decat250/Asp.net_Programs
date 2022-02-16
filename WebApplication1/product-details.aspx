<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product-details.aspx.cs" Inherits="WebApplication1.product_details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>商品資訊|藍色髒東西購物網站</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Place favicon.ico in the root directory -->
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico">
    <link rel="apple-touch-icon" href="apple-touch-icon.png">


    <!-- All css files are included here. -->
    <!-- Bootstrap fremwork main css -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <!-- Owl Carousel min css -->
    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/owl.theme.default.min.css">
    <!-- This core.css file contents all plugings css file. -->
    <link rel="stylesheet" href="css/core.css">
    <!-- Theme shortcodes/elements style -->
    <link rel="stylesheet" href="css/shortcode/shortcodes.css">
    <!-- Theme main style -->
    <link rel="stylesheet" href="style.css">
    <!-- Responsive css -->
    <link rel="stylesheet" href="css/responsive.css">
    <!-- User style -->
    <link rel="stylesheet" href="css/custom.css">
    <!-- Modernizr JS -->
    <script src="js/vendor/modernizr-3.5.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="wrapper">
        <!-- Start Header Style -->
        <header id="htc__header" class="htc__header__area header--one">
            <!-- Start Mainmenu Area -->
            <div id="sticky-header-with-topbar" class="mainmenu__wrap sticky__header">
                <div class="container-fluid " style="background-color:lightgray;>
                    <div class="row">
                        <div class="menumenu__container clearfix">
                            <div class="col-lg-2 col-md-2 col-sm-3 col-xs-5"> 
                                <div class="logo">
                                     <a href="index.aspx"><img src="images/logo/4.png" alt="logo images"></a>
                                </div>
                            </div>
                           <div class="col-md-7 col-lg-8 col-sm-5 col-xs-3">
                                <nav class="main__menu__nav hidden-xs hidden-sm">
                                    <ul class="main__menu">
                                       <li class="drop"><a href="index.aspx">所有商品</a></li>
                                        <li class="drop"><a href="noctice.aspx">購買須知</a> </li>
                                        <li class="drop"><a href="History.aspx">訂單查詢</a> </li>                 
                                        <li><a href="contactus.aspx">聯絡我們</a></li>
                                    </ul>
                                </nav>
                                <div class="mobile-menu clearfix visible-xs visible-sm">
                                    <nav id="mobile_dropdown">
                                        <ul>
                                          <li class="drop"><a href="index.aspx">所有商品</a></li>
                                        <li class="drop"><a href="noctice.aspx">購買須知</a> </li>
                                        <li class="drop"><a href="History.aspx">訂單查詢</a> </li>                 
                                        <li><a href="contactus.aspx">聯絡我們</a></li>
                                        </ul>
                                    </nav>
                                </div>  
                            </div>
                            <div class="col-md-3 col-lg-2 col-sm-4 col-xs-4">
                                <div class="header__right">
                                    <div class="header__account">
                                    <asp:LinkButton ID="LinkButton2" runat="server">LinkButton</asp:LinkButton>
                                    </div>
                                    <div class="header__account">
                                      <asp:HyperLink ID="HyperLink1" href="#" runat="server" data-toggle="modal" data-target="#Login">登入</asp:HyperLink>  
                                    </div>
                                    <div class="header__account">
                                      <asp:HyperLink ID="HyperLink2" href="#" runat="server" data-toggle="modal" data-target="#Signup">註冊</asp:HyperLink>  
                                    </div>   
                                    <div class="header__account">
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">登出</asp:LinkButton>
                                    </div> 
                                    <div class="htc__shopping__cart">
                                        <a href="Checkout.aspx"><i class="icon-handbag icons"></i></a>
                                        <a href="Checkout.aspx"><span class="htc__qua"><asp:Literal ID="Literal11" runat="server"></asp:Literal></span></a>
                                    </div>
                                </div>
                        </div>
                    </div>
                    <div class="mobile-menu-area"></div>
                </div>
            </div>
            <!-- End Mainmenu Area -->
        </header>
        <!-- End Header Area -->

         
       <section class="htc__product__details bg__white ptb--100">
            <!-- Start Product Details Top -->
            <div class="htc__product__details__top">
                <div class="container">
                    <div class="row">
                        <div class="col-md-5 col-lg-5 col-sm-12 col-xs-12">
                            <div class="htc__product__details__tab__content">
                                <!-- Start Product Big Images -->
                                <div class="product__big__images">
                                    <div class="portfolio-full-image tab-content">
                                        <div role="tabpanel" class="tab-pane fade in active" id="img-tab-1">
                                            <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade" id="img-tab-2">
                                            <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade" id="img-tab-3">
                                            <asp:Literal ID="Literal7" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <!-- End Product Big Images -->
                                <!-- Start Small images -->
                                <ul class="product__small__images" role="tablist">
                                    <li role="presentation" class="pot-small-img active">
                                        <a href="#img-tab-1" role="tab" data-toggle="tab">
                                             <asp:Literal ID="Literal8" runat="server"></asp:Literal>
                                        </a>
                                    </li>
                                    <li role="presentation" class="pot-small-img">
                                        <a href="#img-tab-2" role="tab" data-toggle="tab">
                                             <asp:Literal ID="Literal9" runat="server"></asp:Literal>
                                        </a>
                                    </li>
                                    <li role="presentation" class="pot-small-img">
                                        <a href="#img-tab-3" role="tab" data-toggle="tab">
                                             <asp:Literal ID="Literal10" runat="server"></asp:Literal>
                                        </a>
                                    </li>
                                </ul>
                                <!-- End Small images -->
                            </div>
                        </div>
                        <div class="col-md-7 col-lg-7 col-sm-12 col-xs-12 smt-40 xmt-40">
                            <div class="ht__product__dtl">
                                <h2>
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                               
                              </h2>
                                <ul  class="pro__prize">
                                    <li>
                                       <asp:Literal ID="Literal2" runat="server"></asp:Literal>

                                    </li>
                                </ul>
                                <p class="pro__info">
                                    <asp:Literal ID="Literal3" runat="server" ></asp:Literal>
                                    </p>
                                <div class="ht__pro__desc">
                                    
                                    <div class="sin__desc align--left">
                                        <p><span>數量</span></p>
                                        <asp:Literal ID="Literal12" runat="server"></asp:Literal>
                                    </div>                                                             
                                </div>
                            </div>
                            <div class="send__btn">
                                <asp:Literal ID="Literal13" runat="server"></asp:Literal>
                                        </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End Product Details Top -->
        </section>
        
        <section class="htc__produc__decription bg__white">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <!-- Start List And Grid View -->
                        <ul class="pro__details__tab" role="tablist">
                            <li role="presentation" class="description active"><a href="#description" role="tab" data-toggle="tab">商品描述</a></li>                  
                        </ul>
                        <!-- End List And Grid View -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="ht__pro__details__content">
                            <!-- Start Single Content -->
                            <div role="tabpanel" id="description" class="pro__single__content tab-pane fade in active">
                                <asp:Literal ID="Literal4" runat="server"></asp:Literal>

                            </div>
                           
                            <!-- End Single Content -->
                        </div>
                    </div>
                </div>
            </div>
        </section>
 
       
        <!-- End Brand Area -->
        <!-- Start Banner Area -->
        <div class="htc__banner__area">
            <ul class="banner__list owl-carousel owl-theme clearfix">
                <li><a href="product-details.html"><img src="images/banner/bn-3/1.jpg" alt="banner images"></a></li>
                <li><a href="product-details.html"><img src="images/banner/bn-3/2.jpg" alt="banner images"></a></li>
                <li><a href="product-details.html"><img src="images/banner/bn-3/3.jpg" alt="banner images"></a></li>
                <li><a href="product-details.html"><img src="images/banner/bn-3/4.jpg" alt="banner images"></a></li>
                <li><a href="product-details.html"><img src="images/banner/bn-3/5.jpg" alt="banner images"></a></li>
                <li><a href="product-details.html"><img src="images/banner/bn-3/6.jpg" alt="banner images"></a></li>
                <li><a href="product-details.html"><img src="images/banner/bn-3/1.jpg" alt="banner images"></a></li>
                <li><a href="product-details.html"><img src="images/banner/bn-3/2.jpg" alt="banner images"></a></li>
            </ul>
        </div>
        <!-- End Banner Area -->
        <!-- End Banner Area -->
        <!-- Start Footer Area -->
     
        <footer id="htc__footer">
            <!-- Start Footer Widget -->
            <div class="footer__container bg__cat--1">
                <div class="container">
                    <div class="row">
                        <!-- Start Single Footer Widget -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="footer">
                                <h2 class="title__line--2">關於我們</h2>
                                <div class="ft__details">
                                    <p>我們是一個新創立的購物網站 期望建立出讓使用者可以更方便購物的交易平台</p>
                                    <div class="ft__social__link">
                                        <ul class="social__link">
                                            <li><a href="#"><i class="icon-social-twitter icons"></i></a></li>

                                            <li><a href="#"><i class="icon-social-instagram icons"></i></a></li>

                                            <li><a href="#"><i class="icon-social-facebook icons"></i></a></li>

                                            <li><a href="#"><i class="icon-social-google icons"></i></a></li>

                                            <li><a href="#"><i class="icon-social-linkedin icons"></i></a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- End Single Footer Widget -->
                        <!-- Start Single Footer Widget -->
                        <div class="col-md-2 col-sm-6 col-xs-12 xmt-40">
                            <div class="footer">
                                <h2 class="title__line--2">地址</h2>
                                <div class="ft__inner">
                                    <ul class="ft__list">
                                        <p>新北市板橋區四川路二段58號</p>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- End Single Footer Widget -->
                        <!-- Start Single Footer Widget -->
                        <div class="col-md-2 col-sm-6 col-xs-12 xmt-40 smt-40">
                            <div class="footer">
                                <h2 class="title__line--2">服務特色</h2>
                                <div class="ft__inner">
                                    <ul class="ft__list">
                                        <li><a href="#">滿指定金額免運費</a></li>
                                        <li><a href="cart.html">全省宅配到府</a></li>
                                        <li><a href="#">購物即有購物金優惠</a></li>
                                        
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- End Single Footer Widget -->
                        <!-- Start Single Footer Widget -->
                        <div class="col-md-2 col-sm-6 col-xs-12 xmt-40 smt-40">
                            <div class="footer">
                                <h2 class="title__line--2">合作廠商</h2>
                                <div class="ft__inner">
                                    <ul class="ft__list">
                                        <li><a href="#">沒屋頂拍賣</a></li>
                                        <li><a href="#">藍色鬼屋股份有限公司</a></li>
                                        <li><a href="#">白貓宅急便</a></li>
                                        <li><a href="#">亞東物流</a></li>
                               
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- End Single Footer Widget -->
                        <!-- Start Single Footer Widget -->
                        <div class="col-md-3 col-sm-6 col-xs-12 xmt-40 smt-40">
                            <div class="footer">
                                <h2 class="title__line--2">與我們合作 </h2>
                                <div class="ft__inner">
                                    <div class="news__input">
                                        <input type="text" placeholder="Your Mail*">
                                        <div class="send__btn">
                                            <a class="fr__btn" href="#">Send Mail</a>
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                        <!-- End Single Footer Widget -->
                    </div>
                </div>
            </div>
            <!-- End Footer Widget -->
            <!-- Start Copyright Area -->
        
            <!-- End Copyright Area -->
        </footer>
        <!-- End Footer Style -->
    </div>
        </div>
     <div class="modal fade" id="Login" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">登入帳號</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
        <div class="modal-body">
            <div class="form-group">
                <label for="exampleInputEmail1">會員帳號</label>
                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">會員密碼</label>
                 <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
            </div>
           
        </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">關閉</button>
          <asp:Button ID="Button1" class="btn btn-secondary" runat="server" Text="登入" OnClick="Button1_Click1" />
      </div>
    </div>
  </div>
</div>
        <div class="modal fade" id="Signup" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="">會員註冊</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="exampleInputEmail1">會員帳號</label>
                        <asp:TextBox ID="TextBox3" runat="server" class="form-control"  placeholder="請輸入會員帳號"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">使用者姓名</label>
                        <asp:TextBox ID="TextBox4" runat="server" class="form-control"  placeholder="請輸入姓名"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">信箱</label>
                        <asp:TextBox ID="TextBox5" runat="server" class="form-control" placeholder="請輸入信箱"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">密碼</label>
                        <asp:TextBox ID="TextBox6" runat="server" class="form-control" placeholder="請輸入密碼" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">請重新輸入密碼</label>
                        <asp:TextBox ID="TextBox7" runat="server" class="form-control" placeholder="請輸入密碼" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="兩次的密碼不一致" ControlToCompare="TextBox6" ControlToValidate="TextBox7"></asp:CompareValidator>

                        </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">關閉</button>
                    <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="註冊" OnClick="Button2_Click1" />
                </div>
            </div>
        </div>
    </div>
            </form>

    <script src="js/vendor/jquery-3.2.1.min.js"></script>
    <!-- Bootstrap framework js -->
    <script src="js/bootstrap.min.js"></script>
    <!-- All js plugins included in this file. -->
    <script src="js/plugins.js"></script>
    <script src="js/slick.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <!-- Waypoints.min.js. -->
    <script src="js/waypoints.min.js"></script>
    <!-- Main js file that contents all jQuery plugins activation. -->
    <script src="js/main.js"></script>
</body>
</html>
