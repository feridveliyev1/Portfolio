<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="defaultinner" %>
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
										Ödəniş
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
                                                    <th>Başlama saatı</th>
                                                    <th>Status</th>
                                                    <th>Müştəri</th>
                                                    <th></th>
                                                    <th></th>
                                                    <th></th>
                                                </tr>
                                            </thead>

                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="ObjectsGrid_ItemCommand" OnItemDataBound="ObjectsGrid_ItemDataBound">
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("BEGIN_TIME")%></td>
                                                         <td><%# Eval("STATUS")%></td>
                                                         <td><%# Eval("PRICE")%></td>
                                                         <td><%# Eval("PAY_TYPE")%></td>
                                                         <td><%# Eval("PAYMENT_DATE")%></td>
                                                        
                                                         <td align="center">
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
    


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
     <!-- Modal -->
    <div id="con-close-modal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                           <ContentTemplate>
                                               <asp:HiddenField ID="ObjectID_hf" runat="server" />
                                           <div class="modal-dialog modal-lg"> 
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
                                                            <div class="col-md-3"> 
                                                             <asp:SqlDataSource id="client_dll_sql" runat ="server"></asp:SqlDataSource>
                                                                <label for="field-3"  class="control-label">Müştəri</label> 
                                                              <asp:DropDownList ID="client_ddl" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="client_dll_sql" DataValueField="ID" DataTextField="FIO" OnSelectedIndexChanged="Clientdd_SelectedIndexChanged" ondatabound="client_ddl_DataBound" >
                                                                </asp:DropDownList>
                                                               </div>
                                                               <div class="col-md-3">
                                                               <label for="field-3"  class="control-label">Qeyri-müştəri</label> 
                                                                <asp:TextBox ID="client_txt" CssClass="required form-control" runat="server" ></asp:TextBox>
                                                               </div>
                                                              <div class="col-md-3"> 
                                                                <label for="field-4"  class="control-label">Başlama tarixi</label> 
			                                				<asp:TextBox ID="begindate_edt" CssClass="required form-control" TextMode="Date" runat="server"  AutoPostBack="true" ></asp:TextBox>
                                                               </div>
                                                                <div class="col-md-3">  
                                                               <label for="field-3"  class="control-label">Başlama saatı</label> 
                                                               <div class="row">
                                                                  <div class="col-md-6">
                                                                  <asp:DropDownList ID="begin_hour_ddl" runat="server" CssClass="form-control" AutoPostBack="true">
                                                                    <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                                                    <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                                                    <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                                                    <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                                                    <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                                                    <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                                    <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                                                    <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                                                    <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                                                    <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                  </div>
                                                                 
                                                                   <div class="col-md-6">
                                                                  <asp:DropDownList ID="begin_minutes_ddl" runat="server" CssClass="form-control" AutoPostBack="true">
                                                                    <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                                  </asp:DropDownList>
                                                                  </div>
                                                                  </div>

                                                               </div> 
                                                                <div class="col-md-4"> 
                                                  <label for="field-3"  class="control-label">Aparatlar kategoriyası</label> 
                                                  <asp:SqlDataSource id="category_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="category_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="category_dll_sql" DataValueField="ID" DataTextField="NAME" OnSelectedIndexChanged="Category_SelectedIndexChanged" ondatabound="category_dll_DataBound" >
                                                                </asp:DropDownList>        
                                                               </div> 
                                                               <div class="col-md-4">
                                                                <div class="col-md-8"> 
                                                  <label for="field-3"  class="control-label">Paketlər</label> 
                                                  <asp:SqlDataSource id="package_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="packages_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="package_dll_sql" DataValueField="ID" DataTextField="NAME" OnSelectedIndexChanged="Packagedll_SelectedIndexChanged" ondatabound="package_dll_DataBound" >
                                                                </asp:DropDownList>
                                                               </div>
                                                                <div class="col-md-4"> 
                                                                <label for="field-4"  class="control-label">Müddəti</label> 
                                                                <asp:TextBox ID="time_edt" CssClass="required form-control" runat="server" ></asp:TextBox>
                                                               </div> 
                                                               </div>
                                                                <div class="col-md-4"> 
                                                  <label for="field-3"  class="control-label">Aparatlar</label> 
                                                  <asp:SqlDataSource id="devices_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="device_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="devices_dll_sql" DataValueField="ID" DataTextField="NAME"  ondatabound="device_dll_DataBound" >
                                                                </asp:DropDownList>        
                                                               </div> 
                                                               <div class="col-md-3"> 
                                                  <label for="field-3"  class="control-label">Oyunlar</label> 
                                                  <asp:SqlDataSource id="game_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="game_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="game_dll_sql" DataValueField="ID" DataTextField="NAME" OnSelectedIndexChanged="Gamesdll_SelectedIndexChanged" ondatabound="game_dll_DataBound" >
                                                                </asp:DropDownList>        
                                                               </div> 
                                                                <div class="col-md-4">
                                                                <label for="field-3"  class="control-label">Oyunlar cədvəli</label> 
                                                              <asp:Listbox ID="games_lstbx" runat="server" CssClass="form-control" SelectionMode="Multiple" Width="250px" Height="60px" OnTextChanged="remove_game_text" AutoPostBack="true"></asp:Listbox>
                                                            </div>
                                                            <div class="col-md-2"> 
                                                                <label for="field-4"  class="control-label">Sayı</label> 
                                                                <asp:TextBox ID="count_edt" CssClass="required form-control" runat="server" ></asp:TextBox>
                                                               </div>
                                                               <div class="col-md-3"> 
                                                               <div class="col-md-7"> 
                                                  <label for="field-3"  class="control-label">Status</label> 
                                                  <asp:SqlDataSource id="status_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="status_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="status_dll_sql" DataValueField="ID" DataTextField="NAME" OnSelectedIndexChanged="Statusdll_SelectedIndexChanged" ondatabound="status_dll_DataBound" >
                                                                </asp:DropDownList>        
                                                               </div> 
                                                               <div class="col-md-5">
                                                               <label for="field-3"  class="control-label">Qeyd</label>                              
                                                    <asp:LinkButton ID="Save_status_btn" runat="server" 
                                                        CssClass="btn btn-primary waves-effect waves-light required form-control" 
                                                        ValidationGroup="OBJECT_ADD_EDIT" OnClick="Save_status_btn_Click" >Saxla</asp:LinkButton>
                                                        </div>
                                                        </div>
                                                                <div class="col-md-3"> 
                                                                <label for="field-3"  class="control-label">Qiymət</label> 
                                                              <asp:TextBox ID="price_edt" CssClass="required form-control" runat="server"  AutoPostBack="true" Enabled="false"></asp:TextBox>
                                                               </div>
                                                               <div class="col-md-3"> 
                                                                <label for="field-3"  class="control-label">Ümumi cəm</label> 
                                                              <asp:TextBox ID="Total_price" CssClass="required form-control" runat="server"  AutoPostBack="true" Enabled="false"></asp:TextBox>
                                                               </div>
                                                               <div class="col-md-2">
                                                                <label for="field-3"  class="control-label">Ödəniş forması</label> 
                                                              <asp:DropDownList ID="paytype_dll" runat="server" CssClass="form-control"  >
                                                               <asp:ListItem Text="Seçin:" Value="0"></asp:ListItem>
                                                                  <asp:ListItem Text="Kart" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Nəğd" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div> 
                                                                
                                                               
                                                                 <div class="col-md-2">
                                                                <label for="field-3"  class="control-label">Müştəri kartı</label> 
                                                              <asp:DropDownList ID="specialpayment_dll" runat="server" CssClass="form-control"  AutoPostBack="true" >
                                                               <asp:ListItem Text="Seçin:" Value="0"></asp:ListItem>
                                                                  <asp:ListItem Text="Var" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Yoxdur" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-2">
                                                               <label for="field-3"  class="control-label">Kartın kodu</label> 
                                                                <asp:TextBox ID="kardcode_edt" CssClass="required form-control"  runat="server" AutoPostBack="true" Enabled="false" ></asp:TextBox>
                                                               </div>
                                                         
                                                              <div class="col-md-2">
                                                               <label for="field-3"  class="control-label">Kartın balansı</label> 
                                                                <asp:TextBox ID="kardbalance_edt" CssClass="required form-control"  runat="server" AutoPostBack="true" Enabled="false" ></asp:TextBox>
                                                               </div>
                                                               <div class="col-md-2"> 
                                                                <label for="field-3"  class="control-label">İmtina səbəbləri</label> 
                                                                 <asp:SqlDataSource id="reject_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="reject_dll" runat="server" CssClass="form-control" DataSourceID="reject_dll_sql" DataValueField="ID" DataTextField="NAME"  ondatabound="reject_ddl_DataBound" >
                                                                </asp:DropDownList>
                                                               </div>
                                                                <div class="col-md-2">
                                                                <label for="field-3"  class="control-label">İmtina əlavə</label> 
                                                              <asp:TextBox ID="reject_edt" CssClass="required form-control" runat="server" ></asp:TextBox>
                                                               </div>
                                                               
                                                            
                                                        </div> 
                                                    </div> 
                                                 
                                                </div> 
                                                </div>
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">İmtina</button> 
                                                    <asp:LinkButton ID="Start_btn" runat="server" 
                                                        CssClass="btn btn-primary waves-effect waves-light" 
                                                        ValidationGroup="OBJECT_ADD_EDIT" OnClick="Start_btn_Click">Start</asp:LinkButton>
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

