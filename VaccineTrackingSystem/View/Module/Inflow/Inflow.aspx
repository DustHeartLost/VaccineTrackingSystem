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
    <ul>
           <li style="float:left;width:160px;"><a class="list" href="/View/Home/Home.aspx">系统主页</a></li>
           <li style="float:left;width:160px;"><a class="list" href="#" style="background-color:#63b5de9c">产品入库</a></li>
    </ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
     <div style="float: left;">
        <input type="text" placeholder="入库日期" id="dataSearch" class="sx_inp search-input" style="float: left;width:100px;margin-left:10px">
        <input type="text" placeholder="药品名称" id="cagNameSearch" class="sx_inp search-input" style="float: left;width:100px;margin-left:10px">
        <input type="text" placeholder="药品编码" id="cagNumSearch" class="sx_inp search-input" style="float: left;width:100px;margin-left:10px">&nbsp;
        <input id="searchButton"  type="button" value="搜索" class="auto-style2" onclick="search()"/></div>
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
          <button id="showAll" onclick="showAll()"  style="padding:5px">返回</button>
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
                <th>到期时间</th>
            </tr>
        </table>
       </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
    <div style="height:50px"></div>
</asp:Content>
