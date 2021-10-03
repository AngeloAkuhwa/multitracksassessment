<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Pages_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../lib/bootstrap/js/bootstrap.min.js"></script>
    <script src="https://use.fontawesome.com/f59bcd8580.js"></script>
    <link href="../PageToSync/css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">   
       
        <div class="container">
            <div class="row">
		        <div class="mx-auto p-4">
			        <a href="/default.aspx">
                        <img src="//mtracks.azureedge.net/public/images/site/logo/en/logo-mono.svg" id="header_logo" class="header--mobile--logo--img mod-full" alt="MultiTracks.com"/>
                    </a>
		        </div>
            </div>
        </div>
        <div class="container">
            <div class="row m-5 no-gutters shadow-lg">
                <div class="col-md-6 d-none d-md-block">
                <img src="https://unsplash.com/photos/nOFXvnRMMK4/download?force=true" class="img-fluid" style="min-height:100%;" />
                </div>
            <div class="col-md-6 bg-white p-5">
                <h3 class="pb-3">Login</h3>
                <div class="form-style">
                <form>

                      <div class="form-group pb-3">    
                        <input type="email" placeholder="Email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">   
                      </div>

                      <div class="form-group pb-3">   
                        <input type="password" placeholder="Password" class="form-control" id="exampleInputPassword1">
                      </div>

                      <div class="d-flex align-items-center justify-content-between">
                        <div class="d-flex align-items-center"><input name="" type="checkbox" value="" /> <span class="pl-2 font-weight-bold">Remember Me</span></div>
                        <div><a href="#">Forget Password?</a></div>
                      </div>

                       <div class="pb-2">
                          <button type="submit" class="btn btn-dark w-100 font-weight-bold mt-2">Submit</button>
                       </div>
                </form>
                      <div class="sideline">OR</div>

                      <div>
                      <button type="submit" class="btn btn-primary w-100 font-weight-bold mt-2"><i class="fa fa-facebook" aria-hidden="true"></i> Login With Facebook</button>
                      </div>

                      <div class="pt-4 text-center">
                      Get Members Benefit. <a href="/SignUp.aspx">Sign Up</a>
                      </div>
                    
               </div>

            </div>
            </div>
        </div>
    </form>
</body>
</html>
