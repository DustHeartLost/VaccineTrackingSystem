function createTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].cagNum + "</td><td class=\"editTd\">" + data[i].name + "</td><td class=\"editTd\">" + data[i].kind + "</td><td class=\"editTd\">" + data[i].spec + "</td><td class=\"editTd\">" + data[i].storeID + "</td><td class=\"editTd\">";
            html += data[i].quantity + "</td><td class=\"editTd\">" + data[i].money + "</td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td><input class=\"checkBox\" type=\"checkbox\" onclick=\"clickCheck(this)\"></td><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].cagNum + "</td><td class=\"editTd\">" + data[i].name + "</td><td class=\"editTd\">" + data[i].kind + "</td><td class=\"editTd\">" + data[i].spec + "</td><td class=\"editTd\">" + data[i].storeID + "</td><td class=\"editTd\">";
            html += data[i].quantity + "</td><td class=\"editTd\">" + data[i].money + "</td></tr>";
        }

    }
    $("#caption").after(html);
    var x = extra.split('+');
    $("#up").show();
    $("#down").show();
    $("#update").show();
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

    $("#down").hide();
    $("#up").hide();
    $("#current").hide();
    $("#total").hide();

    $("#returnAll").hide();

    $(":checkbox").each(function () {
        if ($(this).prop("checked")) {
            var tempCon = $(this).closest("tr").find("td.ID").text();
            if (tempCon == "") { alert("暂无记录"); return; }
            $.ajax({
                type: "post",
                url: "Indetail.aspx/setStockId",//方法所在页面和方法名
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{'temp':'" + tempCon + "'}",
                success: function (data) {
                    var tempT = JSON.parse(data.d);//返回的数据用data.d获取内容
                    if (tempT.code == 200) {
                        window.location.href = "Indetail.aspx";
                    }
                    else {
                        alert("跳转失败");
                        return;
                    }

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
        url: "Outflow.aspx/GetDown",//方法所在页面和方法名
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
        url: "Outflow.aspx/GetUp",//方法所在页面和方法名
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


 
function search() {
    $("#update").hide();
    var tempCon = $("#searchText").val();
    if (tempCon != "") {
        $.ajax({
            type: "post",
            url: "Outflow.aspx/SearchCon",//方法所在页面和方法名
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{'temp':'" + tempCon + "'}",
            success: function (data) {
                var tempT = JSON.parse(data.d);//返回的数据用data.d获取内容
                if (tempT.code == 200) {
                    $("#addOutflow").show();
                    $("#returnAll").show();
                    $("#total").text("共 1 页");
                    $("#current").text("第 1 页");
                    $("#up").hide();
                    $("#down").hide();
                    reCreateTable(tempT.data, tempT.extra);
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

function returnAll() {
    clear();
    $.ajax({
        type: "post", //要用post方式                 
        url: "Outflow.aspx/GetALL",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                $("#addOutflow").hide();
                $("#returnAll").hide();
                reCreateTable(temp.data, temp.extra);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}


function addOutflow() {
    var tempCon = "";
    $("tr.dataRow").find("td.ID").each(function () {
        tempCon = $(this).text();
    });
    if (tempCon == "") { alert("暂无记录");return;}
    $.ajax({
        type: "post",
        url: "Indetail.aspx/setStockId",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: "{'temp':'" + tempCon + "'}",
        success: function (data) {
            var tempT = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (tempT.code == 200) {
                window.location.href = "Indetail.aspx";
            }
            else {
                alert("跳转失败");
                return;
            }
           
        },
        error: function (err) {
            alert(err);
        }
    });
   
}