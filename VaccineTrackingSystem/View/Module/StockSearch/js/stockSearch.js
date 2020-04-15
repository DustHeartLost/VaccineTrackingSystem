function createTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].num + "</td><td>" + data[i].name + "</td><td>" + data[i].unit + "</td><td>" + data[i].spec + "</td><td>" + data[i].factory + "</td><td>" + data[i].quantity + "</td><td>" + data[i].money + "</td><td>" + data[i].storeID + "</td><td class=\"need\">" + data[i].stockID + "</td><td><button onclick=\"detail(this)\"  style=\"padding:5px\">查看明细</button></td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].num + "</td><td>" + data[i].name + "</td><td>" + data[i].unit + "</td><td>" + data[i].spec + "</td><td>" + data[i].factory + "</td><td>" + data[i].quantity + "</td><td>" + data[i].money + "</td><td>" + data[i].storeID + "</td><td class=\"need\">" + data[i].stockID + "</td><td><button onclick=\"detail(this)\" style=\"padding:5px\">查看明细</button></td></tr>";
        }
    }
    $("#caption").after(html);
    var x = extra.split('+');
    $("#total").text("共" + x[0] + "页");
    $("#current").text("第" + x[1] + "页");
    $("#money").text("共" + x[2] + "元");
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

function search() {
    var tempCon = $("#searchText").val();
    if (tempCon != "") {
        $.ajax({
            type: "post",
            url: "StockSearch.aspx/Controller",//方法所在页面和方法名
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{'state':'0','data':'" + tempCon + "'}",
            success: function (data) {
                var tempT = JSON.parse(data.d);//返回的数据用data.d获取内容
                if (tempT.code == 200) {
                    clear();
                    createTable(tempT.data, tempT.extra);
                }
                else {
                    alert(tempT.data);
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    }
    else
        alert("请输入药品编号");
}

function down() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "StockSearch.aspx/GetDown",//方法所在页面和方法名
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
        url: "StockSearch.aspx/GetUp",//方法所在页面和方法名
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

function detail(obj) {
    var stockID = $(obj).closest("tr").find("td.need").text();
    window.open("Detail.aspx?stockID=" + stockID);
}