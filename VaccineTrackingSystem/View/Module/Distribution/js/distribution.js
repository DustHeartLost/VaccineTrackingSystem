function createTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td><input class=\"checkBox\"  type=\"checkbox\"  style=\"padding: 5px;\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td  id=\"ban\">" + data[i].userName + "</td><td   id=\"ban\">" + data[i].apartID + "</td><td id=\"ban\">" + data[i].job + "</td><td id=\"ban\">" + data[i].roleID + "</td><td id=\"ban\">" + data[i].num + "</td><td  id=\"ban\">" + data[i].name + "</td><td><select class=\"storeName\"><option>" + data[i].storeName + "</option></select></td>";
            html += data[i].note + "</td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" style=\"padding: 5px;\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td  id=\"ban\">" + data[i].userName + "</td><td   id=\"ban\">" + data[i].apartID + "</td><td id=\"ban\">" + data[i].job + "</td><td id=\"ban\">" + data[i].roleID + "</td><td id=\"ban\">" + data[i].num + "</td><td  id=\"ban\">" + data[i].name + "</td><td><select class=\"storeName\"><option>" + data[i].storeName + "</option></select></td>";
            html += data[i].note + "</td></tr>";
        }
    }
    $("#caption").after(html);
    var x = extra.split('+');
    $("#total").text("共" + x[0] + "页");
    $("#current").text("第" + x[1] + "页");
    $(".checkBox").hide();
    $("#showAll").hide();
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


function showCheckBox() {
    $(".checkBox").show();
    $("#cancelUpdate").show();
    $("#confirmUpdate").show();
    $("#update").hide();

    $("#down").hide();
    $("#up").hide();
    $("#current").hide();
    $("#total").hide();

    $("#showAll").show();
}

function cancelUpdate() {
    $(".checkBox").hide();
    $("#cancelUpdate").hide();
    $("#confirmUpdate").hide();
    $("#update").show();
    $(".editTd").attr("contenteditable", false);
    $(".edit").attr("disabled", true);

    $("#down").show();
    $("#up").show();
    $("#current").show();
    $("#total").show();

    clear();
    $.ajax({
        type: "post", //要用post方式                 
        url: "Distribution.aspx/GetALL",//方法所在页面和方法名
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
            var temp = $(this).closest("tr").find("td.ID").text() + "@@";
            temp += $(this).closest("tr").find(".storeName").find("option:selected").text() + "@@";
            temp1 = temp.split("@@");
            var data1 = new Object();
            data1.id = temp1[0];
            data1.storeName = temp1[1];
            $.ajax({
                type: "post", //要用post方式                 
                url: "Distribution.aspx/Update",//方法所在页面和方法名
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{'temp':'" + JSON.stringify(data1) + "'}",
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
    $(obj).closest("tr").find("#ban").each(function () {
        $(this).attr("contenteditable", false);
    });
    $.ajax({
        type: "post", //要用post方式                 
        url: "Distribution.aspx/GetData",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                $(obj).closest("tr").find(".storeName").each(function () {
                    var tp = "<option>" + $(this).find("option:selected").text() + "</option>";
                    $(this).html(tp + createOption(temp.data, $(this).find("option:selected").text()));
                });
            } else {
                alert(temp.data);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function inputSelect() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Distribution.aspx/GetData",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                $("#storerooms").html(createOption(temp.data));
            }else {
                alert(temp.data);
            }
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}

function createOption(data) {
    var temp = JSON.parse(data);
    var result = "";
    for (var i = 0; i < temp.length; i++) {
        result += "<option value=\"" + temp[i] + "\">";
    }
    return result;
}


function search() {
    var tempCon = $("#store").val();
    if (tempCon != "") {
        $.ajax({
            type: "post",
            url: "Distribution.aspx/SearchCon",//方法所在页面和方法名
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{'temp':'" + tempCon + "'}",
            success: function (data) {
                var tempT = JSON.parse(data.d);//返回的数据用data.d获取内容
                if (tempT.code == 200) {
                    reCreateTable(tempT.data, tempT.extra);
                    $("#showAll").show();
                    $("#up").hide();
                    $("#down").hide();
                    $("#current").hide();
                    $("#total").hide();

                    $("#cancelUpdate").hide();
                    $("#confirmUpdate").hide();
                    $("#update").show();
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
        alert("请输入部门名称");
}

function down() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Distribution.aspx/GetDown",//方法所在页面和方法名
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
        url: "Distribution.aspx/GetUp",//方法所在页面和方法名
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

function createOption(data, value) {
    var temp = JSON.parse(data);
    var result = "";
    for (var i = 0; i < temp.length; i++) {
        if (temp[i] != value)
            result += "<option>" + temp[i] + "</option>"
    }
    return result;
}
function showAll() {
    cancelUpdate();
}
