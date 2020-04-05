<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="VaccineTrackingSystem.VIew.Home.Home" %>

<html>
<head>
<title>疫苗追踪管理系统</title>

<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<link href="css/default.css" rel="stylesheet">
<link href="css/alk_main.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" type="text/css" href="css/htmleaf-demo.css" media="all">
<link href="css/bootstrap.min.css" rel="stylesheet">
<link href="css/font-awesome.css" rel="stylesheet" media="all">
<link href="css/animate.min.css" rel="stylesheet" media="all">
<link href="css/bootstrap-touch-slider.css" rel="stylesheet" media="all">
<link href="css/font-awesome(1).css" rel="stylesheet" media="all">

</head>
<body>
    <form id="form1" runat="server">
<!--header-->
<div class="header-box">
      <%-- 此处添加头部的照片 不可删除--%>
      <div class="alk-header-title"><img src="" alt=""></div>
</div>
<!--banner-->
<%-- 中间的大图片 --%>
<div class="htmleaf-container">
    <div>
        <img src="images/banner1.jpg" alt="Bootstrap Touch Slider" class="slide-image" style="height: 400px;width: 100%">
        <div class="container">
            <div class="slide-text slide_style_center">
                
            </div>
        </div>
 </div>
<!--//banner-->

   
    <div class="student-box">
        <div class="student_menu">
            <div class="student-tabList">
                <ul id="cont_one_1" class="one flow-ul block" >
                     <asp:Panel ID="Panel1" runat="server" >
                            <li>
                                <a href="index.html">
                                    <dl>
                                        <dt><img src="images/1._____________.png" width="94px" height="94px" alt=""></dt>
                                        <dd>机构管理</dd>
                                    </dl>
                                </a>
                            </li>
                    </asp:Panel>
                        
                    <asp:Panel ID="Panel2" runat="server" >
                               <li>
                                <a href="index.html">
                                    <dl>
                                        <dt><img src="images/2.____________.png" width="94px" height="94px" alt=""></dt>
                                        <dd>角色管理</dd>
                                    </dl>
                                </a>
                                </li>
                     </asp:Panel>
                              
                    <asp:Panel ID="Panel3" runat="server" >
                            <li hidden="hidden">
                                <a href="index.html">
                                    <dl>
                                        <dt><img src="images/____.png" width="94px" height="94px" alt=""></dt>
                                        <dd>用户管理</dd>
                                    </dl>
                                </a>
                            </li>
                     </asp:Panel>

                     <asp:Panel ID="Panel4" runat="server" >
                            <li>
                                <a href="index.html">
                                    <dl>
                                        <dt><img src="images/3.__________________.png" width="94px" height="94px" alt=""></dt>
                                        <dd>库房管理</dd>
                                    </dl>
                                </a>
                            </li>
                    </asp:Panel>
                        
                    <asp:Panel ID="Panel5" runat="server" >
                            <li>
                                <a href="index.html">
                                    <dl>
                                        <dt><img src="images/icon28.png" alt=""></dt>
                                        <dd>品类管理</dd>
                                    </dl>
                                </a>
                            </li>
                    </asp:Panel>

                <asp:Panel ID="Panel6" runat="server" >
                            <li>
                                <a href="index.html">
                                    <dl>
                                        <dt><img src="images/7._______________.png" width="94px" height="94px" alt=""></dt>
                                        <dd>入库管理</dd>
                                    </dl>
                                </a>
                            </li>
                 </asp:Panel>
                 <asp:Panel ID="Panel7" runat="server" >
                            <li>
                                <a href="index.html">
                                    <dl>
                                        <dt><img src="images/8._________________.png" width="94px" height="94px" alt=""></dt>
                                        <dd>出库管理</dd>
                                    </dl>
                                </a>
                            </li>
                  </asp:Panel>    
                    
                  <asp:Panel ID="Panel8" runat="server" >
                            <li>
                                <a href="index.html">
                                    <dl>
                                        <dt><img src="images/12.________.png" width="94px" height="94px" alt=""></dt>
                                        <dd>销毁处理</dd>
                                    </dl>
                                </a>
                            </li>
                   </asp:Panel> 
                    
                   <asp:Panel ID="Panel9" runat="server" >
                            <li>
                                <a href="index.html">
                                    <dl>
                                        <dt><img src="images/7._______________(1).png" width="94px" height="94px" alt=""></dt>
                                        <dd>库存查询</dd>
                                    </dl>
                                </a>
                            </li>
                    </asp:Panel> 
                    
                    <asp:Panel ID="Panel10" runat="server" >
                            <li>
                                <a href="index.html">
                                    <dl>
                                        <dt><img src="images/____(1).png" width="94px" height="94px" alt=""></dt>
                                        <dd>报表管理</dd>
                                    </dl>
                                </a>
                            </li>
                   </asp:Panel> 
                </ul>
            </div>
        </div>
  
    </div>
</div>
</div>
    </form>
</body>
</html>