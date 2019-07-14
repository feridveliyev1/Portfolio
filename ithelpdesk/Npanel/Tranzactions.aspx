<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tranzactions.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Tranzactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/plugins/custombox/dist/custombox.min.css" rel="stylesheet">

<!-- DataTables -->
<link href="assets/plugins/datatables/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />

    <!-- JQuery DataTable Css -->
    <link href="plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">

<!-- Validator -->
<link href="assets/plugins/bootstrapvalidator/src/css/bootstrapValidator.css" rel="stylesheet" type="text/css" />

<!---------Google Chart--------------->
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
   <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

     <script type="text/javascript">
      google.charts.load("current", {packages:["corechart"]});
      google.charts.setOnLoadCallback(drawChart);
        function drawChart() {  


        //--------PAckage_type---------------------------
            var datapackagetype = google.visualization.arrayToDataTable([
        ['Task', 'Hours per Day'],
            <% =Package_type_ %>
          
         
        ]);

            var options = {
                title: 'Package type',
                  pieHole: 0.4,
            };
            var chartackagetype = new google.visualization.PieChart(document.getElementById('Package_type'));
               chartackagetype.draw(datapackagetype, options);
                
            //------------------------------------------------

                    //--------PAckages senior ---------------------------
            var datapackagesenior = google.visualization.arrayToDataTable([
        ['Task', 'Hours per Day'],
            <% =Senior_Packages %>
          
         
        ]);

            var options = {
                title: 'Senior package',
                  pieHole: 0.4,
            };
            var chartackagesenior = new google.visualization.PieChart(document.getElementById('Package_senior'));
               chartackagesenior.draw(datapackagesenior, options);
                
            //------------------------------------------------

                 //--------PAckages junior ---------------------------
            var datapackagesenior = google.visualization.arrayToDataTable([
        ['Task', 'Hours per Day'],
            <% =Junior_Packages %>
          
         
        ]);

            var options = {
                title: 'Junior package',
                  pieHole: 0.4,
            };
            var chartackagejunior = new google.visualization.PieChart(document.getElementById('Package_junior'));
               chartackagejunior.draw(datapackagesenior, options);
                
            //------------------------------------------------

            //--------Payment type ---------------------------
            var datapaymenttype = google.visualization.arrayToDataTable([
        ['Task', 'Hours per Day'],
            <% =Payment_type %>
          
         
        ]);

            var options = {
                title: 'Payment type',
                  pieHole: 0.4,
            };
            var chartpayment_type = new google.visualization.PieChart(document.getElementById('Payment_type'));
               chartpayment_type.draw(datapaymenttype, options);
                
            //------------------------------------------------


          
          
        }
    </script>


<script language="javascript">
    function editing(id) {
        __doPostBack('<% =LoadInfo_btn.UniqueID%>', '');

    }
    function sum()
    {
    document.getElementById('<% =test.ClientID%>').value = (parseInt(document.getElementById('<% =test.ClientID%>').value)+2).toString();
    }

