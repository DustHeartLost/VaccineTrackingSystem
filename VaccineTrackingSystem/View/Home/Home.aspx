<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="VaccineTrackingSystem.VIew.Home.Home" %>

<!-- saved from url=(0041)https://ehall.jlu.edu.cn/jlu_portal/login -->
<html><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<link href="css/default.css" rel="stylesheet">
<link href="css/alk_main.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" type="text/css" href="css/htmleaf-demo.css" media="all">
<link href="css/bootstrap.min.css" rel="stylesheet">
<link href="css/font-awesome.css" rel="stylesheet" media="all">
<link href="css/animate.min.css" rel="stylesheet" media="all">
<link href="css/bootstrap-touch-slider.css" rel="stylesheet" media="all">
<link href="css/font-awesome(1).css" rel="stylesheet" media="all">
<script src="../Template/jquery/jquery-3.4.1.min.js"></script>
<script src="js/home.js"></script>
<title>疫苗管理系统</title>
    
 <script>
     window.onload = getName;
     function getName() {
         var obj =<%=GetUserName() %>; 
         $("#uname").html("您好，"+obj);
     }
</script>


</head><body>

		 <div class="alk-header">
    	<div class="header-box"> <a id="ex" class="alk-header-ul"  style="margin-right:20px" href="#"  OnClick="ExitOu()">退出</a>
             <a id="pass" class="alk-header-ul"  style="margin-right:20px" href="../SetPassword/set.aspx">修改密码</a> 
            
            <ul class="alk-header-ul">
                  <li id="uname"><i class="fa fa-user"></i> </li>
            </ul>

        </div>
         
    </div>


<!--banner-->
<div class="htmleaf-container">
    <div>
        <img src="images/banner1.jpg" alt="Bootstrap Touch Slider" class="slide-image" style="height: 400px;width: 100%">
        <div class="container">
            <div class="slide-text slide_style_center">
                
            </div>
        </div>
    </div>
    <!--//banner-->

    <!--学生服务-->
    <div class="student-box">
        <div class="student_menu">
            <!--tab-->
            <div class="student-tab">
                <ul>
                    <li id="one2" class="on">
                        业务流程
                    </li>
                </ul>
            </div>
            <!--//tab-->
            <!--tabList-->
            <div class="student-tabList">
               
                    
                <ul id="cont_one_2" class="one flow-ul" style="display: block;">
                    
                    <asp:Panel ID="Panel1" runat="server">
                     <li >
                         <a href="../Module/Apartment/Apartment.aspx" >
                               <dl>
                                   <dt><img src="images/7._______________.png"  alt=""></dt>
                                   <dd>系统设置</dd>
                               </dl>
                          </a>
                    </li>
                    </asp:Panel>
                        
                    <asp:Panel ID="Panel2" runat="server">
                        <li>
                           <a href="../Module/Category/Category.aspx">
                                    <dl>
                                        <dt><img src="images/7._______________(1).png"  alt=""></dt>
                                        <dd>基础数据管理</dd>
                                    </dl>
                                </a>
                            </li>
                    </asp:Panel>                         
                        
                   <asp:Panel ID="Panel3" runat="server">
                       <li>
                          <a href="../Module/Inflow/Inflow.aspx" >
                             <dl>
                                <dt><img src="images/3.__________________(1).png" alt=""></dt>
                                 <dd>入库管理</dd>
                              </dl>
                           </a>
                       </li>
                   </asp:Panel>
                    
                        
                    <asp:Panel ID="Panel4" runat="server">
                     <li>
                         <a href="../Module/Outflow/Outflow.aspx">
                             <dl>
                                <dt><img src="images/5._______.png"  alt=""></dt>
                                <dd>出库管理</dd>
                             </dl>
                          </a>
                      </li>
                    </asp:Panel>

                    <asp:Panel ID="Panel5" runat="server">
                    <li>
                        <a href="../Module/Destory/Destory.aspx" >
                            <dl>
                                <dt><img src="images/icon28.png" alt=""></dt>
                                <dd>销毁管理</dd>
                            </dl>
                        </a>
                    </li>
                    </asp:Panel>

                    <asp:Panel ID="Panel6" runat="server">
                    <li>
                                <a href="../Module/StockSearch/StockSearch.aspx" >
                                    <dl>
                                        <dt><img src="images/5._______.png"  alt=""></dt>
                                        <dd>库存查询</dd>
                                    </dl>
                                </a>
                            </li>
                    </asp:Panel>

                    <asp:Panel ID="Panel7" runat="server">
                    <li>
                        <a href="../Module/Table/InflowTable.aspx" >
                            <dl>
                                <dt><img src="images/icon28.png" alt=""></dt>
                                <dd>报表管理</dd>
                            </dl>
                        </a>
                    </li>
                    </asp:Panel>
                </ul>
            </div>
        </div>
    </div>
    
<!--footer-->
<div class="alk-footer">
    <div class="copy-footer">
        吉林中新正大药品疫苗库存管理系统V1.0 &nbsp; &nbsp;&nbsp; copyright©&nbsp; &nbsp;吉林中新正大食品有限公司版权所有 &nbsp; &nbsp;&nbsp; 
    </div>
</div>


</div></body></html>