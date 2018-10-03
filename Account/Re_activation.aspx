<%@ Page Title="Email Activation" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Re_activation.aspx.cs" Inherits="Account_Re_activation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
</asp:Content>

