function createTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\"></td><td>" + data[i].cagNum + "</td><td>" + data[i].name + "</td><td>" + data[i].kind + "</td><td>" + data[i].spec + "</td><td class=\"data\">" + data[i].id + "</td><td class=\"data\">" + data[i].stockID + "</td><td class=\"data\">" + data[i].batchNum + "</td><td class=\"data\">" + data[i].date + "</td><td class=\"data\">" + data[i].quantity + "</td><td class=\"data\">" + data[i].price + "</td><td class=\"data\">" + data[i].note + "</td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\"></td><td>" + data[i].cagNum + "</td><td>" + data[i].name + "</td><td>" + data[i].kind + "</td><td>" + data[i].spec + "</td><td class=\"data\">" + data[i].id + "</td><td class=\"data\">" + data[i].stockID + "</td><td class=\"data\">" + data[i].batchNum + "</td><td class=\"data\">" + data[i].date + "</td><td class=\"data\">" + data[i].quantity + "</td><td class=\"data\">" + data[i].price + "</td><td class=\"data\">" + data[i].note + "</td></tr>";
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
    $("#total").text("共0页");
    $("#current").text("第0页");
}


function down() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Destory.aspx/GetDown",//方法所在页面和方法名
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
        url: "Destory.aspx/GetUp",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                createTable(temp.data,temp.extra);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function destoryAll() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Destory.aspx/DestoryAllRecord",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200)
            { clear(); alert("销毁成功"); }
            else alert(temp.data);
        },
        error: function (err) {
            alert(err);
        }
    });
}
function destory() {
    var list = [];
    $(":checkbox").each(function () {
        if ($(this).prop("checked")) {
            var temp = "";
            $(this).closest("tr").find("td.data").each(function () {
                temp += $(this).text() + "@@";
            });
            temp1 = temp.split("@@");
            var obj = new Object();
            obj.id = temp1[0];
            obj.stockID = temp1[1];
            obj.batchNum = temp1[2];
            obj.date = temp1[3];
            obj.quantity = temp1[4];
            obj.price = temp1[5];
            obj.note = temp1[6];
            list.push(obj);
        }
    });
    if (list.length==0) {
        return;
    }
    $.ajax({
        type: "post", //要用post方式                 
        url: "Destory.aspx/DestoryRecord",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: "{'temp':'" + JSON.stringify(list) + "'}",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                alert("销毁成功");
                clear();
                if (temp.data != "null" && temp.extra != "null")
                    createTable(temp.data, temp.extra);
                else {
                    $("#total").text("共0页");
                    $("#current").text("第0页");
                }
            }
            else alert(temp.data);
        },
        error: function (err) {
            alert(err);
        }
    });
}