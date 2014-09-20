<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LOGIN.aspx.cs" Inherits="BTL_CSDL.admin.LOGIN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <title>LOGIN CAY THUOC VN</title>

    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css"/>
    <link rel="stylesheet" type="text/css" href="stylesheets/theme.css"/>
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css"/>

    <script src="lib/jquery-1.7.2.min.js" type="text/javascript"></script>

    <!-- Demo page code -->

    <style type="text/css">
        #line-chart {
            height: 300px;
            width: 800px;
            margin: 0px auto;
            margin-top: 1em;
        }

        .brand {
            font-family: georgia, serif;
        }

            .brand .first {
                color: #ccc;
                font-style: italic;
            }

            .brand .second {
                color: #fff;
                font-weight: bold;
            }
    </style>

    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

    <!-- Le fav and touch icons -->
    <link rel="shortcut icon" href="../assets/ico/favicon.ico">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="navbar">
                <div class="navbar-inner">
                    <ul class="nav pull-right">
                    </ul>
                    <a class="brand" href="#"><span class="first">CÂY THUỐC</span></a>
                </div>
            </div>
            <div class="row-fluid">
                <div class="dialog">
                    <div class="block">
                        <p class="block-heading">ĐĂNG NHẬP HỆ THỐNG CÂY THUỐC VIỆT NAM</p>
                        <div class="block-body">
                            <asp:Label runat="server" ID="lbHienThi"></asp:Label>
                            <label>MÃ TÀI KHOẢN HOẶC EMAIL:</label>
                            <asp:TextBox class="span12" ID="txtUserName" runat="server"></asp:TextBox>
                            <label>MẬT KHẨU:</label>
                            <asp:TextBox TextMode="Password"  ID="txtPass" class="span12" runat="server"></asp:TextBox>
                            <asp:LinkButton class="btn btn-primary pull-right"  ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Đăng nhập</asp:LinkButton>
                            
                            <label class="remember-me">
                                <asp:CheckBox ID="cbRememberMe" runat="server" />
                                Remember me</label>
                            <div class="clearfix"></div>

                        </div>
                    </div>
                </div>
            </div>
            <script src="lib/bootstrap/js/bootstrap.js"></script>
            <script type="text/javascript">
                $("[rel=tooltip]").tooltip();
                $(function () {
                    $('.demo-cancel-click').click(function () { return false; });
                });
    </script>
        </div>
    </form>
</body>
</html>
