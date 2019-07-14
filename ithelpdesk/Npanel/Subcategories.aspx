<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Subcategories.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Subcategories" %>

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
								<h4 class="page-title">Subkategoriyalar</h4>
								<ol class="breadcrumb">
									<li>
										<a href="#">Kategoriya</a>
									</li>
									<li class="active">
										SubKategoriya
									</li>
								</ol>
							</div>
						</div>

                       <div class="row">
                           <div class="col-sm-2">
                               <a class="btn btn-primary waves-effect waves-light" data-toggle="modal" data-target="#subcategory-modal" onclick="javascript:editing('-1');"><i class="md md-add"></i> Əlavə et</a>
                           </div>
                        </div>
                             <br />
                               <div class="row">
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                       <ContentTemplate>
                                    <asp:SqlDataSource ID="subcategory_sql" runat="server"></asp:SqlDataSource>
                                    <table id="datatable" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="width:2%">№</th>
                                                    <th>Category</th>
                                                    <th>Subcategory</th>
                                                    <th>Alt kategoriya</th>
                                                    <th>Подкатегория</th>
                                                    <th>Qiymət</th>
                                                    <th style="width:2%"></th>
                                                    <th style="width:2%"></th>
                                                   
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="subcategory_sql" OnItemCommand="ObjectsGrid_ItemCommand" OnItemDataBound="ObjectsGrid_ItemDataBound">
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("CATEGORY") %></td>
                                                         <td><%# Eval("EN_NAME") %></td>
                                                         <td><%# Eval("AZ_NAME") %></td>
                                                         <td><%# Eval("RU_NAME") %></td>
                                                         <td><%# Eval("PRICE") %></td>
                                                        <td align="center">
                                                            <a href="#" class="table-action-btn" data-toggle="modal" data-target="#subcategory-modal"
                                                               onclick="javascript:editing('<%# Eval("ID") %>');">
                                                               <i class="md md-edit"></i></a>
                                                         </td>
                                                         <td align="center">
                                                             <asp:LinkButton ID="Delete_btn" runat="server" CssClass="table-action-btn" CommandArgument='<%# Eval("ID") %>' CommandName="DELETE_subcategory"><i class="md md-delete"></i></asp:LinkButton>
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
    <div id="subcategory-modal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
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
                                                    <div class ="col-sm-6">
                                                    <div class="form-group">
                                                    <label for="field-3" class="control-label">Kategoriyanın adı</label> 
                                                    <asp:SqlDataSource ID="category_sql" runat="server" ></asp:SqlDataSource>
                                                    <asp:DropDownList ID="category_ddl"  runat="server" DataSourceID="category_sql" DataTextField="NAME" CssClass="form-control" DataValueField="ID" OnDataBound="category_DataBound"></asp:DropDownList>
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator22" runat="server" errormessage="Kateqoriya seçin" controltovalidate="category_ddl" ValidationGroup="OBJECT_ADD_EDIT"   Display="Dynamic" initialvalue="0" ></asp:requiredfieldvalidator>
                                                    </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                              <label for="field-3" class="control-label">Qiymət</label> 
                                                                <asp:TextBox ID="price_edt" runat="server" CssClass="form-control" placeholder=" Qiymət  daxil edin.."></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="price_edt" Display="Dynamic" ValidationGroup="OBJECT_ADD_EDIT"></asp:RequiredFieldValidator>
                                                           </div>
                                                             <div class="col-sm-2">              
                                    <label for="field-3"  class="control-label">Valyuta</label> 
                                    <asp:SqlDataSource id="SqlDataSource4" runat ="server"></asp:SqlDataSource>
                                    <asp:DropDownList ID="valyuta_ddl" runat="server" CssClass="form-control" DataSourceID="SqlDataSource4" DataValueField="ID" DataTextField="NAME" OnDataBound="valyuta_ddl_DataBound"></asp:DropDownList>                             
                                                </div>
                                                    </div>
                                                       <div class="col-md-12">
                                                    <div class="form-group">

                                                    <div class="col-sm-4">
                                                              <label for="field-3" class="control-label">AZ Name</label> 
                                                                <asp:TextBox ID="sub_category_az_edt" runat="server" CssClass="form-control" placeholder="Alt kategoriyanın adını daxil edin.."></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="sub_category_az_edt" Display="Dynamic" ValidationGroup="OBJECT_ADD_EDIT"></asp:RequiredFieldValidator>
                                                           </div>

                                                    <div class="col-sm-4">
                                                              <label for="field-3" class="control-label">EN Name</label> 
                                                                <asp:TextBox ID="sub_category_en_edt" runat="server" CssClass="form-control" placeholder="Add subcategory name.."></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="sub_category_en_edt" Display="Dynamic" ValidationGroup="OBJECT_ADD_EDIT"></asp:RequiredFieldValidator>
                                                           </div>

                                                    <div class="col-sm-4">
                                                              <label for="field-3" class="control-label">RU Name</label> 
                                                                <asp:TextBox ID="sub_category_ru_edt" runat="server" CssClass="form-control" placeholder="Добавить название подкатегория.."></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="sub_category_ru_edt" Display="Dynamic" ValidationGroup="OBJECT_ADD_EDIT"></asp:RequiredFieldValidator>
                                                           </div>
                                                    </div>
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


