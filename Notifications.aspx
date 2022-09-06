<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="SchoolManagementReport.Notifications" MasterPageFile="~/Site.Master" Title="Create Notification" %>

<asp:Content runat="server" ContentPlaceHolderID="HeaderContentPlaceHolder">
	<link href="Content/css/dataTables.jqueryui.css" rel="stylesheet" />
	<link href="Content/Site.css" rel="stylesheet" />

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">

<main id="Parents">

<section id="WardsInformation" style="display:flex;gap:50px;padding:2em 2em;flex-direction:row;">

<div id="NoticeInfo" class="dashboardSummary" style="width:40%;padding:1em 1em;flex-direction:column;gap:12px;height:85vh;overflow:auto;">
<label style="color: #000000;width:100%">Create a Notice</label>
<div style="display:flex;padding:1em 1em;flex-direction:row;gap:12px;justify-content:flex-start;">

<div class="NoticeInfo">

<div class="studentInfo" style="display:flex;flex-direction:column;gap:12px">
<div style="display:flex;flex-direction:column;gap:12px">
<label class="param" >Details</label>
<textarea id="Narration" name="Narration" class=" form-control"  rows="3" cols="100" ><%=Narration %></textarea>




<label class="param" >Posted Date</label> 
<input type="date"  name="startDate" id="startDate" class=" form-control"  value="<%=startDate%>"  />


<label  style="width:100%">Post Expiring Date</label>
<input type="date"  name="EndDate" id="EndDate" class=" form-control"  value="<%=endDate%>"  />



<label >Posted By</label> 
<input type="text" readonly name="signatory" class=" form-control"  id="signatory" value="<%=postedBy%>"  />
<div style="display:flex;gap:12px;margin-top:12px;place-content:center;">
<button class=" btn  btn-primary" type="button" onclick="SaveRecord()">Save</button>
<button class="btn btn-danger" disabled onclick="PostRecord()" id="btnPost">Post</button></div>
<input type="hidden" id="Action" />
<input type="hidden" id="RowID" name="RowID" />
</div>
</div>

</div>


</div>
</div>
<div id="NoticeDetails" class="dashboardSummary table-responsive" style="width:50%;padding:1em 1em;flex-direction:column;align-items:start;gap:12px;height:85vh;overflow:auto">
 <label style="color: #000000;width:100%">NOTICE BOARD</label>
<table id="NotificationTable" class="table  table-condensed" width="100%">
  <thead>
	<tr>
	<th></th>
	<th></th>
	</tr>
  </thead>
</table>
</div>
</section>

</main>
<script src="Scripts/datatables.js"></script>
	<script src="Scripts/Notification.js"></script>
</asp:Content> 