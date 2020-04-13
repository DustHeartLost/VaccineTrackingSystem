﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="set.aspx.cs" Inherits="VaccineTrackingSystem.View.SetPassword.set" %>
<!DOCTYPE html>

<head runat="server">
<link href="css/main.css" rel="stylesheet">
<link href="css/login.css" rel="stylesheet">
<script src="js/setpassword.js"></script>
 <script src="../Template/jquery/jquery-3.4.1.min.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        function submit() {

        }
    </script>
</head>
<body>
    <div class="common-header">
	<div class="header-wrap">
		<div class="header-left">
			<img class="header-logo" src="images/ico_logo.png" style="cursor:pointer" onclick="javascript:goto_index()"></img>
			<p id="sub_title" class="page-title"></p>
		</div>
		<div class="header-right">
			<div class="header-divide-line"></div>
		
		</div>
	</div> 
    </div>

    <div class="main_form">
                <form id="input_account_form">
                    <div class="mod-form-block input">
                        <label for="account">设置新密码：</label>
                        <div>
                            <div class="formblock medium" style="width:264px">

                                <input type="password" style="width:264px" id="input_password" placeholder="输入密码">

                            </div>
                        </div>
                    </div>
                    <div class="mod-form-block input verify">
                        <label for="code-verify">再次输入：</label>
                        <div>
                            <div class="formblock medium" style="width:264px">

                                <input type="password" style="width:264px" id="input_password_two" placeholder="输入密码">

                            </div>
                        </div>
                    </div>
                    <button type="button" class="mod-btn blue large"  id="next_step" style="margin-top:15px;width:80px" onclick="newPassword()">确定</button>
                </form>
            </div>
    	
     <div id="footer_new">
		<p> <span id="current_year">2020</span> Copyright © 疫苗管理中心 </p>
	</div>             

</body>
