<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>
<html lang="en" class="">
   <head>
      <meta name="viewport" content="width=device-width, initial-scale=1.0">
      <title>
         Assessment | MultiTracks
      </title>
      <meta charset="utf-8">
        <link href="../Content/bootstrap.min.css" rel="stylesheet" />
        <script src="../Scripts/jquery-3.0.0.min.js"></script>
        <script src="../lib/bootstrap/js/bootstrap.min.js"></script>
       <link href="PageToSync/css/LandingView.css" rel="stylesheet" />
       <link href="css/font-awesome.min.css" rel="stylesheet" />
   </head>
   <body id="about" class="premium standard">
      <form>
         <header class="header mod-interior remodal-bg">

           <nav class="navbar navbar-expand-lg navbar-light bg-light">
                  <div class="container-fluid">
                    <a class="navbar-brand" href="#">
                        <img src="//mtracks.azureedge.net/public/images/site/logo/en/logo-mono.svg" id="header_logo" class="header--mobile--logo--img mod-full" alt="MultiTracks.com">
                    </a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                      <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                      <ul class="navbar-nav me-auto mb-2 mb-lg-0 ">
                        <li class="nav-item">
                          <a class="nav-link" href="#">All</a>
                        </li>
                         <li class="nav-item">
                          <a class="nav-link" href="/SignUp.aspx">Sign Up</a>
                        </li>
                        <li class="nav-item">
                          <a class="nav-link" href="/login.aspx">Login</a>
                        </li>
                        <li class="nav-item">
                        <a class="nav-link" href="/login.aspx">Cart</a>
                        </li> 
                        <li class="nav-item">
                         <a class="nav-link" href="/login.aspx">Help Center</a>
                        </li> 
                         <li class="nav-item">
                         <a class="nav-link" href="/artistDetails.aspx">Artist Details</a>
                        </li>  
                      </ul>
                          <hr/>
                    </div>
                  </div>
            </nav>

             <div class="container">
                <div class="row">
                      <div class="conectedStage">
                        <h1>Welcome to </h1>
                        <h1>The Connected Stage</h1>
                      </div>
                  </div>
             </div>

             <div class="container">
                     <div class="jumbotron">
                         <img src="https://unsplash.com/photos/yWF2LLan-_o/download?force=true" alt="musical photo" style="width:100%; height:400px; object-fit:cover"/>
                     </div>
             </div>
         </header>

         <div class="wrapper mod-standard remodal-bg">
            <div class="text-hero mod-headphones ly-delta">
               <h1 class="text-hero--title">DotNET Assessment</h1>
            </div>
            <main class="standard--container u-container">
               <div class="u-row mod-between-md">
                  <div class="u-col-xs-12 u-col-md-12 u-col-lg-10">
                     <div class="standard--content">
                        <div class="about--row">
                           <h2>Welcome!</h2>
                            <p>So you want to work for MultiTracks.com? This is a step in the right direction!</p>
                            <p>
                                This page is part of a Visual Studio solution containing a Class Library and a Web Forms Website project.
                                As a member of the DotNET server team at MultiTracks.com you will most likely find yourself in similar projects on a regular basis.
                                We have a number of projects also utilizing DotNetCore and all new projects in DotNet 5.
                            </p>

                            <p>
                                Below is a list of tasks required to complete this assessment.
                            </p>

                            <p runat="server" id="publishDB">
                                <strong>First things first! Go ahead and publish the DB and get the website connection string updated.</strong>
                            </p>

                            <ul runat="server" id="items">
                                <asp:Repeater runat="server" ID="assessmentItems">
                                    <ItemTemplate>
                                        <li><%#Eval("text") %></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>

                        </div>
                     </div>
                  </div>
               </div>

                
            </main>
         </div>
      </form>
   </body>
</html>