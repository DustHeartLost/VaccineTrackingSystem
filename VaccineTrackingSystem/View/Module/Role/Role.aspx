<%@ Page Title=" " Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="VaccineTrackingSystem.VIew.Module.Role.Role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/myStyle.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/createTable.js"></script>
    <script>
        function create() {
            var obj = JSON.parse('<%=GetString()%>');
            createTable(obj);
        }
    </script>
    <style type="text/css">
        .auto-style2 {
            width: 17px;
            overflow: hidden;
            position: relative;
            margin-top: 10px;
            left: -1px;
            top: -10px;
            height: 0px;
            margin-left: auto;
            margin-right: auto;
            margin-bottom: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <div><a id="list">角色管理</a></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入角色名称进行查找" id="search" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="create()"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
    <div id="table">
        <table id="tableContainer">
            <tr id="caption">
                <th>角色ID</th><th>名称</th><th>机构管理</th><th>角色管理</th><th>用户管理</th><th>库房管理</th><th>品类管理</th><th>入库管理</th><th>出库管理</th><th>销毁管理</th><th>库存查询</th><th>报表管理</th><th>备注</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
