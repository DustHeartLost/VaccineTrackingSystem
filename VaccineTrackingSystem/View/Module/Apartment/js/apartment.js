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
    $("tr").remove(".dataRow3");
}



function reCreateTable(temp){
    clear();
    createTable(temp);
} 


function addRecord() { 
    html = "<tr id=\"newOne\" class=\"dataRow3\"  style=\"height:50px;width:130px\"><td>请依次填充id之后的内容 </td><td class=\"dbclicktd\"> </td><td class=\"dbclicktd\"> </td><td class=\"dbclicktd\"> </td></tr>";
    $("#caption").after(html);
    $(".dataRow3").find(".dbclicktd").bind("click", function () {
        var inputNum = "<input type='text' id= 'aptNum' style='height:35px;' value=" + $(this).text() + " >";
        $(this).text("");
        $(this).append(inputNum);
        $("#aptNum").focus();
        $("input").blur(function () {
            if ($(this).val() == "") {
                $(this).remove();
            } else {
                $(this).closest("td").text($(this).val());
            }
        });
    });
}