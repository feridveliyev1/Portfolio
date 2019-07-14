<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Report" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/plugins/custombox/dist/custombox.min.css" rel="stylesheet">

<!-- DataTables -->
<link href="assets/plugins/datatables/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />

    <!-- JQuery DataTable Css -->
    <link href="plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">

<!-- Validator -->
<link href="assets/plugins/bootstrapvalidator/src/css/bootstrapValidator.css" rel="stylesheet" type="text/css" />

<script language="javascript">
    function editing(id) {
        document.getElementById('<% =ObjectID_hf.ClientID%>').value = id;
        __doPostBack('<% =LoadInfo_btn.UniqueID%>', '');

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
                                       </div>
                                       <div class="col-sm-3">
                                         <label for="field-3"  class="control-label">Operator</label> 
                                            <asp:SqlDataSource ID="operator_sql" runat="server"></asp:SqlDataSource>
                                          <asp:DropDownList ID="Operator_ddl" ClientIDMode="Static"  runat="server" CssClass="form-control" OnDataBound="Operator_DataBound" DataSourceID="operator_sql" DataTextField="NAME" DataValueField="ID"></asp:DropDownList>
                                       </div>
                                      
                                           <div class="col-sm-3 ">
                                            <label for="field-3"  class="control-label">Time interval</label>
                                        
                                            <div class="input-group">
                                         <asp:TextBox ID="Start_edt" runat="server"    CssClass="form-control" data-provide="datepicker" placeholder="From date" ></asp:TextBox>
                                         <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                         </div>
                                         <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="Start_edt" ValidationGroup="for_date" ErrorMessage="Səhv aşkarlandı" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                        </div>


                                        <div class="col-sm-3 ">
                                            <asp:CheckBox ID="deadline_chk" runat="server"  Text="Son tarix" ClientIDMode="Static" style="visibility:hidden;"  />
                                          <div class="col-sm-12">
                                           <div class="input-group">
                                            <asp:TextBox ID="Deadline_edt" runat="server"    CssClass="form-control" data-provide="datepicker" placeholder="To date"></asp:TextBox>
                                         <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                        </div>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Deadline_edt" ValidationGroup="for_date" ErrorMessage="Səhv aşkarlandı" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                    </div>
                                    </div>
                               
                                                                                 <div class="col-sm-3">
                                          <label for="field-3"  class="control-label">Subject</label> 
                                          <asp:TextBox runat="server" ID="Subject_txt" CssClass="form-control" placeholder="Issue description"></asp:TextBox>
                                       </div>   
                                       <div class="col-sm-3">
                                          <label for="field-3"  class="control-label">Description</label> 
                                          <asp:TextBox runat="server" ID="Description_txt" CssClass="form-control" placeholder="Issue description"></asp:TextBox>
                                       </div>   
                                     <div class="col-sm-3" style="    margin-top: 27px;">
                                       <asp:LinkButton ID="show_btn" runat="server" CssClass="btn btn-primary waves-effect waves-light" OnClick="Search_btn_Click"  ><span class="btn-label"><i class="ion-ios7-search-strong"></i></span>Search</asp:LinkButton>
                                   </div> 
                                   </div>
                             </div>

                         
                            <div class="col-sm-12" style="margin-top: 20px;">
                                <div class="card-box table-responsive">
                                    


                                    <asp:SqlDataSource ID="report_sql" runat="server" ></asp:SqlDataSource>
                                         <table id="datatable" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="width:2%">№</th>
                                                    <th>Username</th>
                                                    <th>Date</th>
                                                    <th>SUBJECT</th>
                                                    <th>OPERATOR</th>
                                                    <th style="width:2%">About</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="report_sql" >
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("USERNAME") %></td>
                                                         <td><%# Eval("DATE") %></td>
                                                         <td><%# Eval("SUBJECT")%></td>
                                                         <td><%# Eval("WORKER") %></td>
                                                            <td align="center">
                                                            <a href="#" class="table-action-btn" data-toggle="modal" data-target="#teamviewer-modal"
                                                               onclick="javascript:editing('<%# Eval("ID") %>');">
                                                               <i class="md md-edit"></i></a>
                                                         </td></th>
                                                        
                                                      </tr>
                                                   </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                     <asp:LinkButton ID="LoadInfo_btn" runat="server" OnClick="LoadInfo_btn_Click" ></asp:LinkButton>
                                        
                                </div>
                            </div>
    

     </ContentTemplate>
                                    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
     <!-- Modal -->
    <div id="generator-modal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                           <ContentTemplate>
                                               <asp:HiddenField ID="ObjectID_hf" runat="server" />
                                           <div class="modal-dialog modal-lg"> 
                                            <div class="modal-content"> 
                                                <div class="modal-header"> 
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" id="close_btn">×</button> 
                                                    <h4 class="modal-title">
                                                        <asp:Literal ID="ModalCaption_lb" runat="server">Create card</asp:Literal></h4> 
                                                </div> 
                                                <div class="modal-body"> 
                                                    <div class="row"> 
                                                        <div class="col-md-12"> 
                                                            <div class="form-group">
                                                           
                                                        <div class="col-sm-4">              
                                    <label for="field-3"  class="control-label">Package type</label> 
                                    <asp:SqlDataSource id="Package_type_sql" runat ="server"></asp:SqlDataSource>
                                    <asp:DropDownList ID="Package_type_ddl" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="Package_type_sql" DataValueField="ID" DataTextField="NAME" ></asp:DropDownList>                             
                                                </div>
                                                       <div class="col-sm-4">              
                                    <label for="field-3"  class="control-label">Package</label> 
                                    <asp:SqlDataSource id="Package_sql" runat ="server"></asp:SqlDataSource>
                                    <asp:DropDownList ID="Package_ddl" runat="server" CssClass="form-control" DataSourceID="Package_sql" DataValueField="ID" DataTextField="NAME" AutoPostBack="true"></asp:DropDownList>                             
                                                </div>
                                                <div class="col-sm-4">
                                                <label for="field-3" class="control-label">Count</label>
                                                <asp:TextBox runat="server" ID="count_txt" CssClass="form-control" placeholder="Write count" TextMode="Number"></asp:TextBox>
                                                </div>
                                                 <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                                        <ProgressTemplate>
                                           <img src="assets/images/preloader.gif" />
                                        </ProgressTemplate>
                                     </asp:UpdateProgress> 
                                                            

                                                         
                                                           </div>
                                                    </div> 

                                                </div>
                                                </div>
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect btn-danger" data-dismiss="modal">İmtina</button> 
                                                    <asp:Button ID="Save_btn" runat="server" 
                                                        CssClass="btn btn-primary waves-effect waves-light" 
                                                         Text="Create cards"   OnClientClick="this.disabled='true'; this.value='Please wait...';" UseSubmitBehavior="false"/>
                                                </div>
                                                </div>
                                            </div> 
                                        </div>
                                        
                                           </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                      <div id="teamviewer-modal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                           <ContentTemplate>
                                               <asp:HiddenField ID="HiddenField1" runat="server" />
                                           <div class="modal-dialog modal-lg"> 
                                            <div class="modal-content"> 
                                                <div class="modal-header"> 
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" id="Button1">×</button> 
                                                    <h4 class="modal-title">
                                                        <asp:Literal ID="Literal1"  runat="server">Əlavə et</asp:Literal></h4> 
                                                </div> 
                                                <div class="modal-body"> 
                                                    <div class="row"> 
                                                   
                                                     <div class="col-md-12">    
                                                              <div id="Div1" class="col-sm-3" runat="server" >
                                                           <label for="field-3" class="control-label">Client :</label>
                                                           <asp:TextBox runat="server" ID="Username_edt" Enabled="false" CssClass="form-control"  ></asp:TextBox>
                                                         </div>
                                                              <div class="col-sm-3">
                                                                <label for="field-3" class="control-label">Time to Connect :</label>
                                                           <asp:TextBox runat="server" ID="Date_edt" Enabled="false"  CssClass="form-control" ></asp:TextBox>
                                                           </div>
                                                              <div class="col-sm-3">
                                                            <label for="field-3" class="control-label">Teamviewer code:</label>
                                                          <asp:TextBox runat="server" ID="Teamviewer_edt" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                                           </div>
                                                              <div class="col-sm-3">
                                                            <label for="field-3" class="control-label">Teamviewer login:</label>
                                                          <asp:TextBox runat="server" ID="team_log_edt" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                                           </div>
                                                              
                                                         </div>

                                                     <div class="col-md-12">
                                                         <div class="col-sm-12">
                                                           <label for="field-3" class="control-label">Subject :</label>
                                                           <asp:TextBox runat="server" ID="Subject_edt" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                                           </div>
                                                         </div>
                                                   
                                                     <div class="col-md-12">
                                                            <label for="field-3" class="control-label">Description :</label>
                                                           <asp:TextBox runat="server" ID="Description_edt" Enabled="false" CssClass="form-control" TextMode="MultiLine" Rows="3"> </asp:TextBox>
                                                    </div>
                                                  
                                                     <div class="col-md-4">
                                                           
                                                           <label for="field-3" class="control-label">Services :</label>
                                                           <asp:SqlDataSource runat="server" ID="services_sql" ></asp:SqlDataSource>
                                                           <asp:Repeater runat="server" ID="services_rpt"  DataSourceID="services_sql">
                                                           <ItemTemplate>
                                                            <li>
                                                                  <asp:Label runat="server" ID="lang_lbl" Class="circle-text " Font-Bold="true" Font-Underline="true"><%# Eval("NAME") %></asp:Label>
                                                               </li>
                                                           </ItemTemplate>
                                                           </asp:Repeater>
                                                           
                                                           </div>

                                                     <div class="col-md-4" style="padding: 25px 0 0 0; font-size: 13px;">
                                                             
                                                           <asp:Label ID="name_lbl"  runat="server" TextMode="Multiline"></asp:Label>
                                                           </div>

                                                     <div class="col-md-4">
                                                           
                                                            <label for="field-3" class="control-label">Order status :</label>
                                                            <asp:DropDownList runat="server" ID="order_status_ddl" class="form-control" onchange="Problem_func(this.options[this.selectedIndex].value);" DataSourceID="order_type_sql" DataTextField="NAME" DataValueField="ID"></asp:DropDownList>
                                                           <asp:SqlDataSource ID="order_type_sql" runat="server"></asp:SqlDataSource>
                                                            
                                                           <asp:RadioButtonList ID="order_type_rdb" runat="server" Visible="false" DataValueField="ID" DataTextField="NAME" DataSourceID="order_type_sql"></asp:RadioButtonList>
                                                           </div>

                                                     <div class="col-md-12"  runat="server" id="problem_div" style="display:none">
                                                            <label for="field-3" class="control-label">Description for problem :</label>
                                                           <asp:TextBox runat="server" ID="problem_txt"   class="form-control" TextMode="MultiLine" Rows="3"> </asp:TextBox>
                                                    </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect btn-danger" data-dismiss="modal">İmtina</button> 
                                                </div>
                                                </div>
                                            </div> 
                                           </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                   
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
          jQuery('#<% =Deadline_edt.ClientID %>').datepicker({
              autoclose: true,
              todayHighlight: true
          });
          jQuery('#<% =Start_edt.ClientID %>').datepicker({
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
