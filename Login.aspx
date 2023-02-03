<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RevUp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="CSS/main.css"/>
</head>
<body>
    <section>
    <div class="container">
      <div class="user signinBx">
        <div class="imgBx"><img src="https://raw.githubusercontent.com/WoojinFive/CSS_Playground/master/Responsive%20Login%20and%20Registration%20Form/img1.jpg" alt="" /></div>
        <div class="formBx">
          <form id="form1" runat="server" onsubmit="return false;">
            <h2>Sign In</h2>
              <asp:TextBox ID="TextBox1" TextMode="Email" runat="server"></asp:TextBox>
              <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
              <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <p class="signup">
              Don't have an account ?
              <a href="#" onclick="toggleForm();">Sign Up.</a>
            </p>
          </form>
        </div>
      </div>
     
    </div>
  </section>
</body>
    <script  src="JS/main.js"></script>
</html>
