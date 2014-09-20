<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="quanly-chitietlienhe.aspx.cs" Inherits="BTL_CSDL.admin.quanly_chitietlienhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">
            <asp:Label runat="server" Text="Chi Tiết Liên Hệ" ID="lbTitle"></asp:Label></h1>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="btn-toolbar">

        <asp:Button runat="server" CssClass="btn btn-primary" ID="btnSave" Text="Update" OnClick="btnSave_Click"/>
        <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn" OnClick="btnDelete_Click" >Cancel</asp:LinkButton>
        <div class="btn-group">
        </div>
    </div>
    <div class="well">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">Thông Tin</a></li>
        </ul>
        <div id="myTabContent" class="tab-content">
            <div class="tab-pane active in" id="home">
                <asp:Label runat="server" ID="lbDisplay"></asp:Label>
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" Enabled="false" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <label>Tên Hiển Thị</label>
                <asp:TextBox ID="txtTenHienThi" Enabled="false" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <label>Tiêu Đề</label>
                <asp:TextBox ID="txtTieuDe" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <label>Nội Dung</label>
                <asp:TextBox ID="txtNoiDung" Enabled="false" TextMode="MultiLine" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <label>Trạng thái</label>
                <span>
                    <asp:CheckBox runat="server" ID="cbTrangThai" Text="Trạng thái liên hệ" /></span>
                <label>Số Điện Thoại</label>
                <asp:TextBox ID="txtSoDienThoai" Enabled="false" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <label>Ngày Gửi</label>
                <asp:TextBox ID="txtNgayGui" Enabled="false" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <br />
                <asp:Label runat="server" ID="lbNgayLienHe">Ngày Liên Hệ</asp:Label>
                <br />
                <asp:TextBox ID="txtNgayLienHe" Enabled="false" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <label>Mã Quản Lý Đã Liên Hệ</label>
                <asp:TextBox ID="txtMaQL" Enabled="false" CssClass="input-xlarge" runat="server"></asp:TextBox>

            </div>
        </div>

    </div>
</asp:Content>
