
const actionbutton = document.getElementById("RefreshButton")
const HeaderTitle = document.getElementById("HeaderTitle")
const inputfile = document.getElementById("inputfile")
const PrintButton = document.getElementById("PrintButton")
const SideMenu = document.getElementsByClassName("SideMenu")[0]
const SubjectModal = document.getElementById("SubjectModal")
const CloseButton = document.getElementById("CloseButton")
var path = window.location.pathname;
var pageName = path.split("/").pop();

function PrintPage() {

	PrintButton.style.display = "none"
	MainEntryForm.style.display = "none"
	SideMenu.style.display = "none"
	HeaderTitle.style.textAlign = "center"
	CloseButton.style.display = "none"
	HeaderTitle.innerText ="Rayon International School \n\n Student Admission Form"
	window.print()
	actionbutton.style.display = "block"
}


$(document).ready(function (e) {
	if (pageName.includes("StudentAdmissionForm")) {
		LoadClassLevel()
		LoadParents()
		$("#ParentName").select2({ selectOnClose: true})
		actionbutton.addEventListener("click", function () {
			PrintButton.style.display = "block"
			SideMenu.style.display = "block"
			CloseButton.style.display = "block"
			actionbutton.style.display = "none"
			MainEntryForm.style.display = "block"
			//PageFooter.style.display = "block"
		});
	}

	if (pageName.includes("Students")) {

		LoadAllStudents();

		
	}
	if (pageName.includes("TeachersInformation")) { LoadAllTeachers() }
	if (pageName.includes("Subjects")) {
		$("#SubjectModal").draggable()
		LoadClassLevel()
		LoadAllSubjectTeacher()
		LoadAllSubjects()

	}
	
})
async function LoadClassLevel() {
	await fetch(`../api/ClassInfo/GetAllClassLevel`).then((response) => {
		if (response.status == 200) {

			$("#CurrentLevel").empty()
			$('#CurrentLevel').append('<option selected disabled value="">Select Class Level</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#CurrentLevel').append('<option value="' + data + '">' + data + '</option>');
				});

			})
		} else {
			$("#CurrentLevel").empty()
			$('#CurrentLevel').append('<option selected disabled value="">Select Class Level</option>');
		}

	})
}
async function LoadClassCategory() {
	var ClassLevel = $("#ClassLevel").val()
	await fetch(`../api/ClassInfo/GetAllClassCategory?Level=${ClassLevel}`).then((response) => {
		if (response.status == 200) {

			$("#ClassCategory").empty()
			$('#ClassCategory').append('<option selected disabled value="">Select Class Category</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#ClassCategory').append('<option value="' + data + '">' + data + '</option>');
				});

			})
		} else {
			$("#ClassCategory").empty()
			$('#ClassCategory').append('<option selected disabled value="">Select Class Category</option>');
		}

	})

}
async function LoadParents() {
	await fetch("../api/Parents/GetAllParents").then((response) => {
		if (response.status == 200) {

			$("#ParentName").empty()
			$('#ParentName').append('<option selected disabled value="">Select Parent</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#ParentName').append('<option value="' + data.ParentID + '">' + data.FirstName + " " + data.LastName + '</option>');
				});

			})
		} else {
			$("#ParentName").empty()
			$('#ParentName').append('<option selected disabled value="">Select Parent</option>');
		}

	})
}
async function GetClassByLevel() {
	var CurrentLevel = $("#ClassLevel").val();

	await fetch(`../api/StudentClass/GetClassByLevel?Level=${CurrentLevel}`).then((response) => {
		if (response.status == 200) {

			$("#CurrentClass").empty()
			$('#CurrentClass').append('<option selected disabled value="">Select Current Class</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#CurrentClass').append('<option value="' + data + '">' + data + '</option>');
				});

			})
		} else {
			$("#CurrentClass").empty()
			$('#CurrentClass').append('<option selected disabled value="">Select Current Class</option>');
		}

	})
}
async function  LoadClassLevel() {
	await fetch("../api/ClassInfo/GetAllClassLevel").then((response) => {
		if (response.status == 200) {

			$("#ClassLevel").empty()
			$('#ClassLevel').append('<option selected disabled value="">Select Class Level</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#ClassLevel').append('<option value="' + data + '">' + data + '</option>');
				});

			})
		} else {
			$("#ClassLevel").empty()
			$('#ClassLevel').append('<option selected disabled value="">Select Class Level</option>');
		}

	})
}

