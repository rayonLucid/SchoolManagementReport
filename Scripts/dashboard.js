const StudentFile = document.getElementById("ImportStudents")
const Admin = document.getElementById("Admin")
const TeacherFile = document.getElementById("ImportTeachers")
const ActionHolder = document.getElementById("ActionHolder")
const ImportSubjects = document.getElementById("ImportSubjects")
const ImportResults = document.getElementById("ImportResults")

$(document).ready(function (e) {
	if (Admin == null || Admin == undefined) {

		ImportResults.addEventListener("change", function () {
			const MainForm = document.getElementById("MainForm")
			ActionHolder.name = "Import"
			ActionHolder.value = "ImportResults"
			MainForm.enctype = "multipart/form-data";
			MainForm.method = "post";
			MainForm.submit()
		});
	} else {
		StudentFile.addEventListener("change", function () {
			const MainForm = document.getElementById("MainForm")
			ActionHolder.name = "Import"
			ActionHolder.value = "ImportStudents"
			MainForm.enctype = "multipart/form-data";
			MainForm.method = "post";
			MainForm.submit()
		});

		TeacherFile.addEventListener("change", function () {
			const MainForm = document.getElementById("MainForm")
			ActionHolder.name = "Import"
			ActionHolder.value = "ImportTeacher"
			MainForm.enctype = "multipart/form-data";
			MainForm.method = "post";
			MainForm.submit()
		});
		ImportSubjects.addEventListener("change", function () {
			const MainForm = document.getElementById("MainForm")
			ActionHolder.name = "Import"
			ActionHolder.value = "ImportSubject"
			MainForm.enctype = "multipart/form-data";
			MainForm.method = "post";
			MainForm.submit()
		});
	}



})