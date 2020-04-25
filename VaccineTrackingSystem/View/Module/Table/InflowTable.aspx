<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="InflowTable.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Table.InflowTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/table.css" />
    <script src="js/JsonExportExcel.min.js"></script>
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/inflowTable.js"></script>
    <script>
        window.onload = create;
        function create() {
            var obj =<%=GetALLInflow()%>;
            if (obj.code == 200) createInflowTable(obj.data, obj.extra);
            else alert(obj.data);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <ul><li style="float:left;width:160px"><a id="list1" href="InflowTable.aspx">入库流水</a></li><li><a id="list2" href="OutflowTable.aspx">出库流水</a></li></ul>  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="暂未添加功能" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="confirm()"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <label id="money" style="text-align:center;font-size:medium">共0元</label>
    <button id="export" type="button" onclick="tableExport()">导出</button>
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
