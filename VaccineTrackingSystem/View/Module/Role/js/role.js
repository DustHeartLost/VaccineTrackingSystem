function createTable(temp,extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        html += "<tr class=\"dataRow\" style=\"height:60px\"><td><input class=\"checkBox\" type=\"checkbox\" onclick=\"clickCheck(this)\"></td><td>" + data[i].id + "</td><td class=\"editTd\">" + data[i].name + "</td>";
        for (var j = 0; j < 10; j++) {
            if (data[i].authority[j] == 1) {
                html += "<td><select class=\"edit\" disabled=\"disabled\"><option>允许</option><option>拒绝</option></select ></td>";
            } else {
                html += "<td><select class=\"edit\" disabled=\"disabled\"><option>拒绝</option ><option>允许</option></select ></td>";
            }
        }
        html += "<td class=\"editTd\">"+data[i].note + "</td></tr>";
    }
    $("#caption").after(html);
    var x = extra.split('+');
    console.log(x[1]);
    $("#total").text("共"+x[0]+"页");
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
 });
function clear() {
    $("tr").remove(".dataRow");
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
}

function cancelUpdate() {
    $(".checkBox").hide();
    $("#cancelUpdate").hide();
    $("#confirmUpdate").hide();
    $("#update").show();
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
            var temp = "";
            $(this).closest("tr").find("td").each(function () {
                temp += $(this).text() + "@@";
            });
            temp1 = temp.split("@@");
            var data1 = new Object();
            data1.id = temp1[1];
            data1.name = temp1[2];
            data1.authority = authority;
            data1.note = temp1[0];
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