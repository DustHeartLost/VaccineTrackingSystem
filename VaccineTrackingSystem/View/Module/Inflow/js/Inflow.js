function createTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].cagNum + "</td><td class=\"editTd\">" + data[i].cagName + "</td><td class=\"editTd\">";
            html += data[i].kind + "</td><td class=\"editTd\">" + data[i].spec + "</td><td class=\"editTd\">" + data[i].date + "</td><td class=\"editTd\">" + data[i].quantity + "</td><td class=\"editTd\">" + data[i].price + "</td><td class=\"editTd\">" + data[i].batchNum + "</td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].cagNum + "</td><td class=\"editTd\">" + data[i].cagName + "</td><td class=\"editTd\">";
            html += data[i].kind + "</td><td class=\"editTd\">" + data[i].spec + "</td><td class=\"editTd\">" + data[i].date + "</td><td class=\"editTd\">" + data[i].quantity + "</td><td class=\"editTd\">" + data[i].price + "</td><td class=\"editTd\">" + data[i].batchNum + "</td></tr>";
        }
    }
    $("#caption").after(html);
    var x = extra.split('+');
    $("#total").text("共" + x[0] + "页");
    $("#current").text("第" + x[1] + "页");
    $(".checkBox").hide();
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


function add() {
    window.location.href = "InflowAdd.aspx";
}

function down() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Inflow.aspx/GetDown",//方法所在页面和方法名
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
        url: "Inflow.aspx/GetUp",//方法所在页面和方法名
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
    var obj = new Object();
    obj.date = $("#dataSearch").val();
    obj.cagName = $("#cagNameSearch").val();
    obj.cagNum = $("#cagNumSearch").val();
    if (obj.date != "" || obj.cagName != "" || obj.cagNum != "") {
        $.ajax({
            type: "post",
            url: "Inflow.aspx/SearchCon",//方法所在页面和方法名
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{'temp':'" + JSON.stringify(obj) + "'}",
            success: function (data) {
                var tempT = JSON.parse(data.d);//返回的数据用data.d获取内容
                if (tempT.code == 200) {
                    reCreateTable(tempT.data, tempT.extra);
                    $("#showAll").show();
                    $("#up").hide();
                    $("#down").hide();
                    $("#current").hide();
                    $("#total").hide();

                    $("#add").show();
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
        alert("请输入搜索内容");
}


function showAll() {
    $("#down").show();
    $("#up").show();
    $("#current").show();
    $("#total").show();

    $("#add").show();
    clear();
    $.ajax({
        type: "post", //要用post方式                 
        url: "Inflow.aspx/GetALL",//方法所在页面和方法名
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
