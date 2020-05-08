function newPassword() {
    var one = $("#input_password").val();
    var two = $("#input_password_two").val();
    if (one == "") {
        alert("请输入新密码");
        return;
    }
    if (two=="") {
        alert("请输入新密码");
        return;
    }
    if (one=="123456") {
        alert("新密码不能和初始密码相同");
        return;
    }
    if (one != two) {
        alert("密码不一致");
        return;
    }
    $.ajax({
        type: "post",
        url: "set.aspx/SetNewPassword",//方法所在页面和方法名
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: "{'temp':'" + two + "'}",
        success: function (data) {
            var tempT = JSON.parse(data.d);//返回的数据用data.d获取内容
            if (tempT.code == 200) {
                alert(tempT.data);
                window.location.href ="../Login/Login.aspx";
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