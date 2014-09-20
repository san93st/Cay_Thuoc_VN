<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="doi-matkhau.aspx.cs" Inherits="BTL_CSDL.admin.reset_pass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#home" data-toggle="tab">Đổi mật khẩu</a></li>
        </ul>
        <div id="myTabContent" class="tab-content">
            <div class="tab-pane active in" id="home">
                <asp:Label runat="server" ForeColor="Red" ID="lbDisplay"></asp:Label>
                <label>Mật Khẩu Cũ</label>
                <asp:TextBox ID="txtOldPass" TextMode="Password" CssClass="input-xlarge" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" Display="Dynamic" ControlToValidate="txtOldPass" ValidationGroup="editQL" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Thiếu mật khẩu cũ"></asp:RequiredFieldValidator>

                <label>Mật khẩu mới</label>
                <asp:TextBox ID="txtNewPass1" CssClass="input-xlarge" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtNewPass1" ValidationGroup="editQL" ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Thiếu mật khẩu mới"></asp:RequiredFieldValidator>
                <asp:CompareValidator ForeColor="Red" Display="Dynamic" ControlToValidate="txtNewPass1" ControlToCompare="txtNewPass2" ID="CompareValidator1" runat="server" ValidationGroup="editQL" ErrorMessage="Mật khẩu mới và gõ lại mật khẩu không trùng nhau"></asp:CompareValidator>
                
                <label>Gõ Lại Mật khẩu mới</label>
                <asp:TextBox ID="txtNewPass2" CssClass="input-xlarge" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtNewPass2" ValidationGroup="editQL" ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Thiếu mật khẩu mới"></asp:RequiredFieldValidator>
                <div>
                    <asp:Button ValidationGroup="editQL" OnClick="btnUpdate_Click" ID="btnUpdate" runat="server" Text="Đổi" class="btn btn-primary"></asp:Button>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">Đổi lại mật khẩu</h1>
    </div>
</asp:Content>
