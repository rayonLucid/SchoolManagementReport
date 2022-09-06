<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" MasterPageFile="~/Site.Master" Inherits="SchoolManagementReport.DashBoard" Title="Dashboard" %>

<asp:Content runat="server" ContentPlaceHolderID="HeaderContentPlaceHolder">
	<link href="Content/bootstrap.css" rel="stylesheet" />
	<link href="Content/Site.css" rel="stylesheet" />

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">

<% if(Admin ==true){  %>
<main id="Admin">
<section id="Summary" style="display:flex;gap:25px;flex-wrap:wrap">
<div id="AllStudents" class="dashboardSummary">
<i class="glyphicon glyphicon-user" style="font-size:50px;color:green;background-color:lightgreen;padding:10px;border-radius:40px"></i>

<div style="display:flex;gap:1px;flex-direction:column;align-items:end;padding:0em 2em">
<label style="color: #a8a8a8;">Students</label>
<label>50000</label>
</div>

</div>
<div id="AllTeachers" class="dashboardSummary">
<i class="glyphicon glyphicon-user" style="font-size:50px;color:yellow;background-color:lightyellow;padding:10px;border-radius:40px"></i>

<div style="display:flex;gap:1px;flex-direction:column;align-items:end;padding:0em 2em">
<label style="color: #a8a8a8;">Teachers</label>
<label>50000</label>
</div>

</div>
<div id="AllParents" class="dashboardSummary">
<i class="glyphicon glyphicon-user" style="font-size:50px;color:blue;background-color:lightblue;padding:10px;border-radius:40px"></i>

<div style="display:flex;gap:1px;flex-direction:column;align-items:end;padding:0em 2em;position:relative">
<label style="color: #a8a8a8;">Parents</label>
<label>50000</label>
</div>

</div>

<div id="CurrentSession" class="dashboardSummary" style="width:35%">
<i class="glyphicon  glyphicon-hourglass" style="font-size:50px;color:blue;background-color:transparent;padding:10px;border-radius:40px"></i>

<div style="display:flex;gap:1px;flex-direction:column;align-items:end;padding:0em 2em;position:relative">
<label style="color: #a8a8a8;">Current Session</label>
<label id="CurrentSessionlbl">2023/2019</label>
</div>

</div>
<div id="CurrentTerm" class="dashboardSummary" style="width:35%">
<i class="glyphicon  glyphicon-certificate" style="font-size:50px;color:brown;background-color:transparent;padding:10px;border-radius:40px"></i>

<div style="display:flex;gap:1px;flex-direction:column;align-items:end;padding:0em 2em;position:relative">
<label style="color: #a8a8a8;">Current Term</label>
<label id="CurrentTermlbl">Third Term</label>
</div>

</div>
</section>
<section id="ChartSummary" style="display:flex;gap:50px;padding:2em 2em;">
<div id="PieChartSummary" class="dashboardSummary" style="width:50%;padding:1em 1em;flex-direction:column;align-items:center;gap:3px">
<label style="color: #000000;width:100%">Students Chart</label>

<canvas id="student-doughnut-chart" width="603" height="450" style="display: block; height: 300px; width: 402px;" class="chartjs-render-monitor"></canvas>

</div>
<div id="Actions" class="dashboardSummary" style="width:50%;padding:1em 1em;flex-direction:column;align-items:center;gap:12px">
<label style="color: #000000;width:100%">Actions</label>
<div style="flex-direction:column;align-items:center;gap:24px;display:flex;">
<asp:FileUpload runat="server"  ID="ImportStudents"  name="ImportStudents"  CssClass="FileButtons" ClientIDMode="Static" />

<asp:FileUpload runat="server"  ID="ImportTeachers"  name="ImportTeachers"  CssClass="FileButtons" ClientIDMode="Static" />

<asp:FileUpload runat="server"  ID="ImportSubjects"  name="ImportSubjects"  CssClass="FileButtons" ClientIDMode="Static" />
<input type="hidden" id="ActionHolder" />
</div>


</div>
</section> 
</main>

<%}%>
<% if (Student == true)	{  %>
<main id="Students">
<section id="StudentProfile" style="display:flex;gap:50px;padding:2em 2em;">
<div id="ProfileInformation" class="dashboardSummary" style="width:100%;padding:1em 1em;flex-direction:column;gap:12px">
<label style="color: #000000;width:100%">About Me</label>

<div style="display:flex;align-items:flex-start;gap:24px;">
<img src="#" alt="My Image" width="150" height="150" />
<div id="studentInformation" style="display:flex;flex-direction:column;gap:12px">
<div style="display:flex;flex-direction:row;gap:12px"><label >Name</label> <label id="Name"></label></div>
<div style="display:flex;flex-direction:row;gap:12px"><label >Gender</label> <label id="Gender"></label></div>
<div style="display:flex;flex-direction:row;gap:12px"><label >DOB</label> <label id="DateOB"></label></div>
<div style="display:flex;flex-direction:row;gap:12px"><label >Parent Name</label> <label id="ParentName"></label></div>
<div style="display:flex;flex-direction:row;gap:12px"><label >Admission No</label> <label id="AdmissionNo"></label></div>
<div style="display:flex;flex-direction:row;gap:12px"><label >Admission Date</label> <label id="AdmissionDate"></label></div>
<div style="display:flex;flex-direction:row;gap:12px"><label >Residential Address</label> <label id="REsidentialAddress"></label></div>
</div>
</div>

</div>
</section>
<section id="StudentAttendanceChart" style="display:flex;gap:50px;padding:2em 2em;">
<div id="PieChartAttendance" class="dashboardSummary" style="width:50%;padding:1em 1em;flex-direction:column;align-items:center;gap:3px">
<label style="color: #000000;width:100%">Students Attendance Chart</label>

<canvas id="studentAttendance-doughnut-chart" width="603" height="450" style="display: block; height: 300px; width: 402px;" class="chartjs-render-monitor"></canvas>

</div>
</section> 
</main>
<%} %>