async function LoadAllSubjectTeacher() {

	await fetch("../api/Subjects/GetAllSubjectTeacher").then((response) => {
		if (response.status == 200) {

			$("#SubjectTeacher").empty()
			$('#SubjectTeacher').append('<option selected disabled value="">Select Subject Teacher</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					
					$('#SubjectTeacher').append('<option value="' + data.UserID + '">' + data.FirstName + "  " + data.LastName + '</option>');
				});

			})
		} else {
			$("#SubjectTeacher").empty()
			$('#SubjectTeacher').append('<option selected disabled value="">Select Subject Teacher</option>');
		}

	})

}
async function LoadAllSubjects() {
	
	const MainForm = document.getElementById("MainForm")
await	fetch("../api/Subjects/GetAllSubjects").then((response) => {
		if (response.status == 200) {

			response.json().then((data) => {
				$('#AllSubjects').DataTable({
					data: data,
					scrollY: '400px',
					scrollCollapse: true,
					paging: true,
					columns: [
						{
							"render": function (data, type, row) {
								return "<a id='btnEdit' class='btn  btn-default btn-info' style='color:white;' >Edit</a>"
							}
						},
						{ title: 'Name',data:"SubjectName" },
						{ title: 'Class Level', data: "ClassLevel" },
						{ title: 'Class Category', data: "ClassCategory" },
						
						
					
					],
				});

				$('#AllSubjects tbody').on('click', "#btnEdit", function () {

					var currentrow = $(this).closest("tr")
					var Dbdata = $('#AllSubjects').DataTable().row(currentrow).data();
					MainForm.RowID.value = Dbdata["ID"]
					MainForm.SubjectName.value = Dbdata["SubjectName"]
					$("#ClassLevel").val(Dbdata["ClassLevel"]).trigger("change")
					ReloadLoadClassCategory(Dbdata["ClassLevel"], Dbdata["ClassCategory"])
					//$("#ClassCategory").val(Dbdata["ClassCategory"]).trigger("change")
					$("#SubjectTeacher").val(Dbdata["SubjectTeacher"]).trigger("change")
				
					Showmodal()
					
				});


			})

		}
	})
}
async function ReloadLoadClassCategory(ClassLevel,ClassCategory) {

	await fetch(`../api/ClassInfo/GetAllClassCategory?Level=${ClassLevel}`).then((response) => {
		if (response.status == 200) {

			$("#ClassCategory").empty()
			$('#ClassCategory').append('<option selected disabled value="">Select Class Category</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#ClassCategory').append('<option value="' + data + '">' + data + '</option>');
				});
				$('#ClassCategory').val(ClassCategory)
			})
		} else {
			$("#ClassCategory").empty()
			$('#ClassCategory').append('<option selected disabled value="">Select Class Category</option>');
		}

	})
}
function Showmodal() {
	$("#SubjectModal").modal({ backdrop: 'static' }, "show")
}
function PreviewModal() {
	$("#PreviewPage").modal({ backdrop: 'static' }, "show")
}
function LoadAllTeachers() {

	$('#AllTeacher').DataTable({
		data: {},
		columns: [
			{ title: 'Name' },
			{ title: 'Phone Number' },
			{ title: 'Email' },
			{ title: 'Date Of Birth' },
			{ title: 'Subject' },
			{ title: '' },
		],
	});
}
function UploadImage(id, targetImage) {
	

		ImageFiles = []
		ImageFileNames = []
		var AllFiles = document.getElementById(id).files
		var filesize = parseInt(AllFiles[0].size)
		var fileName = AllFiles[0].name;
		
		var reader = new FileReader()
		reader.onload = function (e) {
		   document.getElementById(targetImage).src = e.target.result
		    ImageUrl = e.target.result;
		    var dataImage = e.target.result.split(",")[1]
		    ImageFiles.push(dataImage)
		    document.getElementById("UploadedFile").value = ImageFiles[0];
		}
		reader.readAsDataURL(AllFiles[0])
		ImageFileNames.push(AllFiles[0].name)
	
}
function LoadAllStudents() {
	
	$('#AllStudents').DataTable({
		data: {},
		columns: [
			{ title: 'Name' },
			{ title: 'Current Class' },
			{ title: 'Session Admitted' },
			{ title: 'Date Admitted' },
			{ title: 'Date Of Birth' },
			{ title: '' },
		],
	});
}


function SaveRecord() {
	const MainForm = document.getElementById("MainForm")
	const ActionHolder = document.getElementById("Action")
	ActionHolder.name = "Save"
	ActionHolder.value = "SaveRecord"
	MainForm.enctype = "multipart/form-data";
	MainForm.method = "post";
	MainForm.submit()
}