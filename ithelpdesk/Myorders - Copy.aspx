 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Myorders.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Myorders" %>

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
								<h4 class="page-title">My orders</h4>
								<ol class="breadcrumb">
									<li>
										<a href="#">Orders</a>
									</li>
									<li class="active">
										My Orders
									</li>
								</ol>
							</div>
						</div>

                     
                             <br />
                               <div class="row">
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                       <ContentTemplate>
                                    <asp:SqlDataSource ID="orders_sql" runat="server"></asp:SqlDataSource>
                                    <table id="datatable" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="width:2%">№</th>
                                                    <th>Subject</th>
                                                    <th>Date</th>
                                                    <th>Status</th>
                                                    <th>Point</th>
                                                    <th style="width:2%"></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="orders_sql" OnItemCommand="ObjectsGrid_ItemCommand" OnItemDataBound="ObjectsGrid_ItemDataBound">
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("SUBJECT") %></td>
                                                         <td><%# Eval("DATE") %></td>
                                                         <td><%# getStatus( Eval("STATUS")) %></td>
                                                          <td><%# Eval("POINT") %></td>
                                                      
                                                        <td align="center">
                                                            <a href="#" class="table-action-btn" data-toggle="modal" data-target="#teamviewer-modal"
                                                               onclick="javascript:editing('<%# Eval("ID") %>');">
                                                               <i class="md md-edit"></i></a>
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
    <div id="teamviewer-modal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                           <ContentTemplate>
                                               <asp:HiddenField ID="ObjectID_hf" runat="server" />
                                           <div class="modal-dialog modal-lg"> 
                                            <div class="modal-content"> 
                                                <div class="modal-header"> 
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" id="close_btn">×</button> 
                                                    <h4 class="modal-title">
                                                        <asp:Literal ID="ModalCaption_lb"  runat="server">Əlavə et</asp:Literal></h4> 
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
                                                  
                                                     <div class="col-md-8">
                                                           
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

                                                 

                                                     <div class="col-md-4">
                                                           
                                                            <label for="field-3" class="control-label">Order status :</label>
                                                           <asp:TextBox runat="server" ID="order_status_edt" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                                            
                                                           </div>

                                                     <div class="col-md-12"  runat="server" id="problem_div" style="display:none">
                                                            <label for="field-3" class="control-label">Description for problem :</label>
                                                           <asp:TextBox runat="server" ID="problem_txt"   class="form-control" TextMode="MultiLine" Rows="3"> </asp:TextBox>
                                                    </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer"> 
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
        
         $('#datatable').DataTable({
            "order": [[0, "desc"]],
                  });
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


    