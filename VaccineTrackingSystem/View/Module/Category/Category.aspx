<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Category.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="css/category.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/category.js"></script>
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
         <li style="float:left;width:160px;"><a id="list3" class="list" href="../Storeroom/Storeroom.aspx">库房管理</a></li>
          <li style="float:left;width:160px;"><a id="list4" class="list" href="Category.aspx" style="background-color:#63b5de9c">品类管理</a></li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入品类编号关键字进行查找" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="search()"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <button id="add"  onclick="add()" style="padding:5px">增加品类</button>
    <button id="confirmAdd"  onclick="confirmAdd()" style="padding:5px">确认增加</button>
    <button id="concelAdd"  onclick="concelAdd()"  style="padding:5px">取消增加</button>
    <button id="update" onclick="showCheckBox()" style="padding:5px">修改品类</button>
    <button id="cancelUpdate"  onclick="cancelUpdate()"  style="padding:5px">取消修改</button>
    <button id="confirmUpdate"  onclick="confirmUpdate()"  style="padding:5px">确认修改</button>
     <button id="showAll" onclick="showAll()"  style="padding:5px">显示全部</button>
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
                <th>药品编码</th>
                <th>药品名称</th>
                <th>药品类别</th>
                <th>规格</th>
                <th>单位</th>
                <th>备注</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
    <div style="height:50px"></div>
</asp:Content>
