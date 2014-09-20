<%@ Page Title="" Language="C#" MasterPageFile="~/client.Master" AutoEventWireup="true" CodeBehind="lienhe.aspx.cs" Inherits="BTL_CSDL.lienhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <tr>
        <td>
            <center><b>FORM LIÊN HỆ VỚI QUẢN TRỊ WEBSITE</b>
             <asp:Label runat="server" ID="lbDisplay" ForeColor="Red"></asp:Label>
            <br />
            <table border="0">
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox Style="width: 300px" runat="server" ID="txtEmail" TextMode="Email"></asp:TextBox></td>

                </tr>
                <tr>
                    <td>Tên Hiển Thị:</td>
                    <td>
                        <asp:TextBox Style="width: 300px" runat="server" ID="txtTenHienThi"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Tiêu Đề:</td>
                    <td>
                        <asp:TextBox Style="width: 300px" runat="server" ID="txtTieuDe"  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Nội Dung:</td>
                    <td>
                        <asp:TextBox Style="width: 300px" runat="server" ID="txtNoiDung" Rows="10" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Số Điện Thoại:</td>
                    <td>
                        <asp:TextBox Style="width: 300px" runat="server" ID="txtSDT" TextMode="Phone"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="btnSend" Text="Gửi Liên Hệ" OnClick="btnSend_Click" />
                    </td>
                </tr>
            </table>
            </center>
        </td>
    </tr>
</asp:Content>
