<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Inflow.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Inflow.Inflow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="css/inflow.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/inflow.js"></script>
    <script>
        window.onload = create;
        function create() {
            clear();
            var obj =<%=GetALL() %>;
            $("#concelAdd").hide();
            $("#confirmAdd").hide();
            $("#add").show();
            if (obj.code == 200) createTable(obj.data, obj.extra);
            else alert(obj.data);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <div><a id="list">产品入库</a></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
     <div style="float: right;" id="upAndDownArea">
        <button id="up" class="upAnddown" onclick="up()" aria-valuetext="&lt;"> <</button>
        <button id="down" class="upAnddown" onclick="down()" aria-valuetext="&gt;"> ></button>
         
         <label id="current">第页</label>
         <label id="total">共页</label>
    </div>
     <div style="float: left;" id="addArea">
        <button id="add"  onclick="add()" style="padding:5px">操作入库</button>
     </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
     <div id="table">
        <table id="tableContainer">
            <tr id="caption">
                <th>入库编号</th>
                <th>药品编码</th>
                <th>药品名称</th>
                <th>药品种类</th>
                <th>药品规格</th>
                <th>入库时间</th>
                <th>数量</th>
                <th>单价</th>
                <th>批号</th>
            </tr>
        </table>
       </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
    <div style="height:50px"></div>
</asp:Content>
