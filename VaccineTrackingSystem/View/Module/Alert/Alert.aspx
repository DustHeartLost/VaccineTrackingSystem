<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Alert.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Alert.Alert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/alert.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/alert.js"></script>
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
            $("#destory").hide();
            $("#destoryAll").hide();
            $("#dfunct").show();       
            if (obj.code == 200) createTable(obj.data, obj.extra);
            else alert(obj.data);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <ul>
         <li style="float:left;width:160px;"><a class="list" href="/View/Home/Home.aspx">系统主页</a></li>
         <li style="float:left;width:160px;"><a class="list" href="../Apartment/Apartment.aspx">机构管理</a></li>
         <li style="float:left;width:160px;"><a class="list" href="../Role/Role.aspx">角色管理</a></li>
         <li style="float:left;width:160px;"><a class="list" href="../User/User.aspx">用户管理</a></li>
         <li style="float:left;width:160px;"><a class="list" href="#" style="background-color:#63b5de9c">提醒定义</a></li>
     </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <div style="float: left;" id="addArea">
        <button id="add" class="upAnddown" onclick="add()">增加</button>
        <button id="confirmAdd" class="upAnddown" onclick="confirmAdd()" >确认增加</button>
        <button id="concelAdd" class="upAnddown" onclick="concelAdd()" >取消增加</button>
        <button id="update" class="upAnddown" onclick="showCheckBox()">修改</button>
        <button id="cancelUpdate"  class="upAnddown" onclick="cancelUpdate()">取消修改</button>
        <button id="confirmUpdate" class="upAnddown" onclick="confirmUpdate()">确认修改</button>
          <button id="dfunct" class="upAnddown" onclick="dfunct()">删除</button>
         <button id="destory" class="upAnddown" onclick="destory()">确认删除</button>
        <button id="showAll" onclick="showAll()"  class="upAnddown">显示全部</button>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
    <div id="table">
        <table id="tableContainer" style="table-layout:fixed">
            <tr id="caption">
                <th></th>
                <th>ID</th>
                <th>剩余天数</th>
                <th>警示颜色数值</th>
                <th>示例颜色</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
