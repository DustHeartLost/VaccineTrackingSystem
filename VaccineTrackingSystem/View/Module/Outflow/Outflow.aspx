<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Outflow.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Outflow.Outflow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/outflow.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/outflow.js"></script>
    <script>
        window.onload = create;
        function create() {
            $("#addOutflow").hide();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
     <ul><li><a id="list">产品出库</a></li></ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入药品编号进行精确查找" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="search()"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <button id="addOutflow"  onclick="addOutflow()" style="padding:5px">出库</button>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
     <div id="table">
        <table id="tableContainer">
            <tr id="caption" class="test">
                    <th> 库存编号</th>
                    <th >药品编码</th>
                    <th >库房编号</th>
                    <th>库存数量</th>
                    <th>库存金额</th>
            </tr >
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
