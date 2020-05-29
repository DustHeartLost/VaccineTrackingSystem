<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Outflow.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Outflow.Outflow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/outflow.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/outflow.js"></script>
    <script>
        window.onload = create;
        function create() {
            var obj =<%=GetALL() %>;
            $("#addOutflow").hide();
            $("#returnAll").hide();
            if (obj.code == 200)
                createTable(obj.data, obj.extra);
            else alert(obj.data); 
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
     <ul>
           <li style="float:left;width:160px;"><a class="list" href="/View/Home/Home.aspx">系统主页</a></li>
        <li style="float:left;width:160px;"><a class="list" href="#" style="background-color:#63b5de9c">产品出库</a></li>
  
     </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入药品名称关键字" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="search()"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <button id="update" onclick="showCheckBox()" style="padding:5px">确认出库</button>
    <button id="addOutflow"  onclick="addOutflow()" style="padding:5px">出库</button>
    <button id="returnAll"  onclick="returnAll()"  style="padding:5px">显示全部</button>
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
            <tr id="caption" class="test">
                    <th class="checkbox"></th>
                    <th> 库存编号</th>
                    <th >药品编码</th>
                    <th>药品名称</th>
                    <th>药品种类</th>
                    <th>药品规格</th>
                    <th >库房编号</th>
                    <th>库存数量</th>
                    <th>库存金额</th>
            </tr >
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
