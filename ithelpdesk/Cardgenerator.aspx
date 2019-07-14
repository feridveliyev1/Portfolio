<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cardgenerator.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Cardgenerator" %>

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
						<div class="row">
							<div class="col-sm-12">
								<h4 class="page-title">Card generator</h4>
								<ol class="breadcrumb">
									<li>
										<a href="#">Generator</a>
									</li>
								</ol>
							</div>
						</div>

                       <div class="row">
                           <div class="col-sm-2">
                               <a class="btn btn-primary waves-effect waves-light" data-toggle="modal" data-target="#generator-modal" onclick="javascript:editing('-1');"><i class="md md-add"></i>Create card</a>
                           </div>
                        </div>
                             <br />
                               <div class="row">
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                       <ContentTemplate>

                                    <asp:SqlDataSource ID="category_sql" runat="server"></asp:SqlDataSource>
                                    <table id="datatable" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="width:2%">№</th>
                                                    <th>Type</th>
                                                    <th>Package</th>
                                                    <th>Code</th>
                                                    <th style="width:2%"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="category_sql" OnItemCommand="ObjectsGrid_ItemCommand" OnItemDataBound="ObjectsGrid_ItemDataBound">
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("TYPE") %></td>
                                                         <td><%# Eval("PACKAGE") %></td>
                                                         <td><%# Eval("CODE") %></td>
                                                       
                                                         <td align="center">
                                                             <asp:LinkButton ID="Delete_btn" runat="server" CssClass="table-action-btn" CommandArgument='<%# Eval("ID") %>' CommandName="DELETE_card"><i class="md md-delete"></i></asp:LinkButton>
                                                         </td>
                                                      </tr>
                                                   </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    <asp:LinkButton ID="LoadInfo_btn" runat="server" onclick="LoadInfo_btn_Click"></asp:LinkButton>
                                         </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
    


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
                                    <asp:DropDownList ID="Package_type_ddl" runat="server" CssClass="form-control" OnSelectedIndexChanged="package_type_selectedindex" AutoPostBack="true" DataSourceID="Package_type_sql" DataValueField="ID" DataTextField="NAME" OnDataBound="Package_type_ddl_DataBound"></asp:DropDownList>                             
                                                </div>
                                                       <div class="col-sm-4">              
                                    <label for="field-3"  class="control-label">Package</label> 
                                    <asp:SqlDataSource id="Package_sql" runat ="server"></asp:SqlDataSource>
                                    <asp:DropDownList ID="Package_ddl" runat="server" CssClass="form-control" DataSourceID="Package_sql" DataValueField="ID" DataTextField="NAME" AutoPostBack="true" OnDataBound="Package_ddl_DataBound"></asp:DropDownList>                             
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
                                                         Text="Create cards" OnClick="Create_cards"  OnClientClick="this.disabled='true'; this.value='Please wait...';" UseSubmitBehavior="false"/>
                                                </div>
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
          var table = $('#datatable').DataTable({
              dom: 'Bfrtip',
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

   













</asp:Content>
