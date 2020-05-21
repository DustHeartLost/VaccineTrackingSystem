<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.User.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/user.css" />
    <script src="js/user.js"></script>
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script>
        window.onload = create;
        function create() {
            var obj =<%=GetALL() %>;
            $("#cancelUpdate").hide();
            $("#confirmUpdate").hide();
            $("#concelAdd").hide();
            $("#confirmAdd").hide();
            $("#add").show();
            $("#update").show();
            if (obj.code == 200) createTable(obj.data, obj.extra);
            else alert(obj.data);
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <ul>
         <li style="float:left;width:160px;"><a class="list" href="/View/Home/Home.aspx">系统主页</a></li>
         <li style="float:left;width:160px;"><a class="list" href="../Apartment/Apartment.aspx" >机构管理</a></li>
         <li style="float:left;width:160px;"><a class="list"  href="../Role/Role.aspx">角色管理</a></li>
         <li style="float:left;width:160px;"><a class="list" href="#"style="background-color:#63b5de9c">用户管理</a></li>
         <li style="float:left;width:160px;"><a class="list" href="../Alert/Alert.aspx">提醒定义</a></li> 
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入用户编号进行查找" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="search()"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <button id="add" class="upAnddown" onclick="add()">增加用户</button>
    <button id="confirmAdd" class="upAnddown" onclick="confirmAdd()">确认增加</button>
    <button id="concelAdd" class="upAnddown" onclick="concelAdd()">取消增加</button>
    <button id="update"class="upAnddown" onclick="showCheckBox()">修改用户</button>
    <button id="cancelUpdate" class="upAnddown" onclick="cancelUpdate()">取消修改</button>
    <button id="confirmUpdate" class="upAnddown" onclick="confirmUpdate()">确认修改</button>
    <button id="showAll" class="upAnddown" onclick="showAll()">显示全部</button>
    <div id="upAndDownArea">
        <button id="up" class="upAnddown" onclick="up()"><</button>
        <button id="down" class="upAnddown" onclick="down()">></button>
        <label id="current"></label>
        <label id="total"></label>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
    <div id="table">
        <table id="tableContainer">
            <tr id="caption">
                <th class="checkbox"></th><th>ID</th><th>用户名</th><th>密码</th><th>所在部门</th><th>职务</th><th>角色</th><th>员工编号</th><th>真实姓名</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
   
</asp:Content>
