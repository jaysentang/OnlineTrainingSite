<%@ Page Title="Project Maintenance - Modification" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProjectModification.aspx.cs" Inherits="Admin_ProjectModification" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    
       <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete the data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>
      <style type="text/css">





          .QuestionList th { 
              text-align : center !important 

          }

          .QuestionList td {
          word-wrap: break-word !important;
        
          
          }


   /* SQUARED FOUR */
.squaredFour {
	width: 20px;	
	margin: 20px auto;
	position: relative;
}

.squaredFour label {
	cursor: pointer;
	position: absolute;
	width: 20px;
	height: 20px;
	top: 0;
	border-radius: 4px;
    color:transparent;
	-webkit-box-shadow: inset 0px 1px 1px white, 0px 1px 3px rgba(0,0,0,0.5);
	-moz-box-shadow: inset 0px 1px 1px white, 0px 1px 3px rgba(0,0,0,0.5);
	box-shadow: inset 0px 1px 1px white, 0px 1px 3px rgba(0,0,0,0.5);
	background: #fcfff4;

	background: -webkit-linear-gradient(top, #fcfff4 0%, #dfe5d7 40%, #b3bead 100%);
	background: -moz-linear-gradient(top, #fcfff4 0%, #dfe5d7 40%, #b3bead 100%);
	background: -o-linear-gradient(top, #fcfff4 0%, #dfe5d7 40%, #b3bead 100%);
	background: -ms-linear-gradient(top, #fcfff4 0%, #dfe5d7 40%, #b3bead 100%);
	background: linear-gradient(top, #fcfff4 0%, #dfe5d7 40%, #b3bead 100%);
	filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#fcfff4', endColorstr='#b3bead',GradientType=0 );
}

.squaredFour label:after {
	-ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=0)";
	filter: alpha(opacity=0);
	opacity: 0;
	content: '';
	position: absolute;
	width: 9px;
	height: 5px;
	background: transparent;
	top: 4px;
	left: 4px;
	border: 3px solid #333;
	border-top: none;
	border-right: none;

	-webkit-transform: rotate(-45deg);
	-moz-transform: rotate(-45deg);
	-o-transform: rotate(-45deg);
	-ms-transform: rotate(-45deg);
	transform: rotate(-45deg);
}

.squaredFour label:hover::after {
	-ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=30)";
	filter: alpha(opacity=30);
	opacity: 0.5;
}



.squaredFour input[type=checkbox]:checked + label:after {
	-ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
	filter: alpha(opacity=100);
	opacity: 1;
}

.squaredFour input[type=checkbox]{
 visibility:hidden;
}



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
                                    <asp:Label runat="server" AssociatedControlID="selectedProject" CssClass="col-md-2 control-label">Project Header</asp:Label>
                                    <div class="col-md-10">
                                         <asp:DropDownList runat="server" ID="selectedProject" CssClass="col-md-4 control-label" EnableViewState="true"  ValidationGroup="projectTab" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-1">
                                        <asp:Button runat="server" ID="Submit" Text="Confirm" CssClass="btn btn-default"  ValidationGroup="projectTab" OnClick="Submit_Click"/>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-8">
                                    <asp:FormView ID="ProjectDetail" runat="server">
                                        <ItemTemplate>
                                            <table class="table">
                                                <tr>
                                                    <td>Project Header :</td>
                                                    <td colspan="2"><asp:TextBox runat="server" ID="newProjectHeader" Text= '<%# Eval("Text") %>'/></td>
                                                </tr>
                                                <tr>
                                                    <td>Number of Sections :</td>
                                                    <td><asp:Label runat="server" ID="SectionQTY" Text='<%# checkValue(Eval("Section")) %>' ReadOnly="true"/></td>
                                                    <td><asp:Button runat="server" ID="displaySection" Text="show" OnClick="displaySection_Click"/></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="text-align:center;">
                                                        
                                                    <asp:Button runat="server" ID="Update" CssClass="btn btn-primary" text="Update" OnClick="Update_Click"/>
                                                    
                                                    <asp:Button runat="server" ID="Delete" CssClass="btn btn-primary" Text="Delete" OnClick="Delete_Click" OnClientClick="Confirm()"/>
                                                       

                                                    </td>
                                                    
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:FormView>
                                    </div>


                                    <div class="col-md-offset-2 col-md-8">
            
                                    <asp:GridView runat="server" ID="SectionDetail" CssClass="table">
                                         <HeaderStyle BackColor="#9A2EFE" ForeColor="white" />
                                    </asp:GridView>
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

