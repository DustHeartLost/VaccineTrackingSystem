<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Distribution.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Distribution.Distribution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="css/distribution.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/distribution.js"></script>
    <script>
        window.onload = create;
        function create() {
            var obj =<%=GetALL() %>;
            $("#cancelUpdate").hide();
            $("#confirmUpdate").hide();
            $("#update").show();
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
         <li style="float:left;width:160px;"><a class="list" href="Distribution.aspx"  style="background-color:#63b5de9c">库房绑定</a></li>
         <li style="float:left;width:160px;"><a class="list" href="../Alert/Alert.aspx">提醒定义</a></li> 
     </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
     <input type="text" placeholder="请输入库管员真实姓名关键字" id="searchText" class="sx_inp search-input">
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
        <button id="update" class="upAnddown" onclick="showCheckBox()">修改绑定</button>
        <button id="cancelUpdate"  class="upAnddown" onclick="cancelUpdate()">取消修改</button>
        <button id="confirmUpdate" class="upAnddown" onclick="confirmUpdate()">确认修改</button>
         <button id="showAll" class="upAnddown" onclick="showAll()">返回</button>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
        <div id="table">
        <table id="tableContainer" style="table-layout:fixed">
            <tr id="caption">
                <th class="checkbox"></th>
                <th>编号</th>
                <th>用户名</th>
                <th>所在部门</th>
                <th>职务</th>
                <th>角色</th>
                <th>员工编号</th>
                <th>真实姓名</th>
                <th>绑定库房</th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
