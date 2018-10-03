<%@ Page Title="CourseContent" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CourseContent.aspx.cs" Inherits="Course_CourseContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
       <style type="text/css">

           @media (max-width: 768px) {
           .course-section-header {
                font-size:small;
               }
               .customlink {
                font-size:smaller;
               }
               .glyphicon.glyphicon-play-circle {
               font-size:15px;
               top:4px;
               }

               .glyphicon.glyphicon-pencil {
               font-size:15px;
               top:4px;
               }
               .glyphicon.glyphicon-ok {
               font-size:10px;
               top:4px;
               }

                .glyphicon.glyphicon-ok.seen {
               font-size:10px;
               top:4px;
               }
           }
       </style>
		
       <div class="col-md-12">
           <div>
               <img style="width:100%; height:330px" src="image/asrs-shuttle.jpg" />
           </div>

        <div class="content-box-course">
            
            <div runat="server" class="panel-body" id="container">
                
            </div>
            </div>
           </div>
        
   
</asp:Content>

