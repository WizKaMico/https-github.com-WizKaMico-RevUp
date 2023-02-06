<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg_Information.aspx.cs" Inherits="RevUp.Reg_Information" %>


<!DOCTYPE html>
<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title></title>
 <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"><link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css'>
    <link rel="stylesheet" href="CSS/home.css" />

</head>
<body>
<!-- partial:index.partial.html -->
<nav class="navbar navbar-dark flex-md-nowapr fixed-top p-0 shadow" style="background-color:#53e3a6;">
  <a class="navbar-brand col-sm-3 col-md-2 mr-0" href="#">DASHBOARD</a>
  <form class="form">
    <input class="form-control form-control-primary" type="search" placeholder="Search" aria-label="Search">
  </form>
    <ul class="navbar-nav px-3">
      <li class="nav-item text-nowarp">
        <a class="nav-link" href="/Login.aspx">Logout</a>
      </li>
    </ul>

</nav>

<!--container-->
<div class="container-fluid">
  <div class="row">
    <!-- Sidebar --->
    <div class="col-md-2 bg-light d-md-block sidebar">
      <div class="left-sidebar">
        <ul class="nav flex-column sidebar-nav">
          <li class="nav-item">
            <a class="nav-link active" href="#">
              <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-chevron-right" viewBox="0 0 16    16"><path fill-rule="evenodd" d="M4.646 1.646a.5.5 0 0 1 .708 0l6 6a.5.5 0 0 1 0 .708l-6 6a.5.5 0 0 1-.708-.708L10.293 8 4.646 2.354a.5.5 0 0 1 0-.708z"/></svg>
              HOME
            </a>
          </li>
        
        </ul>
      </div>
    </div>
      
      <!--Main element-->
        <main role="main" class="col-md-10 ml-sm-auto col-lg-10 px-4">
          <h3>HI! <b><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></b> | CODE SPECIFIC FILE :  <b><asp:Label ID="lblCode" runat="server" Text=""></asp:Label></b></h3>
          <hr>
          <div class="table-responsive-sm">
               <div class="row">
                  <div class="col-sm-6">
                    <div class="card">
                      <div class="card-body">
                        <h5 class="card-title">REGISTRANT INFORMATION</h5>
                          <form runat="server">
                          <asp:Label ID="lblFname" runat="server" Text="Firstname"></asp:Label>
                          <br />
                          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                          <br />
                          <br />
                          <asp:Label ID="lblMname" runat="server" Text="Middlename"></asp:Label>
                          <br />
                          <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                          <br />
                          <br />
                          <asp:Label ID="lblLname" runat="server" Text="Lastname"></asp:Label>
                          <br /> 
                          <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                          <br />
                          <br />
                          <hr />
                          <asp:Button ID="Button1" runat="server" Text="UPDATE" OnClick="Button1_Click"/>
                          </form>
                      </div>
                    </div>
                  </div>
                  <div class="col-sm-6">
                    <div class="card">
                      <div class="card-body">
                        <h5 class="card-title">QR CODE</h5>
                          <center><asp:Image ID="Image1" runat="server" /></center>
                      </div>
                    </div>
                  </div>
                </div>
         </div>
          
       

    

          
       </main>
<!-- partial -->
 <script src='https://code.jquery.com/jquery-3.3.1.slim.min.js'></script>
<script src='https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js'></script>
<script src='https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js'></script>
</body>
</html>

