﻿$(document).ready(function () {
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

function add() {
    $("#add").hide();
    $("#confirmAdd").show();
    $("#concelAdd").show();

    addRecord();
}

function concelAdd() {
    $("#add").show();
    $("#confirmAdd").hide();
    $("#concelAdd").hide();
    $("tr").remove(".dataRow");
}

function addRecord() {
    html = "<tr id=\"newOne\" class=\"dataRow\"  style=\"height:50px;width:130px\"><td></td><td><select id=\"cagNum\"></select></td>";
    html += "<td contentEditable=\"true\" class=\"editTd\"></td><td contentEditable=\"true\" class=\"editTd\"></td><td contentEditable=\"true\" class=\"editTd\"></td></tr>";
    $("#caption").after(html);
    $.ajax({
        type: "post", //要用post方式                 
        url: "Inflow.aspx/GetData",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                $("#cagNum").html(createOption(temp.data, ""));
            } else {
                alert(temp.data);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function confirmAdd() {
    var temp = "";
    temp += $("tr.dataRow").find("#cagNum").find("option:selected").text() + "@@"; 
    $("tr.dataRow").find("td.editTd").each(function () {
        temp += $(this).text() + "@@";
    });
    temp1 = temp.split("@@");
    if (temp1[0] == "") { alert("请输入药品编号"); return; }
    if (temp1[1] == "") { alert("请输入数量"); return; }
    if (temp1[2] == "") { alert("请输入单价"); return; }
    if (temp1[3] == "") { alert("请输入批号"); return; }   
    var data1 = new Object();
    data1.id = 0;
    data1.cagNum = temp1[0];
    data1.quantity = temp1[1];
    data1.price = temp1[2];
    data1.batchNum = temp1[3];
    $.ajax({
        type: "post", //要用post方式                 
        url: "Inflow.aspx/Insert",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: "{'temp':'" + JSON.stringify(data1) + "'}",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            alert(temp.data);
            $("#add").show();
            $("#confirmAdd").hide();
            $("#concelAdd").hide();
        },
        error: function (err) {
            alert(err);
        }
    });
    
}

function createOption(data, value) {
    var temp = JSON.parse(data);
    var result = "";
    for (var i = 0; i < temp.length; i++) {
        if (temp[i] != value)
            result += "<option>" + temp[i] + "</option>"
    }
    return result;
}