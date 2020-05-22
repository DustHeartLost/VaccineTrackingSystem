<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VaccineTrackingSystem.VIew.Login.Login" %>
<!DOCTYPE html >
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
<title>统一身份认证</title>
<link href="css/login.css" rel="stylesheet">
<script>
    
    var CheckForm = function () {
        var username = document.getElementById("Username").value;
        var password = document.getElementById("Password").value;
        if (username == "" | password == "") { alert("请输入账号或密码"); return false; }
        
    }
</script>
</head>
<body>
<div class="login-wrap">
<%--  <div data-v-b827f0d6="" class="topbar-wrap">
    <div data-v-b827f0d6="" class="layout-center clearfix">
      <div data-v-b827f0d6="" class="title">统一身份认证</div>
    </div>
  </div>--%>
    <div><img src="images/1590058321(1).png" style="width:100%;float:left;margin-top:100px"/></div>
  <div class="main-center">
      <div id="contain">
    <form id="login" runat="server">
      <div class="input-item"><i class="fa fa-user-o fa-lg login-icon loginname-icon"><img src="images/user.png" style="width:100%;height:100%"/></i>
          <asp:TextBox ID="Username" runat="server"  CssClass="formtitle"></asp:TextBox>
      </div>
        <div class="input-item"><i class="fa fa-user-o fa-lg login-icon loginname-icon"><img src="images/lock.png" style="width:100%;height:100%"/></i>
          <asp:TextBox ID="Password" runat="server" TextMode="Password"  CssClass="formtitle"></asp:TextBox>
      </div>
      <!---->
     
    <div class="showMessage">
        
        </div>
      <input type="hidden" name="_eventId" value="submit">
        <asp:ImageButton ID="Submit" runat="server"  Width="250px" OnClick="submit" OnClientClick="return CheckForm()" ImageUrl="~/View/Login/images/loginButtom.png"/>
        </form>
     </div>
  </div>
  <div data-v-759ce404="" class="footer-wrap">
    <div data-v-759ce404="" class="layout-center clearfix">
      <div data-v-759ce404="" class="title">Copyright © 吉林中新正大食品有限公司</div>
    </div>
  </div>
</div>
    <script>
        function IsPC() {
            var userAgentInfo = navigator.userAgent;
            var Agents = ["Android", "iPhone",
                "SymbianOS", "Windows Phone",
                "iPad", "iPod"];
            var flag = true;
            for (var v = 0; v < Agents.length; v++) {
                if (userAgentInfo.indexOf(Agents[v]) > 0) {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        if (!IsPC()) //true为PC端，false为手机端
            document.getElementById("login").style.margin = "8% auto";
    </script>
</body>
</html>
