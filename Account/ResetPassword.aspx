<%@ Page Title="Reset Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="Account_ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

      <div class="row">
        <div class="col-md-8 col-center-block">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h3><%: Title %>.</h3>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p runat="server" id="message" class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                  
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" PlaceHolder="example@someone.com"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The Email field is required." ValidationGroup="reset" />
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Email"  ValidationGroup="reset" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" CssClass="text-danger" ErrorMessage="The Email is invalid."/>
                        </div>
                    </div>
                  
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10" style="">
                            <asp:Button runat="server" ID="ResetBtn" OnClick="ResetBtn_Click" Text="Reset"  CssClass="btn btn-default" ValidationGroup="reset"/>
                        </div>
                    </div>
                </div>
               
            </section>
        </div>
    
    

    </div>
</asp:Content>

