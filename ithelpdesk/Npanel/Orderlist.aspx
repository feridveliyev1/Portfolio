<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orderlist.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Orderlist" %>


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
    function Problem_func(val) {
      
        if (val == "3") {
            document.getElementById('<%= problem_div.ClientID %>').style.display = "block";
        }
        else document.getElementById('<%= problem_div.ClientID %>').style.display = "none";
                                   
    }








</script>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <!-- Page-Title -->
						<div class="row">
							<div class="col-sm-12">
								<h4 class="page-title">Order list</h4>
								<ol class="breadcrumb">
									<li>
										<a href="#">Orders</a>
									</li>
									<li class="active">
										 Orders
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
                                    <asp:SqlDataSource ID="orderlist_sql" runat="server"></asp:SqlDataSource>
                                    <table id="datatable" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="width:2%">№</th>
                                                    <th>Time to Connect</th>
                                                    <th>Teamviewer code</th>
                                                    <th>Teamviewer login</th>
                                                    <th>Client</th>
                                                    <th style="width:2%">About</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="orderlist_sql" >
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("DATE") %></td>
                                                         <td><%# Eval("TEAMVIEWER_CODE") %></td>
                                                         <td><%# Eval("TEAMVIEWER_LOGIN")%></td>
                                                         <td><%# Eval("USER_FIO") %></td>
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
                                                    <asp:Button ID="Save_btn" runat="server" 
                                                        CssClass="btn btn-primary waves-effect waves-light" 
                                                        ValidationGroup="OBJECT_ADD_EDIT" Text="Saxla" OnClick="Save_btn_click"  OnClientClick="this.disabled='true'; this.value='Please wait...';" UseSubmitBehavior="false"/>
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
