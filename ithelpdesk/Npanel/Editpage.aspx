<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editpage.aspx.cs" Inherits="Npanel_Editpage" %>



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
  <link rel="icon" href="asset/img/favicon.png">
	<!-- Stylesheets -->
	<link rel="stylesheet" type="text/css" href="asset/css/plugins.css">
	<link rel="stylesheet" type="text/css" href="asset/css/style.css">
  <link id="theme" rel="stylesheet" href="asset/css/color/color-1.css">
	<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!--[if lt IE 9]>
  <script type="text/javascript" src="asset/vendor/backward/html5shiv.js"></script>
  <script type="text/javascript" src="asset/vendor/backward/respond.min.js"></script>
  <![endif]-->

  <!-- Start of  Zendesk Widget script -->
<script id="ze-snippet" src="https://static.zdasset.com/ekr/snippet.js?key=afa89fb2-e03b-4297-a908-901ca4b36baf"> </script>
<!-- End of  Zendesk Widget script -->


<script language="javascript">
    function big() {
        var text = document.getElementById("text");
        var s = big_text_edt.value;

        var big_label = document.getElementById("big_label");
        big_label.innerText = s;
    }

    function small() {
        var big_text_edt = document.getElementById("small_text_edt");
        var s = big_text_edt.value;

        var big_label = document.getElementById("small_label");
        big_label.innerText = s;
    }

    function img() {

        var url = inputToURL(document.getElementById("<%=FileUpload1.ClientID %>"));
        document.getElementById("<%=image_file1.ClientID %>").src = url;
     

    }
    function inputToURL(inputElement) {
        var file = inputElement.files[0];
        return window.URL.createObjectURL(file);
    }

    function img2() {

        var url = inputToURL(document.getElementById("<%=FileUpload2.ClientID %>"));
        document.getElementById("<%=image_file2.ClientID %>").src = url;


    }
    function inputToURL(inputElement) {
        var file = inputElement.files[0];
        return window.URL.createObjectURL(file);
    }

    function img3() {

        var url = inputToURL(document.getElementById("<%=FileUpload3.ClientID %>"));
        document.getElementById("<%=image_file3.ClientID %>").src = url;


    }
    function inputToURL(inputElement) {
        var file = inputElement.files[0];
        return window.URL.createObjectURL(file);
    }

    function img4() {

        var url = inputToURL(document.getElementById("<%=FileUpload4.ClientID %>"));
        document.getElementById("<%=image_file4.ClientID %>").src = url;


    }
    function inputToURL(inputElement) {
        var file = inputElement.files[0];
        return window.URL.createObjectURL(file);
    }

    function img5() {

        var url = inputToURL(document.getElementById("<%=FileUpload5.ClientID %>"));
        document.getElementById("<%=image_file5.ClientID %>").src = url;


    }
    function inputToURL(inputElement) {
        var file = inputElement.files[0];
        return window.URL.createObjectURL(file);
    }


</script>



</head>

