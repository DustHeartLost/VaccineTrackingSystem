<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VaccineTrackingSystem.VIew.Login.Login" %>
<!DOCTYPE html >
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
<title>统一身份认证</title>
<link href="css/login.css" rel="stylesheet">
</head>
<body>
<div class="login-wrap">
  <div data-v-b827f0d6="" class="topbar-wrap">
    <div data-v-b827f0d6="" class="layout-center clearfix">
     <%-- <div data-v-b827f0d6="" class="logo"></div>--%>
      <div data-v-b827f0d6="" class="title">统一身份认证</div>
    </div>
  </div>
  <div class="main-center">
    <form id="login" runat="server">
      <div class="formtitle"><span class="student">疫苗追踪系统</span> </div>
      <div class="input-item"><i class="fa fa-user-o fa-lg login-icon loginname-icon"><img src="images/user.png" /></i>
          <asp:TextBox ID="Username" runat="server" placeholder="请输入账号" CssClass="formtitle"></asp:TextBox>
      </div>
      <div class="input-item"><i class="fa fa-lock fa-lg login-icon loginpass-icon"><img src="images/lock.png" /></i>
          <asp:TextBox ID="Password"  runat="server" TextMode="Password" placeholder="请输入密码" CssClass="hasvertificode"></asp:TextBox>
      </div>
      <!---->
      <div class="showMessage"></div>
      <%--<input type="button" name="login_submit" id="login-submit" value="登录">--%>
        
      <input type="hidden" name="_eventId" value="submit">
        <asp:Button ID="Button1" runat="server" Text="登录" BackColor="#007CCC" Font-Bold="True" Font-Size="Medium" ForeColor="White" Height="46px" Width="250px" />
        
    </form>
  </div>
  <div data-v-759ce404="" class="footer-wrap">
    <div data-v-759ce404="" class="layout-center clearfix">
      <div data-v-759ce404="" class="title">Copyright © 疫苗管理中心</div>
    </div>
  </div>
</div>
</body>
</html>
