function createTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0)
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td><input class=\"checkBox\"  type=\"checkbox\"  style=\"padding: 5px;\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].kind + "</td></tr>";
        else
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\"  style=\"padding: 5px;\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].kind + "</td></tr>";
    }
    $("#caption").after(html);
    var x = extra.split('+');
    $("#total").text("共" + x[0] + "页");
    $("#current").text("第" + x[1] + "页");
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

function reCreateTable(temp, extra) {
    clear();
    createTable(temp, extra);
}

function showCheckBox() {
    global = 1;
    $(".checkBox").show();
    $("#cancelUpdate").show();
    $("#confirmUpdate").show();
    $("#update").hide();

    $("#down").hide();
    $("#up").hide();
    $("#current").hide();
    $("#total").hide();

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

    $("#down").show();
    $("#up").show();
    $("#current").show();
    $("#total").show();

    $("#concelAdd").hide();
    $("#confirmAdd").hide();
    $("#add").show();

    $("#dfunct").show();
    $("#destory").hide();

    clear();
    $.ajax({
        type: "post", //要用post方式                 
        url: "Drug.aspx/GetALL",//方法所在页面和方法名
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
            $(this).closest("tr").find("td.editTd").each(function () {
                temp += $(this).text() + "@@";
            });
            temp1 = temp.split("@@");
            if (temp1[1] == "") {
                alert("请输入药品类别");
                return;
            };
            
            var data1 = new Object();
            data1.id = temp1[0];
            data1.kind = temp1[1];
            $.ajax({
                type: "post", //要用post方式                 
                url: "Drug.aspx/Update",//方法所在页面和方法名
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
    if (global == 1) {
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
    }

}

function down() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Drug.aspx/GetDown",//方法所在页面和方法名
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
        url: "Drug.aspx/GetUp",//方法所在页面和方法名
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

function add() {
    $("#up").hide();
    $("#down").hide();
    $("#current").hide();
    $("#total").hide();

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

function concelAdd() {
    $("#down").show();
    $("#up").show();
    $("#current").show();
    $("#total").show();

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
        url: "Drug.aspx/GetALL",//方法所在页面和方法名
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

function addRecord() {
    html = "<tr class=\"dataRow3\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" onclick=\"clickCheck(this)\"></td><td class=\"ID\"></td><td contentEditable=\"true\" class=\"editTd\" ></td></tr>";
    $("#caption").after(html);
    // $("#kind").html("")
}

function confirmAdd() {
    var temp = "";
    $("tr.dataRow3").find("td.editTd").each(function () {
        temp += $(this).text() + "@@";
    });
    temp += $("#kind").find("option:selected").text() + "@@";
    temp1 = temp.split("@@");
    if (temp1[0] == "") {
        alert("请输入药品类别");
        return;
    };
    var data1 = new Object();
    data1.id = 0;;
    data1.kind = temp1[0];
    $.ajax({
        type: "post", //要用post方式                 
        url: "Drug.aspx/Insert",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: "{'temp':'" + JSON.stringify(data1) + "'}",
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


function search() {
    $("#cancelUpdate").hide();
    $("#confirmUpdate").hide();
    $("#confirmAdd").hide();
    $("#concelAdd").hide();
    var tempCon = $("#searchText").val();
    if (tempCon != "") {
        $.ajax({
            type: "post",
            url: "Drug.aspx/SearchCon",//方法所在页面和方法名
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

                    $("#add").hide();
                    $("#confirmAdd").hide();
                    $("#concelAdd").hide();

                    $("#cancelUpdate").hide();
                    $("#confirmUpdate").hide();
                    $("#update").show();

                    $("#dfunct").hide();
                    $("#destory").show();
                    $(".checkBox").show();
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
        alert("请输入药品类别");
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

    $("#down").hide();
    $("#up").hide();
    $("#current").hide();
    $("#total").hide();

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
            obj.kind = temp1[1];
            list.push(obj);
        }
    });
    if (list.length == 0) {
        return;
    }
    $.ajax({
        type: "post", //要用post方式                 
        url: "Drug.aspx/DestoryRecord",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: "{'temp':'" + JSON.stringify(list) + "'}",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                alert("删除成功");
                clear();
                if (temp.data != "null" && temp.extra != "null")
                {
                    createTable(temp.data, temp.extra);
                    $("#showAll").show();
                    $("#destory").show();
                }
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
