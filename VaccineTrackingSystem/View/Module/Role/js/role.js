function createTable(temp,extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {

        html += "<tr class=\"dataRow\" style=\"height:60px\"><td>" + data[i].id + "</td><td>" + data[i].name + "</td><td>";
        for (var j = 0; j < 10; j++) {
            if (data[i].authority[j] == 1) {
                html += "允许</td><td>";
            } else {
                html += "拒绝</td><td>";
            }
        }
        html+=data[i].note + "</td></tr>";
    }
    $("#caption").after(html); 
    var x = extra.split('+');
    console.log(x[1]);
    $("#total").text("共"+x[0]+"页");
    $("#current").text("第"+x[1]+"页");
}

 $(document).ready(function () {
     $("#tableContainer").delegate(".dataRow", "mouseenter", function () {
            $(this).addClass("tr-mouseover");
        });
     $("#tableContainer").delegate(".dataRow", "mouseleave", function () {
            $(this).removeClass("tr-mouseover");
        });
 });
function clear() {
    $("tr").remove(".dataRow");
}

function reCreateTable(temp,extra) {
    clear();
    createTable(temp, extra);
} 