<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VaccineTrackingSystem.VIew.Login.Login" %>

<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="UTF-8" />
<title>webos</title>
<meta name="keywords" content="webos" />
<meta name="description" content="webos" />
<meta name="Language" content="zh-CN" />
<meta name="Copyright" content="webos" />
<meta name="Designer" content="webos" />
<meta name="Publisher" content="webos" />
<meta name="Distribution" content="Global" />
<meta name="author"  content="webos" />
<meta name="robots" content="index,follow" />
<meta name="googlebot" content="index,follow,archive" />
<link href="css/main1.css" rel="stylesheet" type="text/css" />
</head>
<body>


<div class="login">
    <div class="box png">
		<div class="logo"></div>
		<div class="input">
			<div class="log">
				<form id="form1" runat="server">
					<div class="name">
						<label>用户名</label>
                        <asp:TextBox ID="Account" runat="server" tabindex="2" CssClass="text"></asp:TextBox>
					</div>
					<div class="pwd">
						<label>密码</label>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password" tabindex="2" CssClass="text"></asp:TextBox>
                        <asp:Button ID="Button" runat="server" Text="登录" CssClass="submit" TabIndex="3" OnClick="Button_Click"  />
						<div class="check"></div>
					</div>
				</form>
				<div class="tip"></div>
			</div>
		</div>
	</div>
    <div class="air-balloon ab-1 png"></div>
	<div class="air-balloon ab-2 png"></div>
    <div class="air-balloon ab-1 png"></div>
    <div class="footer"></div>
</div>

<script type="text/javascript" src="jslib/jQuery.js"></script>
<script type="text/javascript" src="js/fun.base.js"></script>
<script type="text/javascript" src="js/login.js"></script>

<!--[if lt IE 8]>
<script src="jslib/PIE.js" type="text/javascript"></script>
<script type="text/javascript">
$(function(){
    if (window.PIE && ( $.browser.version >= 6 && $.browser.version < 10 )){
        $('input.text,input.submit').each(function(){
            PIE.attach(this);
        });
    }
});
</script>
<![endif]-->

<!--[if IE 6]>
<script src="jslib/DD_belatedPNG.js" type="text/javascript"></script>
<script>DD_belatedPNG.fix('.png')</script>
<![endif]-->

</body>
</html>
    

