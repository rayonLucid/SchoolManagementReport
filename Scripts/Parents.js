$(document).ready(function (e) {

	$('#ParentsInfo').DataTable({
		data: {},
		retrieve: true,
		order: [[1, 'asc']],
		bSort: false,
		columns: [
			{
				data: 'FirstName',
				render: function (data, type, row) {
					return row.FirstName + " " + row.MiddleName + " " + row.LastName
				}
			},
			{ data: 'Phone' },
			{ data: 'Email' },
			{ data: 'IsActive' },
			{
				render: function (data, type, row) {
					return "<a id='btnEdit' class='btn  btn-default btn-primary' style='color:white;' >Edit</a>"
				}
			}


		]
	})

	$('#ChildrenInfo').DataTable({
		data: {},
		retrieve: true,
		order: [[1, 'asc']],
		bSort: false,
		columns: [
			//{
			//	render: function (data, type, row) {
			//		return "<a id='btnEdit' class='btn  btn-default btn-info' style='color:white;' >Edit</a>"
			//	}
			//},
			{
				render: function (data, type, row) {
					return `<img id='StudentImg'  src=${row.ImageUrl} style='border-radius:100%;background-color:#808080'/>`
				}
			},
			{

				"render": function (data, type, row) {
					return row.FirstName + " " + row.MiddleName + " " + row.LastName
				}
			},
			{ title: 'Admission No', data: "AdmissionID" },
			{ title: 'Class Teacher', data: "ClassTeacher" },
			{ title: 'Current Class', data: "CurrentClass" },



		],
	});

	LoadParents()
	
})

async function LoadChildren(ParentID) {
	const MainForm = document.getElementById("MainForm")
	await fetch(`../api/Parents/GetAllChildren?ParentID=${ParentID}`).then((response) => {
		if (response.status == 200) {

			response.json().then((data) => {
				$('#ChildrenInfo').DataTable().destroy()
				$('#ChildrenInfo').DataTable({
					data: data,
					columns: [
						
						{
							render: function (data, type, row) {
								return `<img id='StudentImg'  src=${row.ImageUrl} style='border-radius:100%;background-color:#808080'/>`
							}
						},
						{
						title:"Name",
							render: function (data, type, row) {
								return row.FirstName + " " + row.MiddleName + " " + row.LastName
							}
						},
						{ title: 'Admission No', data: "AdmissionID" },
						{ title: 'Class Teacher', data: "ClassTeacher" },
						{ title: 'Current Class', data: "CurrentClass" },
						
						{
							render: function (data, type, row) {
								return "<a id='btnEdit' class='btn  btn-default btn-info' style='color:white;' >View</a>"
							}
						},

					],
				});

				$('#ChildrenInfo tbody').on('click', "#btnEdit", function () {

					var currentrow = $(this).closest("tr")
					var Dbdata = $('#ChildrenInfo').DataTable().row(currentrow).data();
					MainForm.ClassTeacher.value = Dbdata["ClassTeacher"]
					MainForm.CSessionAdmitted.value = Dbdata["SessionAdmitted"]
					MainForm.CFirstName.value = Dbdata["FirstName"]
					MainForm.CMiddleName.value = Dbdata["MiddleName"]
					MainForm.CLastName.value = Dbdata["LastName"]
					MainForm.CDOB.value = new Date(Dbdata["DOB"]).toLocaleDateString('en-us', { year: "numeric", month: "short", day: "numeric" })
					MainForm.CAdmissionDate.value = new Date(Dbdata["AdmissionDate"]).toLocaleDateString('en-us', { year: "numeric", month: "short", day: "numeric" })
					MainForm.CResidentialAddress.value = Dbdata["ResidentialAddress"]
					MainForm.Gender.value = Dbdata["Gender"]
					MainForm.CurrentClass.value = Dbdata["CurrentClass"]
					ShowChildmodal()
					


				});


			})

		}
	})
}
async function LoadParents() {
	const MainForm = document.getElementById("MainForm")
	await fetch("../api/Parents/GetAllParents").then((response) => {
		if (response.status == 200) {

			response.json().then((data) => {
				$('#ParentsInfo').DataTable().destroy()
				$('#ParentsInfo').DataTable({
					data: data,
					scrollY: '400px',
					scrollCollapse: true,
					paging: true,
					columns: [
						{
							render: function (data, type, row) {
								return "<a id='btnEdit' class='btn  btn-default btn-info' style='color:white;' >Edit</a>"
							}
						},
						{
							title: 'Name',
						
							"render": function (data, type, row) {
								return row.FirstName + " " + row.MiddleName + " " + row.LastName
							}
						},
						{ title: 'Phone Number', data: "Phone" },
						{ title: 'Email', data: "Email" },


					],
				});

				data.map(function (data) {
					if (data.ParentID.length > 0) {
						LoadChildren(data.ParentID)
					}
					
				});
				$('#ParentsInfo tbody').on('click', "#btnEdit", function () {

					var currentrow = $(this).closest("tr")
					var Dbdata = $('#ParentsInfo').DataTable().row(currentrow).data();
					MainForm.RowID.value = Dbdata["RowID"]
					MainForm.UserID.value = Dbdata["UserID"]
					MainForm.FirstName.value = Dbdata["FirstName"]
					MainForm.MiddleName.value = Dbdata["MiddleName"]
					MainForm.LastName.value = Dbdata["LastName"]
					MainForm.Email.value = Dbdata["Email"]
					MainForm.Phone.value = Dbdata["Phone"]
					MainForm.ResidentialAddress.value = Dbdata["ResidentialAddress"]
					MainForm.IsActive.checked = (Dbdata["IsActive"] == true)
					Showmodal()
				//	LoadTeacherSubject(MainForm.UserID.value)


				});


			})

		}
	})
}
function ShowChildmodal() {
	$("#Childmodal").draggable()
	$("#Childmodal").modal({ backdrop: 'static' }, "show")
}
function Showmodal() {
	$("#ParentModal").draggable()
	$("#ParentModal").modal({ backdrop: 'static' }, "show")
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