<%@ Page Language="C#" AutoEventWireup="true" CodeFile="defaultinner.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="defaultinner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
   <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load("current", {packages:["corechart"]});
      google.charts.setOnLoadCallback(drawChart);
        function drawChart() {  


        //--------MAN AND WOMAN---------------------------
            var datagender = google.visualization.arrayToDataTable([
        ['Task', 'Hours per Day'],
            <% =Gender %>
          
         
        ]);

            var options = {
                title: 'Пол',
                  pieHole: 0.4,
            };
            var chartgender = new google.visualization.PieChart(document.getElementById('Man_woman'));
               chartgender.draw(datagender, options);
                
            //------------------------------------------------

            //----------------------SOURCE-----------------------
                var datasource = google.visualization.arrayToDataTable([
          ['Task', 'Hours per Day'],
             <% =Source %>
         
        ]);

            var options = {
                title: 'Источники',
                  pieHole: 0.4,
            };
            var chartsource = new google.visualization.PieChart(document.getElementById('Costumer_business'));
               chartsource.draw(datasource, options);
                
            //-----------------------------------------------


              //----------------------AGE-----------------------
                var dataage = google.visualization.arrayToDataTable([
          ['Task', 'Hours per Day'],
            ['10-18 ( <% =from10to18Count %> )', <% =from10to18 %>],
          ['18-25 ( <% =from18to25Count %> )', <% =from18to25 %>],
           ['25-40 ( <% =from25to40Count %> )', <% =from25to40 %>]
         
        ]);

            var options = {
                title: 'Возраст',
                  pieHole: 0.4,
            };
            var chartage = new google.visualization.PieChart(document.getElementById('Age_interval'));
               chartage.draw(dataage, options);
                
            //------------------------------------------------

                    //--------PACKAGES---------------------------
            var datapackages = google.visualization.arrayToDataTable([
        ['Task', 'Hours per Day'],
            <% =Packages %>
          
         
        ]);

            var options = {
                title: 'Пакеты',
                  pieHole: 0.4,
            };
            var chartpackages = new google.visualization.PieChart(document.getElementById('PPackages'));
               chartpackages.draw(datapackages, options);
                
            //------------------------------------------------

            //--------CATEGORY---------------------------
            var datacategory = google.visualization.arrayToDataTable([
        ['Task', 'Hours per Day'],
            <% =Category %>
          
         
        ]);

            var options = {
                title: 'Категории',
                  pieHole: 0.4,
            };
            var chartcategory = new google.visualization.PieChart(document.getElementById('DCategory'));
               chartcategory.draw(datacategory, options);
                
            //------------------------------------------------

                 //--------------DEVICE---------------------
            var datadevice = google.visualization.arrayToDataTable([
        ['Task', 'Hours per Day'],
            <% =Device %>
          
         
        ]);

            var options = {
                title: 'Аппараты',
                  pieHole: 0.4,
            };
            var chartdevice = new google.visualization.PieChart(document.getElementById('DDevice'));
               chartdevice.draw(datadevice, options);
                
            //------------------------------------------------

             //--------------GAMES---------------------
            var datagames = google.visualization.arrayToDataTable([
        ['Task', 'Hours per Day'],
            <% =Games %>
          
         
        ]);

            var options = {
                title: 'Игры',
                  pieHole: 0.4,
            };
            var chartgames = new google.visualization.PieChart(document.getElementById('GGames'));
               chartgames.draw(datagames, options);
                
            //------------------------------------------------

          
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

	<%--<section class="charts">
		<div class="page-container">
			<ul>
				<li>
                     <div id="Man_woman" style="height: 400px; max-width: 420px; margin: 0px auto;"></div>                   
				</li>
				<li>
                     <div id="Costumer_business" style="height: 400px; max-width: 420px; margin: 0px auto;"></div>
				</li>
			</ul>
            <br />
			<ul>
				<li>
                      <div id="Age_interval" style="height: 400px; max-width: 920px; margin: 0px auto;"></div>
				</li>
				
			</ul>
		</div>
	</section>--%>
            <div class="row">
            <div class="col-lg-6 form-group" >
            <div id="Man_woman"style=" height: 300px;" ></div>                   
			</div>
            <div class="col-lg-6 form-group">
                     <div id="Costumer_business" style=" height: 300px;"></div>                   
                     </div>
                <br />
                <br />
                <br />
                     <div class="col-lg-6 form-group">
                     <div id="Age_interval" style=" height: 300px;" ></div>   
                     </div>
                      <div class="col-lg-6 form-group">
                     <div id="PPackages" style=" height: 300px;" ></div>   
                     </div>   
                          <div class="col-lg-6 form-group">
                     <div id="DCategory" style=" height: 300px;" ></div>   
                     </div> 
                        <div class="col-lg-6 form-group">
                     <div id="DDevice" style=" height: 300px;" ></div>   
                     </div> 
                          <div class="col-lg-6 form-group">
                     <div id="GGames" style=" height: 300px;" ></div>   
                     </div> 
                     
                                     
                     </div>
                     


</asp:Content>