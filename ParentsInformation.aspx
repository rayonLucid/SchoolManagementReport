<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParentsInformation.aspx.cs" Inherits="SchoolManagementReport.ParentsInformation" Title="Guardian Information" MasterPageFile="~/Site.Master" %>



<asp:Content runat="server" ContentPlaceHolderID="HeaderContentPlaceHolder">
	<link href="Scripts/jquery-ui-1.13.2.custom/jquery-ui.min.css" rel="stylesheet" />
	<link href="Scripts/datatables.min.css" rel="stylesheet" />
	
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div class="card-body" style=" padding:15px 30px 30px; background-color:#ffffff; border-radius:4px;">
                        <div class="heading-layout1" style="display:flex; justify-content: space-between; align-items: center;background-color: transparent; border: none; margin-bottom: 12px;">
                           
                 <h3 id="HeaderTitle" style="width:100%;">All Parents List</h3>
                      
                             <ul style="list-style:none;width:50%;display:flex;gap:12px;justify-content:flex-end;text-decoration:none">
                           <li><a class="btn btn-secondary"   onclick="Showmodal()" >Add New Parent</a></li>
                            
                           </ul>
                        </div>
                      <div class="new-added-form" style="display:block; margin-top: 0em;">
                       
                       	
<table id="ParentsInfo" class="table table-table-hover" width="100%">
  <thead>
        <tr>
            <th>Name</th>
            <th>Phone Number</th>
            <th>Email</th>
            <th>Is Active</th>
            <th></th>
        </tr>
    </thead>
</table>
                        </div>
                         
                    </div>
                    <div id="ParentModal" class="modal" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document" backdrop="static">
                    
                    <div class="modal-content" style="width:60vw">
                    <div class="modal-header">
                    <div class="panel-title"> Parent Information</div>
                    </div>
                    <div class="modal-body" >
                   <div class="row">
                   <div class="col-md-6 form-group">
                   <label for="FirstName">First Name</label>
                    <input type="text" id="FirstName" name="FirstName" class="form-control"/>
                   </div>

                    <div class="col-md-6 form-group">
                      <label for="MiddleName">Middle Name</label>
                    <input type="text" id="MiddleName" name="MiddleName" class="form-control" />

                    </div>
                     <div class="col-md-6 form-group">
                       <label for="MiddleName">Last Name</label>
                    <input type="text" id="LastName" name="LastName" class="form-control" />
                     </div>
                     
                    
                     <div class="col-md-6 form-group">
                       <label for="Email">Email</label>
                    <input type="email" id="Email" name="Email" class="form-control" />
                     </div>
                   <div class="col-md-6 form-group">
                       <label for="Email">Phone</label>
                    <input type="tel" id="Phone" name="Phone" class="form-control" />

                    <div class="col-md-6 form-group" style="display:flex ;gap:20px;flex-wrap:wrap;padding-top:24px;">
                    <label for="IsActive">Is Active</label>
                    <input type="checkbox" id="IsActive" name="IsActive" style="transform:scale(2)" class="checkbox" />
                   </div>
                     </div>
                   
                     <div class="col-md-6 form-group">
                       <label for="Address">Residential Address</label>
                    <textarea type="text" id="ResidentialAddress" name="ResidentialAddress" class="form-control"  cols="5" rows="5" ></textarea> 
                     </div>
                   
                   </div>
                    </div>
                    <div  id="ParentsChildren" style="padding:2em 2em;display:flex;flex-direction:column;gap:15px;">
                    <div class="panel-title" style="display:none; ">
                    <a onclick="ShowSubjectModal()">Add Subject</a>
                    </div>
                    <table id="ChildrenInfo" class="table  table-condensed" width="100%"> </table>

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

                    <div id="Childmodal" class="modal" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document" backdrop="static">
                    
                    <div class="modal-content" style="width:auto;padding:2px">
                    <div class="modal-header">
                    <div class="panel-title"> Children Information</div>
                    </div>
                    <div class="modal-body" >
                   <div class="row">
                 
                   <div class=" col-md-6">
                       <label for="CFirstName"> FirstNamelass Level</label>
                    <input type="text" id="CFirstName" readonly name="CFirstName" class="form-control" >
                    
                      </div>
                       <div class=" col-md-6">
                       <label for="CMiddleName"> Middle Name</label>
                    <input type="text" id="CMiddleName" readonly name="CMiddleName" class="form-control" >
                    
                      </div>
                       <div class=" col-md-6">
                       <label for="CMiddleName"> Last Name</label>
                    <input type="text" id="CLastName" readonly name="CLastName" class="form-control" >
                    
                      </div>
                       <div class=" col-md-6">
                       <label for="Gender">Gender</label>
                    <input type="text" id="Gender" readonly name="Gender" class="form-control" >
                    
                      </div>
                       <div class=" col-md-6">
                       <label for="CDOB">Date Of Birth</label>
                    <input type="text" id="CDOB" readonly name="CDOB" class="form-control" >
                    
                      </div>
                       <div class=" col-md-6">
                       <label for="CResidentialAddress">Address</label>
                    <input type="text" id="CResidentialAddress" readonly name="CResidentialAddress" class="form-control" >
                    
                      </div>
                        <div class=" col-md-6">
                       <label for="ClassTeacher">Class Teacher</label>
                    <input type="text" id="ClassTeacher" readonly name="ClassTeacher" class="form-control" >
                    
                      </div>
                      <div class=" col-md-6">
                       <label for="CurrentClass">Current Class</label>
                    <input type="text" id="CurrentClass"  name="CurrentClass" class="form-control" />
                  
                      </div>
                       <div class=" col-md-6">
                       <label for="CAdmissionDate">Admission Date</label>
                    <input type="text" id="CAdmissionDate" readonly name="CAdmissionDate" class="form-control" >
                    
                      </div>

                        <div class=" col-md-6">
                       <label for="CSessionAdmitted">Session Admitted</label>
                    <input type="text" id="CSessionAdmitted" readonly name="CSessionAdmitted" class="form-control" >
                    
                      </div>

                      

                      <%-- <div class=" col-md-6" >
                       <label for="ClassCategory"> Class Category</label>
                    <select type="text" id="ClassCategory" name="ClassCategory" onchange=" GetClassByLevel()" class="form-control" >
                    <option disabled selected >Select Class Category</option>
                  
                    </select> 
                      </div>--%>
                    
                  
                  
                   
                   
                   </div>
                    </div>
                    
                    <div class="modal-footer" style="padding:2px;">
                    <button type="button" class="btn  btn-primary" onclick="UpdateRecord()" >Update</button>
                    <button type="button" class="btn  btn-danger" data-dismiss="modal">Close</button>
                   <input type="hidden" id="SubjectID" />
                    <input type="hidden" id="SubjectRecords" />
                   </div>
                    </div>
                   

                    </div>
                    </div>

	<script src="Scripts/Parents.js"></script>
</asp:Content>