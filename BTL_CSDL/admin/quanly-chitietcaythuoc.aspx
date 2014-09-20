<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="quanly-chitietcaythuoc.aspx.cs" Inherits="BTL_CSDL.admin.quanly_chitietcaythuoc" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">Quản lý cây thuốc</h1>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="btn-toolbar">

        <asp:Button ValidationGroup="save" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" ID="btnSave" Text="Save"  />
        <asp:LinkButton runat="server" ID="btnDelete" OnClick="btnDelete_Click" CssClass="btn" >Cancel</asp:LinkButton>
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
                <label>Mã Cây Thuốc</label>
                <asp:TextBox ID="txtMaCayThuocs" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <label>Tên Hiển Thị</label>
                <asp:TextBox ID="txtTenHienThi" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ControlToValidate="txtTenHienThi" ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Thiếu Tên Hiển Thị"></asp:RequiredFieldValidator>
                <label>Tên Khoa Học</label>
                <asp:TextBox ID="txtTenKH" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="txtTenKH" ValidationGroup="save" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Thiếu Tên Khoa Học"></asp:RequiredFieldValidator>
                <label>Mã Họ Của Cây Thuốc</label>
                <asp:DropDownList ID="dlMaHo" runat="server"></asp:DropDownList>
                <label>Nội Dung Hiển Thị</label>
                <CKEditor:CKEditorControl BasePath="ckeditor" ID="txtNoiDung" runat="server"></CKEditor:CKEditorControl>
                <label>Trạng Thái(Hiển Thị Hay Không)</label>
                <asp:CheckBox  runat="server" ID="cbDisplay" />
            </div>
        </div>

    </div>
</asp:Content>
