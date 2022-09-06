$(document).ready(function (e) {
	$('#NotificationTable').DataTable({
		data: {},
		retrieve: true,
		order: [[1, 'asc']],
		bSort: false,
		columns: [

			{
				"render": function (data, type, row) {

					var dt = new Date(row.StartDate)
					var notdate = dt.toLocaleDateString('en-us', { weekday: "long", year: "numeric", month: "short", day: "numeric" })
					var pdate = ""
					if (row.Posted == true) {
						var pdt = new Date(row.PostedDate)
						pdate = pdt.toLocaleDateString('en-us', { weekday: "long", year: "numeric", month: "short", day: "numeric" })
					} else {
						pdate = "Not Yet Posted"
					}

					return `<div id="NotificationBox">
              
                <div id="NotificationInfo" >
               <div class="modal-header">
               <h3 class="NoficationDate" style="width:auto">${notdate}</h3>
                 </div>

                 <div class=" panel-body">
                 <p class="NoficationDetail" style="text-align:left;padding:0em 1em">
                 ${row.Narrative}
                 </p>
                  </div>
                 <div class=" panel-footer">
                <h4 class="NoficationSignature" style="font-family:'Lucida Calligraphy';bottom:0px;position:relative;">${row.Signatory}</h4>

                </div>
              <h4 class="NoficationSignature" style="font-family:'Lucida Calligraphy';bottom:0px;position:relative;">Posted On : ${pdate}</h4>

                  </div>

                </div>`
				}
			},
			{
				render: function (data, type, row) {
					return "<a id='btnEdit' class='btn  btn-default btn-info' style='color:white;' >Edit</a>"
				}
			},



		],
	});
	LoadNotifications();

})

async function LoadNotifications() {
	const MainForm = document.getElementById("MainForm")
	await fetch("../api/Notification/GetNotification").then((response) => {
		if (response.status == 200) {

			response.json().then((data) => {
				$('#NotificationTable').DataTable().destroy()
				$('#NotificationTable').DataTable({
					data: data,
					retrieve: true,
					order: [[1, 'asc']],
					bSort: false,
					columnDefs: [
						{ "width": "96%", "targets": 0 }
					],
					columns: [
						
						{
							
						
							"render": function (data, type, row) {
							
								var dt = new Date(row.StartDate)
								var notdate = dt.toLocaleDateString('en-us', { weekday: "long", year: "numeric", month: "short", day: "numeric" })
								var pdate =""
								if (row.Posted == true) {
									var pdt = new Date(row.PostedDate)
									 pdate = pdt.toLocaleDateString('en-us', { weekday: "long", year: "numeric", month: "short", day: "numeric" })
								} else {
									 pdate ="Not Yet Posted"
								}
							
								return `<div id="NotificationBox">
              
                <div id="NotificationInfo" >
               <div class="modal-header">
               <h3 class="NoficationDate" style="width:auto">${notdate}</h3>
                 </div>

                 <div class=" panel-body">
                 <p class="NoficationDetail" style="text-align:left;padding:0em 1em">
                 ${row.Narrative}
                 </p>
                  </div>
                 <div class=" panel-footer">
                <h4 class="NoficationSignature" style="font-family:'Lucida Calligraphy';bottom:0px;position:relative;">${row.Signatory}</h4>

                </div>
              <h4 class="NoficationSignature" style="font-family:'Lucida Calligraphy';bottom:0px;position:relative;">Posted On : ${pdate}</h4>

                  </div>

                </div>`
							}
						},
						{
							render: function (data, type, row) {
								return "<a id='btnEdit' class='btn  btn-default btn-info' style='color:white;' >Edit</a>"
							}
						},
						


					],
				});

				$('#NotificationTable tbody').on('click', "#btnEdit", function () {

					var currentrow = $(this).closest("tr")
					var Dbdata = $('#NotificationTable').DataTable().row(currentrow).data();
					MainForm.RowID.value = Dbdata["ID"]
					MainForm.Narration.value = Dbdata["Narrative"]

					var dt = new Date(Dbdata["StartDate"])
					let ye = new Intl.DateTimeFormat('en', { year: 'numeric' }).format(dt);
					let mo = new Intl.DateTimeFormat('en', { month: '2-digit' }).format(dt);
					let da = new Intl.DateTimeFormat('en', { day: '2-digit' }).format(dt);
					var Startdate =`${ye}-${mo}-${da}`;

					
					var edt = new Date(Dbdata["EndDate"])
					let yer = new Intl.DateTimeFormat('en', { year: 'numeric' }).format(edt);
					let mon = new Intl.DateTimeFormat('en', { month: '2-digit' }).format(edt);
					let day = new Intl.DateTimeFormat('en', { day: '2-digit' }).format(edt);
					var Enddate = `${yer}-${mon}-${day}`;
					

					MainForm.startDate.value = Startdate ;
					MainForm.EndDate.value = Enddate
					MainForm.btnPost.disabled = false;
					MainForm.signatory.value = Dbdata["Signatory"]
					//MainForm.Address.value = Dbdata["ResidentialAddress"]
					//$("#Gender").val(Dbdata["Gender"]).trigger("change")
					//$("#SubjectTeacher").val(Dbdata["SubjectTeacher"]).trigger("change")
				//	LoadTeacherSubject(MainForm.RowID.value)


				});


			})

		}
	})
}
async function PostRecord() {
	const MainForm = document.getElementById("MainForm")

		var NotificationRec = {
			ID: $("#RowID").val(),
			Signatory: $("#signatory").val(),
			EndDate: $("#EndDate").val(),
			StartDate: $("#startDate").val(),
			Narrative: $("#Narration").val(),
		}
	await fetch(`../api/Notification/PostNotification`,
		{
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
		body: JSON.stringify(NotificationRec)
		}).then((response) => {
			if (response.status == 200) {
				LoadNotifications()
			

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