<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Createorder.aspx.cs" Inherits="Createorder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/plugins/custombox/dist/custombox.min.css" rel="stylesheet">

<!-- DataTables -->
<link href="assets/plugins/datatables/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />

<lin<link href="assets/plugins/timepicker/bootstrap-timepicker.min.css" rel="stylesheet">
		<link href="assets/plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet">
		<link href="assets/plugins/clockpicker/dist/jquery-clockpicker.min.css" rel="stylesheet">

        <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />


<!-- Validator -->
<link href="assets/plugins/bootstrapvalidator/src/css/bootstrapValidator.css" rel="stylesheet" type="text/css" />

<script language="javascript">

    function add_item(Value,  Subcategory_id, Point) {

        document.getElementById('<% =Value_hf.ClientID%>').value = Value;
        document.getElementById('<% =price_hf.ClientID%>').value = Point;
     
        document.getElementById('<% =subcategory_id.ClientID%>').value = Subcategory_id;
        __doPostBack('<% =Add_items_btn.UniqueID%>', '');


    }

    function reset() {
      
        document.getElementById('<%= subject_txt.ClientID %>').value = "";
        document.getElementById('<%=Deadline_edt.ClientID %>').value = "";
     
        document.getElementById('<%=total_lbl.ClientID %>').value = "0";
        document.getElementById('<%=Selected_lbx.ClientID %>').options.length = 0;
    }

    function Teamviwer_code() {
        if (document.getElementById('<%=teamviewer_code_edt.ClientID %>').value.length > 0 && document.getElementById('<%=Temviewer_login_edt.ClientID %>').value.length > 0) {

            document.getElementById('<%=Login_teamviewer_txt.ClientID %>').value = document.getElementById('<%=Temviewer_login_edt.ClientID %>').value;
            document.getElementById('<%=Teamviwer_txt.ClientID %>').value = document.getElementById('<%=teamviewer_code_edt.ClientID %>').value;
            $('#teamviewer-modal').modal('hide');
        }
    }

    function show_modal() {
        $('#teamviewer-modal').modal('show');
    }


 
