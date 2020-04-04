<!DOCTYPE html>
<script runat="server">

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs)

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

        <script src="assets/js/jquery-1.8.2.min.js" ></script>
        <script src="assets/js/supersized.3.2.7.min.js" ></script>
        <script src="assets/js/supersized-init.js" ></script>
        <script src="assets/js/scripts.js" ></script>

        <div class="page-container">
            <h1>疫苗追踪管理系统</h1>
            <input id="Username" type="text" />
            <input id="Password" type="password" title="根本改变"/><div class="error"><span>+</span></div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登   录" BackColor="#E95A25" Font-Bold="True" Font-Size="Large" Width="365px" />
     
        </div>
	
        </form>

    </body>
</html>

