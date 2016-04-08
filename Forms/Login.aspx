<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hospital_asp.Forms.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>ورود به برنامه</title>
    <link href="../Fonts/font.css" rel="stylesheet" />
    <link href="../css-common/commons.css" rel="stylesheet" />
    <link href="../Image/Dapino-Medical-Medical-suitecase.ico" rel="shortcut icon" />
    <link href="../assets/Bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../assets/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <div class=" background">
        <div class="demu">
            <div class=" avatar col-lg-8 col-lg-offset-2 col-md-3 col-md-offset-3 col-sm-6 col-sm-offset-3 col-xs-6 col-xs-offset-3  container-fluid" style="text-align:center">
                <img src="../Image/avatar.png" class="img-circle">
            </div>

        </div>
        <div class=" login-form col-lg-offset-5">
            <div class=" login-row">
                <svg class="login-icon ">
                    <path d="M0,20 a10,8 0 0,1 20,0z M10,0 a4,4 0 0,1 0,8 a4,4 0 0,1 0,-8"></path>
                </svg>
                <asp:TextBox runat="server"  id="username" class="login-input" placeholder="نام کاربری"/>
            </div>
            <div class="login-row">
                <svg class="login-icon pass " >
                    <path d="M0,20 20,20 20,8 0,8z M10,13 10,16z M4,8 a6,8 0 0,1 12,0"></path>
                </svg>
               <asp:TextBox  runat="server" id="password" class="login-input" placeholder="پسورد"/>
            </div>
           <asp:Button  runat="server" id="btn_Login" Text="ورود" class=" login-submit" OnClick="btn_Login_Click"/>

        </div>



    </div>



    
 
    </form>
    <script src="../assets/Bootstrap/js/bootstrap.min.js"></script>
 
    <script src="../assets/jquery/jquery-2.1.4.min.js"></script>
    <script src="../assets/Bootstrap/js/bootstrap.js"></script>
    
    <script src="../js-common/commons.js"></script>
</body>
</html>
