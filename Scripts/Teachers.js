$(document).ready(function (e) {
	LoadAllTeachers()
	LoadSubjectLevel()
	$('#TeacherSubjects').DataTable({
		data: {},
		retrieve: true,
		order: [[1, 'asc']],
		bSort: false,
		columns: [
			{ data: 'SubjectName' },
			{ data: 'ClassLevel' },
			{ data: 'ClassCategory' },
			{
				render: function (data, type, row) {
					return "<a id='btnEdit' class='btn  btn-default btn-primary' style='color:white;' >Edit</a>"
				}
			}


		]})
})

async function LoadAllTeachers() {

	const MainForm = document.getElementById("MainForm")
	await fetch("../api/Teachers/GetAllTeachers").then((response) => {
		if (response.status == 200) {

			response.json().then((data) => {
				$('#AllTeachers').DataTable({
					data: data,
					columns: [
						{
							render: function (data, type, row) {
					return "<a id='btnEdit' class='btn  btn-default btn-info' style='color:white;' >Edit</a>"
							}
						},
						{
							title: 'Name',
							data: "FirstName",
							"render": function (data, type, row) {
								return row.FirstName + " " + row.MiddleName + " " + row.LastName
							}
						},
						{ title: 'Phone Number', data: "Phone" },
						{ title: 'Email', data: "Email" },


					],
				});

				$('#AllTeachers tbody').on('click', "#btnEdit", function () {

					var currentrow = $(this).closest("tr")
					var Dbdata = $('#AllTeachers').DataTable().row(currentrow).data();
					MainForm.RowID.value = Dbdata["RowID"]
					MainForm.UserID.value = Dbdata["UserID"]
					MainForm.FirstName.value = Dbdata["FirstName"]
					MainForm.MiddleName.value = Dbdata["MiddleName"]
					MainForm.LastName.value = Dbdata["LastName"]
					MainForm.Email.value = Dbdata["Email"]
					MainForm.Phone.value = Dbdata["Phone"]
					MainForm.Address.value = Dbdata["ResidentialAddress"]
					MainForm.IsActive.checked = (Dbdata["IsActive"] == true)
					MainForm.IsSubjectTeacher.checked = (Dbdata["IsSubjectTeacher"] == true)
					MainForm.IsClassTeacher.checked = (Dbdata["IsClassTeacher"] == true)
					$("#Gender").val(Dbdata["Gender"]).trigger("change")
					//$("#SubjectTeacher").val(Dbdata["SubjectTeacher"]).trigger("change")
					LoadTeacherSubject(MainForm.UserID.value)
					

				});


			})

		}
	})
}

async function UpdateRecord() {

	var TeachersSUbject = {
		ID: $("#SubjectID").val(),
		ClassLevel: $("#ClassLevel").val(),
		ClassCategory: $("#ClassCategory").val(),
		SubjectName: $("#Subjects").val(),
		SubjectTeacher: MainForm.UserID.value
	}
	await fetch(`../api/Teachers/UpdateTeacherSubject`, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json;charset=utf-8'
		},
		body: JSON.stringify(TeachersSUbject)
	}).then((response) => {
		if (response.status == 200) {
			LoadTeacherSubject(MainForm.UserID.value)
			//$('#TeacherSubjects').DataTable().ajax.reload();

		}
	})
}