<body data-spy="scroll" data-target=".primary-nav">
  <!-- Preloader -->
 <form id="form1" runat="server">
 
  

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
    <img src="asset/img/animation-bg.jpg" alt="" class="animation-bg">
    <div class="stray-wave"></div>
    <div class="stray-wave stray-wave-2"></div>
      <div class="slider-text">
      <asp:SqlDataSource ID="main_sql" runat="server"></asp:SqlDataSource>
        <h1><span id="big_label" runat="server"></span></h1>
        <h2><span id="small_label" runat="server"></span></h2>
  
  
         <input id="big_text_edt" autocomplete="off" class="input-text autoclear" runat="server" type="text" onInput="big()">
          <input id="small_text_edt" autocomplete="off" class="input-text autoclear" runat="server" type="text" onInput="small()">
          <asp:LinkButton ID="save_btn" CssClass="form-control" style="background-color:#229cd6;font-weight:600;color:White;border:0px;margin-top:20px;width:15%;margin-left:auto;margin-right:auto;" runat="server" OnClick="save_click" >Save</asp:LinkButton>
        
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
                <img src="asset/img/about-video-bg.jpg" alt="">
                <i class="video-icon icofont icofont-play-alt-3"></i>
            </div>
            <!-- For Youtube Video -->
            <!-- <div class="about-video js-video-button" data-video-id='nImFZRtGeAQ'>
                <img src="asset/img/about-video-bg.jpg" alt="">
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
    <img src="asset/img/fun-fact2.jpg" alt="" class="bg-img">
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
    <img src="asset/img/call-to-action-bg.jpg" alt="" class="bg-img">
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
       <asp:FileUpload runat="server" style="display:none;"  ID="FileUpload1" ClientIDMode="Static" onchange="img();"   />
       <asp:FileUpload runat="server" style="display:none;"  ID="FileUpload2" ClientIDMode="Static" onchange="img2();"   />
       <asp:FileUpload runat="server" style="display:none;"  ID="FileUpload3" ClientIDMode="Static" onchange="img3();"   />
       <asp:FileUpload runat="server" style="display:none;"  ID="FileUpload4" ClientIDMode="Static" onchange="img4();"   />
       <asp:FileUpload runat="server" style="display:none;"  ID="FileUpload5" ClientIDMode="Static" onchange="img5();"   />
       
        <asp:Image ID="image_file1" ImageUrl="~/Npanel/image/1/_1.jpg" onclick="document.getElementById('FileUpload1').click(); return false" style="padding-left:15px;" runat="server" Width="260px" Height="260px"/>
        <asp:Image ID="image_file2" ImageUrl="~/Npanel/image/2/_2.jpg" onclick="document.getElementById('FileUpload2').click(); return false" style="padding-left:15px;"  runat="server" Width="260px" Height="260px"/>
        <asp:Image ID="image_file3" ImageUrl="~/Npanel/image/3/_3.jpg" onclick="document.getElementById('FileUpload3').click(); return false" style="padding-left:15px;" runat="server" Width="260px" Height="260px"/>
        <asp:Image ID="image_file4" ImageUrl="~/Npanel/image/4/_4.jpg" onclick="document.getElementById('FileUpload4').click(); return false" style="padding-left:15px;" runat="server" Width="260px" Height="260px"/>
        <asp:Image ID="image_file5" ImageUrl="~/Npanel/image/5/_5.jpg" onclick="document.getElementById('FileUpload5').click(); return false" style="padding-left:15px;" runat="server" Width="260px" Height="260px"/>
     
 <asp:LinkButton ID="team_save_btn" runat="server" CssClass="form-control" style="background-color:#229cd6;font-weight:600;color:White;border:0px;Width:15%;text-align:center;margin-left:auto;margin-right:auto;margin-top:20px;" OnClick="team_save_click">save</asp:LinkButton>
   
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
                <img src="asset/img/logo.png" alt="">
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
                <a href=""><img src="asset/img/instagram-img-01.jpg" alt=""></a>
                <a href=""><img src="asset/img/instagram-img-02.jpg" alt=""></a>
                <a href=""><img src="asset/img/instagram-img-03.jpg" alt=""></a>
                <a href=""><img src="asset/img/instagram-img-04.jpg" alt=""></a>
                <a href=""><img src="asset/img/instagram-img-05.jpg" alt=""></a>
                <a href=""><img src="asset/img/instagram-img-06.jpg" alt=""></a>
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
      <button id="color-1" data-theme="asset/css/color/color-1.css"></button>
      <button id="color-2" data-theme="asset/css/color/color-2.css"></button>
      <button id="color-3" data-theme="asset/css/color/color-3.css"></button>
      <button id="color-4" data-theme="asset/css/color/color-4.css"></button>
      <button id="color-5" data-theme="asset/css/color/color-5.css"></button>
      <button id="color-6" data-theme="asset/css/color/color-6.css"></button>
      <button id="color-7" data-theme="asset/css/color/color-7.css"></button>
      <button id="color-8" data-theme="asset/css/color/color-8.css"></button>
  </section>
  <!-- End Customizer -->

  <!-- Scripts -->
  <script src="asset/js/vendor/modernizr-3.5.0.min.js"></script>
  <script src="asset/js/vendor/jquery-1.12.4.min.js"></script>
  <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyBgwgIuDRkO7HlxvpWN-vPePnGVWss5r5g"></script>
  <script src="asset/js/plugins.js"></script>
  <script src="asset/js/main.js"></script>
  </form>
</body>
</html>

