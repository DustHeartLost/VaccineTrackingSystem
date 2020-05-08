﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Drug.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Drug.Drug" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="css/drug.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/drug.js"></script>
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
          <li style="float:left;width:160px;"><a id="list0" href="/View/Home/Home.aspx">系统主页</a></li>
        <li style="float:left;width:160px;"><a id="list1" href="#" style="background-color:#63b5de9c">药品类别管理</a></li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
     <input type="text" placeholder="请输入类别名称进行查找" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="search()"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
     <button id="add"  onclick="add()" style="padding:5px">增加品类</button>
    <button id="confirmAdd"  onclick="confirmAdd()" style="padding:5px">确认增加</button>
    <button id="concelAdd"  onclick="concelAdd()"  style="padding:5px">取消增加</button>
    <button id="update" onclick="showCheckBox()" style="padding:5px">修改品类</button>
    <button id="cancelUpdate"  onclick="cancelUpdate()"  style="padding:5px">取消修改</button>
    <button id="confirmUpdate"  onclick="confirmUpdate()"  style="padding:5px">确认修改</button>
     <button id="showAll" onclick="showAll()"  style="padding:5px">返回</button>
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
                <th>药品类别</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
    <div style="height:50px"></div>
</asp:Content>