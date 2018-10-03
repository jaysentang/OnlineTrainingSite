<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .carousel {
    height: 250px;
    }

.item,
.active,
.carousel-inner {
    height: 250px;
    }

/* Background images are set within the HTML using inline CSS, not here */

    .fill {
    width: 100%;
    height: 250px;
   
    -webkit-background-size: cover;
    -moz-background-size: cover;
    background-size: cover;
    -o-background-size: cover;
    }
    </style>

    <!--div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </!--div>

    <!--div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div-->
     <div class="col-md-12">

    <div id="myCarousel" class="carousel slide">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for Slides -->
        <div class="carousel-inner">
            <div class="item active">
                <!-- Set the first background image using inline CSS below. -->
                <div class="fill" style="background-image:url('images/fullscreen/slide2.jpg');"></div>
                <!--div class="carousel-caption">
                    <input type="button" class="btn btn-default" style="background-color:transparent; color:white;" value="Get Started &raquo" />
                </div-->
            </div>
            <div class="item">
                <!-- Set the second background image using inline CSS below. -->
                <div class="fill" style="background-image:url('images/fullscreen/slide3.jpg');"></div>
                <!--div class="carousel-caption">
                    <h2>Caption 2</h2>
                </div-->
            </div>
            <div class="item">
                <!-- Set the third background image using inline CSS below. -->
                <div class="fill" style="background-image:url('images/fullscreen/slide4.jpg');"></div>
                <!--div class="carousel-caption">
                    <h2>Caption 3</h2>
                </!div-->
            </div>
        </div>

        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="icon-prev"></span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="icon-next"></span>
        </a>

   
         </div>
</div>

     <div class="col-md-6">
            <h2>What is ASRS</h2>
            <p>
                AS/RS systems are designed for automated storage and retrieval of parts and items in manufacturing, distribution, retail, wholesale and institutions. 
            </p>
          
        </div>
        <div class="col-md-6">
            <h2>How it work?</h2>
            <p>
               This site will deliver the understanding of how to control and monitor the AS/RS system.
            </p>
            <p>
                <a class="btn btn-default" style="background-color:transparent; color:black;" href="Account/Login.aspx">Get Started &raquo</a>
            </p>
        </div>
    
    <script>
    $('.carousel').carousel({
        interval: 5000 //changes the speed
    })
    </script>
</asp:Content>
