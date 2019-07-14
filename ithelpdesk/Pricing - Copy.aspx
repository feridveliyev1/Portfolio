<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pricing.aspx.cs" Inherits="mainpage" %>

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

  <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />

        <script language="javascript">

            function package_pay(id) {
                document.getElementById('<% =ObjectID_hf.ClientID%>').value = id;
              

            }
            function package_pay1(id) {
                document.getElementById('<% =ObjectID_hf.ClientID%>').value = id;
                __doPostBack('<% =Pay_btn.UniqueID%>', '');

            }
        
        </script>

	<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!--[if lt IE 9]>
  <script type="text/javascript" src="assets/vendor/backward/html5shiv.js"></script>
  <script type="text/javascript" src="assets/vendor/backward/respond.min.js"></script>
  <![endif]-->
</head>

<body data-spy="scroll" data-target=".primary-nav">
   <form id="form1" runat="server">      
      <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
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
 
  <!-- End Site Header -->
  <!-- Start animation-version -->
 
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
        <asp:HiddenField runat="server" ID="ObjectID_hf" />
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
             <a href="#" class="tm-btn tm-btn-black" data-toggle="modal" data-target="#category-modal" onclick="javascript:package_pay(4);"><span>START THE PLAN</span></a>

            <asp:LinkButton runat="server" ID="Pay_btn" OnClick="Package_pay"></asp:LinkButton>
                                              
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
          <<a href="#" class="tm-btn tm-btn-black" data-toggle="modal" data-target="#category-modal" onclick="javascript:package_pay(5);"><span>START THE PLAN</span></a>
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
          <a href="#" class="tm-btn tm-btn-black" data-toggle="modal" data-target="#category-modal" onclick="javascript:package_pay(6);"><span>START THE PLAN</span></a>
            
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
          <a href="#" class="tm-btn tm-btn-black" data-toggle="modal" data-target="#category-modal" onclick="javascript:package_pay(7);"><span>START THE PLAN</span></a>
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
          <a href="#" class="tm-btn tm-btn-black" data-toggle="modal" data-target="#category-modal" onclick="javascript:package_pay(8);"><span>START THE PLAN</span></a>
            
            
                                
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
             <a href="#" class="tm-btn tm-btn-black" data-toggle="modal" data-target="#category-modal" onclick="javascript:package_pay(9);"><span>START THE PLAN</span></a>
          </div><!-- .single-price -->
        </div><!-- .col -->
       
      </div>
    </div>
  </section>
 
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

  
        <script src="assets/js/bootstrap.min.js"></script>
        
        <div id="category-modal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                           <ContentTemplate>
                                               <asp:HiddenField ID="HiddenField1" runat="server" />
                                           <div class="modal-dialog modal-lg"> 
                                            <div class="modal-content"> 
                                                <div class="modal-header"> 
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" id="close_btn">×</button> 
                                                    <h4 class="modal-title">
                                                        <asp:Literal ID="ModalCaption_lb" runat="server">Əlavə et</asp:Literal></h4> 
                                                </div> 
                                                <div class="modal-body"> 
                                                    <div class="row"> 
                                                        <div class="col-md-12"> 
                                                            <div class="form-group">

                                                             <div class="col-sm-12">
                                                              <label for="field-3" class="control-label">Card code</label> 
                                                                <asp:TextBox ID="Card_code_edt" runat="server" CssClass="form-control" placeholder="Enter code"></asp:TextBox>
                                                                <br />
                                                                <h3 style="color:Red;" runat="server" id="error_lbl" visible="false" >This card in not found</h3>
                                                           </div>

                                                </div>
                                                </div>
                                                </div>
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect btn-danger" data-dismiss="modal">İmtina</button> 
                                                    <asp:Button ID="Save_btn" runat="server" 
                                                        CssClass="btn btn-primary waves-effect waves-light" 
                                                         Text="Saxla" OnClick="Package_pay"  OnClientClick="this.disabled='true'; this.value='Please wait...';" UseSubmitBehavior="false"/>
                                                </div>
                                                
                                            </div> 
                                        </div>
                                        
                                           </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

 
 </form>
</body>
</html>
