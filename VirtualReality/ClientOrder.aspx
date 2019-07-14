<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientOrder.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="defaultinner" %>
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

    <link href="assets/plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"
        rel="stylesheet" type="text/css" />
    <script src="assets/js/jquery.maskedinput.js" type="text/javascript"></script>

    <script type="text/javascript">
        function mask() {
            $("#<% =PhoneNumber_edt.ClientID %>").mask("kkk kk kk");


            $.mask.definitions['9'] = '';
            $.mask.definitions['d'] = '[0-9]';

            //$('#datatablecards').dataTable();
        }

        $(document).ready(function () {
            init();
        });
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
								<h4 class="page-title">Sifariş</h4>
								<ol class="breadcrumb">

									<li>
										<a href="#">Sifariş</a>
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
                                                    <th width="2%">№</th>
                                                    <th>Müştəri</th>
                                                    <th>Əlaqə nömrəsi</th>
                                                    <th>Kateqoriya</th>
                                                    <th>Paket</th>
                                                    <th width="2%">Say</th>
                                                    <th>Sifariş tipi</th>
                                                    <th>Sifariş gÜnü</th>
                                                    <th>Sifariş saatı</th>
                                                    <th>İmtina səbəbi</th>
                                                    <th></th>
                                                    <th></th>
                                                </tr>
                                            </thead>

                                            <tbody>
                                                <asp:Repeater ID="ObjectsGrid" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="ObjectsGrid_ItemCommand" OnItemDataBound="ObjectsGrid_ItemDataBound">
                                                   <ItemTemplate>
                                                      <tr>
                                                         <td><%# Eval("ID") %></td>
                                                         <td><%# Eval("CLIENT_NAME")%></td>
                                                           <td><%# Eval("CLIENT_PHONE")%></td>
                                                         <td><%# Eval("CATEGORY")%></td>
                                                          <td><%# Eval("PACKAGES")%></td>
                                                         <td><%# Eval("DEVICE_CATEGORY_COUNT")%></td>
                                                         <td><%# Eval("OR_TYPE")%></td>
                                                         <td><%# Convert.ToDateTime(Eval("ORDER_DATE")).ToString("dd.MM.yyyy")%></td>
                                                         <td><%# Eval("TIME")%></td>
                                                         <td><%# Eval("REJECT")%></td>
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
                                                             <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Müştəri</label> 
                                                                 <asp:SqlDataSource id="client_ddl_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="client_ddl" runat="server" CssClass="form-control"   DataSourceID="client_ddl_sql" DataValueField="ID" DataTextField="NAME"  ondatabound="client_ddl_DataBound" OnSelectedIndexChanged="client_ddl_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                               </div>
                                                               <div class="col-md-6">
                                                               <label for="field-3"  class="control-label">Qeyri-müştəri</label> 
                                                                <asp:TextBox ID="client_txt" CssClass="required form-control" runat="server" ></asp:TextBox>
                                                                
                                                               </div>
                                                               <asp:UpdatePanel ID="as" runat="server"> 
                                                               <ContentTemplate>
                                                                  <div class="col-md-6"> 
                                                                 <div class="row">
                                                                  <div class="col-md-5">
                                                                <label for="field-3"   class="control-label">Növü</label> 
                                                                <asp:DropDownList ID="numberddl" runat="server" CssClass="required form-control" Width="100px">
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
                                                               <asp:TextBox ID="PhoneNumber_edt" runat="server" class="required form-control" MaxLength="7"></asp:TextBox>
                                                           
                                                               <asp:requiredfieldvalidator id="r1" runat="server" errormessage="" ForeColor="Purple" controltovalidate="PhoneNumber_edt" validationgroup="A"></asp:requiredfieldvalidator>

                                                                <asp:regularexpressionvalidator id="regular1" controltovalidate="PhoneNumber_edt" runat="server" ForeColor="Purple" errormessage="" BorderColor="Red" validationexpression="^\d+$" validationgroup="A"></asp:regularexpressionvalidator>


                                                                </div>
                                                               </div>
                                                               </div>
                                                                <div class="col-md-6"> 
                                                                <label for="field-4"  class="control-label">Sifariş forması</label> 
                                                              <asp:DropDownList ID="gender_ddl" runat="server" CssClass="form-control" >
                                                                  <asp:ListItem Text="Bron" Value="1"></asp:ListItem>
                                                                </asp:DropDownList>
                                                               </div>
                                                                  <div class="col-md-5"> 
                                                                <label for="field-3"  class="control-label">Kateqoriya</label> 
                                                            <asp:SqlDataSource id="device_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="device_dll" runat="server" CssClass="form-control" AutoPostBack="true"  DataSourceID="device_dll_sql" DataValueField="ID" DataTextField="NAME" OnSelectedIndexChanged="category_changed"  ondatabound="device_ddl_DataBound"  >
                                                                </asp:DropDownList>
                                   
                                                               </div> 
                                                                <div class="col-md-5"> 
                                                  <label for="field-3"  class="control-label">Paketlər</label> 
                                                  <asp:SqlDataSource id="package_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="packages_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="package_dll_sql" DataValueField="ID" DataTextField="NAME"  ondatabound="package_dll_DataBound" OnSelectedIndexChanged="packages_changed" >
                                                                </asp:DropDownList>
                                                               </div> 
                                                                <div class="col-md-2">
                                                                <label for="field-3"  class="control-label">Sayı</label> 
                                                              <asp:TextBox ID="cetegory_count" runat="server" CssClass="form-control" ></asp:TextBox>
                                                              
                                                            </div>
                                                           
                                                                </ContentTemplate></asp:UpdatePanel>
                                                                 
                                                              <div class="col-md-4"> 
                                                                <label for="field-4"  class="control-label">Sifariş vaxtı</label> 
			                                				
                                                                <asp:TextBox ID="orderdate_edt" CssClass="required form-control" TextMode="Date" runat="server" ></asp:TextBox>
                                                               
                                                               </div>
                                                               <div class="col-md-4">  
                                                               <label for="field-3"  class="control-label">Saat</label> 
                                                               <div class="row">
                                                                  <div class="col-md-6">
                                                                  <asp:DropDownList ID="hour_ddl" runat="server" CssClass="form-control" >
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
                                                                  <asp:DropDownList ID="minutes_ddl" runat="server" CssClass="form-control" >
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
                                                                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                                                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                                                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                                                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                                                    <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                                                    <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                                                    <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                                                    <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                                                    <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                                                    <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                                                    <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                                                    <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                                                    <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                                                    <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                                                    <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                                                    <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                                    <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                                                    <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                                                    <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                                                    <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                                    <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                                                    <asp:ListItem Text="52" Value="52"></asp:ListItem>
                                                                    <asp:ListItem Text="53" Value="53"></asp:ListItem>
                                                                    <asp:ListItem Text="54" Value="54"></asp:ListItem>
                                                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                                                    <asp:ListItem Text="56" Value="56"></asp:ListItem>
                                                                    <asp:ListItem Text="57" Value="57"></asp:ListItem>
                                                                    <asp:ListItem Text="58" Value="58"></asp:ListItem>
                                                                    <asp:ListItem Text="59" Value="59"></asp:ListItem>
                                                                    <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                                                  </asp:DropDownList>
                                                                  </div>
                                                                  </div>

                                                               </div> 
                                                                <div class="col-md-4"> 
                                                                <label for="field-3"  class="control-label">İmtina səbəbləri</label> 
                                                                 <asp:SqlDataSource id="reject_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="reject_dll" runat="server" CssClass="form-control" DataSourceID="reject_dll_sql" DataValueField="ID" DataTextField="NAME"  ondatabound="reject_ddl_DataBound" >
                                                                </asp:DropDownList>
                                                               </div>
                                                                <div class="col-md-12">
                                                                <label for="field-3"  class="control-label">İmtina səbəbi qeyd</label> 
                                                              <asp:TextBox ID="reject_edt" CssClass="required form-control" runat="server" ></asp:TextBox>
                                                               </div>
                                                              </div>
                                                    </div> 
                                                 
                                                </div> 
                                                </div>
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect btn-danger" data-dismiss="modal">İmtina</button> 
                                   
                                                         <asp:Button ID="Save_btn" runat="server" Text="Submit" CssClass="btn btn-primary waves-effect waves-light" UseSubmitBehavior="false" OnClick="Save_btn_Click" OnClientClick="this.disabled='true'; this.value='Please wait...';"  />
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
    <script src="assets/js/jquery.maskedinput.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/multiselect/js/jquery.multi-select.js"></script>
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


    <script src="assets/plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"
        type="text/javascript"></script>
     <script>
         jQuery(document).ready(function () {

             // 
                
                // Date Picker
                jQuery('.datepicker').datepicker();
                jQuery('.datepicker-autoclose').datepicker({
                	autoclose: true,
                	todayHighlight: true
                });
                jQuery('.datepicker-inline').datepicker();
                jQuery('.datepicker-multiple-date').datepicker({
                    format: "dd/MM/yyyy",
					clearBtn: true,
					multidate: true,
					multidateSeparator: ","
                });
                 jQuery('.date-range').datepicker({
                    toggleActive: true
                });
                //Date range picker
				jQuery('.input-daterange-datepicker').daterangepicker({
					buttonClasses: ['btn', 'btn-sm'],
		            applyClass: 'btn-default',
		            cancelClass: 'btn-white'
				});
                 jQuery('.input-limit-datepicker').daterangepicker({
		            format: 'MM/DD/YYYY',
		            minDate: '06/01/2015',
		            maxDate: '06/30/2015',
		            buttonClasses: ['btn', 'btn-sm'],
		            applyClass: 'btn-default',
		            cancelClass: 'btn-white',
		            dateLimit: {
		                days: 6
		            }
		        });
		

             }, function (start, end, label) {
                 console.log(start.toISOString(), end.toISOString(), label);
                 jQuery('.reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
             });

         });
		</script>



</asp:Content>

