﻿function ExitOu() {
    $.ajax({
        type: "post", //要用post方式                 
        url: "Home.aspx/LoginOut",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            window.location.href = "../Login/Login.aspx";
        },
        error: function (err) {
            alert(err);
        }
    });
}