function concelAdd() {
    $("#confirmAdd").hide();
    $("#concelAdd").hide();
    $("tr").remove(".dataRow");
    clear();
    window.location.href = "Inflow.aspx";
}

function addRecord() {
    $("#confirmAdd").show();
    $("#concelAdd").show();
    html = "<tr id=\"newOne\" class=\"dataRow\"  style=\"height:50px;width:130px\"><td><input list=\"cagNum\" id=\"cag\"><datalist id = \"cagNum\"></datalist></td>";
    html += "<td contentEditable=\"true\" class=\"editTd\"></td><td contentEditable=\"true\" class=\"editTd\"></td><td contentEditable=\"true\" class=\"editTd\"></td>"
    html += "<td contentEditable=\"true\" class=\"editTd\"></td><td><input id=\"sup\" list=\"suppliers\"><datalist id = \"suppliers\"></datalist></td><td contentEditable=\"true\" id=\"note\"></td></tr>";
    $("#caption").after(html);
    $.ajax({
        type: "post", //要用post方式                 
        url: "InflowAdd.aspx/GetData",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                $("#cagNum").html(createOption(temp.data));
                $("#suppliers").html(createOption(temp.extra));
            } else if (temp.code == 205) {
                $("#suppliers").html(createOption(temp.extra));
                alert("暂无药品品类,请增加药品品类后刷新重试");
            } else if (temp.code == 206) {
                $("#cagNum").html(createOption(temp.data));
                alert("暂无供应商,请增加供应商后刷新重试");
            } else {
                alert(temp.data);
            }
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}

function confirmAdd() {
    var temp = "";
    temp += $("#cag").val() + "@@";
    $("tr.dataRow").first().find("td.editTd").each(function () {
        temp += $(this).text() + "@@";
    });
    temp += $("#sup").val() + "@@";
    temp += $("#note").text() + "@@";
    temp1 = temp.split("@@");
    if (temp1[0] == "") { alert("请输入药品编码"); return; }
    if (temp1[1] == "") { alert("请输入数量"); return; }
    if (temp1[2] == "") { alert("请输入单价"); return; }
    if (temp1[3] == "") { alert("请输入到期时间"); return; }
    if (temp1[4] == "") { alert("请输入批号"); return; }
    if (temp1[5] == "") { alert("请输入生产厂家"); return; }
    var data1 = new Object();
    data1.id = 0;
    data1.cagNum = temp1[0];
    data1.quantity = temp1[1];
    data1.price = temp1[2];
    data1.batchNum = temp1[3];
    data1.batchNum2 = temp1[4];
    data1.suppliers = temp1[5];
    data1.notes = temp1[6];
    $.ajax({
        type: "post", //要用post方式                 
        url: "InflowAdd.aspx/Insert",//方法所在页面和方法名
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

function createOption(data) {
    var temp = JSON.parse(data);
    var result = "";
    for (var i = 0; i < temp.length; i++) {
        result += "<option value=\"" + temp[i]+"\">";
    }
    return result;
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