async function LoadTeacherSubject(Username) {
	await fetch(`../api/Teachers/GetAllTeacherSubject?Username=${Username}`).then((response) => {
		if (response.status == 200) {
			response.json().then((data) => {
				$('#TeacherSubjects').DataTable().destroy()
				$('#TeacherSubjects').DataTable({
					data: data,
					retrieve: true,
					order: [[1, 'asc']],
					bSort: false,
					columns: [
						{  data: 'SubjectName' },
						{  data: 'ClassLevel' },
						{  data: 'ClassCategory' },
						{
							render: function (data, type, row) {
								return "<a id='btnEdit' class='btn  btn-default btn-primary' style='color:white;' >Edit</a>"
							}
						}
						

					],
				});

				$('#TeacherSubjects tbody').on('click', "#btnEdit", function () {
					ShowSubjectModal("Edit")
					var currentrow = $(this).closest("tr")
					var Dbdata = $('#TeacherSubjects').DataTable().row(currentrow).data();
					MainForm.SubjectID.value = Dbdata["ID"]
					$("#ClassLevel").val(Dbdata["ClassLevel"]).trigger("change")
					ReloadGetClassCategory(Dbdata["ClassLevel"], Dbdata["ClassCategory"])
					ReloadSubject(Dbdata["ClassLevel"], Dbdata["ClassCategory"], Dbdata["SubjectName"])

				});
				Showmodal()
			})
		}
	})
}

async function ReloadSubject(ClassLevel, ClassCategory, SubjectName) {


	await fetch(`../api/Teachers/GetSubjectByLevel?Level=${ClassLevel}&ClassCategory=${ClassCategory}`).then((response) => {
		if (response.status == 200) {

			$("#Subjects").empty()
			$('#Subjects').append('<option selected disabled value="">Select Subject</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#Subjects').append('<option value="' + data + '">' + data + '</option>');
				});
				$("#Subjects").val(SubjectName)
			})
		} else {
			$("#Subjects").empty()
			$('#Subjects').append('<option selected disabled value="">Select Subject</option>');
		}

	})
}
async function ReloadGetClassCategory(ClassLevel, ClassCategory) {

	var ClassLevel = $("#ClassLevel").val();
	await fetch(`../api/Teachers/GetClassCategory?Level=${ClassLevel}`).then((response) => {
		if (response.status == 200) {

			$("#ClassCategory").empty()
			$('#ClassCategory').append('<option selected disabled value="">Select Class Category</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#ClassCategory').append('<option value="' + data + '">' + data + '</option>');
				});
				$("#ClassCategory").val(ClassCategory)
			})
		} else {
			$("#ClassCategory").empty()
			$('#ClassCategory').append('<option selected disabled value="">Select Class Category</option>');
		}

	})


}
function ShowSubjectModal(Action) {
	if (Action == "Edit") {
		$("#btnUpdate").html("Update");
	} else {
		$("#btnUpdate").html("Add");
	}
	
	
	$("#TeacherSubjectModal").draggable()
	$("#TeacherSubjectModal").modal({ backdrop: 'static' }, "show")
}
function Showmodal() {
	$("#TeacherModal").draggable()
	$("#TeacherModal").modal({ backdrop: 'static' }, "show")
}

async function GetClassCategory() {

	var ClassLevel = $("#ClassLevel").val();
	await fetch(`../api/Teachers/GetClassCategory?Level=${ClassLevel}`).then((response) => {
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

async function GetClassByLevel() {
	var ClassLevel = $("#ClassLevel").val();
	var ClassCategory = $("#ClassCategory").val();

	await fetch(`../api/Teachers/GetSubjectByLevel?Level=${ClassLevel}&ClassCategory=${ClassCategory}`).then((response) => {
		if (response.status == 200) {

			$("#Subjects").empty()
			$('#Subjects').append('<option selected disabled value="">Select Subject</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#Subjects').append('<option value="' + data + '">' + data + '</option>');
				});

			})
		} else {
			$("#Subjects").empty()
			$('#Subjects').append('<option selected disabled value="">Select Subject</option>');
		}

	})
}
async function LoadSubjectLevel() {
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


function SaveRecord() {
	const MainForm = document.getElementById("MainForm")
	const ActionHolder = document.getElementById("Action")
	ActionHolder.name = "Save"
	ActionHolder.value = "SaveRecord"
	MainForm.enctype = "multipart/form-data";
	MainForm.method = "post";
	MainForm.submit()
}