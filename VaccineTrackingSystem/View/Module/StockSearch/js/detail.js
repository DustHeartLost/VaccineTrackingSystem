function createTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "";
    alert("detail");
    for (var i = 0; i < data.length; i++) {
        alert("xsxds");
        if (data[i].color != null && data[i].color != "") {
            alert(data[i].color);
            html += "<tr class=\"dataRow\" style=\"height:50px;background-color:#" + data[i].color +"\"><td>" + data[i].id + "</td><td>" + data[i].batchNum + "</td><td>" + data[i].date + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td></tr>";
        }
        else {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].batchNum + "</td><td>" + data[i].date + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].batchNum + "</td><td>" + data[i].date + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td></tr>";
            }
        }
    }
    $("#caption").after(html);
    var x = extra.split('+');
    $("#total").text("共" + x[0] + "页");
    $("#current").text("第" + x[1] + "页");
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
    $("tr.dataRow").remove();
    $("tr.dataRow2").remove();
}


function down() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Detail.aspx/GetDown",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                createTable(temp.data, temp.extra);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function up() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Detail.aspx/GetUp",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                createTable(temp.data, temp.extra);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}