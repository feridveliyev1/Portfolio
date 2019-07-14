<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="defaultinner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/plugins/custombox/dist/custombox.min.css" rel="stylesheet">

<!-- DataTables -->
<link href="assets/plugins/datatables/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />

<!-- Validator -->
<link href="assets/plugins/bootstrapvalidator/src/css/bootstrapValidator.css" rel="stylesheet" type="text/css" />

<script language="javascript">
    function editing(id) {
        document.getElementById('<% =ObjectID_hf.ClientID%>').value = id;

        
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
						<!-- Page-Title -->
						<div class="row">
							<div class="col-sm-12">
								<h4 class="page-title">Hesabat</h4>
								
							</div>
						</div>

                        
                            <div class="col-sm-12">       
                                            
                       
                           <div class="col-sm-2">
                              <asp:Label ID="baslangic" runat="server">Başlanğıc vaxt:</asp:Label>
			                    <br />
			                    
			                    
			                    
			                    
			                    <asp:TextBox ID=FromDAte  CssClass=form-control TextMode=Date runat=server Width="300"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator"
                            runat="server"
                            ControlToValidate="FromDAte"
                            Display="Static"
                            ErrorMessage="Tarix boşdur!" ValidationGroup="GetReport_btn" />
                           </div>
                          <div class="col-sm-2">
                                <asp:Label ID="son" runat="server">Son vaxtı:</asp:Label>
			                    <br />
			                    <asp:TextBox ID=ToDate CssClass=form-control TextMode=Date runat=server></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server"
                            ControlToValidate="ToDate"
                            Display="Static"
                            ErrorMessage="Tarix boşdur!" ValidationGroup="GetReport_btn" />
                           </div>

                       
                           <div class="col-sm-2">
                               <br />
                               <asp:LinkButton ID="GetReport_btn" runat="server" 
                                   CssClass="btn btn-primary waves-effect waves-light" 
                                   onclick="GetReport_btn_Click">Hesabat Çıxart</asp:LinkButton>
                           </div>
                      
                            </div>
                            <br />
                          
                        

                        <br />
                      
                        <br />
                            <div class="row">
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                       <ContentTemplate>
                                       <asp:HiddenField ID="ObjectID_hf" runat="server" />
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                                    <table id="datatable" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Müştəri</th>
                                                    <th>Qiymət</th>
                                                    <th>Vaxt</th>
                                                    <th>Worker</th>
                                                    <th>DELETED</th>
                                                    <th>İstifadəçi</th>
                                                  
                                                    


                                                    <th></th>
                                                </tr>
                                            </thead>

                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server"  OnItemCommand="ObjectsGrid_ItemCommand" OnItemDataBound="ObjectsGrid_ItemDataBound">
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("CLIENT_NAME")%></td>
                                                         <td><%# Eval("PRICE")%></td>
                                                         <td><%# Eval("END_TIME")%></td>
                                                         <td><%# Eval("NAME")%></td>
                                                         <td><%# getStatus(Eval("DELETED"))%></td>
                                                         <td><%#Eval("OPNAME") %></td>
                                                        
                                                         <td>
                                                             <asp:LinkButton ID="Delete_btn" runat="server" CssClass="table-action-btn" CommandArgument='<%# Eval("ID") %>' CommandName="DELETE_Name"><i class="md md-delete"></i></asp:LinkButton>
                                                         </td>
                                                      </tr>
                                                   </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                         </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">       
                            <div class="card-box table-responsive">                 
                        <div class="row">
                           
                          <div class="col-sm-2">
                                <b>Qazanc:</b><br />
			                    
			                    <asp:TextBox ID="txtqazanc" CssClass="form-control"  runat="server" Enabled="false"></asp:TextBox>
                           </div>

                         
                           <div class="pull-right">
                          
                          
                           </div>
                        </div>
                            </div>
                          </div>
                        </div>
                        

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
     5<!-- Modal -->
   
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

