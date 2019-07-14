<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <link rel="shortcut icon" href="assets/images/vricon.png" style="background:transparent">
		<title>Virtual Reality</title>

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
            <div class="loader"></div>
        </div>

        <div class="account-pages"></div>
        <div class="clearfix"></div>
        <div class="wrapper-page">
        	<div class=" card-box">
            <div class="panel-heading"> 
                <table width="100%">
                   <tr>
                      <td align="center">
                          
                          <img src="assets/images/phobia%20logo_final.jpg" height="80" width="300" /></td>
                   </tr>
                </table>
            </div> 


            <div class="panel-body">
            <form class="form-horizontal m-t-20" action="#">
                
                <div class="form-group ">
                    <div class="col-xs-12">
                         <asp:TextBox ID="Login_edt" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br /><br />
                <div class="form-group">
                    <div class="col-xs-12">
                        <asp:TextBox ID="Password_edt" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
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
