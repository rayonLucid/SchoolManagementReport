<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Subjects.aspx.cs" Inherits="SchoolManagementReport.Subjects" Title="Subject Information" MasterPageFile="~/Site.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="HeaderContentPlaceHolder">
	<link href="Scripts/datatables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div class="modal-body" style=" padding:15px 30px 30px; background-color:#ffffff; border-radius:4px;">
                        <div class="heading-layout1" style="display:flex; justify-content: space-between; align-items: center;background-color: transparent; border: none; margin-bottom: 12px;">
                           
                 <h3 id="HeaderTitle" style="width:100%;">All Subject List</h3>
                      
                           <ul style="list-style:none;width:50%;display:flex;gap:12px;justify-content:flex-end;text-decoration:none">
                           <li><a class="btn btn-secondary"   onclick="Showmodal()" >Add New Subject</a></li>
                            
                           </ul>
                        </div>
                      <div class=" modal-content" style="display:block; margin-top: 0em;">
                       
                       	<div class="modal-body">
                          <table id="AllSubjects" class="table table-hover" width="100%"></table>
                       	</div>
                   
                        </div>
                         
                    </div>
                    <div id="SubjectModal" class="modal" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document" backdrop="static">
                    
                    <div class="modal-content" style="width:fit-content">
                    <div class="modal-header">
                    <div class="panel-title"> Subject Information</div>
                    </div>
                    <div class="modal-body" >
                   <div style="display:flex;gap:12px;flex-direction:column;align-content:center;justify-content:center">
                    <label for="SubjectName">Subject Name</label>
                    <input type="text" id="SubjectName" name="SubjectName" class="form-control"/>
                   
                    <label for="SubjectName">Class Level</label>
                    <select type="text" id="ClassLevel" name="ClassLevel" onchange="LoadClassCategory()" class="form-control" ></select> 

                     <label for="ClassCategory">Class Category</label>
                    <select type="text" id="ClassCategory" name="ClassCategory" class="form-control" ></select> 
                   
                  <%--  <label for="SubjectName">Subject Teacher</label>
                    <select type="text" id="SubjectTeacher" name="SubjectTeacher" class="form-control" ></select> --%>
                   </div>
                    </div>
                    <div class="modal-footer">
                    <button type="button" class="btn  btn-primary" onclick="SaveRecord()" >Save</button>
                    <button type="button" class="btn  btn-danger" data-dismiss="modal">Close</button>
                    <input id="RowID" name="RowID" type="hidden" />
                    <input id="Action" type="hidden" />
                    </div>
                    </div>

                    </div>
                    </div>

	<script src="Scripts/StudentAdmissionForm.js"></script>
</asp:Content>

