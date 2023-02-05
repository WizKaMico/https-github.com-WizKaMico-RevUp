<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="RevUp.Verification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="CSS/main.css"/>
</head>
<body>
    <section style="background-color:#53e3a6;">
    <div class="container">
      <div class="user signinBx">
       <div class="imgBx"  style="background-color:white;"><img alt="" src="CSS/LOGO/PFVF_logo.png" style="width:100%; margin-top:170px; height:auto;"/></div>
        <div class="formBx"  style="background-color:white;">
          <form id="form1" runat="server"   >
            <h2>HI <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></h2>
              <asp:Label ID="lblResponse" runat="server" Text=""></asp:Label>
              <asp:TextBox ID="TextBox1" TextMode="Number" runat="server"></asp:TextBox>
              <asp:Button ID="Button1" runat="server" Text="VERIFY" OnClick="Button1_Click" />
            
          </form>
        </div>
      </div>
     
    </div>
  </section>
</body>
    <script  src="JS/main.js"></script>
</html>

