﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="VaccineTrackingSystem.VIew.Home.Home" %>

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

<title>疫苗管理系统</title>
</head><body>

		 <div class="alk-header">
    	<div class="header-box">
        	<div class="alk-header-title"><img src="" alt=""></div>
            <ul class="alk-header-ul">
	           <li><i class="fa fa-user"></i>&nbsp;您好&nbsp;&nbsp;&nbsp;</li>
		         
	            <li>&nbsp;系统主页</li>
                
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
                    <li id="one2" onClick="setTab(&quot;one&quot;,2,3)" class="on">
                        业务流程
                    </li>
                </ul>
            </div>
            <!--//tab-->
            <!--tabList-->
            <div class="student-tabList">
               
                    
                <ul id="cont_one_2" class="one flow-ul" style="display: block;">
                    
                    <asp:Panel ID="Panel1" runat="server">
                     <li>
                         <a href="../Module/Apartment/Apartment.aspx">
                               <dl>
                                   <dt><img src="images/7._______________.png" width="94px" height="94px" alt=""></dt>
                                   <dd>机构管理</dd>
                               </dl>
                          </a>
                    </li>
                    </asp:Panel>

                    <asp:Panel ID="Panel2" runat="server">
                        <li>
                                <a href="../Module/Role/Role.aspx">
                                    <dl>
                                        <dt><img src="images/8._________________.png" width="94px" height="94px" alt=""></dt>
                                        <dd>角色管理</dd>
                                    </dl>
                                </a>
                            </li>
                    </asp:Panel>
                            
                    <asp:Panel ID="Panel3" runat="server">
                        <li>
                                <a href="../Module/User/User.aspx">
                                    <dl>
                                        <dt><img src="images/12.________.png" width="94px" height="94px" alt=""></dt>
                                        <dd>用户管理</dd>
                                    </dl>
                                </a>
                            </li>
                    </asp:Panel>
                    
                        
                    <asp:Panel ID="Panel4" runat="server">
                        <li>
                           <a href="../Module/Storeroom/Storeroom.aspx">
                                    <dl>
                                        <dt><img src="images/7._______________(1).png" width="94px" height="94px" alt=""></dt>
                                        <dd>库房管理</dd>
                                    </dl>
                                </a>
                            </li>
                    </asp:Panel>     
                            
                     
                    <asp:Panel ID="Panel5" runat="server">
                         <li>
                             <a href="../Module/Category/Category.aspx">
                                <dl>
                                    <dt><img src="images/____(1).png" width="94px" height="94px" alt=""></dt>
                                    <dd>品类管理</dd>
                                </dl>
                             </a>
                         </li>
                   </asp:Panel>
                    
                        
                   <asp:Panel ID="Panel6" runat="server">
                       <li>
                          <a href="../Module/Inflow/Inflow.aspx">
                             <dl>
                                <dt><img src="images/3.__________________(1).png" width="94px" height="94px" alt=""></dt>
                                 <dd>入库管理</dd>
                              </dl>
                           </a>
                       </li>
                   </asp:Panel>
                    
                        
                    <asp:Panel ID="Panel7" runat="server">
                     <li>
                         <a href="">
                             <dl>
                                <dt><img src="images/5._______.png" width="94px" height="94px" alt=""></dt>
                                <dd>出库管理</dd>
                             </dl>
                          </a>
                      </li>
                    </asp:Panel>

                    <asp:Panel ID="Panel8" runat="server">
                    <li>
                        <a href="">
                            <dl>
                                <dt><img src="images/icon28.png" alt=""></dt>
                                <dd>销毁管理</dd>
                            </dl>
                        </a>
                    </li>
                    </asp:Panel>

                    <asp:Panel ID="Panel9" runat="server">
                    <li>
                                <a href="../Module/StockSearch/StockSearch.aspx">
                                    <dl>
                                        <dt><img src="images/5._______.png" width="94px" height="94px" alt=""></dt>
                                        <dd>库存查询</dd>
                                    </dl>
                                </a>
                            </li>
                    </asp:Panel>

                    <asp:Panel ID="Panel10" runat="server">
                    <li>
                        <a href="../Module/Table/Table.aspx">
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
    <div class="tj-footer">
        <ul class="tj-box">
            <li class="tj-fwl"><img src=""></li>
            <li class="tj-fwl">你好</li>
            <li class="tj-fwl">欢迎您</li>
        </ul>
    </div>
    <div class="copy-footer">
        地址：吉林省长春市 &nbsp; &nbsp;&nbsp; 版权：疫苗管理中心 &nbsp; &nbsp;&nbsp; 信息管理：疫苗管理中心
    </div>
</div>


</div></body></html>