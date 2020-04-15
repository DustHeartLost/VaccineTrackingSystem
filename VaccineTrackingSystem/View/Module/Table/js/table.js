function createInflowTable(temp,extra){
    var data = JSON.parse(temp);
    var html = "<tr id=\"caption\"><th>ID</th><th>药品编码</th><th>关联库房</th><th>入库时间</th><th>操作人</th><th>数量</th><th>单价</th><th>批号</th></tr>";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0)
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].cagNum + "</td><td>" + data[i].storeID + "</td><td>" + data[i].date + "</td><td>" + data[i].userNum + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td><td>" + data[i].batchNum + "</td></tr>";
        else
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].cagNum + "</td><td>" + data[i].storeID + "</td><td>" + data[i].date + "</td><td>" + data[i].userNum + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td><td>" + data[i].batchNum + "</td></tr>";
    }
    $("#tableContainer").after(html);
    var x = extra.split('+');
    $("#total").text("共" + x[0] + "页");
    $("#current").text("第" + x[1] + "页");
    $("#money").text("共" + x[2] + "元");
}

function createOutflowTable(temp, extra) {
    var data = JSON.parse(temp);
    var html = "<tr id=\"caption\"><th>ID</th><th>药品编码</th><th>关联库房</th><th>出库时间</th><th>操作人</th><th>数量</th><th>单价</th><th>批号</th><th>状态</th></tr>";
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0)
            html += "<tr class=\"dataRow\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].cagNum + "</td><td>" + data[i].storeID + "</td><td>" + data[i].date + "</td><td>" + data[i].userNum + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td><td>" + data[i].batchNum + "</td><td>" + data[i].state + "</td></tr>";
        else
            html += "<tr class=\"dataRow2\" style=\"height:50px\"><td>" + data[i].id + "</td><td>" + data[i].cagNum + "</td><td>" + data[i].storeID + "</td><td>" + data[i].date + "</td><td>" + data[i].userNum + "</td><td>" + data[i].quantity + "</td><td>" + data[i].price + "</td><td>" + data[i].batchNum + "</td><td>" + data[i].state + "</td></tr>";
    }
    $("#tableContainer").after(html);
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

function confirm() {
    if ($("#inflow").is(":checked")) state = 0;
    else state = 1;
    $.ajax({
        type: "post", //要用post方式                 
        url: "Table.aspx/Controller",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        data: "{'state':'" + state + "','data':''}",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                switch (temp.extra.split("+")[3]) {
                    case "0": createInflowTable(temp.data, temp.extra); break;
                    case "1": createOutflowTable(temp.data, temp.extra); break;
                }
            } else {
                alert(temp.data);
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
        url: "Table.aspx/GetDown",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                switch (temp.extra.split("+")[3]) {
                    case "0": createInflowTable(temp.data, temp.extra); break;
                    case "1": createOutflowTable(temp.data, temp.extra); break;
                }
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
        url: "Table.aspx/GetUp",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var temp = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (temp.code == 200) {
                clear();
                switch (temp.extra.split("+")[3]) {
                    case "0":createInflowTable(temp.data, temp.extra); break;
                    case "1": createOutflowTable(temp.data, temp.extra); break;
                }
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}