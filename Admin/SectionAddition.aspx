<%@ Page Title="Content Maintenance - Registration" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SectionAddition.aspx.cs" Inherits="Admin_SectionAddition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


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
                        <asp:TabPanel runat="server" ID="SectionTab" HeaderText="Section">
                            <ContentTemplate>
                                  <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedProject" CssClass="col-md-2 control-label">Project</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList runat="server" ID="selectedProject" CssClass="col-md-4 control-label">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="SectionHeader" CssClass="col-md-2 control-label">Section Header</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="SectionHeader" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="SectionHeader" CssClass="text-danger" ErrorMessage="The Section Header field is required." ValidationGroup="sectionTab"/>
                                    </div>
                                </div>

                                

                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-1">
                                        <asp:Button runat="server" ID="Submit" Text="Add" CssClass="btn btn-default" OnClick="Submit_Click" ValidationGroup="sectionTab"/>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:TabPanel>

                        <asp:TabPanel runat="server" ID="CourseTab" HeaderText="Course">
                            <ContentTemplate>

                                  <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedProject2" CssClass="col-md-2 control-label">Project</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList runat="server" ID="selectedProject2" CssClass="col-md-4 control-label" AutoPostBack="true" OnSelectedIndexChanged="selectedProject2_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedSection" CssClass="col-md-2 control-label">Section</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList runat="server" ID="selectedSection" CssClass="col-md-4 control-label">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="CourseHeader" CssClass="col-md-2 control-label">Course Header</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="CourseHeader" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="CourseHeader" CssClass="text-danger" ErrorMessage="The Course Header field is required."  ValidationGroup="courseTab"/>
                                    </div>
                                </div>

                               

                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="Upload" CssClass="col-md-2 control-label">Video</asp:Label>
                                    <div class="col-md-10">

                                        <asp:FileUpload runat="server" ID="Upload" ValidationGroup="courseTab"/>
                                    </div>
                                    <div class="col-md-offset-0 col-md-3" style="margin-top: 30px;">
                                        <table>
                                            <tr>
                                                <td>
                                                      <asp:Button runat="server" ID="UploadButton" Text="Upload" CssClass="btn btn-default" OnClick="UploadButton_Click" OnClientClick="displaywaiting()" ValidationGroup="courseTab"/>
                                                </td>
                                                <td>
                                                    <asp:Image runat="server" ImageUrl="~/images/waiting.gif" style="display:none;" ID="waiting" Width="50px" Height="50px"/>
                                                </td>
                                            </tr>
                                        </table>
                                      
                                        
                                     
                                    </div>
                                </div>
                                
                                   

                            </ContentTemplate>
                        </asp:TabPanel>

                        
                        <asp:TabPanel runat="server" ID="QuizTab" HeaderText="MCQ">
                            <ContentTemplate>

                                <div id="eventBinder">

                                  <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedProject3" CssClass="col-md-2 control-label">Project</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList runat="server" ID="selectedProject3" CssClass="col-md-4 control-label" AutoPostBack="true" OnSelectedIndexChanged="selectedProject3_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="selectedSection2" CssClass="col-md-2 control-label">Section</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList runat="server" ID="selectedSection2" CssClass="col-md-4 control-label" ClientIDMode="Static">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" CssClass="col-md-2 control-label" Font-Bold="true">Question</asp:Label>
                                    <div class="col-md-10">
                                         <input type="text"  id="Question" Class="form-control" />
                           
                                    </div>
                                </div>

                               

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
                                   <div class="form-group">
                                        <div class="col-md-offset-2 col-md-3">
                                       
                                            <input id="Commit" type="button" value="Save" Class="btn btn-default" style="width:60px; margin-top:20px;" />
                                           
                            
                                        </div>
                                   </div>
                                   
                            </div>
                            </ContentTemplate>
                        </asp:TabPanel>


                    </asp:TabContainer>
                    <script type="text/javascript">
                        function displaywaiting()
                        {
                            if (document.getElementById('<%= Upload.ClientID %>').files.length === 0) {
                                
                            }
                            else{
                            var img = document.getElementById('<%= waiting.ClientID %>');
                            img.style.display = 'block';
                            }
                        }


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
                                    for (f =0; f<this.ansArray.length; f++) {
                                        if (this.ansArray[f].id == ansID) {
                                            //delete this.ansArray[f];
                                            this.ansArray.splice(f,1);
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
                                        data: JSON.stringify( data ),//{data:data}
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
                                    window.AnswerList.add(answer.value);
                                    answer.value = "";
                                    if (s.childNodes.length > 0 && s.childNodes!=null) {
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
                                else if (window.AnswerList.listEl.childNodes.length<=1 ) {
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
                                }*/
                                else {
                                    window.AnswerList.commit();
                                    var text = document.createTextNode('Added.')
                                    s.appendChild(text);
                                }
                            }
                        }, false);


                       

                    </script>

                </div>
            </div>
        </div>
    </div>


</asp:Content>

