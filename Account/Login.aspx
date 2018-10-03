﻿<%@ Page Title="Log in" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" Async="true" ValidateRequest="false" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   
    
    <div class="row">
        <div class="col-md-8 col-center-block">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h3><%: Title %>.</h3>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                            <asp:HyperLink runat="server" ID="re_active" Visible="false"> Active Now.</asp:HyperLink>
                        </p>
                    </asp:PlaceHolder>
                  
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Username</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-3 col-md-10" style="">
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in"  CssClass="btn btn-default" />
                            <asp:Button runat="server" Text="Reset" CssClass="btn btn-default" Visible="false" PostBackUrl="ResetPassword.aspx" />
                        </div>
                    </div>
                </div>
               
            </section>
        </div>
    
    

    </div>

 
</asp:Content>
