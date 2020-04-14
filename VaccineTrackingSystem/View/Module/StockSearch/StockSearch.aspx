<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="StockSearch.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.StockSearch.StockSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/stockSearch.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/stockSearch.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <div><a id="list">库存查询</a></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入药品编号进行查找" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="search()"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <label id="money" style="text-align:center;font-size:medium">共0元</label>
    <div style="float: right;" id="upAndDownArea">
        <button id="up" class="upAnddown" onclick="up()" aria-valuetext="&lt;"> <</button>
        <button id="down" class="upAnddown" onclick="down()" aria-valuetext="&gt;"> ></button>
         <label id="current">第0页</label>
         <label id="total">共0页</label>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
     <div id="table">
        <table id="tableContainer" style="table-layout:fixed">
            <tr id="caption">
                <th>品类ID</th>
                <th>药品编码</th>
                <th>药品名称</th>
                <th>规格</th>
                <th>单位</th>
                <th>生产厂家</th>
                <th>库存数量</th>
                <th>库存金额</th>
                <th>所在库房</th>
                <th>库存ID</th>
                <th></th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
