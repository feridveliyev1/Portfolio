<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Clients_add.aspx.cs" Inherits="Clients_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	
<!-- Mirrored from coderthemes.com/ubold_1.1/dark/form-wizard.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 30 Nov 2015 02:12:21 GMT -->
<head>
		


		
		<!--Form Wizard-->
        <link rel="stylesheet" type="text/css" href="assets/plugins/jquery.steps/demo/css/jquery.steps.css" />

		<link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />

        <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
       <meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<meta name="description" content="IPhone Service Controlling System">
		<meta name="author" content="QWANT LLC">
		<link rel="shortcut icon" href="assets/images/favicon.png" style="background:transparent">
		<title>Virtual Reality</title>

        <!--Morris Chart CSS -->
		<link rel="stylesheet" href="assets/plugins/morris/morris.css">
        <link href="Height.css" rel="stylesheet" type="text/css" />


		<link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
    
        <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work    if you view the page via file:// -->
        <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
        <script src="assets/js/modernizr.min.js"></script>
        <script src="assets/js/modernizr.min.js"></script>
         <script type="text/javascript">

             function check() {
                 if (CheckBox1.checked == true)
                     document.getElementById('age_ddl').disable = true;
             }
      
</script>
<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
          m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '../../../www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-69506598-1', 'auto');
    ga('send', 'pageview');
    </script>

	</head>

	<body class="fixed-left">

        <div class="animationload">
            <div class="loader"></div>
        </div>

		<!-- Begin page -->
		<div id="wrapper">

            <!-- Top Bar Start -->
            <div class="topbar" height="40">

                <!-- LOGO -->
                 <div class="topbar-left">
                    <div class="text-center">
                        <a href="#" class="logo">
                            <img src="assets/images/logo%20_qwant.png" height="93px" width="300px"/>
                    </div>
                </div>

                <!-- Button mobile view to collapse sidebar menu -->
               <div class="navbar navbar-default" role="navigation">
                    <div class="container" style="height:50px">
                        <div class="">

                           

                            
                        </div>
                        <!--/.nav-collapse -->
                    </div>
                </div>
            </div>
            <!-- Top Bar End -->


            <br />

            <!-- ========== Left Sidebar Start ========== -->

             <div class="left side-menu" >
                <div class="sidebar-inner slimscrollleft">
                    <!--- Divider -->
                    <div id="sidebar-menu">
                        <ul>
                           <li class="text-muted menu-title"> </li>
                          &nbsp;&nbsp;<asp:Label  ID="Loginlbl" ForeColor="White"  Font-Size=Small  runat="server"  Visible="true" ></asp:Label>
                         <br />&nbsp;&nbsp;<asp:Label  ID="Statuslbl" ForeColor="White"   Font-Size=Small  runat="server"  Visible="true"></asp:Label>
                             
                    <asp:Literal ID="MenuDictionaries_lb" runat="server" Visible="true">
                            <li class="has_sub">
                                <a href="#" class="waves-effect waves-light myactive"><i class="ti-view-list-alt"></i> <span> Lüğətlər </span> </a>
                                <ul class="list-unstyled">
                                    <li><a href="DevicesCategory.aspx"><i class="ion-laptop"></i>Aparat kateqoriyası </a></li>
                                     <li><a href="GamesCategory.aspx"><i class="ion-game-controller-b"></i>Oyun kateqoriyası</a></li>
                                      <li><a href="BusinessPartners.aspx"><i class="ion-briefcase"></i>Biznes əməkdaşları</a></li>
                                      <li><a href="CustomerSources.aspx"><i class="ion-android-social"></i>Müştəri mənbələr</a></li>
                                      <li><a href="RejectReasons.aspx"><i class="ion-close"></i>İmtina  &nbsp;&nbsp;&nbsp;&nbsp; səbəbləri</a></li>
                                </ul>
                            </li>
                </asp:Literal>
                 <asp:Literal ID="Literal1" runat="server" Visible="true">
                            <li>
                                <a href="Devices.aspx" class="waves-effect waves-light"><i class="ti-desktop"></i> <span>Aparatlar</span> </a>
                            </li>
                </asp:Literal>
                <asp:Literal ID="Literal2" runat="server" Visible="true">
                            <li>
                                <a href="Games.aspx" class="waves-effect waves-light"><i class="ti-game"></i> <span>Oyunlar</span> </a>
                            </li>
                </asp:Literal>
                 <asp:Literal ID="getcard_lb" runat="server" Visible="true">
                            <li>
                                <a href="Card.aspx" class="waves-effect waves-light"><i class="ti-credit-card"></i> <span>Kart Almaq</span> </a>
                            </li>
                </asp:Literal>
                  <asp:Literal ID="Literal3" runat="server" Visible="true">
                            <li>
                                <a href="Users.aspx" class="waves-effect waves-light"><i class="ti-user"></i> <span>İstifadəçilər</span> </a>
                            </li>
                </asp:Literal>
                  <asp:Literal ID="Literal4" runat="server" Visible="true">
                            <li>
                                <a href="Default.aspx" class="waves-effect waves-light"><i class="md md-arrow-back"></i> <span>Sistemden çıx</span> </a>
                            </li>
                </asp:Literal>
                            
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>

            <!-- Left Sidebar End -->

			<!-- ============================================================== -->
			<!-- Start right Content here -->
			<!-- ============================================================== -->
			<div class="content-page">
				<!-- Start content -->
				<div class="content">
					<div class="container">

						<!-- Page-Title -->
						<div class="row">
							<div class="col-sm-12">
								<h4 class="page-title">Klient əlavə et</h4>
								<ol class="breadcrumb">

									<li>
										<a href="#">Klientlər</a>
									</li>
								
								</ol>
							</div>
						</div>

                        
                        
                        <!-- Basic Form Wizard -->
                        <div class="row">
                            <div class="col-md-12">
                            	<div class="card-box">
                                
                               
                            		<h4 class="m-t-0 header-title"><b>Bu səhvədə klient əlavə edə bilərsiz</b></h4>
                            		<p class="text-muted m-b-30 font-13">
										Aşağıdakı formu doldurun
									</p>
									
									<form id="basic-form" action="#" >
                                        <div>
                                            <h3> Ümumi məlumat</h3>
                                            <form id="Create_user" runat="server">
                                            <section>
                                          
                                                <div class="form-group clearfix">
                                                    <label class="col-lg-2 control-label " for="userName">Ad *</label>
                                                    <div class="col-lg-10">
                                                    <asp:TextBox ID="name_edt" runat="server" class="required form-control"></asp:TextBox>
                                                     </div>
                                                </div>
                                                <div class="form-group clearfix">
                                                    <label class="col-lg-2 control-label " for="password"> Soyad *</label>
                                                    <div class="col-lg-10">
                                                       <asp:TextBox ID="surname_edt" runat="server" class="required form-control"></asp:TextBox>

                                                    </div>
                                                </div>

                                                <div class="form-group clearfix">
                                                    <label class="col-lg-2 control-label " for="confirm">Əlaqə nömrəsi *</label>
                                                     <div class="col-md-2">
                                                                <asp:DropDownList ID="numberddl" runat="server" CssClass="form-control" Width="100px">
                                                                <asp:ListItem Text="+99450" Value="+99450"></asp:ListItem>
                                                                  <asp:ListItem Text="+99451" Value="+99451"></asp:ListItem>
                                                                    <asp:ListItem Text="+99455" Value="+99455"></asp:ListItem>
                                                                      <asp:ListItem Text="+99470" Value="+99470"></asp:ListItem>
                                                                        <asp:ListItem Text="+99477" Value="+99477"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            
                                                    <div class="col-lg-8">
                                                   
                                                    <asp:TextBox ID="PhoneNumber_edt" runat="server" class="required form-control"  MaxLength="7"></asp:TextBox>
                                                   
                                                </div>
                                                </div>
                                            </section>
                                            <h3>Digər məlumatlar</h3>
                                            <section>
                                           
                                             <div class="form-group clearfix">
                                                    <label class="col-lg-2 control-label " for="userName">Klientin cinsi *</label>
                                                    <div class="col-lg-10">

                                                     <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="100px">
                                                                <asp:ListItem Text="Seçin" Value="0"></asp:ListItem>
                                                                  <asp:ListItem Text="Kişi" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Qadın" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                     </div>
                                                </div>
                                                <div class="form-group clearfix">
                                                   
                                            
                                                    <label class="col-lg-2 control-label " > Doğum tarixi *</label>
                                                     <div class="col-lg-6">
                                                    <asp:TextBox ID="FromDate_edt" CssClass=" required form-control" TextMode="Date" runat="server" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator"
                                                    runat="server"
                                                    ControlToValidate="FromDate_edt"
                                                    Display="Static"
                                                    ErrorMessage="ENTER TIME" />
                                                   </div>
                                                   <div class="col-lg-2">
                                                   
                                                   <asp:DropDownList ID="age_ddl" runat="server" CssClass="required form-control" Width="100px">
                                                                <asp:ListItem Text="Seçin" Value="0"></asp:ListItem>
                                                                 <asp:ListItem Text="10-18" Value="1"></asp:ListItem>
                                                                  <asp:ListItem Text="18-25" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="25-40" Value="3"></asp:ListItem>
                                                                </asp:DropDownList> 
                                                    </div>
                                              </div>
                                                            <div class="form-group clearfix">
                                                    <label class="col-lg-2 control-label " for="userName">Gəldiyi mənbə *</label>
                                                    <div class="col-lg-10">
                                                    <asp:DropDownList ID="logList" runat="server" AutoPostBack="True" 
        onselectedindexchanged="sourche_type_click">
        <asp:ListItem Text="Seçin" Value="1"></asp:ListItem>
                                                                 <asp:ListItem Text="10-18" Value="2"></asp:ListItem>
    </asp:DropDownList>
                                                     <asp:DropDownList ID="sourche_type" runat="server" OnSelectedIndexChanged="sourche_type_click"  CssClass="form-control" Width="100px" AutoPostBack="true">
                                                                <asp:ListItem Text="Seçin" Value="0"></asp:ListItem>
                                                                  <asp:ListItem Text="Küçə" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Biznes" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                     </div>
                                                </div>
                                                    <div class="form-group clearfix">
                                                    <label class="col-lg-2 control-label " for="userName">Gəldiyi mənbə *</label>
                                                    <div class="col-lg-10">

                                                    <asp:SqlDataSource id="source_category_sql" runat ="server"></asp:SqlDataSource>
                                                           <asp:DropDownList  ID="source_category_ddl" runat="server" DataSourceID="source_category_sql" DataValueField="ID" DataTextField="NAME" ondatabound="source_ddl_DataBound" CssClass="required form-control" AutoPostBack="true"></asp:DropDownList>
                                                     </div>
                                                </div>
                                                <asp:button ID="Button1" runat="server"    Style="border-radius:4px" Text="Yadda saxla" Width="250px" Height="35px" CssClass="btn-primary"  />
                         
          
	                                                 
                                            </section>
                                            </form>
                                          </div>
                                            </form>
                                        </div>
                                        
                                   
                                    
                            	</div>
                        	</div>
                    	</div>

                        <!-- End row -->


                        <!-- Vertical Steps Example -->
                        <!-- End row -->



                        <!-- Wizard with Validation -->
                        
                        
                        <!-- End row -->

                    </div> <!-- container -->
                               
                </div> <!-- content -->

                <footer class="footer">
                    2015 © Ubold.
                </footer>

            </div>
            <!-- ============================================================== -->
            <!-- End Right content here -->
            <!-- ============================================================== -->


            <!-- Right Sidebar -->
            
            <!-- /Right-bar -->


        </div>
        <!-- END wrapper -->

        <script>
            var resizefunc = [];
        </script>

        <!-- jQuery  -->
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
        <script src="assets/js/detect.js"></script>
        <script src="assets/js/fastclick.js"></script>
        <script src="assets/js/jquery.slimscroll.js"></script>
        <script src="assets/js/jquery.blockUI.js"></script>
        <script src="assets/js/waves.js"></script>
        <script src="assets/js/wow.min.js"></script>
        <script src="assets/js/jquery.nicescroll.js"></script>
        <script src="assets/js/jquery.scrollTo.min.js"></script>


        <script src="assets/js/jquery.core.js"></script>
        <script src="assets/js/jquery.app.js"></script>

        <!--Form Validation-->
        <script src="assets/plugins/bootstrapvalidator/dist/js/bootstrapValidator.js" type="text/javascript"></script>

        <!--Form Wizard-->
        <script src="assets/plugins/jquery.steps/build/jquery.steps.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>

        <!--wizard initialization-->
        <script src="assets/pages/jquery.wizard-init.js" type="text/javascript"></script>
        <script src="assets/js/jquery.maskedinput.js" type="text/javascript"></script>
       
	   <script type="text/javascript">
	       function init() {
	           jQuery("#<% =PhoneNumber_edt.ClientID %>").mask("kkk kk kk");
	           jQuery.mask.definitions['9'] = '';
	           jQuery.mask.definitions['d'] = '[0-9]';

	           //$('#datatablecards').dataTable();
	       }

	       $(document).ready(function () {
	           init();
	       });
         
      </script>
	</body>

<!-- Mirrored from coderthemes.com/ubold_1.1/dark/form-wizard.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 30 Nov 2015 02:12:21 GMT -->
</html>
