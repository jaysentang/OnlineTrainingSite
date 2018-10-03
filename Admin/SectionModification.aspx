<%@ Page Title="Content Maintenance - Modification" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SectionModification.aspx.cs" Inherits="Admin_SectionModification" MaintainScrollPositionOnPostback="true" %>

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
                    <asp:TabContainer runat="server" ID="TabContent" CssClass="MyTabStyle">
                        <asp:TabPanel runat="server" ID="SectionTab" HeaderText="Section" TabIndex="0">
                            <ContentTemplate>


                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedSection" CssClass="col-md-2 control-label">Section Header</asp:Label>
                                    <div class="col-md-10">
                                         <asp:DropDownList runat="server" ID="selectedSection" CssClass="col-md-4 control-label" EnableViewState="true"  ValidationGroup="sectionTab" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-1">
                                        <asp:Button runat="server" ID="Submit" Text="Confirm" CssClass="btn btn-default"  ValidationGroup="sectionTab" OnClick="Submit_Click"/>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-8">
                                    <asp:FormView ID="SectionDetail" runat="server">
                                        <ItemTemplate>
                                            <table class="table">
                                                <tr>
                                                    <td>Section Header :</td>
                                                    <td colspan="2"><asp:TextBox runat="server" ID="newSectionHeader" Text= '<%# Eval("Header") %>'/></td>
                                                </tr>
                                                <tr>
                                                    <td>Project :</td>
                                                    <td colspan="2"><asp:DropDownList runat="server" ID="selectedProject" CssClass="control-label" EnableViewState="true"></asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td>Number of Courses :</td>
                                                    <td><asp:Label runat="server" ID="CourseQTY" Text='<%# checkValue(Eval("Course")) %>' ReadOnly="true"/></td>
                                                    <td><asp:Button runat="server" ID="displayCourse" Text="show" OnClick="displayCourse_Click"/></td>
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
            
                                    <asp:GridView runat="server" ID="CourseDetail" CssClass="table">
                                         <HeaderStyle BackColor="#9A2EFE" ForeColor="white" />
                                    </asp:GridView>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:TabPanel>

                        <asp:TabPanel runat="server" ID="CourseTab" HeaderText="Course" TabIndex="1">
                            <ContentTemplate>
                                  <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedProject2" CssClass="col-md-2 control-label">Project</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList runat="server" ID="selectedProject2" CssClass="col-md-4 control-label" AutoPostBack="true" OnSelectedIndexChanged="selectedProject2_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                 <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedCourseSection" CssClass="col-md-2 control-label">Section Header</asp:Label>
                                    <div class="col-md-10">
                                         <asp:DropDownList runat="server" ID="selectedCourseSection" CssClass="col-md-4 control-label" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="selectedCourseSection_SelectedIndexChanged"  ValidationGroup="CourseTab">
                                        </asp:DropDownList>
                                    </div>

                                   
                                </div>

                                 <div class="form-group" runat="server" id="courseddl">
                                 <asp:Label runat="server" AssociatedControlID="selectedCourse" CssClass="col-md-2 control-label">Course Title</asp:Label>
                                    <div class="col-md-10">
                                         <asp:DropDownList runat="server" ID="selectedCourse" CssClass="col-md-4 control-label" EnableViewState="true"  ValidationGroup="CourseTab">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                 <div class="form-group">
                                    <div class="col-md-offset-2 col-md-1">
                                        <asp:Button runat="server" ID="Submit_2" Text="Confirm" CssClass="btn btn-default"  ValidationGroup="CourseTab" OnClick="Submit_2_Click"/>
                                    </div>
                                </div>



                                 <div class="form-group">
                                    <div class="col-md-offset-2 col-md-8">
                                    <asp:FormView ID="CourseDetail_2" runat="server">
                                        <ItemTemplate>
                                            <table class="table">
                                                <tr>
                                                    <td>Course Title :</td>
                                                    <td colspan="2"><asp:TextBox runat="server" ID="newCourseTitle" Text= '<%# Eval("Course Title") %>'/>
                                                         <asp:RequiredFieldValidator runat="server" ControlToValidate="newCourseTitle" CssClass="text-danger" ErrorMessage="The Course Header field is required." ValidationGroup="coursedetailtab"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td> Existing Video :</td>
                                                    <td>
                                                            <video id="play" oncontextmenu="return false;" class="video" style="width: 300px; height: auto;" controls>
                                                                <source runat="server" id="cVideo"  type="video/mp4"/>
                                                            </video>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>New video :</td>
                                                    <td>
                                                        <asp:FileUpload runat="server" ID="Upload" ValidationGroup="coursedetailtab"/> 
                                                        <br />   
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align:center;">
                                                        
                                                    <asp:Button runat="server" ID="Update_2" CssClass="btn btn-primary" text="Update" OnClick="Update_2_Click" ValidationGroup="coursedetailtab"/>
                                                    
                                                    <asp:Button runat="server" ID="Delete_2" CssClass="btn btn-primary" Text="Delete" OnClick="Delete_2_Click" OnClientClick="Confirm()"/>
                                                       

                                                    </td>
                                                    
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:FormView>
                                    </div>


                                    <div class="col-md-offset-2 col-md-8">
            
                                    <asp:GridView runat="server" ID="GridView1" CssClass="table">
                                         <HeaderStyle BackColor="#9A2EFE" ForeColor="white" />
                                    </asp:GridView>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>

                        <asp:TabPanel runat="server" ID="OrderTab" HeaderText="Order" TabIndex="2">
                            <ContentTemplate>
                                 <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedProject3" CssClass="col-md-2 control-label">Project</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList runat="server" ID="selectedProject3" CssClass="col-md-4 control-label" AutoPostBack="true" OnSelectedIndexChanged="selectedProject3_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <table style="width: 100%;">
                                    <tr>
                                        <th colspan="2">
                                            <asp:Label runat="server" Text="Section" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <td rowspan="2">
                                            <asp:ListBox runat="server" ID="sectionList" SelectionMode="Single" CssClass="form-control" Height="150" OnSelectedIndexChanged="sectionList_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                                        </td>
                                        <td>
                                            <input type="button" class="btn btn-primary" value="Move Up" onclick="Move_Sections('up');" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="button" class="btn btn-primary" value="Move Down" onclick="Move_Sections('down');" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <th colspan="2">
                                            <asp:Label runat="server" Text="Course" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <td rowspan="2">
                                            <asp:ListBox runat="server" ID="courseList" SelectionMode="Single" CssClass="form-control" Height="150"></asp:ListBox>
                                        </td>
                                        <td>
                                            <input type="button" class="btn btn-primary" value="Move Up" onclick="Move_Courses('up');" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="button" class="btn btn-primary" value="Move Down" onclick="Move_Courses('down');" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center;">
                                            <asp:Button ID="Update_3" CssClass="btn btn-primary" runat="server" Text="Save" OnClientClick="selectall();" OnClick="Update_3_Click" />
                                        </td>
                                    </tr>
                                </table>

                                   

                            </ContentTemplate>
                        </asp:TabPanel>


                        <asp:TabPanel runat="server" ID="QuizTab" HeaderText="MCQ">
                            <ContentTemplate>

                                <!--div id="eventBinder"-->
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedProject4" CssClass="col-md-2 control-label">Project</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList runat="server" ID="selectedProject4" CssClass="col-md-4 control-label" AutoPostBack="true" OnSelectedIndexChanged="selectedProject4_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedSection2" CssClass="col-md-2 control-label">Section</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList runat="server" ID="selectedSection2" CssClass="col-md-4 control-label" ClientIDMode="Static"  ValidationGroup="McqTab">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-1">
                                        <asp:Button runat="server" ID="getQuizList" Text="Select" CssClass="btn btn-default"  ValidationGroup="McqTab" OnClick="GetQuestionList"/>
                                    </div>
                                </div>
                            
                               
                                 <div class="col-md-offset-2 col-md-10 table-responsive" style="padding-left:3px; margin-bottom:14px;">
                                <asp:GridView ID="QuestionList" runat="server" DataKeyNames="Id" CssClass="QuestionList table" OnRowCommand="SelectedQuestion" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="Unnamed_PageIndexChanging" PageSize="5" EnableViewState="true" OnRowEditing="QuestionList_RowEditing" OnRowUpdating="QuestionList_RowUpdating" OnSelectedIndexChanged="QuestionList_SelectedIndexChanged" OnSelectedIndexChanging="QuestionList_SelectedIndexChanging">
                                    <Columns>
                                       
                                        <asp:CommandField ShowSelectButton="true" ShowHeader="false" HeaderStyle-BackColor="WindowFrame" HeaderStyle-Width="80px" ControlStyle-CssClass="btn btn-primary" />
                                        <asp:CommandField ShowEditButton="true" ShowCancelButton="false" ShowHeader="false" HeaderStyle-BackColor="WindowFrame" ControlStyle-CssClass="btn btn-info" HeaderStyle-Width="70px"/>
                                        <asp:TemplateField ShowHeader="false" HeaderStyle-BackColor="WindowFrame" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Button runat="server" ID="DeleteButton" CssClass="btn btn-danger" Text="Delete" CausesValidation="false" OnClientClick="Confirm()" CommandName="DeletedQuiz" CommandArgument='<%# Eval("Id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:BoundField DataField="Text" HeaderText="Questions" />
                                    </Columns>

                                </asp:GridView>
                                </div>
                                
                                <div runat="server" id="answersection" visible="false">
                              
                                 <div class="form-group">
                                    <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">New answer</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="Answer" CssClass="form-control"></asp:TextBox>
                                   
                                    </div>
                                 
                                        </div>
                                <div class="form-group">
                                 <div class="col-md-offset-2 col-md-3">
                                       <asp:Button runat="server" ID="AddAnswer" Text="Add" CssClass="btn btn-default" OnClick="AddAnswer_Click"/>
                                    </div>
                                </div>
                                
                                <div class="col-md-offset-2 col-md-10 table-responsive" style="padding-left:3px; margin-bottom:14px;">
                                    <asp:GridView ID="AnswerList" DataKeyNames="Id" runat="server" CssClass="QuestionList table" OnRowCommand="SelectedAnswer" AutoGenerateColumns="false" AllowPaging="false" OnRowEditing="AnswerList_RowEditing" OnRowUpdating="AnswerList_RowUpdating" OnDataBound="AnswerList_DataBound">
                                         <Columns>
                                          <asp:CommandField ShowEditButton="true" ShowCancelButton="false" ShowHeader="false" HeaderStyle-BackColor="WindowFrame" ControlStyle-CssClass="btn btn-info" HeaderStyle-Width="70px"/>
                                        <asp:TemplateField ShowHeader="false" HeaderStyle-BackColor="WindowFrame" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Button runat="server" ID="DeleteButton" CssClass="btn btn-danger" Text="Delete" CausesValidation="false" OnClientClick="Confirm()" CommandName="DeletedAns" CommandArgument='<%# Eval("Id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CheckBoxField HeaderText="Correct" DataField="IsAnswer" HeaderStyle-Width="110px"/>
                                        <asp:BoundField DataField="Text" HeaderText="Answers" />
                                    </Columns>

                                    </asp:GridView>
                                </div>


                                    </div>
                                    <!--
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="QuestionDropDown" CssClass="col-md-2 control-label">Question</asp:Label>
                                        <asp:DropDownList runat="server" ID="QuestionDropDown" CssClass="col-md-4 control-label"></asp:DropDownList>
                                </div>
                                    -->


                                <!--change client control to server control-->
                                <!--div class="form-group">
                                    <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">Question</asp:Label>
                                    <div class="col-md-10">

                                         <!--input type="text"  id="Question" Class="form-control" /-->
                                       
                           
                                    <!--/div>
                                </!--div>

                             

                                <div class="form-group">
                                    <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">Answers</asp:Label>
                                    <div class="col-md-10">
                                       <input type="text" id="Answer" Class="form-control" />
                                        
                                    </div>
                                     
                                 <div class="col-md-offset-2 col-md-3">
                                       
                                       <input id="AddAnswer" type="button" value="Add" Class="btn btn-default" style="width:60px; margin-top:20px;" />
                                           
                            
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-3">
                                        <ol id="answers"></ol>
                                        <p>Correct Answer:</p>
                                    <select id="correctAnswer" class="control-label"></select>
                                        </div>
                               </div>
                                    <!--
                                    <div class="form-group">
                                    <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">Point</asp:Label>
                                     <div class="col-md-10">
                                       <input type="text" id="Point" Class="form-control" />
                                        
                                    </div>
                                     
                                    </div>
                                    -->
                                   <!--div class="form-group">
                                        <div class="col-md-offset-2 col-md-3">
                                       
                                            <input id="Commit" type="button" value="Save" Class="btn btn-default" style="width:60px; margin-top:20px;" />
                                           
                            
                                        </div>
                                   </!--div>
                                   
                            </div-->
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">







        function Move_Sections(direction) {
             var listbox = document.getElementById('<%= sectionList.ClientID %>');
            var selIndex = listbox.selectedIndex;
 
            if (selIndex == -1) {
                alert("Please select an option to move.");
                return;
            }
  
            var increment = -1;
            if(direction == 'up')
                increment = -1;
            else if(direction == 'down')
                increment = 1;
  
            if((selIndex + increment) < 0 ||
                (selIndex + increment) > (listbox.options.length-1)) {
            return;
            }
  
            var selValue = listbox.options[selIndex].value;
            var selText = listbox.options[selIndex].text;
            listbox.options[selIndex].value = listbox.options[selIndex + increment].value
            listbox.options[selIndex].text = listbox.options[selIndex + increment].text
  
            listbox.options[selIndex + increment].value = selValue;
            listbox.options[selIndex + increment].text = selText;
  
            listbox.selectedIndex = selIndex + increment;
        }

        function Move_Courses(direction) {
             var listbox = document.getElementById('<%= courseList.ClientID %>');
             var selIndex = listbox.selectedIndex;
 
            if (selIndex == -1) {
                alert("Please select an option to move.");
                return;
            }
  
            var increment = -1;
            if(direction == 'up')
                increment = -1;
            else if(direction == 'down')
                increment = 1;
  
            if((selIndex + increment) < 0 ||
                (selIndex + increment) > (listbox.options.length-1)) {
            return;
            }
  
            var selValue = listbox.options[selIndex].value;
            var selText = listbox.options[selIndex].text;
            listbox.options[selIndex].value = listbox.options[selIndex + increment].value
            listbox.options[selIndex].text = listbox.options[selIndex + increment].text
  
            listbox.options[selIndex + increment].value = selValue;
            listbox.options[selIndex + increment].text = selText;
  
            listbox.selectedIndex = selIndex + increment;
        }

        function selectall() {
            document.getElementById('<%= sectionList.ClientID %>').multiple = true;
            document.getElementById('<%= courseList.ClientID %>').multiple = true;

            for (i = 0; i < document.getElementById("<%=sectionList.ClientID %>").options.length; i++)
                document.getElementById("<%=sectionList.ClientID %>").options[i].selected = true;

            for (i = 0; i < document.getElementById("<%=courseList.ClientID %>").options.length; i++)
                document.getElementById("<%=courseList.ClientID %>").options[i].selected = true;
        }



        //mcq section

        /*
        var AnswerList = function (selectorID) {
            return {
                ansArray: [],
                listEl: document.getElementById(selectorID),
                idCnt: 0,
                add: function (ans) {
                    var id = 'myans' + this.idCnt;
                    this.ansArray.push({
                        id: id,
                        answer: ans
                    });
                    var ansDom = document.createElement('li'),
                        ansText = document.createTextNode(ans);
                    ansDom.setAttribute('id', id);
                    ansDom.className = 'answers';
                    ansDom.addEventListener("mouseover", over, false);
                    ansDom.addEventListener("mouseout", out, false);
                    function over() {
                        ansDom.setAttribute("style", "background-color:red")
                    }

                    function out() {
                        ansDom.setAttribute("style", "background-color:white")
                    }
                    ansDom.appendChild(ansText);
                    this.listEl.appendChild(ansDom);

                    var select = document.getElementById('correctAnswer'),
                        option = document.createElement('option');
                    option.setAttribute('value', id);
                    option.text = ans;
                    select.add(option);
                    ++this.idCnt;
                },
                remove: function (ansID) {
                    for (f = 0; f < this.ansArray.length; f++) {
                        if (this.ansArray[f].id == ansID) {
                            //delete this.ansArray[f];
                            this.ansArray.splice(f, 1);
                            var delAns = document.getElementById(ansID),
                                select = document.getElementById('correctAnswer');
                            this.listEl.removeChild(delAns);
                            select.remove(f);
                            break;
                        }
                    }
                },
                commit: function () {
                    var sectionid = $("#selectedSection2").val(),
                        answer = document.getElementById('Answer'),
                        question = document.getElementById('Question'),
                        select = document.getElementById('correctAnswer');

                    // mark = document.getElementById('Point');
                    var data = {
                        "Id": sectionid,
                        "Header": "Quiz",
                        "Questions": question.value,
                        "answers": this.ansArray,
                        "correct_answer": select.selectedIndex
                    }

                    $.ajax({
                        type: "POST",
                        url: "Handler.ashx", //?sectionid=" + sectionid
                        dataType: "text",
                        contentType: "application/json",
                        data: JSON.stringify(data),//{data:data}
                        success: function () {
                            answer.value = "";
                            question.value = "";

                            $("#answers").empty();
                            $("#correctAnswer").empty();
                            window.AnswerList.ansArray.splice(0, window.AnswerList.ansArray.length);
                            while (window.AnswerList.listEl.firstChild) {
                                window.AnswerList.listEl.removeChild(window.AnswerList.listEl.firstChild);
                            }
                            //this.ansArray.splice(0);

                        },
                        error: function (Response, status, error) {
                            //var r = jQuery.parseJSON(Response.responseText);
                            //alert("Message: " + Response.responseText);
                            //alert("StackTrace: " + r.StackTrace);
                            //alert("ExceptionType: " + r.ExceptionType);

                            answer.value = "";
                            question.value = "";

                            $("#answers").empty();
                            $("#correctAnswer").empty();
                            //this.ansArray.empty();
                            window.AnswerList.ansArray.splice(0, window.AnswerList.ansArray.length);
                            while (window.AnswerList.listEl.firstChild) {
                                window.AnswerList.listEl.removeChild(window.AnswerList.listEl.firstChild);
                            }

                            //this.ansArray.splice(0);
                            //mark.value = "";


                        }
                    });

                }
            };
        };

        //Actual app
        window.AnswerList = new AnswerList('answers');



        document.getElementById('eventBinder').addEventListener('click', function (e) {
            if (e.target.id === 'AddAnswer') {
                var answer = document.getElementById('Answer');
                var s = document.getElementById('MainContent_message'),
                    text = document.createTextNode('Answers field is blank.');

                if (s.childNodes.length > 0 && s.childNodes != null) {
                    s.removeChild(s.firstChild);
                }
                if (answer.value.length > 0) {
                //here add into the list
                    window.AnswerList.add(answer.value);
                    answer.value = "";
                    if (s.childNodes.length > 0 && s.childNodes != null) {
                        s.removeChild(s.firstChild);
                    }
                }
                else {

                    s.appendChild(text);
                }
            } else if (e.target.className === 'answers') {
                window.AnswerList.remove(e.target.id);
            } else if (e.target.id === 'Commit') {


                var question = document.getElementById('Question'),
                    s = document.getElementById('MainContent_message'),
                    mark = document.getElementById('Point');

                if (s.childNodes.length > 0 && s.childNodes != null) {
                    s.removeChild(s.firstChild);
                }

                if (question.value.length <= 0) {
                    var text = document.createTextNode('Questions field is blank.')
                    s.appendChild(text);
                }
                else if (window.AnswerList.listEl.childNodes.length <= 1) {
                    var text = document.createTextNode('One or no answer for this question.')
                    s.appendChild(text);
                }
                    /*
                else if (mark.value.length <= 0)
                {
                    var text = document.createTextNode('Please enter point for the question.');
                    s.appendChild(text);
                }
                else if(isNaN(mark.value)){
                    var text = document.createTextNode('Please enter number format for points.');
                    s.appendChild(text);
                }*/ /*
                else {
                    window.AnswerList.commit();
                    var text = document.createTextNode('Added.')
                    s.appendChild(text);
                }
            }
        }, false);

        */
    </script>
</asp:Content>

