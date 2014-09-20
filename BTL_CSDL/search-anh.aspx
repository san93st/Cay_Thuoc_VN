<%@ Page Title="" Language="C#" MasterPageFile="~/client.Master" AutoEventWireup="true" CodeBehind="search-anh.aspx.cs" Inherits="BTL_CSDL.search_anh" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <tr>
        <td>
            <asp:Label runat="server" ID="lbDisplay" ForeColor="Red"></asp:Label>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <div align="center">
                <asp:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="jpg,jpeg,png,gif"
                    MaximumNumberOfFiles="1" OnUploadComplete="AjaxFileUpload1_UploadComplete"
                    Width="500px" />
            </div>
            <center><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Kiểm tra" /></center>

        </td>
    </tr>
    <tr>
        <td>Ảnh Nguồn:
            <asp:Image ID="Image1" Width="200" Height="200" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <h2>Kết Quả</h2>
            <asp:GridView Width="1000px" ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:ImageField  DataImageUrlField="URL" DataImageUrlFormatString="admin/{0}">
                        <ControlStyle Height="140px" Width="140px" />
                    </asp:ImageField>
                    <asp:HyperLinkField DataNavigateUrlFields="Ma_Cay" DataNavigateUrlFormatString="chitiet.aspx?id={0}" DataTextField="Ten_Anh" Text="Tên Ảnh" />
                    <asp:BoundField DataField="Percent" HeaderText="Phần Trăm" />
                </Columns>
            </asp:GridView>

        </td>
    </tr>
</asp:Content>
