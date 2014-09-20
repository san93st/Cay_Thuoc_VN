<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="quanly-chitietuser.aspx.cs" Inherits="BTL_CSDL.admin.quanly_chitietuser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="js/calendar-en.min.js" type="text/javascript"></script>
    <link href="stylesheets/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtNgaySinh.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css">

    <link rel="stylesheet" type="text/css" href="stylesheets/theme.css">
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css">

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">Thông Tin Chi Tiết Quản Lý</h1>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="btn-toolbar">

        <asp:Button runat="server" ValidationGroup="editQL" CssClass="btn btn-primary" ID="btnSave" Text="SAVE" OnClick="btnSave_Click" />
        <asp:LinkButton runat="server" ID="btnCancel" CssClass="btn" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
        <div class="btn-group">
        </div>
    </div>
    <div class="well">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">Thông tin quản lý</a></li>
            <li><a href="#profile" data-toggle="tab">Khôi phục mật khẩu</a></li>
        </ul>
        <div id="myTabContent" class="tab-content">
            <div class="tab-pane active in" id="home">
                <asp:Label runat="server" ID="lbDisplay"></asp:Label>
                <label>Mã Quản Lý</label>
                <asp:TextBox ID="txtMaQL" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="txtMaQL" ValidationGroup="editQL" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Thiếu Mã Quản Lý"></asp:RequiredFieldValidator>

                <label>Tên Quản Lý</label>
                <asp:TextBox ID="txtTenQL" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtTenQL" ValidationGroup="editQL" ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Thiếu Tên Quản Lý"></asp:RequiredFieldValidator>

                <label>Địa Chỉ</label>
                <asp:TextBox ID="txtDiaChi" CssClass="input-xlarge" runat="server"></asp:TextBox>

                <label>Email</label>
                <asp:TextBox ID="txtEmail" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="editQL" ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Thiếu Email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ForeColor="red" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="editQL" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Địa Chỉ Email không đúng!"></asp:RegularExpressionValidator>

                <label>Số Điện Thoại</label>
                <asp:TextBox ID="txtSDT" CssClass="input-xlarge" runat="server"></asp:TextBox>

                <label>Ngày Sinh</label>
                <asp:TextBox ID="txtNgaySinh" runat="server" ReadOnly="true"></asp:TextBox>
                <img src="images/calender.png" />
                <asp:RequiredFieldValidator ControlToValidate="txtNgaySinh" ValidationGroup="editQL" ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Thiếu ngày tháng năm sinh"></asp:RequiredFieldValidator>

                <label>Chỉ định Admin</label>
                <asp:CheckBox ID="cbIsAdmin" runat="server" />
            </div>
            <div class="tab-pane fade" id="profile">
                <label>Khôi phục mật khẩu:</label>
                <asp:Label runat="server" ID="lbKhoiPhucMatKhau" ForeColor="Red"></asp:Label>
                <div>
                    <asp:Button ID="btnKhoiPhuc" OnClick="Unnamed_Click" runat="server" Text="Khôi phục" class="btn btn-primary"></asp:Button>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
