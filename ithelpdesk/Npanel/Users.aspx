<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Category" %>

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

    function show_re_pass(id) {
        document.getElementById('<%= re_password_div.ClientID %>').style.display = "block";
        document.getElementById('<% =ObjectID_hf.ClientID%>').value = id;
        __doPostBack('<% =LoadInfo_btn.UniqueID%>', '');
    }
    function hide_re_pass(id) {
        document.getElementById('<%= re_password_div.ClientID %>').style.display = "none";
        document.getElementById('<% =ObjectID_hf.ClientID%>').value = id;
        __doPostBack('<% =LoadInfo_btn.UniqueID%>', '');
    }

</script>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <!-- Page-Title -->
						<div class="row">
							<div class="col-sm-12">
								<h4 class="page-title">Admistration</h4>
								<ol class="breadcrumb">
									<li>
										<a href="#">Users</a>
									</li>
									<li class="active">
										Users
									</li>
								</ol>
							</div>
						</div>

                       <div class="row">
                           <div class="col-sm-2">
                               <a class="btn btn-primary waves-effect waves-light" data-toggle="modal" data-target="#user-modal" onclick="javascript:show_re_pass('-1');"><i class="md md-add"></i> Əlavə et</a>
                           </div>
                        </div>
                             <br />
                               <div class="row">
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                       <ContentTemplate>
                                    <asp:SqlDataSource ID="users_sql" runat="server"></asp:SqlDataSource>
                                    <table id="datatable" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="width:2%">№</th>
                                                    <th>Name</th>
                                                    <th>Surname</th>
                                                    <th>Login</th>
                                                    <th style="width:2%"></th>
                                                    <th style="width:2%"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="users_sql" OnItemCommand="ObjectsGrid_ItemCommand" OnItemDataBound="ObjectsGrid_ItemDataBound">
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("FNAME") %></td>
                                                         <td><%# Eval("LNAME") %></td>
                                                         <td><%# Eval("USERNAME") %></td>
                                                        <td align="center">
                                                            <a href="#" class="table-action-btn" data-toggle="modal" data-target="#user-modal"
                                                               onclick="javascript:hide_re_pass('<%# Eval("ID") %>');">
                                                               <i class="md md-edit"></i></a>
                                                         </td>
                                                         <td align="center">
                                                             <asp:LinkButton ID="Delete_btn" runat="server" CssClass="table-action-btn" CommandArgument='<%# Eval("ID") %>' CommandName="DELETE_user"><i class="md md-delete"></i></asp:LinkButton>
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
   <div id="user-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                           <ContentTemplate>
                                               <asp:HiddenField ID="ObjectID_hf" runat="server" />
                                           <div class="modal-dialog"> 
                                            <div class="modal-content"> 
                                                <div class="modal-header"> 
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" id="close_btn">×</button> 
                                                    <h4 class="modal-title">
                                                        <asp:Literal ID="ModalCaption_lb" runat="server">Add</asp:Literal></h4> 
                                                </div> 
                                                <div class="modal-body"> 
                                                    <div class="row"> 
                                                        <div class="col-md-12"> 
                                                            <div class="form-group">
                                                             <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Name</label> 
                                                                <asp:TextBox ID="user_name_edt" runat="server" CssClass="form-control" placeholder="First name"></asp:TextBox>
                                                               </div>
                                                                 <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Surname</label> 
                                                                <asp:TextBox ID="user_surname_edt" runat="server" CssClass="form-control" placeholder="Last name"></asp:TextBox>
                                                               </div>
                                                                <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Login</label> 
                                                                <asp:TextBox ID="user_login_edt" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                                               </div>
                                                                <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Status</label> 
                                                                <asp:DropDownList ID="status_ddl" runat="server" Enabled="false" CssClass="form-control">
                                                                <asp:ListItem Text="Operator" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Admin" Value="2"></asp:ListItem>
                                                                 <asp:ListItem Text="SuperAdmin" Value="3"></asp:ListItem>
                                                                </asp:DropDownList>
                                                               </div>
                                                               <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Password</label> 
                                                                <asp:TextBox ID="user_password_edt" runat="server" CssClass="form-control"  placeholder="User password"></asp:TextBox>
                                                               </div>
                                                                <div class="col-md-6" runat="server" id="re_password_div"  style="display:none;"> 
                                                                <label for="field-3"  class="control-label">Confirm Password</label> 
                                                                <asp:TextBox ID="re_user_password_edt" runat="server"  CssClass="form-control"  placeholder="User password"></asp:TextBox>
                                                               </div>
                                                               
                                                               </div>
                                                               
                                                        </div> 
                                                       </div>
                                                  
                                                 
                                                </div> 
                                             
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect btn-danger" data-dismiss="modal">İmtina</button> 
                                                   
                                                         <asp:Button ID="Save_btn" runat="server" Text="Submit" CssClass="btn btn-primary waves-effect waves-light" UseSubmitBehavior="false" OnClick="Saving_btn_Click" OnClientClick="this.disabled='true'; this.value='Please wait...';"/>
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


    