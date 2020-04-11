function createTable(temp) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].num + "</td><td>" + data[i].name + "</td><td>";
            html += data[i].note + "</td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].num + "</td><td>" + data[i].name + "</td><td>";
            html += data[i].note + "</td></tr>";
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



function reCreateTable(temp){
    clear();
    createTable(temp);
} 


function addRecord() { 
    html = "<tr id=\"newOne\" class=\"dataRow3\"  style=\"height:50px;width:130px\"><td>请依次填充id之后的内容 </td><td class=\"dbclicktd\"> </td><td class=\"dbclicktd\"> </td><td class=\"dbclicktd\"> </td></tr>";
    $("#caption").after(html);
    $(".dataRow3").find(".dbclicktd").bind("click", function () {
        var inputNum = "<input type='text' id= 'aptNum' style='height:35px;' value=" + $(this).text() + " >";
        $(this).text("");
        $(this).append(inputNum);
        $("#aptNum").focus();
        $("input").blur(function () {
            if ($(this).val() == "") {
                $(this).remove();
            } else {
                $(this).closest("td").text($(this).val());
            }
        });
    });
}


function add() {
    $("#up").hide();
    $("#down").hide();
    $("#current").hide();
    $("#total").hide();
    $("#add").hide();
    $("#confirm").show();
    $("#concel").show();
    clear();
    addRecord();
}

function confirmAdd() {
    var tempCon = "";
    var i = 0;
    $("#newOne").find("td").each(function () {
        //循环获取每行td的内容
        if (i != 0) {
            var sValue2 = $(this).text();//获取td里面的input内容 
            tempCon = tempCon + sValue2 + ";";
        }
        i++;
    });
    $.ajax({
        type: "post", //要用post方式                 
        url: "Apartment.aspx/AddRecord",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json", 
        data: "{'apt':'"+tempCon+ "'}",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            alert(temp.data);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function concelAdd() {
    clear();
    $("#up").show();
    $("#down").show();
    $("#current").show();
    $("#total").show();
    $("#add").show();
    createAspx();
}