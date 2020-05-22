<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="StockSearch.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.StockSearch.StockSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/stockSearch.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/stockSearch.js"></script>
    <script src="../Table/js/JsonExportExcel.min.js"></script>
    <script>
        window.onload = create;
        function create() {
            clear();
            var obj =<%=GetAll() %>;
            if (obj.code == 200) {
                createTable(obj.data, obj.extra);
                createDrugOption(obj.extra2);
                createStoreOption(obj.extra3);
                if (obj.extra.split('+')[3] == "-1") $("#storeSelect").hide();
            }
            else alert(obj.data);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <ul>
                    <li style="float:left;width:160px;"><a class="list" href="/View/Home/Home.aspx">系统主页</a></li>
        <li style="float:left;width:160px;"><a class="list" href="#" style="background-color:#63b5de9c">库存查询</a></li>

        </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <div>
        <input type="text" placeholder="药品名称" id="cagNameSearch" class="mysearch-input" >
        <select id="storeSelect" class="mysearch-input" style="height:42px"></select>
        <input type="text" placeholder="药品编码" id="cagNumSearch" class="mysearch-input">
        <select id="drugSelect" class="mysearch-input" style="height:42px"></select>
        <input id="searchButton"  type="button" value="搜索" class="auto-style2" onclick="search()"/></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Other" runat="server">
    <label id="money" style="text-align:center;font-size:medium">共0元</label>
    <button id="export"  onclick="tableExport()" style="padding:5px">导出</button>
    <button id="showAll" onclick="showAll()"  style="padding:5px">显示全部</button>
    <div style="float: right;" id="upAndDownArea">
        <button id="up" class="upAnddown" onclick="up()" aria-valuetext="&lt;"> <</button>
        <button id="down" class="upAnddown" onclick="down()" aria-valuetext="&gt;"> ></button>
         <label id="current">第0页</label>
         <label id="total">共0页</label>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
     <div id="table">
        <table id="tableContainer" style="table-layout:fixed">
            <tr id="caption">
                <th>药品编码</th>
                <th>药品名称</th>
                <th>类别</th>
                <th>规格</th>
                <th>单位</th>
                <th>库存数量</th>
                <th>库存金额</th>
                <th>所在库房</th>
                <th>库存号</th>
                <th></th>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="DownAndUp" runat="server">
</asp:Content>
