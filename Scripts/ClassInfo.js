$(document).ready(function (e) {
	
	$('#ClassTeacher').select2({ selectOnClose: true})
	$('#ClassInfo').DataTable({
		data: {},
		retrieve: true,
		order: [[1, 'asc']],
		bSort: false,
		columns: [
			{
			title:"Name"
			
			},
			{ title: 'Class Level' },
			{ title: 'Teacher' },
		
			{ title: 'Population' },
			{
				render: function (data, type, row) {
					return "<a id='btnEdit' class='btn  btn-default btn-primary' style='color:white;' >Edit</a>"
				}
			}


		]
	})

	

	LoadClasses()
	LoadTeachers()
	LoadClassLevel()
})
async function LoadTeachers() {
	await fetch("../api/ClassInfo/GetAllTeachers").then((response) => {
		if (response.status == 200) {

			$("#ClassTeacher").empty()
			$('#ClassTeacher').append('<option selected disabled value="">Select Class Teacher</option>');
			response.json().then((Jsondata) => {
				Jsondata.map(function (data) {
					$('#ClassTeacher').append('<option value="' + data.UserID + '">' + data.FirstName + " " + data.LastName + '</option>');
				});

			})
		} else {
			$("#ClassTeacher").empty()
			$('#ClassTeacher').append('<option selected disabled value="">Select Class Teacher</option>');
		}

	})
}
async function LoadClasses() {
	const MainForm = document.getElementById("MainForm")
	await fetch(`../api/ClassInfo/GetAllClasses`).then((response) => {
		if (response.status == 200) {

			response.json().then((data) => {
				$('#ClassInfo').DataTable().destroy()
				$('#ClassInfo').DataTable({
					data: data,
					scrollY: '400px',
					scrollCollapse: true,
					paging: true,
					columns: [
						{
							title: "Name",data: 'Name'

						},
						{ title: 'Class Level', data: 'ClassLevel'},
						{ title: 'Teacher', data: 'Teacher' },

						{ title: 'Population', data: 'Population' },
						{
							render: function (data, type, row) {
								return "<a id='btnEdit' class='btn  btn-default btn-primary' style='color:white;' >Edit</a>"
							}
						}


					]
				});

				$('#ClassInfo tbody').on('click', "#btnEdit", function () {

					var currentrow = $(this).closest("tr")
					var Dbdata = $('#ClassInfo').DataTable().row(currentrow).data();
					MainForm.ClassTeacher.value = Dbdata["Teacher"]
					MainForm.ClassName.value = Dbdata["Name"]
					MainForm.Population.value = Dbdata["Population"]
					MainForm.ClassLevel.value = Dbdata["ClassLevel"]
					
					Showmodal()



				});


			})

		}
	})
}


async function LoadClassLevel() {
	await fetch(`../api/ClassInfo/GetAllClassLevel`).then((response) => {
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

function Showmodal() {
	$("#ClassModal").draggable()
	$("#ClassModal").modal({ backdrop: 'static' }, "show")
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