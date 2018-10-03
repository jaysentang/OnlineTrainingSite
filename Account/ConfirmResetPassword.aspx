<%@ page title="Confirmation Reset Password" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" codefile="ConfirmResetPassword.aspx.cs" inherits="Account_ConfirmResetPassword" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="Server">
      <div class="row">
        <div class="col-md-8 col-center-block">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h3><%: Title %>.</h3>
                    <hr />
                    
                  <asp:MultiView runat="server" ID="multi">
                      <asp:View runat="server">

                       
                        <div runat="server" ID="ErrorMessage" Visible="false" class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </div>
                   
                           <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" Enabled="false"/>
                        </div>
                    </div>

                     <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="OldPass" CssClass="col-md-2 control-label">New Password</asp:Label>
                          <div class="col-md-10">
                            <asp:TextBox runat="server" ID="OldPass" CssClass="form-control" TextMode="Password" ValidationGroup="reset"/>
                             
                        </div>
                     </div>

                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="NewPass" CssClass="col-md-2 control-label">Confirm New Password</asp:Label>
                          <div class="col-md-10">
                            <asp:TextBox runat="server" ID="NewPass" CssClass="form-control" TextMode="Password" ValidationGroup="reset"/>
                        </div>
                     </div>

                  <asp:CompareValidator runat="server" ControlToCompare="OldPass" ControlToValidate="NewPass" Display="Dynamic" ErrorMessage="Password do not match" CssClass="text-danger"></asp:CompareValidator> 
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10" style="">
                            <asp:Button runat="server" ID="ResetBtn" OnClick="ResetBtn_Click" Text="Reset"  CssClass="btn btn-default" ValidationGroup="reset"/>
                        </div>
                    </div>
            
               
                      </asp:View>
                      <asp:View runat="server">
                         
                        <div runat="server" ID="ErrorMessage2" Visible="false" class="text-danger">
                            <asp:Literal runat="server" ID="FailureText2" /> Try 
                            <asp:HyperLink runat="server" NavigateUrl="~/Account/Login.aspx" Text="Login"/>
                            Now.
                        </div>
                   
                      </asp:View>
                       
                      <asp:View runat="server">
                           <div runat="server" ID="ErrorMessage3" Visible="false" class="text-danger">
                            <asp:Literal runat="server" ID="FailureText3" />
                        </div>
                      </asp:View>
                  </asp:MultiView>
                   </div>
            </section>
        </div>
    </div>
  
</asp:content>

