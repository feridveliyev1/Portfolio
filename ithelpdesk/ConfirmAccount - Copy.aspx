<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmAccount.aspx.cs" Inherits="ConfirmAccount" %>

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
					<h3 class="text-center"> Confirm Your Account </h3>
				</div>

				<div class="panel-body">
					<form method="post" action="#" role="form" class="text-center">
						<div class="alert alert-info alert-dismissable">
							<button type="button" class="close" data-dismiss="alert" aria-hidden="true">
								×
							</button>
							You should recieve a text at <%# AuthCookieParse.UserPhoneNumber() %> with your confirmation code soon. 
						</div>
						<div class="form-group m-b-0">
							<div class="input-group">
                                <asp:TextBox ID="code_edt"  runat="server" CssClass="form-control" placeholder="Enter Confirm Code"></asp:TextBox>
								<span class="input-group-btn">
                                <asp:LinkButton ID="confirm_btn" runat="server" class="btn btn-default waves-effect btn-success" OnClick="confirm_btn_click">Confirm</asp:LinkButton>

                              


								
								</span>
							</div>
                            <br />
                            <br />
                            <div class="alert alert-info alert-dismissable">
							 <b>Resend code</b> (please wait at least 5 minutes before requesting another code)
						</div>
                            <div class="modal-footer">
                              <asp:LinkButton ID="cancel_btn" runat="server" class="btn btn-default waves-effect btn-danger" OnClick="cancel_btn_click">Cancel</asp:LinkButton>
                              <asp:LinkButton ID="resend_btn" runat="server" class="btn btn-primary waves-effect waves-light" OnClick="resend_btn_click">Resend again</asp:LinkButton>
                              </div>
						</div>

					</form>
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


        <script src="assets/js/jquery.core.js"></script>
        <script src="assets/js/jquery.app.js"></script>
    </form>
</body>
</html>
