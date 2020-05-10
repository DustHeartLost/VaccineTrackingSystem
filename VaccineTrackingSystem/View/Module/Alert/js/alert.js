function createTable(temp) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) 
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" style=\"padding: 5px;\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].days + "</td><td class=\"editTd2\">" + data[i].color + "</td><td class=\"demo\" style=\"background: #"+data[i].color+"\"></td></tr>";
        else 
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" style=\"padding: 5px;\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].days + "</td><td class=\"editTd2\">" + data[i].color + "</td><td class=\"demo\" style=\"background: #" + data[i].color +"\"></td></tr>";
    }
    $("#caption").after(html);
    $(".checkBox").hide();
    $("#showAll").hide();
}

var global;

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

function reCreateTable(temp) {
    clear();
    createTable(temp);
}

function addRecord() {
    var html = "<tr id=\"newOne\" class=\"dataRow3\" style=\"height:50px\"><td></td><td></td><td id= \"daysTd\" contentEditable=\"true\"></td><td id=\"colorTd\" contentEditable=\"true\"></td><td  class=\"demo\"></td></tr>";
    $("#caption").after(html);
    $("#colorTd").bind('input propertychange', function () {
        var obj = $("#colorTd");
        var temp = obj.text();
        if(temp.length > 6) {
            temp = temp.substring(0, 6);
            obj.text(temp);
        } else {
            if (temp == "") obj.closest("tr").find("td.demo").css("background", "#f7f1e3");
            else obj.closest("tr").find("td.demo").css("background", "#" + temp);
        }
    });
}

function add() {
    $("#add").hide();
    $("#confirmAdd").show();
    $("#concelAdd").show();

    $("#cancelUpdate").hide();
    $("#confirmUpdate").hide();
    $("#update").hide();

    $("#dfunct").hide();
    $("#destory").hide();

    clear();
    addRecord();
}

function confirmAdd() {
    if ($("#daysTd").text() == "") {
        alert("请输入剩余天数");
        return;
    }
    if ($("#colorTd").text() == "") {
        alert("请输入颜色数值");
        return;
    }
    var data1 = new Object();
    data1.id = 0;
    data1.days = $("#daysTd").text();
    data1.color = $("#colorTd").text();
    $.ajax({
        type: "post", //要用post方式                 
        url: "Alert.aspx/AddRecord",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: "{'data':'" + JSON.stringify(data1) + "'}",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            alert(temp.data);
            if (temp.code == 200)
               concelAdd();
        },
        error: function (err) {
            alert(err);
        }
    });
}

function concelAdd() {
    $("#cancelUpdate").hide();
    $("#confirmUpdate").hide();
    $("#update").show();

    $("#add").show();
    $("#confirmAdd").hide();
    $("#concelAdd").hide();

    $("#dfunct").show();
    $("#destory").hide();

    clear();
    $.ajax({
        type: "post", //要用post方式                 
        url: "Alert.aspx/GetALL",//方法所在页面和方法名
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
}

function showCheckBox() {
    global = 1;
    $(".checkBox").show();
    $("#cancelUpdate").show();
    $("#confirmUpdate").show();
    $("#update").hide();

    $("#concelAdd").hide();
    $("#confirmAdd").hide();
    $("#add").hide();


    $("#dfunct").hide();
    $("#destory").hide();
}

function cancelUpdate() {
    $(".checkBox").hide();
    $("#cancelUpdate").hide();
    $("#confirmUpdate").hide();
    $("#update").show();
    $(".editTd").attr("contenteditable", false);
    $(".edit").attr("disabled", true);

    $("#concelAdd").hide();
    $("#confirmAdd").hide();
    $("#add").show();

    $("#dfunct").show();
    $("#destory").hide();

    clear();
    $.ajax({
        type: "post", //要用post方式                 
        url: "Alert.aspx/GetALL",//方法所在页面和方法名
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
}

function confirmUpdate() {
    $(":checkbox").each(function () {
        if ($(this).prop("checked")) {
            var temp = $(this).closest("tr");
            if (temp.find("td.editTd").text() == "") {
                alert("请输入剩余天数");
                return;
            }
            if (temp.find("td.editTd2").text() == "") {
                alert("请输入颜色值");
                return;
            }

            var data1 = new Object();
            data1.id = temp.find("td.ID").text();
            data1.days = temp.find("td.editTd").text();
            data1.color = temp.find("td.editTd2").text();
            $.ajax({
                type: "post", //要用post方式                 
                url: "Alert.aspx/Update",//方法所在页面和方法名
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{'data':'" + JSON.stringify(data1) + "'}",
                success: function (data) {
                    var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
                    alert(temp.data);
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    });
}

function clickCheck(obj) {
    var myfunction;
    if (global == 1) {
        $(":checkbox").each(function () {
            $(this).prop("checked", false);   //选中，不选中 是false        
        });
    }
        $(obj).prop("checked", true);

        $(".editTd").closest("tr").find("td").each(function () {
            $(this).attr("contenteditable", false);
        });

        $(".editTd2").closest("tr").find("td").each(function () {
            $(this).attr("contenteditable", false);
        });

        $(".editTd2").each(function () {
            $(this).unbind('input propertychange', myfunction);
        });

        $(obj).closest("tr").find("td.editTd").each(function () {
            $(this).attr("contenteditable", true);
        });

        $(obj).closest("tr").find("td.editTd2").each(function () {
            $(this).attr("contenteditable", true);
        });

    $(obj).closest("tr").find("td.editTd2").bind('input propertychange', myfunction = function () {
        var temp = $(this).text();
        if (temp.length > 6) {
            temp = temp.substring(0, 6);
            $(this).text(temp);
        } else {
            if (temp == "") $(this).closest("tr").find("td.demo").css("background", "#f7f1e3");
            else $(this).closest("tr").find("td.demo").css("background", "#" + temp);
        }
    });
}

function showAll() {
    concelAdd();
}


function dfunct() {
    global = 0;
    $("#dfunct").hide();
    $(".checkBox").show();
    $("#cancelUpdate").hide();
    $("#confirmUpdate").hide();
    $("#update").hide();

    $("#concelAdd").hide();
    $("#confirmAdd").hide();
    $("#add").hide();

    $("#destory").show();
    $("#showAll").show();
}



function destory() {
    var list = [];
    global = 0;
    $(".checkBox").show();
    $(":checkbox").each(function () {
        if ($(this).prop("checked")) {

            var temp = $(this).closest("tr").find("td.ID").text() + "@@";
            $(this).closest("tr").find("td.editTd").each(function () {
                temp += $(this).text() + "@@";
            });
            temp1 = temp.split("@@");
            var obj = new Object();
            obj.id = temp1[0];
            obj.days = temp1[1];
            obj.color = temp1[1];
            list.push(obj);
        }
    });
    if (list.length == 0) {
        return;
    }
    $.ajax({
        type: "post", //要用post方式                 
        url: "Alert.aspx/DestoryRecord",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: "{'temp':'" + JSON.stringify(list) + "'}",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                alert("删除成功");
                clear();
                if (temp.data != "null" && temp.extra != "null") {
                    createTable(temp.data, temp.extra);
                    $("#showAll").show();
                    $("#destory").show();
                    $(".checkBox").show();
                }
            }
            else alert(temp.data);
        },
        error: function (err) {
            alert(err);
        }
    });
}


