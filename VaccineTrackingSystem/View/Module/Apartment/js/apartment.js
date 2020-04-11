function createTable(temp) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].num + "</td><td>" + data[i].name + "</td><td>";
            html += data[i].note + "</td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].num + "</td><td>" + data[i].name + "</td><td>";
            html += data[i].note + "</td></tr>";
        }
       
    }
    $("#caption").after(html);

}


$(document).ready(function () {
    $("#tableContainer").delegate(".dataRow", "mouseenter", function () {
        $(this).addClass("tr-mouseover");
    });
    $("#tableContainer").delegate(".dataRow", "mouseleave", function () {
        $(this).removeClass("tr-mouseover");
    });
    $("#tableContainer").delegate(".dataRow2", "mouseenter", function () {
        $(this).addClass("tr-mouseover");
    });
    $("#tableContainer").delegate(".dataRow2", "mouseleave", function () {
        $(this).removeClass("tr-mouseover");
    });
});

function clear() {
    $("tr").remove(".dataRow");
    $("tr").remove(".dataRow2");
}



function reCreateTable(temp){
    clear();
    createTable(temp);
} 

function addRecord() {
    html = "<tr class=\"dataRow\" style=\"height:50px\"><td> </td><td contentEditable= \"true \"> </td><td> </td><td> </td></tr>";
    
}
