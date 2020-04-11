<%@ Page Title="" Language="C#" MasterPageFile="~/View/Template/Main.Master" AutoEventWireup="true" CodeBehind="Apartment.aspx.cs" Inherits="VaccineTrackingSystem.View.Module.Apartment.Apartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/apartment.css" />
    <script src="../../Template/jquery/jquery-3.4.1.min.js"></script>
    <script src="js/apartment.js"></script>
    <script>
        window.onload = createAspx;
        function createAspx() {
            var obj =<%=GetALL()%>;
            if (obj.code == 200) createTable(obj.data);
            else alert(obj.data);  

            var label = document.getElementById("total");
            var tolV =<%=GetTotal()%>;
            label.innerText = "共" + tolV + "页";
            var label = document.getElementById("current");
            var currV =<%=GetCurr()%>;
            label.innerText = "第" + currV + "页";

            $("#confirm").hide();
            $("#concel").hide();

        }

        function down() {
            var obj =<%=GetDown() %>;
           if (obj.code == 200) reCreateTable(obj.data);
           else alert(obj.data);

           var label = document.getElementById("total");
           var tolV =<%=GetTotal() %>;
           label.innerText = "共" + tolV + "页";
           var label = document.getElementById("current");
           var currV =<%=GetCurr() %>;
           label.innerText = "第" + currV + "页";

           $("#confirm").hide();
            $("#concel").hide();
        }

        function up() {
            var obj =<%=GetUp()%>;
            if (obj.code == 200) reCreateTable(obj.data);
            else alert(obj.data);

            var label = document.getElementById("total");
            var tolV =<%=GetTotal()%>;
            label.innerText = "共" + tolV + "页";
            var label = document.getElementById("current");
            var currV =<%=GetCurr()%>;
            label.innerText = "第" + currV + "页";

            $("#confirm").hide();
            $("#concel").hide();
        }

        function add() {
            $("#up").hide();
            $("#down").hide();
            $("#current").hide();
            $("#total").hide();
            $("#add").hide();
            $("#confirm").show();
            $("#concel").show();
            clear();
            addRecord();
        }

        function confirmAdd() {
            var data = "";
            var i = 0;
            $("#newOne").find("td").each(function(){
                //循环获取每行td的内容
                if (i != 0) {
                    var sValue2 = $(this).text();//获取td里面的input内容 
                    data = data + sValue2+ ";" ;
                }
                i++;
            });
            alert(data);
            var a = JSON.parse(data);
            $.ajax({
                type: "post", //要用post方式                 
                url: "AddRecord",//方法所在页面和方法名
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data:a,
                success: function (data) {
                    alert(data.d);//返回的数据用data.d获取内容
                },
                error: function (err) {
                    alert(err);
                }
            });
        }

        function concelAdd() {
            clear();
            $("#up").show();
            $("#down").show();
            $("#current").show();
            $("#total").show();
            $("#add").show();
            createAspx();
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CurrentList" runat="server">
    <div><a id="list">机构管理</a></div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Search" runat="server">
    <input type="text" placeholder="请输入部门名称进行查找" id="search" class="sx_inp search-input">
    <input id="searchButton" type="button" value="搜索" class="auto-style2"/>
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
        <button id="confirm" class="upAnddown" onclick="confirmAdd()" >确认增加</button>
        <button id="concel" class="upAnddown" onclick="concelAdd()" >取消增加</button>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Table" runat="server">
    <div id="table">
        <table id="tableContainer" style="table-layout:fixed">
            <tr id="caption">
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
