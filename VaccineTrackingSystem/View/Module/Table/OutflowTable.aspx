<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="OutflowTable.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Table.Table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/table.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/JsonExportExcel.min.js"></script>
    <script src="js/outflowTable.js"></script>
    <script>
        window.onload = create;
        function create() {
            var obj =<%=GetALLOutflow() %>;
            if (obj.code == 200) createOutflowTable(obj.data, obj.extra);
            else alert(obj.data);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <ul>
        <li style="float:left;width:160px;"><a class="list" href="/View/Home/Home.aspx">系统主页</a></li>
        <li style="float:left;width:160px;"><a class="list" href="InflowTable.aspx">入库流水</a></li>
        <li style="float:left;width:160px;"><a class="list" href="OutflowTable.aspx" style="background-color:#63b5de9c">出库流水</a></li>

    </ul>  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
     <div>
        <input type="text" placeholder="出库日期" id="dataSearch" class="mysearch-input" >
        <input type="text" placeholder="药品名称" id="cagNameSearch" class="mysearch-input" >
         <input type="text" placeholder="库房名称" id="storeNameSearch" class="mysearch-input">
        <input type="text" placeholder="药品编码" id="cagNumSearch" class="mysearch-input">
         <select id="select" class="mysearch-input" style="height:42px"><option>无</option><option>正常出库</option><option>过期作废</option></select>
        <input id="searchButton"  type="button" value="搜索" class="auto-style2" onclick="search()"/></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <label id="money" style="text-align:center;font-size:medium">共0元</label>
    <button id="export" type="button" onclick="tableExport()">导出</button>
    <button id="showAll" onclick="showAll()" type="button">显示全部</button>
    <div id="upAndDownArea" style="float: right;">
        <button id="up" class="upAnddown" onclick="up()"><</button>
        <button id="down" class="upAnddown" onclick="down()">></button>
        <label id="current">第0页</label>
        <label id="total">共0页</label>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
    <div id="table">
        <table id="tableContainer" class="tables">
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
