<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mainpage.aspx.cs" Inherits="mainpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html class="no-js" lang="en">
<head>
	<!-- Meta Tags -->
	<meta charset="utf-8">
	<meta http-equiv="x-ua-compatible" content="ie=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta name="author" content="ThemeMarch">
  <meta name="description" content="">
  <meta name="keywords" content="">
	<!-- Page Title -->
	<title>IT HELP DESK</title>
    <!-- Favicon Icon -->
  <link rel="icon" href="assets/img/favicon.png">
	<!-- Stylesheets -->
	<link rel="stylesheet" type="text/css" href="assets/css/plugins.css">
	<link rel="stylesheet" type="text/css" href="assets/css/style.css">
  <link id="theme" rel="stylesheet" href="assets/css/color/color-1.css">
	<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!--[if lt IE 9]>
  <script type="text/javascript" src="assets/vendor/backward/html5shiv.js"></script>
  <script type="text/javascript" src="assets/vendor/backward/respond.min.js"></script>
  <![endif]-->

  <!-- Start of  Zendesk Widget script -->
<script id="ze-snippet" src="https://static.zdassets.com/ekr/snippet.js?key=afa89fb2-e03b-4297-a908-901ca4b36baf"> </script>
<!-- End of  Zendesk Widget script -->
</head>