</script>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <!-- Page-Title -->
						<div class="row">
							<div class="col-sm-12">
								<h4 class="page-title"><% =HelpFunctions.Translate("createorder_create_order") %></h4>
								<ol class="breadcrumb">
									<li>
										<a href="#"><%= HelpFunctions.Translate("createorder_order") %></a>
									</li>
									<li class="active">
										<%= HelpFunctions.Translate("createorder_create_order") %>
									</li>
								</ol>
							</div>
						</div>

              
                             <br />
                               <div class="row">
                            <div class="col-sm-12 form-group">
                                <div class="card-box table-responsive">
                                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                  <ContentTemplate>
                                  <asp:HiddenField ID="text_hf" runat="server" />
                                  <asp:HiddenField ID="Value_hf" runat="server" />
                                  <asp:HiddenField ID="price_hf" runat="server" />
                                    <asp:HiddenField ID="price_valyuta_hf" runat="server" />
                                  <asp:HiddenField ID="category_id" runat="server" />
                                   <asp:HiddenField ID="subcategory_id" runat="server" />
                                   <asp:Literal runat="server" ID="Max_point" Visible="false"></asp:Literal>
                                  <asp:Literal runat="server" ID="User_Package_id_txt" Visible="false"></asp:Literal>
                                 <div class="row">
                                 <div class="col-sm-12 form-group">
                                 <div class="panel panel-primary">
                                            <div class="panel-body"  style="max-height:250px;overflow-y: scroll;">
                                 <div class="col-sm-4">
                                  <label for="field-3" class="control-label">    <%= HelpFunctions.Translate("createorder_name")%></label> 
                                  <div class="row">
                                     <asp:Repeater ID="Repeater1" runat="server" DataSourceID="subcategory_sql">
                                  <ItemTemplate>
                                  <div class="col-sm-12">
                                   <asp:Literal ><%#Eval("NAME") %></asp:Literal>
                                   <hr />
                                </div>
                                  </ItemTemplate></asp:Repeater>
                                 </div>
                                 </div>
                                 
                                               <div class="col-sm-2">
                                  <label for="field-3" class="control-label">Point</label> 
                                  <div class="row">
                                  <asp:Repeater ID="Repeater3" runat="server" DataSourceID="subcategory_sql">
                                  <ItemTemplate>
                                    <div class="col-sm-12">
                                <asp:label  ><%#Eval("POINT") %></asp:label>
                                <hr />
                                
                                  </div>
                                  
                                  </ItemTemplate></asp:Repeater>
                                     
                                    
                                    
                                 </div>
                                 </div>
                                   <div class="col-sm-4">
                                  <label for="field-3" class="control-label"><%= HelpFunctions.Translate("createorder_check")%></label> 
                                   <div class="row">
                                  <div class="col-sm-12">
                                     <asp:Repeater ID="Repeater2" runat="server" DataSourceID="subcategory_sql" OnItemDataBound="subcategory_databound" >
                                  <ItemTemplate>
                                    <div class="col-sm-12">
                                    <asp:HiddenField ID="check_hf" runat="server" Value='<%# Eval("ID") %>' />
                                    <a  class="table-action-btn"
                                                               onclick="javascript:add_item('<%# Eval("NAME") %>','<%# Eval("ID") %>','<%# Eval("POINT") %>');">
                                                              <asp:CheckBox  runat="server" ID="Check_chk" Height="100%" OnCheckedChanged="Check_check"  /></a>
                                                               <hr />
                                  </div>
                                 
                                  </ItemTemplate></asp:Repeater>
                                    <asp:SqlDataSource ID="subcategory_sql" runat="server"></asp:SqlDataSource>
                                                                        </div>
                                 </div>

                               </div>
                                <div class="col-sm-1">
                                  <label for="field-3" class="control-label">Reset</label>  
                                  <asp:LinkButton class="btn btn-icon waves-effect waves-light btn-primary form-control"  runat="server" ID="reset_btn" OnClientClick="reset()" OnClick="reset"  > <i class="ion-refresh" style="padding:3px;"></i></asp:LinkButton>
                                  </div>
                                    <div class="col-sm-1">
                                    <br />
                                                     <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                                        <ProgressTemplate>
                                           <img src="assets/images/preloader.gif" />
                                        </ProgressTemplate>
                                     </asp:UpdateProgress> 
                                     </div>
                               </div>
                               </div>
                               </div>
                               </div>

                               <br />

                               <div class="row">
                                 <div class="col-sm-12 form-group">

                                 <div class="col-sm-4">
                                 <div class="col-sm-12">
                                   <label for="field-3" class="control-label"><%= HelpFunctions.Translate("createorder_selected_services")%></label> 

                                   <asp:ListBox runat="server" ID="Selected_lbx" ClientIDMode="Static" Width="100%" Height="150px" class="form-control"></asp:ListBox>
                                 </div>
                                 <br />
                                 <div class="col-sm-6" style="text-align:center;">
                              <h3 runat="server" id="Total_text_lbl" style="text-align :left;" ><%= HelpFunctions.Translate("createorder_total")%> <asp:Label  Font-Bold="true" Font-Italic  Font-Underline="true" Height="30px" style="text-align:right"    runat="server" ID="total_lbl">0</asp:Label></h3>
                              <br />
                                  
          
                                 </div>
                                 <br />
                                    <div class="col-sm-12">
                       
                                  <div class="col-sm-6">
                                                         

                                                   




                        <br />
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                                        <ProgressTemplate>
                                           <img src="assets/images/preloader.gif" />
                                        </ProgressTemplate>
                                     </asp:UpdateProgress>  
                                  </div>
                                  </div>
                                 </div>

                                   <div class="col-sm-8">
                                  <div class="col-sm-12">
                                  <div class="col-sm-6">
                                   <label for="field-3" class="control-label"><%= HelpFunctions.Translate("createorder_subject")%></label> 
                                   <input type="text" class="form-control" maxlength="25" name="alloptions"  runat="server" id="subject_txt"  ClientIDMode="Static" />
                                  </div>
                                  <div class="col-sm-6">
                                   <label for="field-3" class="control-label"><%= HelpFunctions.Translate("createorder_time_to_connect")%></label>
                                   <div class="row">
                                   <div class="col-sm-12">
                                    <div class="input-group">
                                 <asp:TextBox ID="Deadline_edt" runat="server"     CssClass="form-control" data-provide="datepicker" ></asp:TextBox>
                                 <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                 </div>
                                 </div>
                                 
 </div> 
                                  </div>
                       
                                    <div class="col-sm-12">
                                   <label for="field-3" class="control-label"><%= HelpFunctions.Translate("createorder_description")%></label> 
                                   <asp:TextBox runat="server" ID="Description_txt" MaxLength="299"  TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                                  </div>
                                      <div class="col-sm-6">
                                  <label for="field-3" class="control-label">Teamviewer Login</label>  
                                   <asp:TextBox ID="Login_teamviewer_txt" Enabled="false" runat="server" CssClass="form-control" placeholder="Teamviewer Code"></asp:TextBox>
                                  </div>
        
                                  <div class="col-sm-6">
                                  <label for="field-3" class="control-label">Teamviewer Code</label>  
                                   <asp:TextBox ID="Teamviwer_txt" Enabled="false" runat="server" CssClass="form-control" placeholder="Teamviewer Code"></asp:TextBox>
                                  </div>
                                  <div class="col-sm-4" style="float:right;">
                                           <asp:LinkButton ID="LinkButton1" runat="server"  style="margin-top:35px;"
                                                        CssClass="btn btn-primary waves-effect waves-light" Width="100%"  OnClick="Pay_btn_click" OnClientClick="this.disabled='true'; this.value='Please wait...';"
                                                         ><%= HelpFunctions.Translate("createorder_pay")%></asp:LinkButton>
                                                         </div>
                                  </div>
                                 </div>
                                 </div>
                                 </div>
                                   <asp:LinkButton ID="Add_items_btn" runat="server" onclick="Add_items_btn_Click"></asp:LinkButton>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                </div>
                              
                            </div>
                        </div>
    


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
     <!-- Modal -->
    <div id="category-modal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
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

                                                           </div>
                                                    </div> 

                                                </div>
                                                </div>
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect btn-danger" data-dismiss="modal">İmtina</button> 
                                                    <asp:Button ID="Save_btn" runat="server" 
                                                        CssClass="btn btn-primary waves-effect waves-light" 
                                                        ValidationGroup="OBJECT_ADD_EDIT" Text="Saxla"   OnClientClick="this.disabled='true'; this.value='Please wait...';" UseSubmitBehavior="false"/>
                                                </div>
                                                </div>
                                            </div> 
                                        </div>
                                        
                                           </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                     <div id="teamviewer-modal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                           <ContentTemplate>
                                               <asp:HiddenField ID="HiddenField1" runat="server" />
                                           <div class="modal-dialog modal-lg"> 
                                            <div class="modal-content"> 
                                                <div class="modal-header"> 
                                                    <h4 class="modal-title">
                                                        <asp:Literal ID="Literal1" runat="server">Əlavə et</asp:Literal></h4> 
                                                </div> 
                                                <div class="modal-body"> 
                                                    <div class="row"> 
                                                        <div class="col-md-12"> 
                                                            <div class="form-group">

                                                             <div class="col-sm-12">
                                                              <label for="field-3" class="control-label">Teamviewer download tutorial:</label>
                                                              </div> 
                                                              <div class="col-sm-12">
                                                                &nbsp;&nbsp; <iframe src="https://www.youtube.com/embed/8roSsCjxiwQ" frameborder="0" allowfullscreen style="height: 315px; width: 800px" id="I1" name="I1">&nbsp;</iframe>
                                                           </div>
                                                           <br />
                                                           <br />
                                                             <div class="col-sm-12">
                                                   
                                                                <a href="https://www.teamviewer.com/en/?pid=google.tv.teamviewer_download.s.int&gclid=Cj0KCQjwjpjkBRDRARIsAKv-0O1Krus8TxSplwu-qyz4tz3fsuPr3RIna8CPpgmZ63FMzfxydOn6eF0aAsb5EALw_wcB" target="_blank"> Teamviewer download link</a>
                                                           </div>
                                                           <br />
                                                           <br />
                                                            <div class="col-sm-6">
                                                              <label for="field-3" class="control-label">Teamviewer login</label> 
                                                                <asp:TextBox ID="Temviewer_login_edt" runat="server" CssClass="form-control" placeholder="Teamviewer Code"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="Temviewer_login_edt" Display="Dynamic" ValidationGroup="Teamviewer_obj"></asp:RequiredFieldValidator>
                                                           </div>
                                                             <div class="col-sm-6">
                                                              <label for="field-3" class="control-label">Teamviewer Code</label> 
                                                                <asp:TextBox ID="teamviewer_code_edt" runat="server" CssClass="form-control" placeholder="Teamviewer Code"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="teamviewer_code_edt" Display="Dynamic" ValidationGroup="Teamviewer_obj"></asp:RequiredFieldValidator>
                                                           </div>
                                                           </div>
                                                    </div> 

                                                </div>
                                                </div>
                                                <div class="modal-footer">

                                              
                                                    
                                                            <asp:LinkButton ID="LinkButton2" runat="server"  style="margin-top:35px;"
                                                        CssClass="btn btn-primary waves-effect waves-light" ValidationGroup="Teamviewer_obj" Width="100px"   OnClientClick="Teamviwer_code()"
                                                         >Save</asp:LinkButton>
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

