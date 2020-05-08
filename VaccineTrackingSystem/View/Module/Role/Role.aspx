<%@ Page Title=" " Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="VaccineTrackingSystem.VIew.Module.Role.Role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/role.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/role.js"></script>
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
     <ul>
         <li style="float:left;width:160px;"><a class="list" href="/View/Home/Home.aspx">系统主页</a></li>
         <li style="float:left;width:160px;"><a class="list" href="../Apartment/Apartment.aspx" >机构管理</a></li>
         <li style="float:left;width:160px;"><a class="list" style="background-color:#63b5de9c" href="#">角色管理</a></li>
         <li style="float:left;width:160px;"><a class="list" href="../User/User.aspx">用户管理</a></li>
     </ul>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入角色名称进行查找" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="search()"/>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <button id="add"  onclick="add()" class="upAnddown">增加角色</button>
    <button id="confirmAdd" class="upAnddown" onclick="confirmAdd()">确认增加</button>
    <button id="concelAdd" class="upAnddown" onclick="concelAdd()">取消增加</button>
    <button id="update"class="upAnddown" onclick="showCheckBox()">修改角色</button>
    <button id="cancelUpdate" class="upAnddown" onclick="cancelUpdate()">取消修改</button>
    <button id="confirmUpdate" class="upAnddown" onclick="confirmUpdate()">确认修改</button>
     <button id="showAll" class="upAnddown" onclick="showAll()">返回</button>
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
                <th></th><th>ID</th><th>名称</th><th>系统设置</th><th>基础数据管理</th><th>入库管理</th><th>出库管理</th><th>销毁管理</th><th>库存查询</th><th>报表管理</th><th>备注</th>
            </tr>
        </table>
    </div>
</asp:Content>


<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
    <div style="height:50px"></div>
</asp:Content>
