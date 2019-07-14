<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

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
					<h3 class="text-center"> Sign Up to <strong class="text-custom">IT HELP DESK</strong> </h3>
				</div>

				<div class="panel-body">
					<form class="form-horizontal m-t-20" action="http://coderthemes.com/ubold_1.1/dark/index.html">

                       <div class="form-group ">
							<div class="col-xs-12">
                                <asp:TextBox ID="name_edt"  runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ValidationGroup="register" 
                        ErrorMessage="&laquo; (Required)" 
                        ControlToValidate="name_edt"
                        CssClass="ValidationError"
                        ToolTip="Please enter your name">
                         </asp:RequiredFieldValidator>
                                
							</div>
						</div>
                        <br />
                        <br />
                        <div class="form-group ">
							<div class="col-xs-12">
                                <asp:TextBox ID="surname_edt"  runat="server" CssClass="form-control" placeholder="Surname"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ValidationGroup="register" 
                        ErrorMessage="&laquo; (Required)" 
                        ControlToValidate="surname_edt"
                        CssClass="ValidationError"
                        ToolTip="Please enter your surname">
                         </asp:RequiredFieldValidator>
							</div>
						</div>
                         <br />
                        <br />
                        <div class="form-group ">
							<div class="col-xs-12">
                                <asp:TextBox ID="phonenumber_edt" runat="server" placeholder="Phone Number" data-mask="(999) 999-9999" class="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ValidationGroup="register" 
                        ErrorMessage="&laquo; (Required)" 
                        ControlToValidate="phonenumber_edt"
                        CssClass="ValidationError"
                        ToolTip="Please enter your phone number">
                         </asp:RequiredFieldValidator>
							</div>
						</div>
                         <br />
                        <br />
						<div class="form-group ">
							<div class="col-xs-12">
                                 <asp:TextBox ID="email_edt"  runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ValidationGroup="register" 
                        ErrorMessage="&laquo; (Required)" 
                        ControlToValidate="email_edt"
                        CssClass="ValidationError"
                        ToolTip="Please enter your email">
                         </asp:RequiredFieldValidator>
							</div>
						</div>
                         <br />
                        <br />
						<div class="form-group">
							<div class="col-xs-12">
                               <asp:TextBox ID="password_edt" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ValidationGroup="register" 
                        ErrorMessage="&laquo; (Required)" 
                        ControlToValidate="password_edt"
                        CssClass="ValidationError"
                        ToolTip="Please enter your password">
                    </asp:RequiredFieldValidator>
                   
							</div>
						</div>
                         <br />
                        <br />
                        	<div class="form-group">
							<div class="col-xs-12">
                                <asp:TextBox ID="Confirm_Password_edt" runat="server" TextMode="Password" CssClass="form-control" placeholder=" Confirm Password"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ValidationGroup="register" 
                        ErrorMessage="&laquo; (Required)"  
                        ControlToValidate="Confirm_Password_edt"
                        CssClass="ValidationError"
                        ToolTip="Please confirm your password">
                    </asp:RequiredFieldValidator>
                         <asp:CompareValidator ID="CompareValidator1" runat="server"  ValidationGroup="register" 
                        ControlToValidate="Confirm_Password_edt"
                        CssClass="ValidationError"
                        ControlToCompare="password_edt"
                        ErrorMessage="No Match" ForeColor="Red"
                        ToolTip="No match" />
                   
							</div>
						</div>
                        <br />
                        <br />
						<div class="form-group">
							<div class="col-xs-10">
								<div class="checkbox checkbox-primary">
									<input id="checkbox-signup" type="checkbox" checked="checked">
									<label for="checkbox-signup">I accept <a href="#">Terms and Conditions</a></label>
								</div>
							</div>
						</div>
                       
                        
						<div class="form-group text-center m-t-40">
							<div class="col-xs-12">
                                 <asp:LinkButton ID="register_btn" runat="server" ValidationGroup="register" 
                            CssClass="btn btn-pink btn-block text-uppercase waves-effect waves-light" 
                            onclick="register_btn_click" CausesValidation="false">Register</asp:LinkButton>
							</div>
						</div>
                        <br />
                        <div class="row">
                 
            </div>
            <br />
            <div class="form-group m-b-0 text-center">
							<div class="col-sm-12">
                                   <asp:LinkButton runat="server" ID="AZ_btn"  CausesValidation="false" OnClick="AZ_btn_Click" ToolTip="azərbaycanсca"><img src="assets/images/Azerbaijan24.png" />  </asp:LinkButton> &nbsp &nbsp
		                     <asp:LinkButton runat="server" ID="RU_btn"  CausesValidation="false" OnClick="RU_btn_Click" ToolTip="русский"><img src="assets/images/Russia24.png" />  </asp:LinkButton>&nbsp &nbsp

		                    <asp:LinkButton runat="server" ID="EN_btn"  CausesValidation="false" OnClick="EN_btn_Click" ToolTip="english"><img src="assets/images/United-Kingdom23.png" />  </asp:LinkButton>&nbsp &nbsp
							</div>
						</div>

                        
                        <br />

					</form>

				</div>
			</div>

			<div class="row">
				<div class="col-sm-12 text-center">
					<p>
						Already have account?<a href="Default.aspx" class="text-primary m-l-5"><b>Sign In</b></a>
					</p>
				</div>
			</div>

		</div>                     
           

        

        
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
        <script src="assets/plugins/bootstrap-inputmask/bootstrap-inputmask.min.js" type="text/javascript"></script>
        <script src="assets/plugins/autoNumeric/autoNumeric.js" type="text/javascript"></script>

        <script src="assets/js/jquery.core.js"></script>
        <script src="assets/js/jquery.app.js"></script>
    </form>
</body>
</html>
