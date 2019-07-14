<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerSources.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="defaultinner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/plugins/custombox/dist/custombox.min.css" rel="stylesheet">

<!-- DataTables -->
<link href="assets/plugins/datatables/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />

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
								<h4 class="page-title">Lüğətlər</h4>
								<ol class="breadcrumb">
									<li>
										<a href="#">Lüğətlər</a>
									</li>
									<li class="active">
										Müştəri Mənbələri
									</li>
								</ol>
							</div>
						</div>

                       <div class="row">
                           <div class="col-sm-2">
                               <a class="btn btn-primary waves-effect waves-light" data-toggle="modal" data-target="#con-close-modal" onclick="javascript:editing('-1');"><i class="md md-add"></i> Əlavə et</a>
                           </div>
                        </div>
                             <br />
                               <div class="row">
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                       <ContentTemplate>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                                    <table id="datatable" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Müştəri Mənbələri</th>
                                                    <th></th>
                                                    <th></th>
                                                </tr>
                                            </thead>

                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="ObjectsGrid_ItemCommand" OnItemDataBound="ObjectsGrid_ItemDataBound">
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("Name")%></td>
                                                         <td align="center">
                                                            <a href="#" class="table-action-btn" data-toggle="modal" data-target="#con-close-modal"
                                                               onclick="javascript:editing('<%# Eval("ID") %>');">
                                                               <i class="md md-edit"></i></a>
                                                         </td>
                                                         <td align="center">
                                                             <asp:LinkButton ID="Delete_btn" runat="server" CssClass="table-action-btn" CommandArgument='<%# Eval("ID") %>' CommandName="DELETE_Name"><i class="md md-delete"></i></asp:LinkButton>
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
     5<!-- Modal -->
    <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                           <ContentTemplate>
                                               <asp:HiddenField ID="ObjectID_hf" runat="server" />
                                           <div class="modal-dialog"> 
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
                                                                <label for="field-3" class="control-label">Müştəri Mənbələri</label> 
                                                                <asp:TextBox ID="Customer_edt" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="Customer_edt" Display="Dynamic" ValidationGroup="OBJECT_ADD_EDIT"></asp:RequiredFieldValidator>
                                                            </div> 
                                                        </div> 
                                                    </div> 
                                                 
                                                </div> 
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect btn-danger" data-dismiss="modal">İmtina</button> 
                                                    <asp:LinkButton ID="Save_btn" runat="server" 
                                                        CssClass="btn btn-primary waves-effect waves-light" 
                                                        ValidationGroup="OBJECT_ADD_EDIT" onclick="Save_btn_Click">Saxla</asp:LinkButton>
                                                </div> 
                                            </div> 
                                        </div>
                                           </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <!-- /.modal -->
  <!-- DataTable-Effect -->
<!---------------------------------------------------------------------------- -->
<script src="assets/plugins/RWD-Table-Patterns/dist/js/rwd-table.min.js" type="text/javascript"></script>
<script src="assets/plugins/datatables/jquery.dataTables.min.js"></script>
<script src="assets/plugins/datatables/dataTables.bootstrap.js"></script>
<script type="text/javascript">

    function init() {
        $('#datatable').dataTable();
    }

    $(document).ready(function () {
        init();
    });

</script>
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

