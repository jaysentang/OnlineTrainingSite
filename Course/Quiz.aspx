<%@ Page Title="Quiz" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Quiz.aspx.cs" Inherits="Course_Quiz" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    
    <style>
.question 
{
	background-color:#E0ECF8; 
	margin:10px 10px 10px 10px; 
	padding:10px 10px 10px 10px;	
	border:solid 2px black;
}

.points 
{
	float:right;
	color:Red;
	font-weight:bold;
	font-size:16px;
}


#popOut {
    left:0;
    right:0;
    height: 100%;
    position: fixed; /* Stay in place */
    z-index: 1;   
    visibility:visible;
    display:none;
    background-color: rgba(22,22,22,0.5);
}

#popOut:target {
    visibility: visible;
    display: block;
}
.reveal-modal {
    background:#e1e1e1; 
    margin: 0 auto;
    text-align:center;
    position:relative; 
    z-index:41;
    top: 25%;
    padding:30px; 
    -webkit-box-shadow:0 0 10px rgba(0,0,0,0.4);
    -moz-box-shadow:0 0 10px rgba(0,0,0,0.4); 
    box-shadow:0 0 10px rgba(0,0,0,0.4);
}

        </style>

    <div id="popOut">
    <div id="exampleModal" class="reveal-modal">
     <h2>Result</h2>
     <p id="result">
    
    </p>
        <div style="text-align:center;">
    <input type="button" value="Continue" class="close-reveal-modal"/>
    </div>
        </div>
    </div>
   

    <div class="panel-heading">
                <div class="panel-title">
                    <h3 runat="server" id="Header" style="color: #111; font-family: 'Open Sans Condensed', sans-serif; font-size: 35px; font-weight: 700;   text-transform: uppercase;"></h3>
                </div>
            </div>    

     <div class="col-md-12">

           <p class="text-danger" runat="server" id="message">

                    <asp:Literal runat="server" ID="ErrorMessage" />

                </p>
     <div class="content-box-course">
        <%  int a = 1; foreach (var quiz in questionList)
            {
               %>
         <div class="question">
            <%= a.ToString()+"." %> <%= quiz.Text %> <!--div class="points">(<=quiz.Points%>)</div-->
            
             <% foreach (var ans in quiz.answers)
                 {%>
                
                    <div>
                        <input type="radio" id=<%= ans.Id %> name=<%= ans.QuestionId %>  class="select"/> <%= ans.Text %>
                    </div>
             <%} %>
         </div>
         <% a++; } %>
         <div style="text-align:right;">
          <input type="hidden" id="No" value="<%= a-1 %>"/>
          <input type="button"  id="Done" value="Submit" class="btn btn-default" style="margin-top:10px; margin-right:10px" />
         </div>
     </div>
   </div>


 <script>
     var query3 = getUrlParam()["projectid"]

     $('.close-reveal-modal').click(function () {
         $('div#popOut').hide();
         //search next video page
         var query2 = getUrlParam()["examid"];
         var query = getUrlParam()["courseid"];
         //var query3 = getUrlParam()["projectid"];

         $.ajax({
             type: "POST",
             url: "Handler.ashx?method=getupdate&sectionid=" + query2 + "&courseid=" + query + "&projectid=" + query3,
             dataType: "text",
             success: ReturnData2,
             error: function (Response, status, error) {
                 var r = jQuery.parseJSON(Response.responseText);
                 alert("Message: " + r.Message);
                 alert("StackTrace: " + r.StackTrace);
                 alert("ExceptionType: " + r.ExceptionType);
             }
         });
     });

     function getUrlParam() {
         var parameter = {};
         var url = window.location.href;
         window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi,
          function (m, key, value) {
              parameter[key] = value;
          });
         return parameter;
     }


     function replaceQueryParam(param, newval, search) {
         var regex = new RegExp("([?;&])" + param + "[^&;]*[;&]?");
         var query = search.replace(regex, "$1").replace(/&$/, '');

         return (query.length > 2 ? query + "&" : "?") + (newval ? param + "=" + newval : '');
     }

     function ReturnData2(data) {
         if (typeof data != 'undefined' && data) {
             var param = data.split(",");
             var location = window.location.href;
             window.location.href = location.substring(0, location.lastIndexOf("/") + 1) + "Loading.aspx?sectionid=" + param[0] + "&courseid=" + param[1] + "&projectid=" + query3;
             
         }
     }

     var submit = document.getElementById('Done');
     submit.addEventListener("click", check, false);
     function check() {
         var radiolist = document.getElementsByClassName('select');
         var qty = document.getElementById('No').value;
         var length = radiolist.length;
         var arr = new Array();
         for (var a = 0; a < length; a++) {

             if(radiolist[a].checked==true){
                 var data = {
                     "id": radiolist[a].id,
                     "question": radiolist[a].getAttribute("name")
                 }
                 arr.push(data);
             }
         }

         if (arr.length < qty) {
             var s = document.getElementById('MainContent_message');
             if (s.childNodes.length > 0 && s.childNodes != null) {
                 s.removeChild(s.firstChild);
             }

             var text = document.createTextNode('Please fill up all given question with answer.')
             s.appendChild(text);
         }
         else {

             function getUrlParam() {
                 var parameter = {};
                 var url = window.location.href;
                 window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi,
                  function (m, key, value) {
                      parameter[key] = value;
                  });
                 return parameter;
             }

             var query = getUrlParam()["examid"]

         $.ajax({
             type: "POST",
             url: "CheckQuiz.ashx?examid="+ query, //?sectionid=" + sectionid
             dataType: "text",
             contentType: "application/json",
             data: JSON.stringify({data:arr}),//{data:data}
             success: function (data) {
                 if (typeof data != 'undefined' && data) {
                     document.getElementById('result').innerText = "Your Score: " + data +"\n"+ "let's proceed to next tutorial.";
                     $('div#popOut').show();
                 }
             },
             error: function (Response, status, error) {
                 //var r = jQuery.parseJSON(Response.responseText);
                 //alert("Message: " + Response.responseText);
                 //alert("StackTrace: " + r.StackTrace);
                 //alert("ExceptionType: " + r.ExceptionType);

           
             }
         });
         }
     }

 </script>
</asp:Content>

