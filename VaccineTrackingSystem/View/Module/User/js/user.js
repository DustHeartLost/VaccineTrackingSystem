 function createTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0)
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].userName + "</td><td class=\"editTd\">******</td><td><select class=\"apartID\"><option>" + data[i].apartID + "</option></select></td><td class=\"editTd\">" + data[i].job + "</td><td><select class=\"roleID\"><option>" + data[i].roleID + "</option></select></td><td class=\"editTd\">" + data[i].num + "</td><td class=\"editTd\">" + data[i].name + "</td>";
        else
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].userName + "</td><td class=\"editTd\">******</td><td><select class=\"apartID\"><option>" + data[i].apartID + "</option></select></td><td class=\"editTd\">" + data[i].job + "</td><td><select class=\"roleID\"><option>" + data[i].roleID + "</option></select></td><td class=\"editTd\">" + data[i].num + "</td><td class=\"editTd\">" + data[i].name + "</td>";
    }
    $("#caption").after(html);
    var x = extra.split('+');
    console.log(x[1]);
    $("#total").text("共" + x[0] + "页");
    $("#current").text("第" + x[1] + "页");
    $(".checkBox").hide();
};
function search() {
    var tempCon = $("#searchText").val();
    if (tempCon != "") {
        $.ajax({
            type: "post",
            url: "User.aspx/SearchCon",//方法所在页面和方法名
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{'temp':'" + tempCon + "'}",
            success: function (data) {
                var tempT = JSON.parse(data.d);//返回的数据用data.d获取内容
                if (tempT.code == 200) {
                    reCreateTable(tempT.data, tempT.extra);
                }
                else {
                    alert(tempT.extra);
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    }
    else
        alert("请输入用户编号");
};
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

    $("#concelAdd").hide();
    $("#confirmAdd").hide();
    $("#add").hide();
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
}
function confirmUpdate() {
    $(":checkbox").each(function () {
        if ($(this).prop("checked")) {
            var temp = $(this).closest("tr").find("td.ID").text() + "@@";
            $(this).closest("tr").find("td.editTd").each(function () {
                temp += $(this).text() + "@@";
            });
            temp += $(this).closest("tr").find(".roleID").find("option:selected").text() + "@@";
            temp += $(this).closest("tr").find(".apartID").find("option:selected").text() + "@@";
            temp1 = temp.split("@@");
            if (temp1[1] == "") { alert("请输入用户名"); return; }
            if (temp1[2] == "") { alert("请输入密码"); return; }
            if (temp1[3] == "") { alert("请输入职务"); return; }
            if (temp1[4] == "") { alert("请输入员工编号"); return; }
            if (temp1[5] == "") { alert("请输入真实姓名"); return; }
            if (temp1[6] == "") { alert("请选择角色"); return; }
            if (temp1[7] == "") { alert("请选择所在部门"); return; }
            var data1 = new Object();
            data1.id = temp1[0];
            data1.userName = temp1[1];
            data1.password = temp1[2];
            data1.job = temp1[3];
            data1.num = temp1[4];
            data1.name = temp1[5];
            data1.roleID = temp1[6];
            data1.apartID = temp1[7];
            $.ajax({
                type: "post", //要用post方式                 
                url: "User.aspx/Update",//方法所在页面和方法名
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
    })
    $(".editTd").closest("tr").find("td").each(function () {
        $(this).attr("contenteditable", false);
    });
    $(obj).closest("tr").find("td.editTd").each(function () {
        $(this).attr("contenteditable", true);
    });
    $(".roleID").each(function () {
        var temp = "<option>" + $(this).find("option:selected").text() + "</option>";
        $(this).find("option").remove();
        $(this).html(temp);
    });
    $(".apartID").each(function () {
        var temp = "<option>" + $(this).find("option:selected").text() + "</option>";
        $(this).find("option").remove();
        $(this).html(temp);
    });
    $.ajax({
        type: "post", //要用post方式                 
        url: "User.aspx/GetData",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                $(obj).closest("tr").find(".apartID").each(function () {
                    var tp = "<option>" + $(this).find("option:selected").text() + "</option>";
                    $(this).html(tp+createOption(temp.extra, $(this).find("option:selected").text()));
                }); 
                $(obj).closest("tr").find(".roleID").each(function () {
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
function down() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "User.aspx/GetDown",//方法所在页面和方法名
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
        url: "User.aspx/GetUp",//方法所在页面和方法名
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

    clear();
    $.ajax({
        type: "post", //要用post方式                 
        url: "User.aspx/GetALL",//方法所在页面和方法名
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
    html = "<tr class=\"dataRow3\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" onclick=\"clickCheck(this)\"></td><td class=\"ID\"></td><td contentEditable=\"true\" class=\"editTd\" ></td><td contentEditable=\"true\" class=\"editTd\"></td><td><select id=\"apartID\"></select></td><td contentEditable=\"true\" class=\"editTd\" ></td><td><select id=\"roleID\"></select></td><td contentEditable=\"true\" class=\"editTd\" ></td><td contentEditable=\"true\" class=\"editTd\"></td></tr>";
    $("#caption").after(html);
    $.ajax({
        type: "post", //要用post方式                 
        url: "User.aspx/GetData",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                $("#apartID").html(createOption(temp.extra,""));
                $("#roleID").html(createOption(temp.data,""));
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
    $("tr.dataRow3").find("td.editTd").each(function () {
        temp += $(this).text() + "@@";
    });
    temp += $("#apartID").find("option:selected").text() + "@@";
    temp += $("#roleID").find("option:selected").text() + "@@";
    temp1 = temp.split("@@");
    if (temp1[0] == "") { alert("请输入用户名"); return;}
    if (temp1[1] == "") {alert("请输入密码"); return; }
    if (temp1[2] == "") {alert("请输入职务"); return; }
    if (temp1[3] == "") {alert("请输入员工编号"); return; }
    if (temp1[4] == "") {alert("请输入真实姓名"); return; }
    if (temp1[5] == "") {alert("请选择所在部门"); return; }
    if (temp1[6] == "") {alert("请选择角色"); return; }
    var data1 = new Object();
    data1.id =0;
    data1.userName = temp1[0];
    data1.password = temp1[1];
    data1.job = temp1[2];
    data1.num = temp1[3];
    data1.name = temp1[4];
    data1.roleID = temp1[5];
    data1.apartID = temp1[6];
    $.ajax({
        type: "post", //要用post方式                 
        url: "User.aspx/Insert",//方法所在页面和方法名
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
function createOption(data,value) {
    var temp = JSON.parse(data);
    var result = "";
    for (var i = 0; i < temp.length; i++) {
        if (temp[i] != value)
        result += "<option>" + temp[i] + "</option>"
    }
    return result;
}
