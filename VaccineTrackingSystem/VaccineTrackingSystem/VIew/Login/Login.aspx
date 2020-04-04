<!DOCTYPE html>
<script runat="server">

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
</script>

<html>
<html lang="en" class="no-js">

    <head>

        <meta charset="utf-8">
        <title>登录(Login)</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="">
        <meta name="author" content="">

        <!-- CSS -->
        <link rel="stylesheet" href="assets/css/reset.css">
        <link rel="stylesheet" href="assets/css/supersized.css">
        <link rel="stylesheet" href="assets/css/style.css">

    </head>

    <body>

        <form id="form1" runat="server">

        <div class="page-container">
            <h1>登   录</h1>
            <input id="Username" type="text" width="300px" />
            <input id="Password" type="password" width="300px" /><div class="error"><span>+</span></div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登   录" BackColor="#E95A25" Font-Bold="True" Font-Size="Large" Width="380px" />
     
        </div>
	
        <script src="assets/js/jquery-1.8.2.min.js" ></script>
        <script src="assets/js/supersized.3.2.7.min.js" ></script>
        <script src="assets/js/supersized-init.js" ></script>
        <script src="assets/js/scripts.js" ></script>

        </form>

    </body>
</html>

