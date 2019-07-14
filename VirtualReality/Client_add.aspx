<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Client_add.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Client_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
 <script src="assets/js/jquery.maskedinput.js" type="text/javascript"></script>
<script type="text/javascript">
    function mask() {
        jQuery("#<% =PhoneNumber_edt.ClientID %>").mask("kkk kk kk");


        jQuery.mask.definitions['9'] = '';
        jQuery.mask.definitions['d'] = '[0-9]';

          //$('#datatablecards').dataTable();
      }

      jQuery(document).ready(function () {
          init();
      });
      </script>
 <script>
     function validate() {
         var req1 = document.getElementById('<%=gender_ddl.ClientID %>');
         if (req1.value == "0") {
             alert("Please select gender");
         }
         var req3 = document.getElementById('<%=age_ddl.ClientID %>');
         if (req3.value == "0") {
             alert("Please select age interval");
         }
         var req4 = document.getElementById('<%=source_type.ClientID %>');
         if (req4.value == "0") {
             alert("Please select source type");
         }
         var req5 = document.getElementById('<%=source_type_name_ddl.ClientID %>');
         if (req5.value == "0") {
             alert("Please select source type name");
         }
     }
 </script>
   

<style type="text/css">
.vertical-text {
  writing-mode: vertical-rl;
  text-orientation: sideways-right;
}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <!-- Page-Title -->
							<div class="row">
							<div class="col-sm-12">
								<h4 class="page-title">Klient əlavə et</h4>
								<ol class="breadcrumb">

									<li>
										<a href="#">Klientlər</a>
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
                                                    <th style="width:2%">№</th>
                                                    <th>Ad</th>
                                                    <th>Soyad</th>
                                                    <th>Telefon nömrəsi</th>
                                                    <th>Cins</th>
                                                   
                                                    <th>Yaş intervalı</th>
                                                    <th>Mənbənin tipi</th>
                                                    <th>Gəldiyi mənbə</th>
                                                    <th>Operator</th>
                                                    <th style="width:2%"></th>
                                                    <th style="width:2%"></th>
                                                </tr>
                                            </thead>

                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="ObjectsGrid_ItemCommand" OnItemDataBound="ObjectsGrid_ItemDataBound">
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td ><%# Eval("NAME")%></td>
                                                         <td ><%# Eval("SURNAME")%></td>
                                                         <td><%# Eval("PHONE_NUMBER")%></td>
                                                         <td><%# Eval("GENDER").ToString()=="1" ? "Kişi" : "Qadın"%> </td>
                                                         
                                                         <td><%# Eval("AGES")%></td>
                                                         <td><%# Eval("SOURCE_T")%></td>
                                                         <td><%# Eval("SOURCE_NAME")%></td>
                                                          <td><%# Eval("USER_ID")%></td>
                                                         <td align="center">
                                                            <a href="#" class="table-action-btn" data-toggle="modal" data-target="#con-close-modal"
                                                               onclick="javascript:editing('<%# Eval("ID") %>');">
                                                               <i class="md md-edit"></i></a>
                                                         </td>
                                                         <td align="center">
                                                             <asp:LinkButton ID="Delete_btn" runat="server" CssClass="table-action-btn" CommandArgument='<%# Eval("ID") %>' CommandName="DELETE_CLIENT"><i class="md md-delete"></i></asp:LinkButton>
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
                                                             <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Ad</label> 
                                                                <asp:TextBox ID="client_name_edt" runat="server" CssClass="form-control"></asp:TextBox>
                                                                
                                                               </div>
                                                                <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Soyad</label> 
                                                                <asp:TextBox ID="client_surname_edt" runat="server" CssClass="form-control"></asp:TextBox>
                                                                 
                                                               </div>
                                                                  <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Cins</label> 
                                                              <asp:DropDownList ID="gender_ddl" runat="server" CssClass="form-control" >
                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                  <asp:ListItem Text="Kişi" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Qadın" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                               
                                                                 </div>
                                                                <div class="col-md-6"> 
                                                                 <div class="row">
                                                                  <div class="col-md-5">
                                                                <label for="field-3"   class="control-label">Növü</label> 
                                                                <asp:DropDownList ID="numberddl" runat="server" CssClass="form-control" Width="100px">
                                                                 <asp:ListItem Text="Seçin" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="+99450" Value="+99450"></asp:ListItem>
                                                                  <asp:ListItem Text="+99451" Value="+99451"></asp:ListItem>
                                                                    <asp:ListItem Text="+99455" Value="+99455"></asp:ListItem>
                                                                      <asp:ListItem Text="+99470" Value="+99470"></asp:ListItem>
                                                                        <asp:ListItem Text="+99477" Value="+99477"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-7" class="form-control">
                                                             <label for="field-3"   class="control-label">Əlaqə nömrəsi</label> 
                                                               <asp:TextBox ID="PhoneNumber_edt" runat="server" class="required form-control"  maxlength="7"></asp:TextBox>
                                                               &nbsp &nbsp &nbsp &nbsp
                                                            </div>
                                                               </div>
                                                               </div>
                                                                <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Doğum tarixi</label> 
                                                                <asp:TextBox ID="birthday_txt" runat="server"  CssClass="required form-control" TextMode="Date"  ></asp:TextBox>
                                                               </div> 
                                                               <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Yaş aralıqı</label> 
                                                                <asp:DropDownList ID="age_ddl" runat="server" CssClass="required form-control" >
                                                                <asp:ListItem Text="Seçin" Value="0"></asp:ListItem>
                                                                 <asp:ListItem Text="10-18" Value="1"></asp:ListItem>
                                                                  <asp:ListItem Text="18-25" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="25-40" Value="3"></asp:ListItem>
                                                                </asp:DropDownList> 
                                                               </div>
                                                               
                                                                <div class="col-md-12"> 
                                                                <label for="field-3"  class="control-label">Gəldiyi mənbə</label> 
                                                                 <div class="row">
                                                                  <div class="col-md-3">
                                                                <asp:DropDownList ID="source_type" runat="server"   CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="source_type_changed"  >
                                                                <asp:ListItem Text="Seçin" Value="0"></asp:ListItem>
                                                                  <asp:ListItem Text="Digər" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Biznes" Value="2"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-9" class="form-control">
                                                             <asp:SqlDataSource id="source_type_sql" runat ="server"></asp:SqlDataSource>
                                                           <asp:DropDownList  ID="source_type_name_ddl" runat="server"  AutoPostBack="true" DataSourceID="source_type_sql" DataValueField="ID" DataTextField="NAME" ondatabound="source_ddl_DataBound" CssClass="required form-control" OnSelectedIndexChanged="TABLE"></asp:DropDownList>
                                                   
                                                            </div>
                                                               </div> 


                                                            </div> 
                                                             <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Operator</label> 
                                                                <asp:TextBox ID="User_txt" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                               </div>

                                                        </div> 
                                                    </div> 
                                                 
                                                </div> 
                                                </div>
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect btn-danger" data-dismiss="modal">İmtina</button> 
                                                   
                                                         <asp:Button ID="Save_btn" runat="server" Text="Submit" CssClass="btn btn-primary waves-effect waves-light" UseSubmitBehavior="false" OnClick="Save_btn_Click" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
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

