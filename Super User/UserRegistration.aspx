<%@ Page Title="User Maintenance - Registration" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="Admin_Register2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="col-md-2">
		  <div class="sidebar content-box" style="display: block;">
                <ul class="nav">
                    <!-- Main menu -->
                    <li class="current"><a href="#"><i class="glyphicon glyphicon-home"></i> Dashboard</a></li>
                   
                    <li class="submenu">
                        <a href="#"><i class="glyphicon glyphicon-user"></i> User Maintenance <span class="caret pull-right"></span></a>
                        <!--Sub menu-->
                        <ul>
                            <li><a href="UserRegistration.aspx">Registration</a></li>
                            <li><a href="UserModification.aspx">Modification</a></li>
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
                        <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Username" PlaceHolder="eg:John" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                                CssClass="text-danger" ErrorMessage="The Username field is required." ValidationGroup="register2"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                         <asp:TextBox runat="server" ID="password" TextMode="Password"  CssClass="form-control"  />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                    CssClass="text-danger" ErrorMessage="The password field is required."
                                    Display="Dynamic" ValidationGroup="register2" />
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

