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
        __doPostBack('<% =LoadInfo_btn.UniqueID%>', '');
    }

    function edit_client(id,tran_id) {
        document.getElementById('<% =ClientID_hf.ClientID%>').value = id;
        document.getElementById('<% =ObjectID_hf.ClientID%>').value = tran_id;
        __doPostBack('<% =LoadClientInfo_btn.UniqueID%>', '');
    }
</script>


  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <!-- Page-Title -->
						<div class="row">
							<div class="col-sm-12">
								<h4 class="page-title">Заказы</h4>
								<ol class="breadcrumb">
									<li class="active">
										Заказы
									</li>
								</ol>
							</div>
						</div>

                       <div class="row">
                           <div class="col-sm-2">
                               <a class="btn btn-primary waves-effect waves-light" data-toggle="modal" data-target="#con-close-modal" onclick="javascript:editing('-1');"><i class="md md-add"></i> Добавить</a>
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
                                                    <th>КЛИЕНТ</th>
                                                    <th>НАЧАЛО</th>
                                                    <th>КОНЕЦ</th>
                                                    <th>СТАТУС</th>
                                                    <th>ЦЕНА</th>
                                                    <th>РАБОТНИК</th>
                                                    <th>ТАЙМЕР</th>
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
                                                         <td><%# Eval("CLIENT_NAME")%></td>
                                                         <td><%# Convert.ToDateTime(Eval("BEGIN_TIME")).ToString("dd.MM.yyyy HH:mm") %></td>
                                                         <td><%# Convert.ToDateTime(Eval("END_TIME")).ToString("dd.MM.yyyy HH:mm")%></td>
                                                         <td><%# Eval("STATUS_NAME")%></td>
                                                         <td><%# Eval("PRICE")%></td>
                                                         <td><%# Eval("NAME")%></td>
                                                         <td>   <div class="timer" data-seconds-left="<%# Eval("DateDif")%>"></div></td>
                                                         <td align="center">
                                                             <a href="#" class="table-action-btn" data-toggle="modal" data-target="#client_div"
                                                               onclick="javascript:edit_client('<%# Eval("CLIENT_ID").ToString() == "0" ? "-1" : Eval("CLIENT_ID").ToString() %>','<%# Eval("ID") %>');">
                                                               <i class="md  md-accessibility"></i></a>
                                                         </td>
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
                                         <asp:LinkButton ID="LoadClientInfo_btn" runat="server" onclick="LoadClientInfo_btn_Click"></asp:LinkButton>
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
                                                        <asp:Literal ID="ModalCaption_lb" runat="server">Создание</asp:Literal></h4> 
                                                </div> 
                                                <div class="modal-body"> 
                                                    <div class="row"> 
                                                        <div class="col-md-12"> 
                                                            <div class="form-group">
                                                            <div class="col-md-3"> 
                                                             <asp:SqlDataSource id="client_dll_sql" runat ="server"></asp:SqlDataSource>
                                                                <label for="field-3"  class="control-label">Клиент</label> 
                                                              <asp:DropDownList ID="client_ddl" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="client_dll_sql" DataValueField="ID" DataTextField="FIO" OnSelectedIndexChanged="Clientdd_SelectedIndexChanged" ondatabound="client_ddl_DataBound" >
                                                                </asp:DropDownList>
                                                               </div>
                                                               <div class="col-md-3">
                                                               <label for="field-3"  class="control-label">Новый клиент</label> 
                                                                <asp:TextBox ID="client_txt" CssClass="required form-control" runat="server" placeholder="Не клиент" ></asp:TextBox>
                                                               </div>
                                                              <div class="col-md-3"> 
                                                                <label for="field-4"  class="control-label">Начало</label> 
			                                				<asp:TextBox ID="begindate_edt" CssClass="required form-control" TextMode="DateTime" runat="server"  AutoPostBack="true" Enabled="false" ></asp:TextBox>
                                                               </div>
                                                                <div class="col-md-3">  
                                                               <label for="field-3"  class="control-label">Конец</label> 
                                                           	<asp:TextBox ID="enddate_edt" CssClass="required form-control" TextMode="DateTime" runat="server"  AutoPostBack="true" Enabled="false" ></asp:TextBox>
                                                               </div> 
                                                                <div class="col-md-4"> 
                                                  <label for="field-3"  class="control-label">Категория аппарата</label> 
                                                  <asp:SqlDataSource id="category_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="category_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="category_dll_sql" DataValueField="ID" DataTextField="NAME" OnSelectedIndexChanged="Category_SelectedIndexChanged" ondatabound="category_dll_DataBound" >
                                                                </asp:DropDownList> 
                                                                
                                                               </div> 
                                                               <div class="col-md-4">
                                                                <div class="col-md-8"> 
                                                  <label for="field-3"  class="control-label">Пакеты</label> 
                                                  <asp:SqlDataSource id="package_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="packages_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="package_dll_sql" DataValueField="ID" DataTextField="NAME" OnSelectedIndexChanged="Packagedll_SelectedIndexChanged" ondatabound="package_dll_DataBound" >
                                                                </asp:DropDownList>
                                                               </div>
                                                                <div class="col-md-4"> 
                                                                <label for="field-4"  class="control-label">Период(мин)</label> 
                                                                <asp:TextBox ID="time_edt" CssClass="required form-control" runat="server" Enabled="false"></asp:TextBox>
                                                               </div> 
                                                               </div>
                                                                <div class="col-md-4"> 
                                                  <label for="field-3"  class="control-label">Аппараты</label> 
                                                  <asp:SqlDataSource id="devices_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="device_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="devices_dll_sql" DataValueField="ID" DataTextField="NAME"  ondatabound="device_dll_DataBound" OnSelectedIndexChanged="device_chg" >
                                                                </asp:DropDownList>        
                                                               </div> 
                                                               <div class="col-md-3"> 
                                                  <label for="field-3"  class="control-label">Игры</label> 
                                                  <asp:SqlDataSource id="game_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="game_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="game_dll_sql" DataValueField="ID" DataTextField="NAME" OnSelectedIndexChanged="Gamesdll_SelectedIndexChanged" ondatabound="game_dll_DataBound" >
                                                                </asp:DropDownList>        
                                                               </div> 
                                                                <div class="col-md-3">
                                                                <label for="field-3"  class="control-label">Таблица игр</label> 
                                                              <asp:Listbox ID="games_lstbx" runat="server" CssClass="form-control" SelectionMode="Multiple" Width="250px" Height="60px" OnTextChanged="remove_game_text" AutoPostBack="true"></asp:Listbox>
                                                            </div>
                                                            <div class="col-md-2"> 
                                                                <label for="field-4"  class="control-label">Кол-во</label> 
                                                                <asp:TextBox ID="count_edt" CssClass="required form-control" runat="server" TextMode="Number" ></asp:TextBox>
                                                               
                                                            </div>
                                                               </div>
                                                               <div class="col-md-4"> 
                                                  <label for="field-3"  class="control-label">Статус</label> 
                                                  <asp:SqlDataSource id="status_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="status_dll" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="status_dll_sql" DataValueField="ID" DataTextField="NAME" OnSelectedIndexChanged="Statusdll_SelectedIndexChanged" ondatabound="status_dll_DataBound" >
                                                                </asp:DropDownList>        
                                                               </div> 
                                                                <div class="col-md-2"> 
                                                                <label for="field-3"  class="control-label">Цена</label> 
                                                              <asp:TextBox ID="price_edt" CssClass="required form-control" runat="server"  AutoPostBack="true" Enabled="false"></asp:TextBox>
                                                               </div>
                                                               <div class="col-md-2"> 
                                                                <label for="field-3"  class="control-label">Общая цена</label> 
                                                              <asp:TextBox ID="Total_price" CssClass="required form-control" runat="server"  AutoPostBack="true" Enabled="false"></asp:TextBox>
                                                               </div>
                                                                <div class="col-md-2"> 
                                                                <label for="field-3"  class="control-label">Баланс клиент</label> 
                                                              <asp:TextBox ID="payed_balane" CssClass="required form-control" runat="server" TextMode="Number"  AutoPostBack="true" Enabled="false" OnTextChanged="payed_balane_textchanged"></asp:TextBox>
                                                               </div>
                                                               <div class="col-md-2">
                                                                <label for="field-3"  class="control-label">Тип оплаты</label> 
                                                              <asp:DropDownList ID="paytype_dll" runat="server" CssClass="form-control"  >
                                                               <asp:ListItem Text="Выберите" Value="0"></asp:ListItem>
                                                                  <asp:ListItem Text="Карта" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Наличные" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div> 
                                                                  <div class="col-md-2"> 
                                                                <label for="field-3"  class="control-label">Сотрудник</label> 
                                                                 <asp:SqlDataSource id="worker_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="worker_dll" runat="server" CssClass="form-control" DataSourceID="worker_dll_sql" DataValueField="ID" DataTextField="NAME"  ondatabound="worker_ddl_DataBound" >
                                                                </asp:DropDownList>
                                                               </div>
                                                               <div class="col-md-2"> 
                                                                <label for="field-3"  class="control-label">Карта</label> 
                                                              <asp:TextBox ID="CardCode_edt" CssClass="required form-control" runat="server" ></asp:TextBox>
                                                               </div>
                                                               <div class="col-md-2"> 
                                                                <label for="field-3"  class="control-label">Причина отказа</label> 
                                                                 <asp:SqlDataSource id="reject_dll_sql" runat ="server"></asp:SqlDataSource>
                                                              <asp:DropDownList ID="reject_dll" runat="server" AutoPostBack="true" CssClass="form-control" DataSourceID="reject_dll_sql" DataValueField="ID" DataTextField="NAME"  ondatabound="reject_ddl_DataBound" Enabled="false" OnSelectedIndexChanged="reject_chg"  >
                                                                </asp:DropDownList>
                                                               </div>
                                                                <div class="col-md-4">
                                                                <label for="field-3"  class="control-label">Отказ описание</label> 
                                                              <asp:TextBox ID="reject_edt" CssClass="required form-control" runat="server" placeholder="Введите причину отказа" Enabled="false" ></asp:TextBox>
                                                               </div>
                                                        </div> 
                                                    </div> 
                                                 
                                             
                                                </div>
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect btn-danger" data-dismiss="modal">Отмена</button> 
                                                    <asp:LinkButton ID="Start_btn" runat="server" Text="Сохранить" CssClass="btn btn-primary waves-effect waves-light" UseSubmitBehavior="false" OnClick="Start_btn_Click" OnClientClick="this.disabled='true'; this.value='Ждите...';"  />
                                                </div>
                                                </div>
                                            </div> 
                                           </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
    <!-- /.modal -->

     <!-- Modal -->
    <div id="client_div" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                           <ContentTemplate>
                                               <asp:HiddenField ID="ClientID_hf" runat="server" />
                                           <div class="modal-dialog"> 
                                            <div class="modal-content"> 
                                                <div class="modal-header"> 
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" id="Button1">×</button> 
                                                </div> 
                                                <div class="modal-body"> 
                                                    <div class="row"> 
                                                        <div class="col-md-12"> 
                                                            <div class="form-group">
                                                             <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Имя</label> 
                                                                <asp:TextBox ID="client_name_edt" runat="server" CssClass="form-control"></asp:TextBox>
                                                                
                                                               </div>
                                                                <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Фамилия</label> 
                                                                <asp:TextBox ID="client_surname_edt" runat="server" CssClass="form-control"></asp:TextBox>
                                                                 
                                                               </div>
                                                                  <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Пол</label> 
                                                              <asp:DropDownList ID="gender_ddl" runat="server" CssClass="form-control" >
                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                  <asp:ListItem Text="Мужчина" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Женщина" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                               
                                                                 </div>
                                                                <div class="col-md-6"> 
                                                                 <div class="row">
                                                                  <div class="col-md-5">
                                                                <label for="field-3"   class="control-label"></label> 
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
                                                             <label for="field-3"   class="control-label">Номер телефона</label> 
                                                               <asp:TextBox ID="PhoneNumber_edt" runat="server" class="required form-control"  maxlength="7"></asp:TextBox>
                                                               &nbsp &nbsp &nbsp &nbsp
                                                            </div>
                                                               </div>
                                                               </div>
                                                                <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Дата рождения</label> 
                                                                <asp:TextBox ID="birthday_txt" runat="server"  CssClass="required form-control" TextMode="Date"  ></asp:TextBox>
                                                               </div> 
                                                               <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Период рождения</label> 
                                                                <asp:DropDownList ID="age_ddl" runat="server" CssClass="required form-control" >
                                                                    <asp:ListItem Text="Выберите" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="10-18" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="18-25" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="25-40" Value="3"></asp:ListItem>
                                                                </asp:DropDownList> 
                                                               </div>
                                                               
                                                                <div class="col-md-12"> 
                                                                <label for="field-3"  class="control-label">Источник</label> 
                                                                 <div class="row">
                                                                  <div class="col-md-3">
                                                                <asp:DropDownList ID="source_type" runat="server"   CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="source_type_changed"  >
                                                                     <asp:ListItem Text="Выберите" Value="0"></asp:ListItem>
                                                                     <asp:ListItem Text="Другое" Value="1"></asp:ListItem>
                                                                     <asp:ListItem Text="Бизнес" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-9" class="form-control">
                                                             <asp:SqlDataSource id="source_type_sql" runat ="server"></asp:SqlDataSource>
                                                                   <asp:DropDownList  ID="source_type_name_ddl" runat="server"  AutoPostBack="true" DataSourceID="source_type_sql" DataValueField="ID" DataTextField="NAME" ondatabound="source_ddl_DataBound" CssClass="required form-control" OnSelectedIndexChanged="TABLE"></asp:DropDownList>
                                                            </div>
                                                               </div> 


                                                            </div> 
                                                             <div class="col-md-6"> 
                                                                <label for="field-3"  class="control-label">Оператор</label> 
                                                                <asp:TextBox ID="User_txt" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                               </div>

                                                        </div> 
                                                    </div> 
                                                 
                                                </div> 
                                                </div>
                                                <div class="modal-footer"> 
                                                    <button type="button" class="btn btn-default waves-effect btn-danger" data-dismiss="modal">Отмена</button> 
                                                     <asp:LinkButton ID="SaveClient_btn" runat="server" Text="Сохранить" CssClass="btn btn-primary waves-effect waves-light" UseSubmitBehavior="false" OnClick="SaveClient_btn_Click" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                </div> 
                                            </div> 
                                        </div>
                                           </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
     <!-- /.modal -->

    <!--------------------Timer----------------------->

    <script src="assets/js/jquery.js" ></script>
    <script src="assets/js/jquery.simple.timer.js" ></script>
  <script>

      function init1() {
          $('.timer').startTimer();

      }

      $(document).ready(function () {
          init1();
      });

</script>
<style>
  .timer {
   font-size: 14px;
   color=red;
    font-weight: bold;
    padding: 5px;
  }

  
  .jst-hours {
    float: left;
  }
  .jst-minutes {
    float: left;
  }
  .jst-seconds {
    float: left;
  }
  .jst-clearDiv {
    clear: both;
  }
  .jst-timeout {
    color: red;
  }
</style>
    <!--------------------Timer----------------------->






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

