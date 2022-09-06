<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassInformation.aspx.cs" Inherits="SchoolManagementReport.ClassInformation" MasterPageFile="~/Site.Master" Title="Class Information" %>
<asp:Content ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
	<link href="Content/css/dataTables.bootstrap5.css" rel="stylesheet" />
	<link href="Scripts/datatables.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<main>
<section class="container-fluid">
<div class="modal-header" style="display:flex;justify-content:flex-end;gap:5px">

<h3  style="flex:1;float:left;">Class List</h3>
<h4><a class="btn" onclick="Showmodal()">New Class</a></h4>
</div>
<div class="modal-content">
<div class="modal-body">
<table class="table table-bordered" id="ClassInfo"></table>
</div> 
</div>
</section>
<section id="ClassModal" class="modal">
<div class="modal-dialog">
<div class="modal-content">
<div class="modal-header">
<h3>Class Information</h3>

</div>
<div class="modal-body">
<div class="row">
<div class="form-group col-md-6">
<label>Class Name</label>
<input type="text" id="ClassName" name="ClassName" class="form-control" />
</div>
<div class="form-group col-md-6">
<label>Class Level</label>
<select type="text" id="ClassLevel" name="ClassLevel" class="form-control" ></select> 
</div>
<div class="form-group col-md-6" style="display:flex;gap:4px;flex-direction:column;">
<label>Class Teacher</label>
<select type="text" id="ClassTeacher" name="ClassTeacher" class="form-control" >
<option selected disabled>Select Class Teacher</option>
</select> 
</div>
<div class="form-group col-md-6">
<label>Class Population</label>
<input type="number" min="0" id="Population" name="Population" class="form-control" />
</div>
 
</div>
</div>
<div class="modal-footer">
<button type="button" class="btn-primary btn">Save</button>
<button type="button" class="btn-danger btn" data-dismiss="modal">Close</button>
<input type="hidden" id="Action" />
<input type="hidden" id="ClassID" />
</div>
</div>
</div>
</section>
</main>
	<script src="Scripts/ClassInfo.js"></script>

</asp:Content>

