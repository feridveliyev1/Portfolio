<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	
<!-- Mirrored from coderthemes.com/ubold_1.1/dark/form-wizard.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 30 Nov 2015 02:12:21 GMT -->
<head>
		

	</head>
    
	<body >
    <script type="text/javascript">
    var buttonCancel = '<button class="btn btn-primary col-sm-12 button-cancel">Cancel</button>'; 
function UpdateDataSet(data){
  if(data != '' && data != undefined){
      data = data.map(function (obj) {
         var ds = timer();
         if (!obj)
         return;
         obj.push(ds,buttonCancel);
         return obj;
      });
  }
  if (dispatchTable) {
    dispatchTable.fnDestroy();
  }
  dispatchTable = $('#table-dispatch').dataTable({
    "data": data,
    "columnDefs": [
        {"sClass": "hide_me", "aTargets": [9]},
        {"sClass": "hide_me", "aTargets": [10]},
    ]
  });
}
 </script>
	</body>

<!-- Mirrored from coderthemes.com/ubold_1.1/dark/form-wizard.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 30 Nov 2015 02:12:21 GMT -->
</html>