</script>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <!-- Page-Title -->
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                       <ContentTemplate>
                                        <div class="row">
                                        <div class="col-sm-12">
                                       <div class="col-sm-3">
                                         <label for="field-3"  class="control-label">Username</label> 
                                            <asp:SqlDataSource ID="username_sql" runat="server"></asp:SqlDataSource>
                                          <asp:DropDownList ID="Username_ddl" ClientIDMode="Static"  runat="server" CssClass="form-control" OnDataBound="username_DataBound" DataSourceID="username_sql" DataTextField="NAME" DataValueField="ID"></asp:DropDownList>
                                       </div> <div class="col-sm-3">              
                                    <label for="field-3"  class="control-label">Package type</label> 
                                    <asp:SqlDataSource id="Package_type_sql" runat ="server"></asp:SqlDataSource>
                                    <asp:DropDownList ID="Package_type_ddl" runat="server" CssClass="form-control" OnSelectedIndexChanged="package_type_selectedindex" AutoPostBack="true" DataSourceID="Package_type_sql" DataValueField="ID" DataTextField="NAME" OnDataBound="Package_type_ddl_DataBound"></asp:DropDownList>                             
                                                </div>
                                                       <div class="col-sm-3">              
                                    <label for="field-3"  class="control-label">Package</label> 
                                    <asp:SqlDataSource id="Package_sql" runat ="server"></asp:SqlDataSource>
                                    <asp:DropDownList ID="Package_ddl" runat="server" CssClass="form-control" DataSourceID="Package_sql" DataValueField="ID" DataTextField="NAME" OnDataBound="Package_ddl_DataBound"></asp:DropDownList>                             
                                                </div>
                                    <div class="col-sm-3">
                                     <label for="field-3"  class="control-label">Payment type</label> 
                                     <asp:SqlDataSource id="payment_type_sql" runat ="server"></asp:SqlDataSource>
                                    <asp:DropDownList ID="payment_ddl" runat="server" CssClass="form-control"  DataSourceID="payment_type_sql" DataValueField="ID" DataTextField="NAME" OnDataBound="Payment_type_ddl_DataBound"></asp:DropDownList>                             
                                    </div>
                                    <div class="col-sm-12">
                                                          <div class="col-sm-3 ">
                                            <label for="field-3"  class="control-label">Time interval</label>
                                            <div class="input-group">
                                         <asp:TextBox ID="Start_edt" runat="server"    CssClass="form-control" data-provide="datepicker"   placeholder="From date" ></asp:TextBox>
                                         <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                         </div>
                                         <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="Start_edt" ValidationGroup="for_date" ErrorMessage="Səhv aşkarlandı" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-sm-3 ">
                                            <asp:CheckBox ID="deadline_chk" runat="server"  Text="Son tarix" ClientIDMode="Static" style="visibility:hidden;"  />
                                          <div class="col-sm-12">
                                           <div class="input-group">
                                            <asp:TextBox ID="Deadline_edt" runat="server"    CssClass="form-control" data-provide="datepicker"  placeholder="To date"></asp:TextBox>
                                         <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                        </div>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Deadline_edt" ValidationGroup="for_date" ErrorMessage="Səhv aşkarlandı" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                    </div>
                                    </div>                                   
                                     <div class="col-sm-3" style="    margin-top: 27px;">
                                       <asp:LinkButton ID="show_btn" runat="server" CssClass="btn btn-primary waves-effect waves-light" OnClick="Search_btn_Click"  ><span class="btn-label"><i class="ion-ios7-search-strong"></i></span>Search</asp:LinkButton>
                                   </div> 
                                      <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                                        <ProgressTemplate>
                                           <img src="assets/images/preloader.gif" />
                                        </ProgressTemplate>
                                     </asp:UpdateProgress> 
                                   </div>
                                   </div>
                             </div>
                            <div class="col-sm-12" style="margin-top: 20px;">
                                <div class="card-box table-responsive">
                                    
                                    <asp:Literal runat="server" ID="test"></asp:Literal>

                                    <asp:SqlDataSource ID="report_sql" runat="server" ></asp:SqlDataSource>
                                         <table id="datatable" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="width:2%">№</th>
                                                    <th>Username</th>
                                                    <th>Type</th>
                                                    <th>Package</th>
                                                    <th>Payment</th>
                                                    <th>Price</th>
                                                    <th>Date</th>
                                                    
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="report_sql" OnItemDataBound="ObjectsGrid_ItemDataBound" >
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("USERNAME") %></td>
                                                         <td><%# Eval("P_TYPE")%></td>
                                                         <td><%# Eval("PACKAGE") %></td>
                                                         <td><%# Eval("PAYMENT_TYPE")%></td>
                                                          <td><%# Eval("PRICE") %>
                                                          
                                                          <asp:HiddenField runat="server" ID="Amount_hf" Value='<%# Eval("PRICE") %>' />
                                                          </td>
                                                          <td><%# Eval("DATE").ToString() %></td>
                                                            
                                                        
                                                      </tr>
                                                   </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                       
                                     <asp:LinkButton ID="LoadInfo_btn" runat="server" OnClick="LoadInfo_btn_Click" ></asp:LinkButton>
                                        
                                </div>
                            </div>
                                      <div class="col-sm-3">
                                       <div class="card-box table-responsive" style="padding:8px;">
                                        <label for="field-3"  class="control-label">Price Sum :</label>
                                        <asp:TextBox runat="server" ID="Amount_txt" CssClass="form-control" Enabled="false" placeholder="Price sum"></asp:TextBox>
                                        </div>
                                        </div>

                                               <div class="row">
                                               <div class="col-sm-12">
            <div class="col-lg-6 form-group" >
            <div id="Package_type"style=" height: 300px;" ></div>                   
			</div>
             <div class="col-lg-6 form-group" >
            <div id="Payment_type"style=" height: 300px;" ></div>                   
			</div>
                   
            <div class="col-lg-6 form-group" >
            <div id="Package_senior" style=" height: 300px;" ></div>                   
			</div>
             <div class="col-lg-6 form-group" >
            <div id="Package_junior" style=" height: 300px;" ></div> 
            </div>                  
			</div>
                     </div>
     </ContentTemplate>
                                    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
     <!-- Modal -->
  

                           
                                   
                                    <!-- /.modal -->

 






   <!-- DataTable-Effect -->
