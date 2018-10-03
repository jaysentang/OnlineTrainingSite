<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomErrorPage.aspx.cs" Inherits="Error_CustomErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Content/style.css" rel="stylesheet" type="text/css"  media="all" />
    <div class="wrap">
			<!---start-header---->
				
			<!---End-header---->
			<!--start-content------>
			<div class="content">
				<img src="../images/error-img.png" title="error" />
				<p><span><label>O</label>hh.....</span>You Requested the page that is no longer There.</p>
				<a href="../Default.aspx">Back To Home</a>
   			</div>
			<!--End-Cotent------>
		</div>
</asp:Content>