<% if (Guardian == true)	{  %>

<main id="Parents">

<section id="WardsInformation" style="display:flex;gap:50px;padding:2em 2em;flex-direction:column;">
<div id="AmountDueSummary" class="dashboardSummary">
<i class="glyphicon glyphicon-piggy-bank" style="font-size:50px;color:green;background-color:lightgreen;padding:10px;border-radius:40px"></i>

<div style="display:flex;gap:1px;flex-direction:column;align-items:end;padding:0em 0.5px">
<label style="color: #a8a8a8;">Amount Due</label>
<label>50000</label>
</div>

</div>
<div id="WardsProfile" class="dashboardSummary" style="width:100%;padding:1em 1em;flex-direction:column;gap:12px">
<label style="color: #000000;width:100%">My Kids</label>
<div style="display:flex;padding:1em 1em;flex-direction:row;gap:12px;justify-content:flex-start;flex-wrap:wrap;overflow:auto;height:40vh">

<div class="KidsInfo">

<img src="#" alt="Image" width="100" height="100" style="background-color:lightblue;border-radius:50px;" />
<div class="studentInfo" style="display:flex;flex-direction:column;gap:12px">
<div style="display:flex;flex-direction:row;gap:12px">
<label class="param" >Name</label>
<label id="wName" class="InfoValue">Ikhuoriah Iseghohime Diamond</label>

</div>
<div style="display:flex;flex-direction:row;gap:12px">
<label >Gender</label> 
<label id="wGender" class="InfoValue">Female</label>

</div>
<div style="display:flex;flex-direction:row;gap:12px">
<label class="param" >DOB</label> 
<label id="wDateOB" class="InfoValue">12-09-2011</label>

</div>

<div style="display:flex;flex-direction:row;gap:12px">
<label  style="width:100%">Admission No</label>
<label id="wAdmissionNo" class="InfoValue">#234953734463721</label>

</div>
<div style="display:flex;flex-direction:row;gap:12px">
<label style="width:100%" >Date Admitted</label>
<label id="wAdmissionDate" class="InfoValue">12-09-2022</label>

</div>
</div>

</div>


</div>
</div>
</section>
<section id="SchoolNotification" style="display:flex;gap:50px;padding:2em 2em;">
<div id="NotificationBox" class="dashboardSummary" style="width:50%;padding:1em 1em;flex-direction:column;align-items:start;gap:12px;height:80vh;overflow:auto">
<label style="color: #000000;width:100%">NOTIFICATIONS</label>
<div id="NotificationInfo" >
<h3 class="NoficationDate" style="width:50%"> 16 June, 2019</h3>
<p class="NoficationDetail" style="text-align:left;padding:0em 1em">Great School manag mene esom tus eleifend lectus sed maximus mi faucibusnting.October 19, 2016 - Valid formats are explained in Date and Time Formats. ... The timestamp which is used as a base for the calculation of relative dates. Returns a timestamp on success, false otherwise. Every call to a date/time function will generate a E_WARNING if the time zone is not valid</p>
<h4 class="NoficationSignature" style="font-family:'Lucida Calligraphy'"> Rayon Solutions</h4>
</div>

</div>
</section> 
</main>
<%} %>
<% if (Teacher == true)	{  %>
<main id="Teacher">

<section id="MyStudentInfo" style="display:flex;gap:50px;padding:2em 2em;flex-direction:column;">
<div style="display:flex;gap:5px;flex-direction:row">
<div id="ClassName" class="dashboardSummary">
<i class="glyphicon glyphicon-user" style="font-size:50px;color:black;background-color:saddlebrown;padding:10px;border-radius:40px"></i>

<div style="display:flex;gap:1px;flex-direction:column;align-items:end;padding:0em 0.5px">
<label style="color: #a8a8a8;" >Teacher</label>
<label id="Tclassname">S.S.3B</label>
</div>

</div>
<div id="TotalStudentSummary" class="dashboardSummary">
<i class="glyphicon glyphicon-user" style="font-size:50px;color:green;background-color:lightgreen;padding:10px;border-radius:40px"></i>

<div style="display:flex;gap:1px;flex-direction:column;align-items:end;padding:0em 0.5px">
<label style="color: #a8a8a8;">Students</label>
<label>50000</label>
</div>

</div>
<div id="TeacherActions" class="dashboardSummary" style="flex-direction:column;align-items:flex-start;padding:12px 5px;">
<label style="color: #a8a8a8;">Actions</label>
<div style="display:flex;gap:1px;flex-direction:column;align-items:center;padding-left:0.5px;padding-right:0.5px">

<asp:FileUpload runat="server"  ID="ImportResults"  name="ImportResults"  CssClass="FileButtons" ClientIDMode="Static" />
<%--<input type="file" id="ImportSubjects" class="FileButtons" />--%>
</div>

</div>
</div>

<div id="MyStudentList" class="dashboardSummary" style="width:100%;padding:1em 1em;flex-direction:column;gap:12px;display:none;">
<label style="color: #000000;width:100%">My Students</label>
<div style="display:flex;padding:1em 1em;flex-direction:row;gap:12px;justify-content:flex-start;flex-wrap:wrap;overflow:auto;height:40vh">




</div>
</div>
</section>
 
</main>
<%} %>

	<script src="Scripts/dashboard.js"></script>
</asp:Content>