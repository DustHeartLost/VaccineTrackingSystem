﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Destory.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Destory.Destory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/destory.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/destory.js"></script>
    <script>
        window.onload = create;
        function create() {
            var obj =<%=GetALL()%>;
            if (obj.code == 200)
                createTable(obj.data, obj.extra);
            else alert(obj.data);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <ul>
          <li style="float:left;width:160px;"><a class="list" href="/View/Home/Home.aspx">系统主页</a></li>
        <li style="float:left;width:160px;"><a class="list" href="#" style="background-color:#63b5de9c">销毁管理</a></li>
 
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <button style="padding:5px" onclick="destory()">销毁</button>
    <button style="padding:5px" onclick="destoryAll()">一键销毁</button>
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
                <th class="checkbox"></th>
                <th>药品编号</th>
                <th>药品名称</th>
                <th>药品类别</th>
                <th>药品规格</th>
                <th>明细号</th>
                <th>库存号</th>
                <th>到期时间</th>
                <th>入库时间</th>
                <th>数量</th>
                <th>单价</th>
                <th>批号</th>
                <th>供应商</th>
                <th>备注</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
