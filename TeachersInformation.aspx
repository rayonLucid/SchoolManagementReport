<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachersInformation.aspx.cs" Inherits="SchoolManagementReport.TeachersInformation" MasterPageFile="~/Site.Master" Title="All Teachers List" %>


<asp:Content runat="server" ContentPlaceHolderID="HeaderContentPlaceHolder">
	<link href="Scripts/datatables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div class="card-body" style=" padding:15px 30px 30px; background-color:#ffffff; border-radius:4px;">
                        <div class="heading-layout1" style="display:flex; justify-content: space-between; align-items: center;background-color: transparent; border: none; margin-bottom: 12px;">
                           
                 <h3 id="HeaderTitle" style="width:100%;">All Teachers List</h3>
                      
                             <ul style="list-style:none;width:50%;display:flex;gap:12px;justify-content:flex-end;text-decoration:none">
                           <li><a class="btn btn-secondary"   onclick="Showmodal()" >Add New Teacher</a></li>
                            
                           </ul>
                        </div>
                      <div class="new-added-form" style="display:block; margin-top: 0em;">
                       
                       	
<table id="AllTeachers" class="table table-hover" width="100%">
  <thead>
        <tr>
            <th>Subject Name</th>
            <th>Class Level</th>
            <th>Class Category</th>
            <th></th>
        </tr>
    </thead>
</table>
                        </div>
                         
                    </div>
                    <div id="TeacherModal" class="modal" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document" backdrop="static">
                    
                    <div class="modal-content" style="width:auto">
                    <div class="modal-header">
                    <div class="panel-title"> Teacher Information</div>
                    </div>
                    <div class="modal-body" >
                   <div class="row">
                    <div class="col-md-6">
                   <label for="vUserID">User ID</label>
                    <input type="text" id="vUserID" name="vUserID" class="form-control"/>
                   </div>
                   <div class="col-md-6">
                   <label for="FirstName">First Name</label>
                    <input type="text" id="FirstName" name="FirstName" class="form-control"/>
                   </div>

                    <div class="col-md-6">
                      <label for="MiddleName">Middle Name</label>
                    <input type="text" id="MiddleName" name="MiddleName" class="form-control" />

                    </div>
                     <div class="col-md-6">
                       <label for="MiddleName">Last Name</label>
                    <input type="text" id="LastName" name="LastName" class="form-control" />
                     </div>
                      <div class=" col-md-6">
                       <label for="gender">Gender</label>
                    <select type="text" id="Gender" name="Gender" class="form-control" >
                    <option disabled selected >Select Gender</option>
                    <option value="Male" >Male</option>
                    <option value="Female" >Female</option>
                    </select> 
                      </div>
                    
                     <div class="col-md-6">
                       <label for="Email">Email</label>
                    <input type="email" id="Email" name="Email" class="form-control" />
                     </div>
                  
                    <div class="col-md-6">
                       <label for="Phone">Phone</label>
                    <input type="email" id="Phone" name="Phone" class="form-control" />
                     </div>
                     <div class="col-md-6">
                       <label for="Address">Address</label>
                    <textarea type="text" id="Address" name="Address" class="form-control" rows="5" cols="5" ></textarea>
                     </div>
                    <div class="col-md-6" style="display:flex ;gap:20px;flex-wrap:wrap;padding-top:12px;">
                       <label for="IsClassTeacher">Is Class Teacher</label>
                    <input type="checkbox" id="IsClassTeacher" name="IsClassTeacher" class="checkbox" style="transform:scale(2)" />
                    
                       <label for="IsSubjectTeacher">Is Subject Teacher</label>
                    <input type="checkbox" id="IsSubjectTeacher" name="IsSubjectTeacher" class="checkbox" style="transform:scale(2)" />
                   
                       <label for="IsActive">Is Active</label>
                    <input type="checkbox" id="IsActive" name="IsActive" style="transform:scale(2)" class="checkbox" />
                    
                   </div>
                    </div>
                    <div  id="TeachersSubject" style="padding:2em 2em;display:flex;flex-direction:column;gap:15px;">
                    <div class="panel-title">
                    <a class="btn" onclick="ShowSubjectModal()">Add Subject</a>
                    </div>
                    <table id="TeacherSubjects" class="table table-table-hover" width="100%"> </table>

                    </div>
                    <div class="modal-footer">
                    <button type="button" class="btn  btn-primary" onclick="SaveRecord()" >Save</button>
                    <button type="button" class="btn  btn-danger" data-dismiss="modal">Close</button>
                    <input id="RowID" name="RowID" type="hidden" />
                     <input id="UserID" name="UserID" type="hidden" />
                    <input id="Action" type="hidden" />
                    </div>
                    </div>

                    </div>
                    </div>

                    <div id="TeacherSubjectModal" class="modal" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document" backdrop="static">
                    
                    <div class="modal-content" style="width:auto;padding:2px">
                    <div class="modal-header">
                    <div class="panel-title"> Teacher Subject Information</div>
                    </div>
                    <div class="modal-body" >
                   <div class="row">
                 

                      <div class=" col-md-6">
                       <label for="ClassLevel"> Class Level</label>
                    <select type="text" id="ClassLevel" onchange="GetClassCategory()" name="ClassLevel" class="form-control" >
                    <option disabled selected >Select Class Level</option>
                  
                    </select> 
                      </div>
                       <div class=" col-md-6" >
                       <label for="ClassCategory"> Class Category</label>
                    <select type="text" id="ClassCategory" name="ClassCategory" onchange=" GetClassByLevel()" class="form-control" >
                    <option disabled selected >Select Class Category</option>
                  
                    </select> 
                      </div>
                    
                     <div class="col-md-6">
                       <label for="Subjects">Subjects</label>
                   <select type="text" id="Subjects" name="Subjects" class="form-control" >
                    <option disabled selected >Select Subject </option>
                  
                    </select> 
                     </div>
                  
                   
                   
                   </div>
                    </div>
                    
                    <div class="modal-footer" style="padding:2px;">
                    <button type="button" id="btnUpdate" class="btn  btn-primary" onclick="UpdateRecord()" >Update</button>
                    <button type="button" class="btn  btn-danger" data-dismiss="modal">Close</button>
                   <input type="hidden" id="SubjectID" />
                    <input type="hidden" id="SubjectRecords" />
                   </div>
                    </div>
                   

                    </div>
                    </div>
<%--	<script src="Scripts/datatables.js"></script>--%>
	<script src="Scripts/Teachers.js"></script>
</asp:Content>