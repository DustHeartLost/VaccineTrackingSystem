<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Table.Table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="css/table.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="https://cuikangjie.github.io/JsonExportExcel/dist/JsonExportExcel.min.js"></script>
    <script src="js/table.js"></script>
    <script>
        window.onload = create;
        function create() {
            var obj =<%=GetALLInflow() %>;
            if (obj.code == 200) createInflowTable(obj.data, obj.extra);
            else alert(obj.data);
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <div><a id="list">入库流水</a></div>
    <div><a id="list">出库流水</a></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <button id="confirm"  onclick="confirm()" style="padding:5px">确认</button><label id="money" style="text-align:center;font-size:medium">共0元</label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <input id="inflow"  type="radio"  name="obey" checked="checked"/>入库流水
    <input id="outflow"  type="radio" name="obey"/>出库流水
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
