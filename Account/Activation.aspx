<%@ page title="Activation" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" codefile="Activation.aspx.cs" inherits="Account_Activation" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="Server">
    <div class="row">
        <div class="col-md-8 col-center-block">
            <section id="activationForm">
                <div class="form-horizontal">
                    <h3><%: Title %>.</h3>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                     </div>
            </section>
        </div>
    </div>
</asp:content>

