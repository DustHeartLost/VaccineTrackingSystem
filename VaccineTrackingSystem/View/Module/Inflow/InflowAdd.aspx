<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="InflowAdd.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Inflow.InflowAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link rel="stylesheet" href="css/inflow.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/inflowAdd.js"></script>
    <script>
        window.onload = create;
        function create() {
            $("#concelAdd").show();
            $("#confirmAdd").show();
            addRecord();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
     <div><ul><li><a id="list">产品入库</a></li></ul></div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
   <button id="confirmAdd"  onclick="confirmAdd()" style="padding:5px">确认入库</button>
    <button id="concelAdd"  onclick="concelAdd()"  style="padding:5px">取消入库</button>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
     <div id="table">
        <table id="tableContainer">
            <tr id="caption">
                <th>入库编号</th>
                <th>药品编码</th>
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
