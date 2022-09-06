<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sessions.aspx.cs" Inherits="SchoolManagementReport.Sessions" Title="Session Setup" MasterPageFile="~/Site.Master" %>
<asp:Content ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
	<link href="Content/css/dataTables.bootstrap5.css" rel="stylesheet" />
	<link href="Scripts/datatables.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<main>
<section class="container-fluid">
<div class="modal-header" style="display:flex;justify-content:flex-end;gap:5px">

<h3  style="flex:1;float:left;">Accademic Year</h3>
<h4><a class="btn" onclick="ShowSetupModal()">New Accademic Year</a></h4>
</div>
<div class="modal-content">
<div class="modal-body">
<table class="table table-bordered" id="AccademicYearInfo"></table>
</div> 
</div>
</section>
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
</main>
	<script src="Scripts/AccademicYear.js"></script>

</asp:Content>

