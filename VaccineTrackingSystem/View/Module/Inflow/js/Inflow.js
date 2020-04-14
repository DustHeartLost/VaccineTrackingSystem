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
    html = "<tr id=\"newOne\" class=\"dataRow\"  style=\"height:50px;width:130px\"><td></td><td contentEditable=\"true\" class=\"editTd\"></td>";
    html += "<td contentEditable=\"true\" class=\"editTd\"></td><td contentEditable=\"true\" class=\"editTd\"></td><td contentEditable=\"true\" class=\"editTd\"></td></tr>";
    $("#caption").after(html);
}

function confirmAdd() {
    var temp = "";
    var i = 1;
    $("tr.dataRow").find("td.editTd").each(function () {
        temp += $(this).text() + "@@";
        if (i == 4)
            return false;
        ++i;
    });
    temp1 = temp.split("@@");
    if (temp1[0] == "" || temp1[1] == "" || temp1[2] == "" || temp1[3] == "") { alert("请输入完整信息"); return; }
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
