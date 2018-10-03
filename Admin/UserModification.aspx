<%@ Page Title="User Maintenance - Modification" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserModification.aspx.cs" Inherits="Admin_Modify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
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
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" PlaceHolder="example@someone.com" ValidationGroup="modify"/>
                            
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The Email field is required." ValidationGroup="modify" />
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Email" ValidationGroup="modify" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" CssClass="text-danger" ErrorMessage="The Email is invalid." />
                            
                        </div>
                        <div class="col-md-4">
                        <asp:Button runat="server" Text="Search" OnClick="getUserProfile" CssClass="btn btn-default" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                    <asp:DetailsView runat="server" ID="User_Detail" AutoGenerateRows="false" DefaultMode="Edit" CssClass="table">
                        <FieldHeaderStyle HorizontalAlign="Right" />
                        <RowStyle HorizontalAlign="Left" BackColor="WHITE" />
                        <AlternatingRowStyle BackColor="WHITE"/>

                        <Fields>
               
                            <asp:TemplateField HeaderText="Username">
                                <EditItemTemplate>
                                    <asp:Label ID="Username" runat="server" Text='<%# Bind("UserName")%>' ReadOnly="true"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project">
                                <EditItemTemplate>
                                    <asp:DropDownList runat="server" ID="selectedProject" CssClass="control-label" EnableViewState="true"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Role">
                                <EditItemTemplate>
                                    <asp:DropDownList runat="server" ID="selectedRole" CssClass="control-label" EnableViewState="true"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Contact" runat="server" Text='<%# Bind("PhoneNumber")%>' /></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <EditItemTemplate>
                                    <asp:Label ID="Email" runat="server" Text='<%# Bind("Email")%>' ReadOnly="true" /></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <EditItemTemplate>
                                    <asp:Label ID="Status" runat="server" Text='<%# getstatus(Eval("LockoutEnabled")) %>' ReadOnly="true"/>
                                </EditItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Last Login">
                                <EditItemTemplate>
                                    <asp:Label ID="LastLogin" runat="server" Text='<%# Bind("LastLoginDate")%>' ReadOnly="true"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>

                        </Fields>
                    </asp:DetailsView>
                    </div>
                         </div>
                   <div class="form-group">
                         <div class="col-md-offset-5 col-md-10">
                              <asp:Button runat="server" ID="update" Text="Update" OnClick="updateUserProfile" CssClass="btn btn-success" Visible="false"/>
                              <asp:Button runat="server"  ID="delete" Text="Delete" OnClientClick="Confirm()" OnClick="delete_Click" CssClass="btn btn-danger" Visible="false"/>
                              <asp:Button runat="server" ID="ban" OnClick="ban_Click" CssClass="btn btn-warning" Visible="false" />
                        </div>
                  </div>
               
            </div>
        </div>
            </div>
    </div>
</asp:Content>

