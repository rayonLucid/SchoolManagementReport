<%@ Page Title="Login Form" Language="C#"  AutoEventWireup="true" CodeBehind="~/Default.aspx.cs" Inherits="SchoolManagementReport._Default" %>

<html lang="en">
    <head>
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <meta charset="UTF-8">

        <title>Login Form</title>
        <style>
        body{ background-color:wheat;}
            .MainForm{
                display:flex;
                place-content:center;
                flex-direction:column;
                width:30%;
                gap:12px;
                border-radius:5px;
                padding:1em;
                position:relative;
                top:4mm;
                height:40vh;
                background-color:#000000a4;
                box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
            }
            .container_wrapper{
                display:flex;
                place-content:center;
                align-items:center;
                flex-direction:column;
                gap:10px;
                
    background:url("./Content/images/banner2.png")  no-repeat 
    ,url("./Content/images/banner.png")  no-repeat;
     background-position:bottom left,bottom right;
   background-size:400px ,300px  ;
  height:90vh;
 
            }
            input[type=text], input[type=password] {
              width: 100%;
              padding: 12px 20px;
              margin: 8px 0;
              display: inline-block;
              border: 1px solid #ccc;
              box-sizing: border-box;
            }
            button {
            background-color: #042954;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
            }

button:hover {
  opacity: 0.8;
}
        </style>
    </head>
    <body>
        <main class="container_wrapper">
        <img src="/Content/images/logo.png" width="200" height="200" />
             <form class="MainForm" id="MainForm" method="post">
      <label for="uname" style="color:white"><b>Username</b></label>
      <input type="text" placeholder="Enter Username" name="uname"  id="UserName" required>

      <label for="psw" style="color:white"><b>Password</b></label>
      <input type="password" placeholder="Enter Password" name="psw" id="Password" required>
        
      <button type="button" onclick="LoginForm()">Login</button>
    

   <%-- <div class="container" style="background-color:#f1f1f1">
      <span class="psw">Forgot <a href="#">password?</a></span>
    </div>--%>
<input type="hidden" id="Action" />
  </form>
            <script src="Scripts/Login.js"></script>
        </main>
    </body>
</html>