console.log("Comeco")


function checkSelect() {
    var selectElement = this;
    var myIndex = selectElement.selectedIndex;
    var selectedValue = selectElement.options[myIndex].value;
    console.log(selectedValue);

   
}

var filterStatus = document.getElementById("filter-select");
var filterOrder = document.getElementById("order-select");

filterStatus.onchange = checkSelect;
filterOrder.onchange = checkSelect;

var taskList = document.getElementById("task-list");
