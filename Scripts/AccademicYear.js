var path = window.location.pathname;
var pageName = path.split("/").pop();
$(document).ready(function (e) {
	if (pageName.includes("Sessions")) { LoadAccademicYearTable() }
	if (pageName.includes("StudentAdmissionForm")) { LoadAccademicYear(); }
	

})

async function LoadAccademicYearTable() {

	await fetch("../api/AccademicYear/GetAllAccademicYear").then((response) => {
		if (response.status == 200) {

	
			response.json().then((data) => {
				$('#AccademicYearInfo').DataTable({
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
						{ title: 'Academic Year', data: "AcademicYear" },
						{ title: 'Current', data: "CurrentSession" },
					



					],
				});

				$('#AccademicYearInfo tbody').on('click', "#btnEdit", function () {

					var currentrow = $(this).closest("tr")
					var Dbdata = $('#AccademicYearInfo').DataTable().row(currentrow).data();
				//	MainForm.RowID.value = Dbdata["ID"]
				//	MainForm.SubjectName.value = Dbdata["SubjectName"]
			//		$("#ClassLevel").val(Dbdata["ClassLevel"]).trigger("change")
				//	ReloadLoadClassCategory(Dbdata["ClassLevel"], Dbdata["ClassCategory"])
					//$("#ClassCategory").val(Dbdata["ClassCategory"]).trigger("change")
				//	$("#SubjectTeacher").val(Dbdata["SubjectTeacher"]).trigger("change")

					ShowSetupModal()

				});

			})
		}

	})
}

async function LoadAccademicYear() {

	await fetch("../api/AccademicYear/GetCurrentAccademicYear").then((response) => {
		if (response.status == 200) {

			$("#SessionAdmitted").empty()
			$('#SessionAdmitted').append('<option selected disabled value="">Select Accademic Year</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#SessionAdmitted').append('<option value="' + data.AcademicYear + '">' + data.AcademicYear + '</option>');
				});

			})
		} else {
			$("#SessionAdmitted").empty()
			$('#SessionAdmitted').append('<option selected disabled value="">Select Accademic Year</option>');
		}

	})
}

async function UpdateAccademicYear() {
	var checked = false;
	if ($('#CurrentSession').is(":checked")) {
		checked = true;
	}
	var AccademicYear = {
	//	RowID: $("#SubjectID").val(),
		CurrentSession: checked,
		AcademicYear: $("#Accademicyear").val()
	
	}
	await fetch(`../api/AccademicYear/UpdateAccademicYear`, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json;charset=utf-8'
		},
		body: JSON.stringify(AccademicYear)
	}).then((response) => {
		if (response.status == 200) {
			if (pageName.includes("Sessions")) { LoadAccademicYearTable() }
			if (pageName.includes("StudentAdmissionForm")) { LoadAccademicYear(); }
		

		}
	})
}
function ShowSetupModal() {
	$("#AccademicYearModal").draggable()
	$("#AccademicYearModal").modal({ backdrop: 'static' }, "show")
}