<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Categories" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <link rel="shortcut icon" href="assets/images/vricon.png" style="background:transparent">
		<title>Golden Pay</title>

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


</head>
<body>
 <form id="form2" runat="server">
        <div class="animationload">
            <div class="loader"></div>
        </div>

          <div class="account-pages"></div>
        <div class="clearfix"></div>
        <div class="wrapper-page" style="width:900px;">
        	<div class=" card-box">
                 <div class="panel-heading"> 
              <h4 class="page-title">Kategoriyalar</h4>
              <div class="nav navbar-nav navbar-right pull-right">
             <asp:LinkButton ID="az_btn" runat="server" OnClick="az_btn_click">AZ</asp:LinkButton>
             <asp:LinkButton ID="en_btn" runat="server" OnClick="en_btn_click">EN</asp:LinkButton>
             <asp:LinkButton ID="ru_btn" runat="server" OnClick="ru_btn_click">RU</asp:LinkButton>
              </div>
            </div>
            <div class="panel panel-primary">

                        <div class="panel-body">
            <form class="form-horizontal m-t-20" action="#">
             <div class="row">
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                  <div class="col-sm-12">
                                                <asp:Repeater ID="Categories_dt" runat="server">
                                                   <ItemTemplate>
                                                   <div class="col-sm-3" style="text-align:center">
                                                 
                                                   <a href="Merchant.aspx?categoryName=<%# Eval("categoryName") %>"><%# getImage(Eval("categoryName"))%></a>
                                                      
                                                      <br />
                                                      <a href="Merchant.aspx?categoryName=<%# Eval("categoryName") %>"><%# Eval("title") %></a>
                                                      </div>

                                                   </ItemTemplate>
                                                </asp:Repeater>
                                                </div>
                                </div>
                            </div>
                        </div>
                       
            </form>
            </div>
            </div>
            </div>
            </div>

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



    <!---------------------------------------------------------------------------- -->
<script src="assets/plugins/RWD-Table-Patterns/dist/js/rwd-table.min.js" type="text/javascript"></script>
<script src="assets/plugins/datatables/jquery.dataTables.min.js"></script>
<script src="assets/plugins/datatables/dataTables.bootstrap.js"></script>

<!-- Plugins -->
<!---------------------------------------------------------------------------- -->
<script src="assets/plugins/bootstrap-select/dist/js/bootstrap-select.min.js" type="text/javascript"></script>
<!---------------------------------------------------------------------------- -->

<!-- Modal-Effect -->
<!---------------------------------------------------------------------------- -->
<script src="assets/plugins/custombox/dist/custombox.min.js"></script>
<script src="assets/plugins/custombox/dist/legacy.min.js"></script>
<!---------------------------------------------------------------------------- -->
</body>
</html>
