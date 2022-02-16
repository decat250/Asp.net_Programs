<%@ Page Language="C#"  validateRequest="false" AutoEventWireup="true" CodeBehind="Noctice.aspx.cs" Inherits="WebApplication1.Noctice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>購買須知|藍色髒東西購物網站</title>
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
        <script src="ckeditor/ckeditor.js" type="text/javascript"></script>

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
                                        <a class="" href="checkout.aspx"><i class="icon-handbag icons"></i></a>
                                                      <a href="checkout.aspx">
                                            <span class="htc__qua"><asp:Literal ID="Literal2" runat="server"></asp:Literal></span>                                    </div>
                                </div>
                        </div>
                    </div>
                    <div class="mobile-menu-area"></div>
                </div>
            </div>
            <!-- End Mainmenu Area -->
        </header>
            <div class="shopping__cart">
                <div class="shopping__cart__inner">
                    <div class="offsetmenu__close__btn">
                        <a href="#"><i class="zmdi zmdi-close"></i></a>
                    </div>
                    
                   
                </div>
            </div>
        <div class="body__overlay"></div>
        <!-- Start Offset Wrapper -->
      
            <!-- End Search Popap -->
            <!-- Start Cart Panel -->
          
            <!-- End Cart Panel -->
        </div>
        <!-- End Offset Wrapper -->
        <!-- Start Bradcaump area -->
        <div class="ht__bradcaump__area" style="background: rgba(0, 0, 0, 0) url(images/bg/4.jpg) no-repeat scroll center center / cover ;">
            <div class="ht__bradcaump__wrap">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="bradcaump__inner">
                                <nav class="bradcaump-inner">
                                  
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- End Brand Area -->
        <!-- Start Banner Area -->
       <div class="wishlist-area ptb--100 bg__white">
            <div class="container">
                <div class="row text-center" >
                     <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    <asp:TextBox ID="Txt1" CssClass="ckeditor" runat="server" TextMode="MultiLine" Visible="False"></asp:TextBox>
                    <asp:Button ID="Button3" class="fr__btn" runat="server" Text="送出更新資料" OnClick="Button3_Click" Visible="False" />

                </div>
            </div>
        </div>
   
    </div>

     
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
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
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