<body data-spy="scroll" data-target=".primary-nav">
  <!-- Preloader -->
  <div id="preloader">
    <div class="preloader-wave"></div>
    <div class="preloader-wave"></div>
    <div class="preloader-wave"></div>
    <div class="preloader-wave"></div>
    <div class="preloader-wave"></div>
  </div>
  <!-- Preloader -->
  <!-- Start Site Header -->
  <header class="site-header">
    <div class="header-wrap">
      <div class="container">
        <div class="site-branding">
          <!-- For Image Logo -->
          <a href="index.html" class="custom-logo-link">
            <img src="#" alt="" class="custom-logo">
          </a>
          <!-- For Site Title -->
          <!-- <span class="site-title">
          <a href="index.html">Stray</a>
          </span> -->
        </div>
        <nav class="primary-nav">
          <ul class="primary-nav-list">
            <li class="menu-item menu-item-has-children current-menu-ancestor current-menu-parent"><a href="#home" class="nav-link">HOME</a>     
            </li>
            <li class="menu-item"><a href="#about" class="nav-link">ABOUT</a></li>
            <li class="menu-item"><a href="#team" class="nav-link">TEAM</a></li>
            <li class="menu-item"><a href="#price" class="nav-link">PRICE</a></li>
            <li class="menu-item"><a href="#contact" class="nav-link">CONTACT</a></li>
          </ul>
        </nav>
      </div>
    </div><!-- .header-wrap -->


  </header>
  <!-- End Site Header -->
  <!-- Start animation-version -->
  <section class="animation-version animation-version-2" id="home">
    <img src="assets/img/animation-bg.jpg" alt="" class="animation-bg">
    <div class="stray-wave"></div>
    <div class="stray-wave stray-wave-2"></div>
      <div class="slider-text">
      <asp:SqlDataSource ID="main_sql" runat="server"></asp:SqlDataSource>
        <h1><asp:Label ID="big_lbl" runat="server"></asp:Label></h1>
        <h2><asp:Label ID="small_lbl" runat="server"></asp:Label>
        </h2>
        <div class="but-group">
          <a href="registration" class="tm-btn"><span>Registrate Now</span></a>
           <a href="default" class="tm-btn tm-btn-black"><span>Log In</span></a>
       
        </div>
      </div>
  </section>
	<!-- End animation-version -->

  <!-- Start About Us Section -->
  <section class="about-us about-us-2 section" id="about">
    <div class="container">
      <div class="section-head text-center">
        <h2>ABOUT US</h2>
        <div class="section-divider">
          <div class="left wow fadeInLeft" data-wow-duration="1s" data-wow-delay="0.2s"></div>
          <span></span>
          <div class="right wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.2s"></div>
        </div>
        <p>Lorem ipsum dolor sit amet, in quodsi vulputate pro. Ius illum vocent mediocritatem</p>
      </div>
      <div class="row">
          <div class="col-lg-7 col-xl-6">
              <div class="about-company">
                  <h3>Welcome to our company</h3>
                  <p>Lorem ipsum dolor sit amet consectetur adipisicing elitsed do eiusmod ncididunt ametfh consectetur.</p>
                  <p>Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod ncididunt ametfh consectetur dolora.</p>
                  <a href="#price" class="tm-btn"><span>Read More</span></a>
              </div>
          </div><!-- .col -->
          <div class="col-lg-5 col-xl-6">
            <!-- For Vimeo Video -->
            <div class="about-video js-video-button" data-video-id='63636954' data-channel="vimeo">
                <img src="assets/img/about-video-bg.jpg" alt="">
                <i class="video-icon icofont icofont-play-alt-3"></i>
            </div>
            <!-- For Youtube Video -->
            <!-- <div class="about-video js-video-button" data-video-id='nImFZRtGeAQ'>
                <img src="assets/img/about-video-bg.jpg" alt="">
                <i class="video-icon"></i>
            </div> -->
          </div><!-- .col -->
      </div>
    </div>
  </section>
  <!-- End About Us Section -->

  <div class="height-100"></div>

  <!-- Start Company Groth Section -->
  <section class="company-groth section overlay-with-img gray-bg company-groth-2">
    <img src="assets/img/fun-fact2.jpg" alt="" class="bg-img">
    <div class="company-groth">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="fun-fact">
              <div class="single-fun-fact">
                <p class="counter">1200</p>
                <i class="icofont icofont-tick-boxed"></i>
                <h2>Projects Complete</h2>
              </div><!-- .single-fun-fact -->
              <div class="single-fun-fact">
                <p class="counter">1150</p>
                <i class="icofont icofont-emo-simple-smile"></i>
                <h2>Happy Client</h2>
              </div><!-- .single-fun-fact -->
              <div class="single-fun-fact">
                <p class="counter">1000</p>
                <i class="icofont icofont-award"></i>
                <h2>Awards</h2>
              </div><!-- .single-fun-fact -->
              <div class="single-fun-fact">
                <p class="counter">2000</p>
                <i class="icofont icofont-envelope"></i>
                <h2>Mail Conversation</h2>
              </div><!-- .single-fun-fact -->
            </div>
          </div><!-- .col -->
        </div>
      </div>
    </div>
  </section>
  <!-- End Company Groth Section -->



  <div class="height-100"></div>

  <!-- Start Call To Action -->
  <section class="cta section overlay-with-img cta-2">
    <img src="assets/img/call-to-action-bg.jpg" alt="" class="bg-img">
    <div class="fun-overlay"></div>
    <div class="container">
      <div class="cta-text">
        <div class="cta-btn">
          <a href="#price" class="tm-btn"><span>Get It Now</span></a>
          <div class="cta-bar"></div>
        </div>
        <h2>
          <span>
            <span class="wow fadeInLeft" data-wow-duration="2s" data-wow-delay="0.1s">START BUILDING YOUR NEXT PROJECT WITH US</span>
          </span>
        </h2>
      </div>
    </div>
  </section>
  <!-- End Call To Action -->



  <!-- Start Team Section -->
  <section class="team section" id="team">
    <div class="container">
      <div class="section-head text-center">
        <h2>Cleaver Team Members</h2>
        <div class="section-divider">
          <div class="left wow fadeInLeft" data-wow-duration="1s" data-wow-delay="0.2s"></div>
          <span></span>
          <div class="right wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.2s"></div>
        </div>
        <p>Lorem ipsum dolor sit amet, in quodsi vulputate pro. Ius illum vocent mediocritatem </p>
      </div>
    </div>
    <div class="member-carousel owl-carousel ex">
      <div class="member">
        <div class="member-overlay"></div>
        <div class="member-gradient"></div>
        <div class="member-img">
          <img src="Npanel/image/1/_1.jpg" alt="">
        </div><!-- .member-img -->
        <div class="member-hover">
          <div class="member-meta">
            <h3>Dylan Rings</h3>
            <p>Founder</p>
          </div>
          <div class="member-social-btn">
            <a href="#"><i class="fa fa-facebook-square"></i></a>
            <a href="#"><i class="fa fa-google-plus-square"></i></a>
            <a href="#"><i class="fa fa-twitter-square"></i></a>
            <a href="#"><i class="fa fa-linkedin-square"></i></a>
            <a href="#"><i class="fa fa-skype"></i></a>
          </div>
        </div>
      </div><!-- .member -->
      <div class="member">
        <div class="member-overlay"></div>
        <div class="member-gradient"></div>
        <div class="member-img">
          <img src="Npanel/image/2/_2.jpg" alt="">
        </div><!-- .member-img -->
        <div class="member-hover">
          <div class="member-meta">
            <h3>Lili Smith</h3>
            <p>Co-Founder</p>
          </div>
          <div class="member-social-btn">
            <a href="#"><i class="fa fa-facebook-square"></i></a>
            <a href="#"><i class="fa fa-google-plus-square"></i></a>
            <a href="#"><i class="fa fa-twitter-square"></i></a>
            <a href="#"><i class="fa fa-linkedin-square"></i></a>
            <a href="#"><i class="fa fa-skype"></i></a>
          </div>
        </div>
      </div><!-- .member -->
      <div class="member">
        <div class="member-overlay"></div>
        <div class="member-gradient"></div>
        <div class="member-img">
          <img src="Npanel/image/3/_3.jpg" alt="">
        </div><!-- .member-img -->
        <div class="member-hover">
          <div class="member-meta">
            <h3>David Newman</h3>
            <p>FrontEnd</p>
          </div>
          <div class="member-social-btn">
            <a href="#"><i class="fa fa-facebook-square"></i></a>
            <a href="#"><i class="fa fa-google-plus-square"></i></a>
            <a href="#"><i class="fa fa-twitter-square"></i></a>
            <a href="#"><i class="fa fa-linkedin-square"></i></a>
            <a href="#"><i class="fa fa-skype"></i></a>
          </div>
        </div>
      </div><!-- .member -->
      <div class="member">
        <div class="member-overlay"></div>
        <div class="member-gradient"></div>
        <div class="member-img">
          <img src="Npanel/image/4/_4.jpg" alt="">
        </div><!-- .member-img -->
        <div class="member-hover">
          <div class="member-meta">
            <h3>Jasifa Dona</h3>
            <p>Web Devloper</p>
          </div>
          <div class="member-social-btn">
            <a href="#"><i class="fa fa-facebook-square"></i></a>
            <a href="#"><i class="fa fa-google-plus-square"></i></a>
            <a href="#"><i class="fa fa-twitter-square"></i></a>
            <a href="#"><i class="fa fa-linkedin-square"></i></a>
            <a href="#"><i class="fa fa-skype"></i></a>
          </div>
        </div>
      </div><!-- .member -->
      <div class="member">
        <div class="member-overlay"></div>
        <div class="member-gradient"></div>
        <div class="member-img">
          <img src="Npanel/image/5/_5.jpg" alt="">
        </div><!-- .member-img -->
        <div class="member-hover">
          <div class="member-meta">
            <h3>Krosho Ya</h3>
            <p>SEO</p>
          </div>
          <div class="member-social-btn">
            <a href="#"><i class="fa fa-facebook-square"></i></a>
            <a href="#"><i class="fa fa-google-plus-square"></i></a>
            <a href="#"><i class="fa fa-twitter-square"></i></a>
            <a href="#"><i class="fa fa-linkedin-square"></i></a>
            <a href="#"><i class="fa fa-skype"></i></a>
          </div>
        </div>
      </div><!-- .member -->
    </div>
  </section>
  <!-- End Team Section -->

  <!-- Start Pricing Table -->
  <section class="pricing-table section" id="price">
    <div class="container">
      <div class="section-head text-center">
        <h2>SENIOR PACKAGES</h2>
        <div class="section-divider">
          <div class="left wow fadeInLeft" data-wow-duration="1s" data-wow-delay="0.2s"></div>
          <span></span>
          <div class="right wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.2s"></div>
        </div>
        
      </div>
                 
                                  
              
                                        
      <div class="row flex pricing-hover-wrap">
      <div class="col-lg-4">
       <div class="single-price">
        <asp:SqlDataSource ID="Subcategory_s24" runat="server"></asp:SqlDataSource>
                                    <table id="datatable" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                   
                                                      <h2 class="pricing-head"><span>24 hours</span></h2>
                                                   
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="Subcategory_s24">
                                                   <ItemTemplate>
                                                      <tr>
                                                       <ul class="pricing-feature">
                                                         <li><i class="fa fa-check"></i><%# Eval("NAME")%></li>
                                                         </ul>
                                                      </tr>
                                                   </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                         <div class="price">
             
             <b id="s24_lbl" runat="server"></b> 
             
              <span>per day</span>
            </div>
            <a href="registration" class="tm-btn tm-btn-black"><span>START THE PLAN</span></a>
          </div>
                       </div>
        <div class="col-lg-4">
          <div class="single-price">
            <asp:SqlDataSource ID="Subcategory_s7" runat="server"></asp:SqlDataSource>
                                    <table id="Table2" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                   
                                                      <h2 class="pricing-head"><span>A week</span></h2>
                                                   
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="Subcategory_s7">
                                                   <ItemTemplate>
                                                      <tr>
                                                       <ul class="pricing-feature">
                                                         <li><i class="fa fa-check"></i><%# Eval("NAME")%></li>
                                                         </ul>
                                                      </tr>
                                                   </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
            <div class="price">
              <b id="s7_lbl" runat="server"></b>
              <span>per week</span>
            </div>
            <a href="registration" class="tm-btn tm-btn-black"><span>START THE PLAN</span></a>
          </div><!-- .single-price -->
        </div><!-- .col -->
        <div class="col-lg-4">
          <div class="single-price special-price">
            <asp:SqlDataSource ID="Subcategory_s30" runat="server"></asp:SqlDataSource>
                                    <table id="Table3" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                   
                                                      <h2 class="pricing-head"><span>A month</span></h2>
                                                   
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater3" runat="server" DataSourceID="Subcategory_s30">
                                                   <ItemTemplate>
                                                      <tr>
                                                       <ul class="pricing-feature">
                                                         <li><i class="fa fa-check"></i><%# Eval("NAME")%></li>
                                                         </ul>
                                                      </tr>
                                                   </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
            <div class="price">
              <b id="s30_lbl" runat="server"></b>
              <span>per month</span>
            </div>
            <a href="registration" class="tm-btn tm-btn-black"><span>START THE PLAN</span></a>
          </div><!-- .single-price -->
        </div><!-- .col -->
       
      </div>
    </div>

    <%--junior--%>

     <div class="container">
      <div class="section-head text-center">
        <h2>JUNIOR PACKAGES</h2>
        <div class="section-divider">
          <div class="left wow fadeInLeft" data-wow-duration="1s" data-wow-delay="0.2s"></div>
          <span></span>
          <div class="right wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.2s"></div>
        </div>
       
      </div>
                 
                                  
              
                                        
      <div class="row flex pricing-hover-wrap">
      <div class="col-lg-4">
       <div class="single-price">
        <asp:SqlDataSource ID="Subcategory_j24" runat="server"></asp:SqlDataSource>
                                    <table id="Table1" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                   
                                                      <h2 class="pricing-head"><span>24 hours</span></h2>
                                                   
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="Subcategory_j24">
                                                   <ItemTemplate>
                                                      <tr>
                                                       <ul class="pricing-feature">
                                                         <li><i class="fa fa-check"></i><%# Eval("NAME")%></li>
                                                         </ul>
                                                      </tr>
                                                   </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                         <div class="price">
             
             <b id="j24_lbl" runat="server"></b> 
             
              <span>per day</span>
            </div>
            <a href="registration" class="tm-btn tm-btn-black"><span>START THE PLAN</span></a>
          </div>
                       </div>
        <div class="col-lg-4">
          <div class="single-price">
            <asp:SqlDataSource ID="Subcategory_j7" runat="server"></asp:SqlDataSource>
                                    <table id="Table4" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                   
                                                      <h2 class="pricing-head"><span>A week</span></h2>
                                                   
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater4" runat="server" DataSourceID="Subcategory_j7">
                                                   <ItemTemplate>
                                                      <tr>
                                                       <ul class="pricing-feature">
                                                         <li><i class="fa fa-check"></i><%# Eval("NAME")%></li>
                                                         </ul>
                                                      </tr>
                                                   </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
            <div class="price">
              <b id="j7_lbl" runat="server"></b>
              <span>per week</span>
            </div>
            <a href="registration" class="tm-btn tm-btn-black"><span>START THE PLAN</span></a>
          </div><!-- .single-price -->
        </div><!-- .col -->
        <div class="col-lg-4">
          <div class="single-price special-price">
            <asp:SqlDataSource ID="Subcategory_j30" runat="server"></asp:SqlDataSource>
                                    <table id="Table5" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                   
                                                      <h2 class="pricing-head"><span>A month</span></h2>
                                                   
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater5" runat="server" DataSourceID="Subcategory_j30">
                                                   <ItemTemplate>
                                                      <tr>
                                                       <ul class="pricing-feature">
                                                         <li><i class="fa fa-check"></i><%# Eval("NAME")%></li>
                                                         </ul>
                                                      </tr>
                                                   </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
            <div class="price">
              <b id="j30_lbl" runat="server"></b>
              <span>per month</span>
            </div>
            <a href="registration" class="tm-btn tm-btn-black"><span>START THE PLAN</span></a>
          </div><!-- .single-price -->
        </div><!-- .col -->
       
      </div>
    </div>
  </section>
  <!-- End Pricing Table -->




 

  <!-- Start Contact Form -->
  <section class="contact-wrap section" id="contact">
    <div class="container">
      <div class="section-head text-center">
          <h2>Contact Us</h2>
          <div class="section-divider">
            <div class="left wow fadeInLeft" data-wow-duration="1s" data-wow-delay="0.2s"></div>
            <span></span>
            <div class="right wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.2s"></div>
          </div>
          <p>Lorem ipsum dolor sit amet, in quodsi vulputate pro. Ius illum vocent mediocritatem</p>
      </div>
      <div class="row">
        <div class="col-lg-4">
          <div class="contact-info">
            <h3 class="contact-head">CONTACT INFO</h3>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod incididunt ametfh consec tetur dolore magna aliqua. Ut enim ad minim veniam dolor sit amet magnaelit.</p>
          </div>
        </div><!-- .col -->
        <div class="col-lg-4">
          <div class="contact-info">
            <h3 class="contact-head">CORPORATE OFFICE</h3>
            <ul>
              <li><i class="icofont icofont-location-arrow"></i> 7503 Wakehurst St, Perrysburg, OH 43551</li>
              <li><i class="icofont icofont-phone"></i> +00 123-456-789</li>
              <li><i class="icofont icofont-email"></i> <a href="mailto:email@yourdomain.com">email@yourdomain.com</a></li>
            </ul>
          </div>
        </div><!-- .col -->
        <div class="col-lg-4">
          <div class="contact-info">
            <h3 class="contact-head">BRANCH OFFICE</h3>
            <ul>
              <li><i class="icofont icofont-location-arrow"></i> 7503 Wakehurst St, Perrysburg, OH 43551</li>
              <li><i class="icofont icofont-phone"></i> +00 123-456-789</li>
              <li><i class="icofont icofont-email"></i> <a href="mailto:email@yourdomain.com">email@yourdomain.com</a></li>
            </ul>
          </div>
        </div><!-- .col -->
      </div><!-- .row -->
      <div class="cf-msg"></div>
 
    </div>
  </section>



  

  <!-- Start Site Footer -->
  <footer class="site-footer">
    <div class="top-footer">
      <div class="container">
        <div class="row">
          <div class="col-md-4">
            <div class="footer-widget">
              <div class="footer-about-widget">
                <img src="assets/img/logo.png" alt="">
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod incididunt ametfh consec tetur dolore magna aliqua. Ut enim ad minim veniam.</p>
              </div>
            </div><!-- .footer-widget -->
          </div><!-- .col -->
          <div class="col-md-4">
            <div class="footer-widget">
              <h2 class="footer-widget-title">Recent Posts</h2>
              <ul class="footer-recent-post-widget">
                <li>
                  <h2><a href="">Just another amazing blog post</a></h2>
                  <span><i class="fa fa-calendar"></i> February 05 2018</span>
                </li>
                <li>
                  <h2><a href="">Just another amazing blog post</a></h2>
                  <span><i class="fa fa-calendar"></i> February 05 2018</span>
                </li>
                <li>
                  <h2><a href="">Just another amazing blog post</a></h2>
                  <span><i class="fa fa-calendar"></i> February 05 2018</span>
                </li>
              </ul>
            </div><!-- .footer-widget -->
          </div><!-- .col -->
          <div class="col-md-4">
            <div class="footer-widget">
              <h2 class="footer-widget-title">Instragram</h2>
              <div class="instagram-widget">
                <a href=""><img src="assets/img/instagram-img-01.jpg" alt=""></a>
                <a href=""><img src="assets/img/instagram-img-02.jpg" alt=""></a>
                <a href=""><img src="assets/img/instagram-img-03.jpg" alt=""></a>
                <a href=""><img src="assets/img/instagram-img-04.jpg" alt=""></a>
                <a href=""><img src="assets/img/instagram-img-05.jpg" alt=""></a>
                <a href=""><img src="assets/img/instagram-img-06.jpg" alt=""></a>
              </div>
            </div><!-- .footer-widget -->
          </div><!-- .col -->
        </div>
      </div>
    </div>
    <div class="bottom-footer text-center">
      <div class="container">
        <div class="copy-right">Copyright © 2019 Anar Baydamirov</div>
      </div>
    </div>
  </footer>
  <!-- End Site Footer -->

  <!-- Color Customizer -->
  <section class="color-customizer">
      <h2>Color Schemes</h2>
      <div class="customizer-btn"><span class="icon-basic_gear icofont icofont-atom"></span></div>
      <button id="color-1" data-theme="assets/css/color/color-1.css"></button>
      <button id="color-2" data-theme="assets/css/color/color-2.css"></button>
      <button id="color-3" data-theme="assets/css/color/color-3.css"></button>
      <button id="color-4" data-theme="assets/css/color/color-4.css"></button>
      <button id="color-5" data-theme="assets/css/color/color-5.css"></button>
      <button id="color-6" data-theme="assets/css/color/color-6.css"></button>
      <button id="color-7" data-theme="assets/css/color/color-7.css"></button>
      <button id="color-8" data-theme="assets/css/color/color-8.css"></button>
  </section>
  <!-- End Customizer -->

  <!-- Scripts -->
  <script src="assets/js/vendor/modernizr-3.5.0.min.js"></script>
  <script src="assets/js/vendor/jquery-1.12.4.min.js"></script>
  <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyBgwgIuDRkO7HlxvpWN-vPePnGVWss5r5g"></script>
  <script src="assets/js/plugins.js"></script>
  <script src="assets/js/main.js"></script>
</body>
</html>
