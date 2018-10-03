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
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="Username" CssClass="form-control" PlaceHolder="eg. John" ValidationGroup="modify"/>
                            
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                                CssClass="text-danger" ErrorMessage="The Username field is required." ValidationGroup="modify" />
                          
                            
                        </div>
                        <div class="col-md-4">
                        <asp:Button runat="server" ID="getProfile" Text="Search" OnClick="getUserProfile" CssClass="btn btn-default" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-8 table-responsive" style="padding-left:3px; margin-bottom:14px;">
                            <asp:GridView ID="UserDetails" runat="server" DataKeyNames="Id" CssClass="UserDetails table" OnRowCommand="UserDetails_RowCommand" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="UserDetails_PageIndexChanging"  PageSize="5" EnableViewState="true">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="false" HeaderStyle-BackColor="WindowFrame" HeaderStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Button runat="server" ID="DeleteButton" CssClass="btn btn-danger" Text="Delete" CausesValidation="false" OnClientClick="Confirm()" CommandName="DeleteUser" CommandArgument='<%# Eval("Id")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="false" HeaderStyle-BackColor="WindowFrame" HeaderStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:Button runat="server" ID="BanButton" CssClass="btn btn-warning" CausesValidation="false" CommandName="BanUser" Text='<%# getBanStatus(Eval("LockoutEnabled")) %>' CommandArgument='<%# Eval("Id")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                        
                                                <asp:BoundField DataField="UserName" HeaderText="Username" />
                                            </Columns>
                            </asp:GridView>
                    </div>
                         </div>
               
            </div>
        </div>
            </div>
    </div>
</asp:Content>

