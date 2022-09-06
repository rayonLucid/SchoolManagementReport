<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="SchoolManagementReport.Students" Title="Student Information" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="HeaderContentPlaceHolder">
	<link href="Scripts/datatables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div class="card-body" style=" padding:15px 30px 30px; background-color:#ffffff; border-radius:4px;">
                        <div class="heading-layout1" style="display:flex; justify-content: space-between; align-items: center;background-color: transparent; border: none; margin-bottom: 12px;">
                           
                 <h3 id="HeaderTitle" style="width:100%;">All Students List</h3>
                      
                             <button style="display:none" type="button" id="PrintButton" onclick="PrintPage()" class="Printbutton">Print</button>
                              <button type="button" id="RefreshButton"  class="Printbutton" style="display:none">Refresh</button>
                        </div>
                      <div class="new-added-form" style="display:block; margin-top: 0em;">
                       
                       	
<table id="AllStudents" class="table table-table-hover" width="100%"></table>
                        </div>
                         
                    </div>
	<script src="Scripts/datatables.js"></script>
	<script src="Scripts/StudentAdmissionForm.js"></script>
</asp:Content>