<%--<!---------------------------------------------------------------------------- -->
<script src="assets/plugins/RWD-Table-Patterns/dist/js/rwd-table.min.js" type="text/javascript"></script>
<script src="assets/plugins/datatables/jquery.dataTables.min.js"></script>
<script src="assets/plugins/datatables/dataTables.bootstrap.js"></script>--%>

  <!-- Jquery DataTable Plugin Js -->
    <script src="plugins/jquery-datatable/jquery.dataTables.js"></script>
    <script src="plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/buttons.flash.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/jszip.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/pdfmake.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/vfs_fonts.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/buttons.html5.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/buttons.print.min.js"></script>





<%--<script type="text/javascript">

    function init() {
        $('#datatable').dataTable();

    }

    $(document).ready(function () {
        init();
    });

</script>--%>

  <script type="text/javascript">
      function init() {
          drawChart()
//          jQuery('#<% =Deadline_edt.ClientID %>').datepicker({
//              dateFormat: 'mm-dd-yyyy',
//              autoclose: true,
//              todayHighlight: true
//          });

          var date = $('#<% =Deadline_edt.ClientID %>').datepicker({ dateFormat: 'mm-dd-yy' });

          jQuery('#<% =Start_edt.ClientID %>').datepicker({
           dateFormat: 'dd-mm-yyyy' ,
              autoclose: true,
              todayHighlight: true
          });
          var table = $('#datatable').DataTable({
              dom: 'Bfrtip',
         
              destroy: true,
              buttons: [
                {
                    extend: 'print',
                    text: 'Print',


                    title: 'Your text here',
                    customize: function (win) {
                        $(win.document.body)
                            .css('font-size', '10pt');



                        $(win.document.body).find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');

                    }
                },
                 {
                     extend: 'excelHtml5',
                     text: 'Excell'


                 }
            ]
             });
           
      }

      $(document).ready(function () {
          init();


          //          var buttonCommon = {
          //              exportOptions: {
          //                  format: {
          //                      body: function (data, row, column, node) {
          //                          // Strip $ from salary column to make it numeric
          //                          return column === 6 ?
          //                        data.replace(/[$,]/g, '') :
          //                        data;
          //                      }
          //                  }
          //              }
          //          };


          //          var dt = $('#datatable').DataTable({
          //              responsive: true,


          //              dom: 'Bfrtip',
          //              colReorder: {
          //                  allowReorder: false
          //              },

          //              buttons: [
          //                 'print',
          //            $.extend(true, {}, buttonCommon, {
          //                extend: 'copyHtml5'
          //            }),
          //            $.extend(true, {}, buttonCommon, {
          //                extend: 'excelHtml5'
          //            }),
          //            $.extend(true, {}, buttonCommon, {
          //                extend: 'pdfHtml5'
          //            }),


          //        ]
          //          });

      });

</script>
<style>
           .dt-buttons {
    margin-bottom: -25px;
           }
           
        </style>
        <style>
        .buttons-print
           {
                   background-color: blue;
    border: none;
    color: white;
    padding: 6px 20px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    border-radius: 27px;
           }
           .buttons-excel
           {
                   background-color: green;
    border: none;
    color: white;
    margin-left: 5px;
    padding: 6px 20px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    border-radius: 27px;
           }
        
        </style>


<!---------------------------------------------------------------------------- -->

<!-- Plugins -->
<!---------------------------------------------------------------------------- -->
<script src="assets/plugins/bootstrap-select/dist/js/bootstrap-select.min.js" type="text/javascript"></script>
<!---------------------------------------------------------------------------- -->

<!-- Modal-Effect -->
<!---------------------------------------------------------------------------- -->
<script src="assets/plugins/custombox/dist/custombox.min.js"></script>
<script src="assets/plugins/custombox/dist/legacy.min.js"></script>
<!---------------------------------------------------------------------------- -->

   


   <!-- DataPicker-->
<!--------------------------------------------------------------------------------------------------------------->
<script src="assets/plugins/moment/moment.js"></script>
<script src="assets/plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>

<!--------------------------------------------------------------------------------------------------------------->
<script src="assets/plugins/bootstrap-inputmask/bootstrap-inputmask.min.js" type="text/javascript"></script>
<script src="assets/plugins/autoNumeric/autoNumeric.js" type="text/javascript"></script>










</asp:Content>