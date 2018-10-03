<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="User_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <div class="col-md-12">
        <div class="content-box-large">
            <div class="form-wrapper">
            <h2>Profile</h2>
            <h3>Edit your account settings and change your password here.</h3>
            </div>
            
            <div class="panel-body">

                <p class="text-danger" runat="server" id="message">

                    <asp:Literal runat="server" ID="ErrorMessage" />

                </p>
                <div class="form-horizontal">
                   
                    <div class="col-md-12 col-md-offset-2" >
                    <asp:Label runat="server"  AssociatedControlID="CurrentPassword" CssClass="col-md-2 control-label">Current password :</asp:Label>
                    <asp:TextBox runat="server" ID="CurrentPassword" CssClass="form-control profile" TextMode="Password" ValidationGroup="PasswordCheck"/>
                    </div>
                    <div class="col-md-12 col-md-offset-2" >
                     <asp:Label runat="server"  AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">New password :</asp:Label>
                    <asp:TextBox runat="server" ID="NewPassword" CssClass="form-control col-md-1 profile" TextMode="Password" ValidationGroup="PasswordCheck"/>
                     <asp:Button runat="server" Text="Change" CssClass="btn btn-primary profile col-md-2" ValidationGroup="PasswordCheck" ID="changePassword" OnClick="changePassword_Click" />
                    </div>
                    <br />
                      
                   </div>  
                </div>
            </div>
       </div>

</asp:Content>

