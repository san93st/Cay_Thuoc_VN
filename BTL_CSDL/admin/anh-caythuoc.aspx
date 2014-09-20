<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="anh-caythuoc.aspx.cs" Inherits="BTL_CSDL.admin.anh_caythuoc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="stylesheets/nomalize.css" />
    <link rel="stylesheet" href="stylesheets/style.css" />

    <link rel="stylesheet" href="stylesheets/asPopup.css" />

    <link rel="stylesheet" href="stylesheets/example.css" />

    <script src="js/jquery-1.9.1.min.js"></script>
    <script src="js/jquery.toc.js"></script>
    <script src="js/prism.js"></script>

    <script src="js/jquery-popup.js" type="text/javascript"></script>
    <script src="js/jquery-popup-move.js" type="text/javascript"></script>
    <script src="js/jquery-popup-keyboard.js" type="text/javascript"></script>
    <script src="js/jquery-popup-thumbnail.js" type="text/javascript"></script>
    <script type="text/javascript">
        (function () {
            $('#toc').toc();
        })();
        $(document).ready(function () {
            $('.popup-gallery').popup();
            // $('.popup-autoSlide').popup({autoSlide:true});
            $('.popup-mix').popup();

            $('.popup-fadeScale').popup({ modalEffect: 'we-fadeScale' });
            $('.popup-slideIn').popup({ modalEffect: 'we-slideIn' });
            $('.popup-fall').popup({ modalEffect: 'we-fall' });

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-family: Calibri">
        <b>
            <h2>Upload Ảnh Cho Cây Thuốc:
                    <asp:Label runat="server" ID="Label2"></asp:Label></h2>
        </b>
    </div>
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <asp:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="jpg,jpeg,png,gif"
            MaximumNumberOfFiles="1" OnUploadComplete="AjaxFileUpload1_UploadComplete1"
            Width="500px" />
    </div>
    

    <br />
    <h2>Danh Sách Ảnh</h2>
    <asp:Label ID="lbDisplay" runat="server" Text=""></asp:Label>
    <asp:ListView ID="lv_anhcaythuoc" runat="server">
        <LayoutTemplate>
            <div class="well">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Ảnh</th>
                            <th>Tên Ảnh</th>
                            <th style="width: 26px;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                    </tbody>
                </table>
            </div>

        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a class="popup-gallery" href="<%# Eval("URL") %>" data-popup-title="<%# Eval("TEN_ANH") %>" data-popup-group="gallery">
                        <img class="img-polaroid" src="<%# Eval("URL") %>" alt="" />
                    </a>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblTen_Hien_Thi">
                            <%# Eval("TEN_ANH") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:LinkButton runat="server" CommandArgument='<%# Eval("MA_ANH") %>' OnClick="btnDelete_Click" ID="btnDelete" OnClientClick='return confirm("Có chắc bạn muốn xóa? Nếu xóa sẽ ảnh hưởng tới các dữ liệu liên quan! Xin cẩn thận!")'><i class="icon-remove"></i></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>

    </asp:ListView>
</asp:Content>
