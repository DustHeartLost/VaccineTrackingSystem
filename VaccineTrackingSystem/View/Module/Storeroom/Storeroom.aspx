<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Storeroom.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Storeroom.Storeroom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="css/storeroom.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/storeroom.js"></script>
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
         <li style="float:left;width:160px;"><a id="list0" class="list" href="/View/Home/Home.aspx">系统主页</a></li>
        <li style="float:left;width:160px;"><a id="list1" class="list" href="../Drug/Drug.aspx" >药品分类</a></li>
         <li style="float:left;width:160px;"><a id="list2" class="list" href="../Suppliers/Suppliers.aspx" >供应商管理</a></li>
         <li style="float:left;width:160px;"><a id="list3" class="list" href="Storeroom.aspx"  style="background-color:#63b5de9c">库房管理</a></li>
          <li style="float:left;width:160px;"><a id="list4" class="list" href="../Category/Category.aspx">品类管理</a></li>
        </ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入库房名称进行查找" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="search()"/>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <button id="add" class="upAnddown" onclick="add()">增加库房</button>
    <button id="confirmAdd" class="upAnddown" onclick="confirmAdd()">确认增加</button>
    <button id="concelAdd" class="upAnddown" onclick="concelAdd()">取消增加</button>
    <button id="update"class="upAnddown" onclick="showCheckBox()">修改库房</button>
    <button id="cancelUpdate" class="upAnddown" onclick="cancelUpdate()">取消修改</button>
    <button id="confirmUpdate" class="upAnddown" onclick="confirmUpdate()">确认修改</button>
    <button id="showAll" class="upAnddown" onclick="showAll()">显示全部</button>
    <div id="upAndDownArea" style="float: right;">
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
                <th class="checkbox"></th>
                <th>ID</th>
                <th>库房名称</th>
                <th>所在位置</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
    <div style="height:50px"></div>
</asp:Content>
