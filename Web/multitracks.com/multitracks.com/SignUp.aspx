<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="Pages_SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../lib/bootstrap/js/bootstrap.min.js"></script>
    <link href="../PageToSync/css/signup.css" rel="stylesheet" />
</head>
<body style="background-color:#e9ecef !important;">

<form  method="post" runat="server" >

<div class="container">
	<div class="row">
		<div class="mx-auto p-4">
			<a href="/default.aspx">
                <img src="//mtracks.azureedge.net/public/images/site/logo/en/logo-mono.svg" id="header_logo" class="header--mobile--logo--img mod-full" alt="MultiTracks.com"/>
            </a>
		</div>
	</div>
	<div class="row">
		<div class="col-xs-12 col-sm-12 col-md-8 mx-auto">
			<div class="form-horizontal">
				<br/>
				<fieldset style="background-color: white !important; margin:0 auto;">
				  <h2 style="font-size:3rem;" class="mx-auto text-center">Create Account</h2>
					<p class="text-center" style="font-size:1.5rem;">Already have an account? <a href="/login.aspx">Login</a></p> 
					
						<div class="form-group">
							<label for="name" class="cols-sm-2 control-label">First Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" runat="server" class="form-control" name="firstname" id="firstname"  placeholder="Enter your firstName" required ="required"/>
								</div>
							</div>
						</div>

					<div class="form-group">
						<label for="email" class="cols-sm-2 control-label">Last Name</label>
						<div class="cols-sm-10">
							<div class="input-group">
								<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
								<input type="text" runat="server" class="form-control" name="lastName" id="lastname"  placeholder="Enter your lastName" required ="required"/>
							</div>
						</div>
					</div>

					
					<div class="form-group">
						<label for="email" class="cols-sm-2 control-label">Email</label>
						<div class="cols-sm-10">
							<div class="input-group">
								<span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
								<input type="text" runat="server" class="form-control" name="email" id="email"  placeholder="Enter your Email" required ="required"/>
							</div>
						</div>
					</div>

					<div class="form-group">
						<label for="email" class="cols-sm-2 control-label">Church or Organization</label>
						<div class="cols-sm-10">
							<div class="input-group">
								<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
								<input type="text" runat="server" class="form-control" name="church" id="church"  placeholder="Enter your church or organization" required="required"/>
							</div>
						</div>
					</div>

					<div class="form-group">
						<label for="email" class="cols-sm-2 control-label">Language</label>
						<div class="cols-sm-10">
							<div class="input-group">
								<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
								<input type="text" runat="server" class="form-control" name="language" id="language"  placeholder="Enter your language" required="required"/>
							</div>
						</div>
					</div>

					<div class="form-group">
						<label for="email" class="cols-sm-2 control-label">Country</label>
						<div class="cols-sm-10">
							<div class="input-group">
								<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
								<input type="text" runat="server" class="form-control" name="country" id="country"  placeholder="Enter your country" required="required"/>
							</div>
						</div>
					</div>

					<div class="form-group">
						<label for="email" class="cols-sm-2 control-label">Address</label>
						<div class="cols-sm-10">
							<div class="input-group">
								<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
								<input type="text" runat="server" class="form-control" name="address" id="address"  placeholder="Enter your address" required="required"/>
							</div>
						</div>
					</div>

					<div class="form-group">
						<label for="password" class="cols-sm-2 control-label">Password</label>
						<div class="cols-sm-10">
							<div class="input-group">
								<span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
								<input type="text" runat="server" class="form-control" name="zip" id="zip"  placeholder="zip code" required="required"/>
							</div>
						</div>
					</div>

					<div class="form-group">
						<label for="password" class="cols-sm-2 control-label">Password</label>
						<div class="cols-sm-10">
							<div class="input-group">
								<span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
								<input type="password" runat="server" class="form-control" name="password" id="password"  placeholder="Enter your Password" required="required"/>
							</div>
						</div>
					</div>


					<div class="form-group ">
						<button type="submit" id="btnRegister" runat="server" class="btn btn-info btn-lg btn-block login-button">Register</button>
					</div>
				</fieldset>
			</div>

			<div class="modal fade" tabindex="-1" id="successModal" data-keyboard="false" data-backdrop="static">
				<div class="modal-dialog modal-md">
					<div class="modal-content">
						<div class="modal-header">
							<button type="button" class="close" data-dissmiss="modal">
								&times;
							</button>
							<h6>Success</h6>
						</div>
						<div class="modal-body">
							<h3>Registration Successful</h3>
						</div>
						<div class="modal-footer">
							<button type="button" data-dissmiss="modal"  class="btn btn-success">
								close
							</button>
						</div>

					</div>

				</div>

				<div id="divError" class="alert alert-alert-danger collapse">
					<a id="linkClose" class="close" href="#">&times;</a>
					<div id="divErrorText"></div>
				</div>
			</div>

		</div>
	</div>
  </div>  
</form>

</body>
</html>
