﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="Stylesheet" href="css/bootstrap.min.css" />
    <link rel="Stylesheet" href="dist/css/login.css" />
    <link rel="Stylesheet" href="css/alertify.min.css" />
    <link rel="Stylesheet" href="dist/css/sweetalert.css" />
    <script src="js/jquery.js"></script>
    <script src="dist/js/bootstrap.js"></script>
    <script src="js/alertify.min.js"></script>
    <script src="dist/js/sweetalert.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="container">
    <div class="row">
        <div class="col-sm-6 col-md-4 col-md-offset-4">
          
            <div class="account-wall">
                <img class="profile-img" src="https://lh5.googleusercontent.com/-b0-k99FZlyE/AAAAAAAAAAI/AAAAAAAAAAA/eu7opA4byxI/photo.jpg?sz=120"
                    alt="">
                <form class="form-signin">
                <asp:TextBox runat="server"  ID="txtUsuario" class="form-control" placeholder="usuario" required autofocus></asp:TextBox><br />
                <asp:TextBox runat="server"  ID="txtContrasena" TextMode="Password"  class="form-control" placeholder="Password" required></asp:TextBox>
                <asp:LinkButton runat="server" ID="btnLogin" class="btn btn-lg btn-primary btn-block" OnClick="btnLogin_Click" >Ingresar</asp:LinkButton> 
                   
               
                <span class="clearfix"></span>
                </form>
            </div>
        </div>
    </div>
</div>
    </form>
</body>
</html>
