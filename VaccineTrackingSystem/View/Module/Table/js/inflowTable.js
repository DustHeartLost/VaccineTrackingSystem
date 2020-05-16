function createInflowTable(temp,extra){
    var data = JSON.parse(temp);
    var html = "<tr id=\"caption\"><th>药品编码</th><th>药品名称</th><th>药品种类</th><th>药品规格</th><th>关联库房</th><th>入库时间</th><th>操作人</th><th>数量</th><th>单价</th><th>到期时间</th><th>批号</th><th>供应商</th></tr>";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0)
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td>" + data[i].cagNum + "</td><td>" + data[i].name + "</td><td>" + data[i].kind + "</td><td>" + data[i].spec + "</td><td>" + data[i].storeID + "</td><td>" + data[i].date + "</td><td>" + data[i].userNum + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td><td>" + data[i].batchNum + "</td><td>" + data[i].batchNum2 + "</td><td>" + data[i].suppliers + "</td></tr>";
        else
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td>" + data[i].cagNum + "</td><td>" + data[i].name + "</td><td>" + data[i].kind + "</td><td>" + data[i].spec + "</td><td>" + data[i].storeID + "</td><td>" + data[i].date + "</td><td>" + data[i].userNum + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td><td>" + data[i].batchNum + "</td><td>" + data[i].batchNum2 + "</td><td>" + data[i].suppliers + "</td></tr>";
    }
    $("#tableContainer").html(html);
    var x = extra.split('+');
    $("#total").text("共" + x[0] + "页");
    $("#current").text("第" + x[1] + "页");
    $("#money").text("共" + x[2] + "元");
}

function clear() {
    $("#caption").remove();
    $("tr.dataRow").remove();
    $("tr.dataRow2").remove();
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

function down() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "InflowTable.aspx/GetDown",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                createInflowTable(temp.data, temp.extra);
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
        url: "InflowTable.aspx/GetUp",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                createInflowTable(temp.data, temp.extra);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function clear() {
    $("tr").remove(".dataRow");
    $("tr").remove(".dataRow2");
    $("tr").remove(".dataRow3");
}

function reCreateTable(temp, extra) {
    clear();
    createInflowTable(temp, extra);
}


function tableExport() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "InflowTable.aspx/ExportALL",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                var option = {};
                var shhead = "";
                option.fileName = "入库流水表";
                shhead = ['入库流水编号', '药品编码', '药品名称', '药品种类', '药品规格', '关联库房', '入库时间', '操作人', '数量', '单价', '到期时间', '批号', '供应商']; 
                option.datas = [
                    {
                        sheetData: JSON.parse(temp.data),
                        sheetName: "",
                        sheetHeader: shhead
                    }
                ];
                var toExcel = new ExportJsonExcel(option);
                toExcel.saveExcel();
            } 
            else
               alert(temp.extra);
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
    obj.storeName = $("#storeNameSearch").val();
    obj.cagNum = $("#cagNumSearch").val();
    if (obj.date != "" || obj.cagName != "" || obj.cagNum != "" || obj.storeName != "") {
        $.ajax({
            type: "post",
            url: "InflowTable.aspx/SearchCon",//方法所在页面和方法名
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{'temp':'" + JSON.stringify(obj) + "'}",
            success: function (data) {
                var tempT = JSON.parse(data.d);//返回的数据用data.d获取内容
                if (tempT.code == 200) {
                    reCreateTable(tempT.data, tempT.extra);
                    $("#showAll").show();
                    $("#up").show();
                    $("#down").show();
                    $("#current").show();
                    $("#total").show();

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
        url: "InflowTable.aspx/GetALLInflow",//方法所在页面和方法名
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
