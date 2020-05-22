function createTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0) {
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td class=\"num\">" + data[i].num + "</td><td class=\"name\">" + data[i].name + "</td><td class=\"kind\">" + data[i].kind + "</td><td class=\"unit\">" + data[i].unit + "</td><td class=\"spec\">" + data[i].spec + "</td><td>" + data[i].quantity + "</td><td>" + data[i].money + "</td><td>" + data[i].storeID + "</td><td class=\"need\">" + data[i].stockID + "</td><td><button onclick=\"detail(this)\"  style=\"padding:5px\">查看明细</button></td></tr>";
        }
        else {
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td class=\"num\">" + data[i].num + "</td><td class=\"name\">" + data[i].name + "</td><td class=\"kind\">" + data[i].kind + "</td><td class=\"unit\">" + data[i].unit + "</td><td class=\"spec\">" + data[i].spec + "</td><td>" + data[i].quantity + "</td><td>" + data[i].money + "</td><td>" + data[i].storeID + "</td><td class=\"need\">" + data[i].stockID + "</td><td><button onclick=\"detail(this)\" style=\"padding:5px\">查看明细</button></td></tr>";
        }
    }
    $("#caption").after(html);
    $("#total").show();
    $("#current").show();
    $("#money").show();
    $("#up").show();
    $("#down").show();
    $("#export").show();
    var x = extra.split('+');
    $("#total").text("共" + x[0] + "页");
    $("#current").text("第" + x[1] + "页");
    $("#money").text("共" + x[2] + "元");
    $("#showAll").hide();
}

function clear() {
    $("tr").remove(".dataRow");
    $("tr").remove(".dataRow2");
    $("tr").remove(".dataRow3");
}

function reCreateTable(temp, extra) {
    clear();
    createTable(temp, extra);
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
    $("tr.dataRow").remove();
    $("tr.dataRow2").remove();
}

function search() {
    var obj = new Object();
    obj.cagName = $("#cagNameSearch").val();
    obj.storeName = $("#storeSelect").find("option:selected").text().split('(')[0];
    obj.cagNum = $("#cagNumSearch").val();
    obj.drug = $("#drugSelect").find("option:selected").text();
    if (obj.cagName != "" || obj.cagNum != "" || obj.storeName != "无" || obj.drug !="无(请选择品类名称)") {
        $.ajax({
            type: "post",
            url: "StockSearch.aspx/SearchCon",//方法所在页面和方法名
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
    clear();
    $.ajax({
        type: "post", //要用post方式                 
        url: "StockSearch.aspx/GetAll",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: "{'state':'0','data':'null'}",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                createTable(temp.data, temp.extra);
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
        url: "StockSearch.aspx/GetDown",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                createTable(temp.data, temp.extra);
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
        url: "StockSearch.aspx/GetUp",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                createTable(temp.data, temp.extra);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function detail(obj) {
    var stockID = $(obj).closest("tr").find("td.need").text();
    var temp = $(obj).closest("tr").find("td.num").text();
    temp += "    " + $(obj).closest("tr").find("td.name").text();
    temp += "    " + $(obj).closest("tr").find("td.kind").text();
    temp += "    " + $(obj).closest("tr").find("td.unit").text();
    temp += "    " + $(obj).closest("tr").find("td.spec").text();
    window.open("Detail.aspx?stockID=" + stockID+"&temp="+temp);
}

function tableExport() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "StockSearch.aspx/ExportALL",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                var option = {};
                var shhead = "";
                option.fileName = "库存表";
                shhead = ['药品编码', '药品名称', '规格', '单位', '库存数量', '库存金额', '所在库房', '库存号'];
                option.datas = [
                    {
                        sheetData: JSON.parse(temp.data),
                        sheetName: "库存表",
                        sheetHeader: shhead
                    }
                ];
                var toExcel = new ExportJsonExcel(option);
                toExcel.saveExcel();
            }
            else
                alert(temp.data);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function createDrugOption(data) {
    var result = "<option>无(请选择品类名称)</option>";
    result += createOption(data,0)
    $("#drugSelect").html(result);
}

function createStoreOption(data) {
    var result = "<option>无(请选择仓库名称)</option>";
    result += createOption(data,1)
    $("#storeSelect").html(result);
}

function createOption(data,start) {
    var result = "";
    var temp = JSON.parse(data);
    for (var i = start; i < temp.length; i++) {
        result += "<option>" + temp[i] + "</option>";
    }
    return result;
}