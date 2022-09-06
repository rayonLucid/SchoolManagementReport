var ItemListHeader = document.getElementsByClassName("ItemListHeader");
//const MainForm = document.getElementById("MainForm")
window.onload = function () {
    
};

$(document).ready(function (e) {
    Array.from(ItemListHeader).forEach(function (ItemListHeader) {
        ItemListHeader.addEventListener('click', MenuToggle, false);
      
    });
})

function MenuToggle(e) {
  let sublist = e.currentTarget.nextElementSibling
  var x = sublist
  if (x === null) { return; }

  var AllSublists = document.getElementsByClassName("ItemSubList");
  for (let i = 0; i < AllSublists.length; i++) {
   
      AllSublists[i].style.display = "none";
    
    
  }
 
   
 
    if (x.style.display === "flex") {
        x.style.display = "none";
    } else {
        x.style.display = "none";
        x.style.display = "flex";
    }
}