<!-- DataPicker-->
<!--------------------------------------------------------------------------------------------------------------->
<script src="assets/plugins/moment/moment.js"></script>
<script src="assets/plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>

<script src="assets/plugins/timepicker/bootstrap-timepicker.min.js"></script>
<script src="assets/plugins/mjolnic-bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"></script>
<script src="assets/plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
<script src="assets/plugins/clockpicker/dist/jquery-clockpicker.min.js"></script>
<script src="assets/plugins/bootstrap-daterangepicker/daterangepicker.js"></script>
     <script src="assets/plugins/bootstrap-maxlength/bootstrap-maxlength.min.js" type="text/javascript"></script>

<script type="text/javascript">

    function init() {
    if(document.getElementById('<%= Login_teamviewer_txt.ClientID  %>').value.length<1)
        show_modal();

        jQuery('#<% =Deadline_edt.ClientID %>').datepicker({
            autoclose: true,
            todayHighlight: true
        });

        $('input#subject_txt').maxlength({
            alwaysShow: true,
            warningClass: "label label-success",
//            limitReachedClass: "label label-danger",
//            separator: ' out of ',
//            preText: 'You typed ',
//            postText: ' chars available.',
            validate: true
        });


        //Clock Picker
        $('.clockpicker').clockpicker({
            donetext: 'Done'
        });

        $('#single-input').clockpicker({
            placement: 'bottom',
            align: 'left',
            autoclose: true,
            'default': 'now'
        });
        $('#check-minutes').click(function (e) {
            // Have to stop propagation here
            e.stopPropagation();
            $("#single-input").clockpicker('show')
				            .clockpicker('toggleView', 'minutes');
        });

     

    }

    $(document).ready(function () {
        init();
    });

</script>

 <script>
     jQuery(document).ready(function () {


  


       

       
       

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
