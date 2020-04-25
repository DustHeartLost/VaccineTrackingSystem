<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Apartment.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Apartment.Apartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/apartment.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/apartment.js"></script>
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
    <ul><li><a id="list">机构管理</a></li></ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入部门编号进行查找" id="searchText" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2" onclick="search()"/>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <div style="float: right;" id="upAndDownArea">
        <button id="up" class="upAnddown" onclick="up()" aria-valuetext="&lt;"> <</button>
        <button id="down" class="upAnddown" onclick="down()" aria-valuetext="&gt;"> ></button>
         
         <label id="current">第页</label>
         <label id="total">共页</label>
    </div>
     <div style="float: left;" id="addArea">
        <button id="add" class="upAnddown" onclick="add()">增加机构</button>
        <button id="confirmAdd" class="upAnddown" onclick="confirmAdd()" >确认增加</button>
        <button id="concelAdd" class="upAnddown" onclick="concelAdd()" >取消增加</button>
        <button id="update" class="upAnddown" onclick="showCheckBox()">修改部门</button>
        <button id="cancelUpdate"  class="upAnddown" onclick="cancelUpdate()">取消修改</button>
        <button id="confirmUpdate" class="upAnddown" onclick="confirmUpdate()">确认修改</button>
         <button id="showAll" class="upAnddown" onclick="showAll()">返回</button>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
    <div id="table">
        <table id="tableContainer" style="table-layout:fixed">
            <tr id="caption">
                <th></th>
                <th>部门ID</th>
                <th>部门编号</th>
                <th>部门名称</th>
                <th>备注</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
