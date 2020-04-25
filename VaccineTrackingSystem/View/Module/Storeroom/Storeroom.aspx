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
    <div><ul><li><a id="list">库房管理</a></li></ul></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入库房名称进行查找" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="search()"/>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <button id="add"  onclick="add()" style="padding:5px">增加库房</button>
    <button id="confirmAdd"  onclick="confirmAdd()" style="padding:5px">确认增加</button>
    <button id="concelAdd"  onclick="concelAdd()"  style="padding:5px">取消增加</button>
    <button id="update" onclick="showCheckBox()" style="padding:5px">修改库房</button>
    <button id="cancelUpdate"  onclick="cancelUpdate()"  style="padding:5px">取消修改</button>
    <button id="confirmUpdate"  onclick="confirmUpdate()"  style="padding:5px">确认修改</button>
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
                <th></th>
                <th>ID</th>
                <th>库房名称</th>
                <th>所在位置</th>
                <th>库管员</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
    <div style="height:50px"></div>
</asp:Content>
