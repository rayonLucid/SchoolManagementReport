<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAdmissionForm.aspx.cs" MasterPageFile="~/Site.Master" Inherits="SchoolManagementReport.StudentAdmissionForm" Title="Student Admission Form" %>

<asp:Content runat="server" ContentPlaceHolderID="HeaderContentPlaceHolder">
<link href="Content/StudentAdmissionForm.css" rel="stylesheet" />
<link href="Content/bootstrap.css" rel="stylesheet" />
<style>
hr{
width:80%;
border-bottom:black solid 1.5px;
margin:0 !important;
padding:12px 0px;

}
.modal{width:100vw;backdrop-filter: blur(8px);}
.modal-dialog {border:solid white 2px; padding:2px;}
</style>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
   <main id="MainForm" class="panel" style="width:100%;overflow:auto;">
                        <section id="PageHeader" class="panel-heading" style="display:flex; justify-content: space-between; align-items: center;background-color: transparent; border: none; margin-bottom: 12px;">
                           
                                <h3 id="HeadTitle" style="width:100%;">New Students</h3>
                      
                            <ul style="list-style:none;width:50%;display:flex;gap:12px;justify-content:flex-end;text-decoration:none">
                           <li><asp:Label runat="server" ID="SuccessLbl"></asp:Label></li>
                            
                           </ul>
                        </section>
                      <section id="PageBody" class="panel-body"  style="display:flex;">
                       <div class="form-group" style="display:flex;place-content:center;flex-wrap:wrap;flex-direction:column;gap:12px">
                                   
                                 <img  id="image" src="#" alt="Passport" width="150" height="150" />
                                  <input id="inputfile" type="file" class="form-control-file" onchange="UploadImage(id,'image')">
                                  <input type="hidden" id="UploadedFile" name="UploadedFile" />
                                </div>
                       <div class="row">
                                <div class="col-md-4">
                                     <div class="col form-group">
                                    <label>First Name *</label>
                                    <input name="FirstNAme" type="text" placeholder="" class="form-control">
                                </div>
                                
                                <div class=" col form-group">
                                    <label>Gender *</label>
                                    <select name="Gender" class="form-control" aria-hidden="true">
                                        <option value="" >Please Select Gender *</option>
                                        <option value="Male">Male</option>
                                        <option value="Female">Female</option>
                                       
                                    </select>
                                  
                                </div>
                                <div class="col form-group">
                                    <label>Date Of Birth *</label>
                                    <input name="DOB" type="date" placeholder="" class="form-control" data-position="bottom right">
                                    <i class="far fa-calendar-alt"></i>
                                </div>
                                <div class="col form-group">
                                    <label>Blood Group *</label>
                                    <select name="bloodgroup"  class="form-control">
                                        <option value="">Please Select Group *</option>
                                        <option value="A+">A+</option>
                                        <option value="A-">A-</option>
                                        <option value="B+">B+</option>
                                        <option value="B-">B-</option>
                                        <option value="O+">O+</option>
                                        <option value="O-">O-</option>
                                    </select>
                                    
                                </div>
                                <div class="col form-group">
                                    <label>Admission Date*</label>
                                   <input type="date" name="Admissiondate" id="Admissiondate" class="form-control" />
                                    
                                </div>
                             </div>
                                <div class="col-md-4">
                                     <div class="col form-group">
                                    <label>Middle Name</label>
                                    <input type="text" name="MiddleName" placeholder="" class="form-control">
                                </div>
                                <div class="col form-group">

                                    <label>Current Level *</label>
                                    <select name="ClassLevel" id="ClassLevel" class="form-control" aria-hidden="true" onchange="GetClassByLevel()">
                                      
                                       
                                    </select>
                                </div>
                                
                                
                                <div class="form-group">
                                    <label>E-Mail</label>
                                    <input name="Email" type="email" placeholder="" class="form-control">
                                </div>
                                <div class="col form-group">
                                    <label>Session Admitted* &nbsp&nbsp&nbsp <a onclick="ShowSetupModal()">Setup</a></label>
                                    <select name="SessionAdmitted" class="form-control" id="SessionAdmitted">
                                        <option value="">Please Select Session *</option>
                                      
                                    </select>
                                    
                                    
                                </div>
                                <div class="form-group">
                                    <label>Parent Name*</label>
                                    <select  name="ParentName" id="ParentName" type="text" placeholder="" class="form-control">
                                    <option disabled selected >Select Parent</option>
                                    </select> 
                                </div>
                             </div>
                                <div class="col-md-4">
                                <div class="form-group">
                                    <label>Last Name *</label>
                                    <input name="LastName" type="text" placeholder="" class="form-control">
                                </div>
                                    <div class="form-group">

                                    <label>Current Class *</label>
                                    <select name="CurrentClass" id="CurrentClass" class="form-control">
                                        <option value="" data-select2-id="12">Please Select Class *</option>
                                       
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label>Phone</label>
                                    <input name="Phone" type="text" placeholder="" class="form-control">
                                </div>
                                
                                <div class="form-group">
                                    <label>Admission ID</label>
                                    <input name="AdmissionID" id="AdmissionID" readonly type="text" placeholder="" class="form-control" value="<%=AdmissionID %>">
                                </div>
                                
                             </div>
                             
                            </div>
                        </section>
                         <section  id="PageFooter" class="modal-footer" style="display:flex;place-content:center;gap:12px;">
                                    <button type="button" onclick="SaveRecord()" class="btn btn-default btn-primary" >Save</button>
                                    <button   type="button" id="PreviewButton"  class="btn   btn-info"  onclick="PreviewModal()">Preview To Print</button>
                                    <button type="reset" onclick="window.location.reload()" >Reset</button>
                                   <input type="hidden" id="Action" />
                                    <input type="hidden" id="RowID" name="UserName" />
                                </section>
                    </main>

                    <div id="PreviewPage" class="modal" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document" backdrop="static">
                     <div class="modal-content">
                           <div class="modal-header">
                            <h3 id="HeaderTitle" style="width:100%;"></h3>
                           </div>
                               
                      
                         <div class="modal-body">
                      
                      <div class="new-added-form" style="display:block; margin-top: 0em;">
                       <div class="col form-group" style="display:flex;place-content:center;flex-wrap:wrap;flex-direction:column;gap:12px">
                                   
                                 <img  id="image1" src="#" alt="Passport" width="150" height="150" />
                                 
                                </div>
                       <div class="row">
                                <div>
                                     <div class="col-md-4">
                                    <label>First Name *</label>
                                     <hr />
                                    
                                 
                                </div>
                                  <div class="col-md-4">
                                    <label>Middle Name</label>
                                   
                                    <hr />
                                </div>
                                  <div class="col-md-4">
                                    <label>Last Name *</label>
                                   
                                   <hr />
                                </div>
                                 
                                <div class="col-md-4">
                                    <label>E-Mail</label>
                                   
                                   <hr />
                                </div>
                                  <div class="col-md-4">
                                    <label>Phone</label>
                                    
                                    <hr />
                                </div>
                                <div class="col-md-4">
                                    <label>Gender *</label>
                                   
                                    <hr />
                                      
                                </div>
                                <div class="col-md-4">
                                    <label>Date Of Birth *</label>
                                    
                                   <hr />
                                   
                                </div>
                                <div class="col-md-4">
                                    <label>Blood Group *</label>
                                    
                                   <hr  />
                                    
                                </div>
                                
                             </div>
                                <div>
                                   
                                <div class="col-md-4">

                                    <label>Current Level *</label>
                                     
                                   <hr />
                                </div>
                                
                               
                                <div class="col-md-4">
                                    <label>Session Admitted*</label>
                                   
                                   <hr />
                                    
                                </div>
                                
                             </div>
                                <div>
                              
                                    <div class="col-md-4">

                                    <label>Current Class *</label>
                                    
                                     <hr />
                                </div>
                              
                                
                                <div class="col-md-4">
                                    <label>Admission ID</label>
                                   
                                    <hr />
                                </div>
                                  <div class="col-md-4">
                                    <label>Admission Date</label>
                                   
                                    <hr />
                                </div>
                                 <div class="col-md-4">
                                    <label>Parent Name</label>
                                   
                                    <hr />
                                </div>
                             </div>
                              <div>
                                 
                               
                               
                              </div>
                            </div>
                        </div>
                         <div class="modal-footer"  style="display:flex;place-content:center;gap:12px;padding-top:12px">
                                
                                     <button  type="button" id="PrintButton" onclick="PrintPage()" class="Printbutton">Print</button>
                                      <button   type="button" id="CloseButton"  class="btn btn-lg  btn-danger" data-dismiss="modal">Cancel</button>
                              <button type="button" id="RefreshButton"  class="Printbutton" style="display:none ;padding:12px;width:40%" data-dismiss="modal">Refresh</button>
                                </div>
                                </div>  
                                </div>
                                </div>
                    </div>

                    <section id="AccademicYearModal" class="modal" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document" backdrop="static">
                     <div class="modal-content">
                           <div class="modal-header">
                            <h3  class="modal-title" style="width:100%;">Setup Accademic Year</h3>
                           </div>
                               
                      
                         <div class="modal-body">

                       <div class="row">
                                
                                     <div class="col-md-6">
                                    <label>Accademic Year*</label>
                                     <input type="text" name="Accademicyear" class="form-control" id="Accademicyear" />
                                    
                                 
                                </div>
                                  <div class="col-md-6" style="display:flex;gap:24px">
                                    <label>Current  Session</label>
                                   
                                     <input type="checkbox" name="CurrentSession" id="CurrentSession" style="transform:scale(2)" />
                                </div>
                            
                            </div>           
                             
                         </div> 
                                                      <div class="modal-footer"  style="display:flex;place-content:center;gap:12px;padding-top:12px">
                                
                                     <button  type="button" id="SaveButton" onclick="UpdateAccademicYear()" class="btn btn-success">Add Record</button>
                                      <button   type="button" id="CloseBtn"  class="btn btn-lg  btn-danger" data-dismiss="modal">Cancel</button>
                             
                                </div>
                                </div>  
                                </div>
                                </section>
             
          <script type="text/javascript" src="Scripts/StudentAdmissionForm.js"></script> 
          	<script src="Scripts/AccademicYear.js"></script>
</asp:Content>