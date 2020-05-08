function createTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td><input class=\"checkBox\"  type=\"checkbox\"  style=\"padding: 5px;\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td>" + data[i].stockID + "</td><td>" + data[i].cagNum + "</td><td>" + data[i].name + "</td><td>" + data[i].kind + "</td><td>" + data[i].spec + "</td><td>" + data[i].batchNum + "</td><td>";
            html += data[i].date + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td><td class=\"editTd\"></td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td><input class=\"checkBox\"  type=\"checkbox\"  style=\"padding: 5px;\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td>" + data[i].stockID + "</td><td>" + data[i].cagNum + "</td><td>" + data[i].name + "</td><td>" + data[i].kind + "</td><td>" + data[i].spec + "</td><td>" + data[i].batchNum + "</td><td>";
            html += data[i].date + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td><td class=\"editTd\"></td></tr>";
        }

    }
    $("#caption").after(html);
    var x = extra.split('+');
    console.log(x[1]);
    $("#total").text("共" + x[0] + "页");
    $("#current").text("第" + x[1] + "页");
    $(".checkBox").show();
    $("#cancelUpdate").show();
    $("#confirmUpdate").show();
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

function reCreateTable(temp, extra) {
    clear();
    createTable(temp, extra);
}


function clickCheck(obj) {
    $(":checkbox").each(function () {
        $(this).prop("checked", false);   //选中，不选中 是false        
    });
    $(obj).prop("checked", true);

    $(".edit").each(function () {
        $(this).attr("disabled", true);
    });
    $(".editTd").closest("tr").find("td").each(function () {
        $(this).attr("contenteditable", false);
    });

    $(obj).closest("tr").find("select").each(function () {
        $(this).attr("disabled", false);
    });
    $(obj).closest("tr").find("td.editTd").each(function () {
        $(this).attr("contenteditable", true);
    });
}

function down() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Indetail.aspx/GetDown",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                reCreateTable(temp.data, temp.extra);
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
        url: "Indetail.aspx/GetUp",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200)
                reCreateTable(temp.data, temp.extra);
        },
        error: function (err) {
            alert(err);
        }
    });
}


function cancelUpdate() {
    clear();
    $.ajax({
        type: "post", //要用post方式                 
        url: "Indetail.aspx/GetALL",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                reCreateTable(temp.data, temp.extra);
            } else {
                alert(temp.data);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
    $(".checkBox").show();
    $("#cancelUpdate").show();
    $("#confirmUpdate").show();
}

function confirmUpdate() {
    $(":checkbox").each(function () {
        if ($(this).prop("checked")) {
            var temp = "";
            $(this).closest("tr").find("td").each(function () {
                temp += $(this).text() + "@@";
            });
            temp1 = temp.split("@@");
            if (temp1[11] == "") { alert("请输入出库数量"); return; };
            if (parseInt(temp1[7]) > parseInt(temp1[5])) { alert("出库数量超过明细记录数量"); return; };
            var data1 = new Object();  
            data1.id = temp1[1];
            data1.stockID = temp1[2];
            data1.batchNum = temp1[7];
            data1.date = temp1[8];
            data1.quantity = parseInt(temp1[11])+"";
            data1.price = temp1[10];
            $.ajax({
                type: "post", //要用post方式                 
                url: "Indetail.aspx/Update",//方法所在页面和方法名
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{'temp':'" + JSON.stringify(data1) + "'}",
                success: function (data) {
                    var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
                    alert(temp.data);
                    cancelUpdate();
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    });
}

function returnOutflow() {
    window.location.href = "Outflow.aspx";
}
