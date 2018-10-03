<%@ Page Title="User Maintenance - Registration" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="Admin_Register2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
                   
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" PlaceHolder="example@someone.com" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The Email field is required." ValidationGroup="register2"/>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Email" ValidationGroup="register2" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" CssClass="text-danger" ErrorMessage="The Email is invalid."/>
                        </div>
                    </div>

                     <div class="form-group">
                      <asp:Label runat="server" AssociatedControlID="selectedProject" CssClass="col-md-2 control-label">Project Header</asp:Label>
                         <div class="col-md-10">
                             <asp:DropDownList runat="server" ID="selectedProject" CssClass="col-md-4 control-label" EnableViewState="true" >

                             </asp:DropDownList>
                         </div>
                     </div>
                    
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Role" CssClass="col-md-2 control-label">Role</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="Role" CssClass="col-md-4 control-label">
                                <asp:ListItem>Administrator</asp:ListItem>
                                <asp:ListItem>Super User</asp:ListItem>
                                <asp:ListItem>User</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-3 col-md-10">
                            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" ValidationGroup="register2" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>

