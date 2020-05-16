function createTable(temp,extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0)
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].name + "</td>";
        else
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].name + "</td>";

        for (var j = 0; j < 7; j++) {
           if (data[i].authority[j] == 1) {
              html += "<td><select class=\"edit\" disabled=\"disabled\"><option>允许</option><option>拒绝</option></select ></td>";
           }
           else {
                html += "<td><select class=\"edit\" disabled=\"disabled\"><option>拒绝</option ><option>允许</option></select ></td>";
            }
        }
        html += "<td class=\"editTd\">" + data[i].note + "</td></tr>";
    }
    $("#caption").after(html);
    var x = extra.split('+');
    console.log(x[1]);
    $("#total").text("共"+x[0]+"页");
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

function reCreateTable(temp,extra) {
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

    clear();
    $.ajax({
        type: "post", //要用post方式                 
        url: "Role.aspx/GetALL",//方法所在页面和方法名
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
            var authority = "";
            $(this).closest("tr").find("select").each(function () {
                if ($(this).find("option:selected").text() == "允许")
                    authority += "1";
                else authority += "0";
            });
            var temp = $(this).closest("tr").find("td.ID").text() + "@@";
            $(this).closest("tr").find("td.editTd").each(function () {
                temp += $(this).text() + "@@";
            });
            temp1 = temp.split("@@");
            if (temp1[1] == "") alert("请输入角色名称");
            var data1 = new Object();
            data1.id = temp1[0];
            data1.name = temp1[1];
            data1.authority = authority;
            data1.note = temp1[2];
            $.ajax({
                type: "post", //要用post方式                 
                url: "Role.aspx/Update",//方法所在页面和方法名
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
}

function down() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Role.aspx/GetDown",//方法所在页面和方法名
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
        url: "Role.aspx/GetUp",//方法所在页面和方法名
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
        url: "Role.aspx/GetALL",//方法所在页面和方法名
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
    html = "<tr id=\"newOne\" class=\"dataRow3\"  style=\"height:50px;width:130px\"><td></td><td></td><td contentEditable=\"true\" class=\"editTd\" style=\"background-color:white\"></td>";
    for (var j = 0; j < 7; j++) html += "<td><select><option>拒绝</option ><option>允许</option></select></td>";
    html += "<td contentEditable=\"true\" class=\"editTd\" style=\"background-color:white\"></td></tr>";
    $("#caption").after(html);
}

function confirmAdd() {
    var authority = "";
    $("tr.dataRow3").find("select").each(function () {
        if ($(this).find("option:selected").text() == "允许")
            authority += "1";
        else authority += "0";
    });
    var temp = "";
    $("tr.dataRow3").find("td.editTd").each(function () {
        temp += $(this).text() + "@@";
    });
    temp1 = temp.split("@@");
    if (temp1[0] == "") { alert("请输入角色名称"); return;}
    var data1 = new Object();
    data1.id =0;
    data1.name = temp1[0];
    data1.authority = authority;
    data1.note = temp1[1];
    $.ajax({
        type: "post", //要用post方式                 
        url: "Role.aspx/Insert",//方法所在页面和方法名
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
    var tempCon = $("#searchText").val();
    if (tempCon != "") {
        $.ajax({
            type: "post",               
            url: "Role.aspx/SearchCon",//方法所在页面和方法名
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
        alert("请输入角色名称");
}

function showAll() {
    concelAdd();
}