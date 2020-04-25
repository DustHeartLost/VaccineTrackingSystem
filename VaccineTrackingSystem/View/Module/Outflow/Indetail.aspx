<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Indetail.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Outflow.Indetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="css/indetail.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/indetail.js"></script>
    <script>
        window.onload = create;
        function create() {
            var obj =<%=GetALL() %>;
            $("#cancelUpdate").show();
            $("#confirmUpdate").show();
            if (obj.code == 200)
                createTable(obj.data, obj.extra);
            else alert(obj.data);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <ul><li><a id="list">产品出库</a></li></ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <button id="confirmUpdate"  onclick="confirmUpdate()" style="padding:5px">确认出库</button>
    <button id="cancelUpdate"  onclick="cancelUpdate()"  style="padding:5px">取消出库</button>
    <button id="returnOutflow"  onclick="returnOutflow()"  style="padding:5px">返回</button>
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
                <th>库存编号</th>
                 <th>药品编码</th>
                <th>药品名称</th>
                <th>药品种类</th>
                <th>药品规格</th>
                <th>批号</th>
                <th>入库时间</th>
                <th>数量</th>
                <th>单价</th>
                <th>出库数量</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
