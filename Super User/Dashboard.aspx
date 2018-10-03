<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Admin_Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
   

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
  
</asp:Content>

