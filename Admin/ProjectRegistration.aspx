<%@ Page Title="Project Maintenance - Registration" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProjectRegistration.aspx.cs" Inherits="Admin_ProjectRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

     <style type="text/css">
        .MyTabStyle .ajax__tab_header {
            font-family: "Helvetica Neue", Arial, Sans-Serif;
            font-size: 14px;
            font-weight: bold;
            display: block;
        }

            .MyTabStyle .ajax__tab_header:after {
                clear: both;
            }

            .MyTabStyle .ajax__tab_header::after {
                content: "";
                display: table;
            }

            .MyTabStyle .ajax__tab_header .ajax__tab_outer {
                border-color: #222;
                color: #222;
                padding-left: 10px;
                margin-right: 3px;
                border: solid 1px #d7d7d7;
            }

            .MyTabStyle .ajax__tab_header .ajax__tab_inner {
                border-color: #666;
                color: #666;
                padding: 3px 10px 2px 0px;
            }

        .MyTabStyle .ajax__tab_hover .ajax__tab_outer {
            background-color: #9c3;
        }

        .MyTabStyle .ajax__tab_hover .ajax__tab_inner {
            color: #fff;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_outer {
            border-bottom-color: #ffffff;
            background-color: #d7d7d7;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_inner {
            color: #000;
            border-color: #333;
        }

        .MyTabStyle .ajax__tab_body {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            background-color: #fff;
            padding-top: 50px;
            padding-left: 10px;
            padding-bottom: 50px;
            border: solid 1px #d7d7d7;
            margin-top: 9px;
        }

         @media (max-width: 768px) {
          .MyTabStyle .ajax__tab_header {
            
            font-size: 10px;

        }
          
          .MyTabStyle .ajax__tab_body {
          
            margin-top: 3px;
        }
          .custom_btn {
          font-size:8px;
          
          }
          }
    </style>
   <div class="col-md-2">
		  	<div class="sidebar content-box" style="display: block;">
                <ul class="nav">
                    <!-- Main menu -->
                    <li class="current"><a href="#"><i class="glyphicon glyphicon-home"></i> Dashboard</a></li>
                    <li class="submenu">
                         <a href="#"><i class="glyphicon glyphicon-th"></i> Project Maintenance <span class="caret pull-right"></span></a>
                        <!--Sub menu-->
                        <ul>
                            <li><a href="ProjectRegistration.aspx">Registration</a></li>
                            <li><a href="ProjectModification.aspx">Modification</a></li>
                        </ul>
                    </li>
                    <li class="submenu">
                        <a href="#"><i class="glyphicon glyphicon-user"></i> User Maintenance <span class="caret pull-right"></span></a>
                        <!--Sub menu-->
                        <ul>
                            <li><a href="UserRegistration.aspx">Registration</a></li>
                            <li><a href="UserModification.aspx">Modification</a></li>
                        </ul>
                    </li>

                    <li class="submenu">
                        <a href="#"><i class="glyphicon glyphicon-book"></i> Content Maintenance <span class="caret pull-right"></span></a>
                        <ul>
                            <li><a href="SectionAddition.aspx">Registration</a></li>
                            <li><a href="SectionModification.aspx">Modification</a></li>
                        </ul>
                    </li>
                </ul>
             </div>
		  </div>



    <div class="col-md-10">
        <div class="content-box-large">
            <div class="panel-heading">
                <div class="panel-title">
                    <h3><%: Title %>.</h3>
                </div>
            </div>
            <div class="panel-body">

                <p class="text-danger" runat="server" id="message">

                    <asp:Literal runat="server" ID="ErrorMessage" />

                </p>

                <div class="form-horizontal">

                    <asp:TabContainer runat="server" ID="TabContent" ActiveTabIndex="0" CssClass="MyTabStyle">
                        <asp:TabPanel runat="server" ID="projectTab" HeaderText="Project">
                            <ContentTemplate>


                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="Project" CssClass="col-md-2 control-label">Project Header</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="Project" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Project" CssClass="text-danger" ErrorMessage="The Project Header field is required." ValidationGroup="projectTab"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-1">
                                        <asp:Button runat="server" ID="Submit" Text="Add" CssClass="btn btn-default" OnClick="Submit_Click" ValidationGroup="projectTab"/>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:TabPanel>


                    </asp:TabContainer>
                   

                </div>
            </div>
        </div>
    </div>
</asp:Content>

