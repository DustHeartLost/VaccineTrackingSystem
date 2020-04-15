﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.StockSearch.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/detail.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/detail.js"></script>
    <script>
        window.onload = create;
        function create() {
            var obj =<%=GetALL() %>;
            if (obj.code == 200) createTable(obj.data, obj.extra);
            else alert(obj.data);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <div><a id="list">单品明细</a></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
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
                <th>ID</th>
                <th>库存id</th>
                <th>批号</th>
                <th>入库时间</th>
                <th>数量</th>
                <th>单价</th>
                <th>备注</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>