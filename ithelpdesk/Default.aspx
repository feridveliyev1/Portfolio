<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <link rel="shortcut icon" href="" style="background:transparent">
		<title>IT HELP DESK</title>

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

    <script src="assets/js/modernizr.min.js"></script>

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
    <script type="text/javascript">

        function translate_Az() {

            document.getElementById('Login_edt').setAttribute("placeholder", "asasasasas");

        }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="animationload">
            <div class="loader-1"></div>
        </div>

        <div class="account-pages"></div>
        <div class="clearfix"></div>
        <div class="wrapper-page">
        	<div class=" card-box">
          
            <div class="panel-heading"> 
                <h3 class="text-center"> <strong class="text-custom"><img src="logo_main.jpg" /></strong> </h3>
            </div>
        <asp:Panel ID="login_panel" runat="server" DefaultButton="Login_btn">



            <div class="panel-body">
            <form class="form-horizontal m-t-20" action="#">
                
                <div class="form-group ">
                    <div class="col-xs-12">
                          <asp:TextBox ID="Login_edt"  runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br /><br />
                <div class="form-group">
                    <div class="col-xs-12">
                        <asp:TextBox ID="Password_edt" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                    </div>
                </div>
                <br /><br />
                <div class="form-group">
                    <div class="col-xs-12">
                        <asp:LinkButton ID="Login_btn" runat="server"  BackColor="#00458B" 
                            ForeColor="White" 
                            CssClass="btn btn-block text-uppercase waves-effect waves-light" 
                            onclick="Login_btn_Click">Login</asp:LinkButton>
                    </div>
                     <br /><br />
                  <%--  <div class="form-group">
                   
                       <div class="col-xs-12" id="password">
                       
                       
                       <asp:LinkButton ID="forgotpassword_btn" runat="server" OnClick="forgotpassword_btn_click" Text="Forgot Password?"></asp:LinkButton>
                   
                    </div>
                     </div>--%>
                     </div>
                </div>

                </asp:Panel>
                 <div class="form-group m-t-30 m-b-0">
                    <div class="col-sm-10" id="forgot_password">
                        <a href="ForgotPassword" class="text-dark"><i class="fa fa-lock m-r-5"></i> <%= HelpFunctions.Translate("default_forgot_password")%></a>
                    </div>
                        
                </div>
           

        		<div class="form-group m-b-0 text-center">
             
							<div class="col-sm-12">
                               <br />
                                   <asp:LinkButton runat="server" ID="AZ_btn"  CausesValidation="false" OnClick="AZ_btn_Click" ToolTip="azərbaycanсca"><img src="assets/images/Azerbaijan24.png" />  </asp:LinkButton> &nbsp &nbsp
		                     <asp:LinkButton runat="server" ID="RU_btn"  CausesValidation="false" OnClick="RU_btn_Click" ToolTip="русский"><img src="assets/images/Russia24.png" />  </asp:LinkButton>&nbsp &nbsp

		                    <asp:LinkButton runat="server" ID="EN_btn"  CausesValidation="false" OnClick="EN_btn_Click" ToolTip="english"><img src="assets/images/United-Kingdom23.png" />  </asp:LinkButton>&nbsp &nbsp
							</div>
						</div>

                        <br />
                        <br />

                        
            </form> 
            
            </div>
            
             <div class="row">
            	<div class="col-sm-12 text-center">
            		<p><%= HelpFunctions.Translate("default_have_account")%> <a href="Registration" class="text-primary m-l-5"><b><%= HelpFunctions.Translate("default_sign_up")%></b></a></p>
                        
                    </div>
            </div>   
            </div>                              
           

        

        
    	<script>
    	    var resizefunc = [];


        </script>
        <style>
            #forgot_password {
    position: absolute;
    height: 200px;
    width: 400px;
    margin: -100px 0 0 -200px;
    top: 95%;
    left: 75%;
}
        </style>

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
    </form>
</body>
</html>
