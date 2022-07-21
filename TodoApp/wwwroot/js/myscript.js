const addBtn = document.querySelector(".AddFormButton");
const inputBox = document.querySelector(".addInput");

// activate the add form button
addBtn.onClick = () =>{

  let userEnteredValue = inputBox.value; // getting user's entered value
  localStorage.setItem("addInput", userEnteredValue);
  document.getElementById("addFormInput").placeholder = localStorage.getItem("addInput");

}

// assing the value for title on add form
function assingLocalStorage() {

  let userEnteredValue = inputBox.value; // getting user's entered value
  localStorage.setItem("addInput", userEnteredValue);
  document.getElementById("addFormInput").placeholder = localStorage.getItem("addInput");
  document.getElementById("addFormInput").value = localStorage.getItem("addInput");

}

function callTwoFunction (){ 
  assingLocalStorage();
  openForm();
}
function openForm() {
  document.getElementById("AddForm").style.display = "block";
  
}

function closeForm() {
  document.getElementById("AddForm").style.display = "none";
}

$(function () {
  $('[data-toggle="popover"]').popover()
})