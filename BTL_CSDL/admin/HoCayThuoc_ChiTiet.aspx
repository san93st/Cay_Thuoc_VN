<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="HoCayThuoc_ChiTiet.aspx.cs" Inherits="BTL_CSDL.admin.HoCayThuoc_ChiTiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">
            <asp:Label runat="server" ID="lbTitle"></asp:Label></h1>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="btn-toolbar">

        <asp:Button ValidationGroup="save" runat="server" CssClass="btn btn-primary" ID="btnSave" Text="Insert" OnClick="btnSave_Click" />
        <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn" OnClick="btnDelete_Click">Cancel</asp:LinkButton>
        <div class="btn-group">
        </div>
    </div>
    <div class="well">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">Thông Tin Họ Cây Thuốc</a></li>
        </ul>
        <div id="myTabContent" class="tab-content">
            <div class="tab-pane active in" id="home">
                <asp:Label runat="server" ID="lbDisplay"></asp:Label>
                <label>Mã họ cây thuốc</label>
                <asp:TextBox ID="txtMaHo" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <label>Tên Hiển Thị</label>
                <asp:TextBox ID="txtTenHienThi" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="save" ForeColor="Red" ControlToValidate="txtTenHienThi" runat="server" ErrorMessage="Chưa nhập thông tin về tên hiển thị của họ cây thuốc"></asp:RequiredFieldValidator>
                <label>Tên Khoa Học</label>
                <asp:TextBox ID="txtTenKH" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtTenKH" ForeColor="red" ValidationGroup="save" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Chưa nhập thông tin về tên Khoa Học của họ cây thuốc"></asp:RequiredFieldValidator>
            </div>
        </div>

    </div>
</asp:Content>
