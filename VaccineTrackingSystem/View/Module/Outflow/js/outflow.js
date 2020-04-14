function createTable(temp) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].cagNum + "</td><td class=\"editTd\">" + data[i].storeID + "</td><td class=\"editTd\">";
            html += data[i].quantity + "</td><td class=\"editTd\">" + data[i].money + "</td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td class=\"ID\">" + data[i].id + "</td><td class=\"editTd\">" + data[i].cagNum + "</td><td class=\"editTd\">" + data[i].storeID + "</td><td class=\"editTd\">";
            html += data[i].quantity + "</td><td class=\"editTd\">" + data[i].money + "</td></tr>";
        }

    }
    $("#caption").after(html);
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

function reCreateTable(temp) {
    clear();
    createTable(temp);
}


function search() {
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
                    reCreateTable(tempT.data);
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

function addOutflow() {
    window.location.href = "Indetail.aspx";
}