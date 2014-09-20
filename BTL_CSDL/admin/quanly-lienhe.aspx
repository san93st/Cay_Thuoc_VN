<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="quanly-lienhe.aspx.cs" Inherits="BTL_CSDL.admin.quanly_lienhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Danh sách những liên hệ chưa xử lý</h2>
    <asp:ListView ID="ListView_ChuaLienHe" runat="server" OnPagePropertiesChanging="ListView_ChuaLienHe_PagePropertiesChanging">
        <LayoutTemplate>
            <div class="well">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Email</th>
                            <th>Tên Hiển Thị</th>
                            <th>Tiêu Đề</th>
                            <th>Số Điện Thoại</th>
                            <th>Ngày Gửi</th>
                            <th style="width: 26px;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                        <tr>
                            <td colspan="6">
                                <asp:DataPager runat="server" ID="datapager1" PageSize="10">
                                    <Fields>
                                        <asp:NumericPagerField ButtonType="Link" />
                                        <asp:NextPreviousPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="true"
                                            FirstPageText="Trang đầu" LastPageText="Trang cuối" NextPageText="Tiếp theo"
                                            PreviousPageText="Quay lại" ShowFirstPageButton="true" ShowLastPageButton="true"
                                            ShowNextPageButton="true" ShowPreviousPageButton="true" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>


        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lbEmail">
                            <%# Eval("EMAIL") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbTenHienThi">
                            <%# Eval("TEN_HIENTHI") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbTieuDe">
                            <%# Eval("TIEU_DE") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbSoDienThoai">
                            <%# Eval("SO_DIEN_THOAI") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbNgayGui">
                            <%# Eval("NGAY_GUI") %>
                    </asp:Label>
                </td>
                <td>
                    <a href="quanly-chitietlienhe.aspx?email=<%# Eval("EMAIL") %>">Edit</a>
                </td>
            </tr>
        </ItemTemplate>

    </asp:ListView>
    <br />
    <br />

    <h2>Danh sách những liên hệ đã được xử lý</h2>
    <asp:Label runat="server" ID="lbDisplayDaLienHe" ForeColor="Red"></asp:Label>
    <asp:ListView ID="listview_dalienhe" runat="server" OnPagePropertiesChanging="listview_dalienhe_PagePropertiesChanging">
        <LayoutTemplate>
            <div class="well">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Email</th>
                            <th>Tên Hiển Thị</th>
                            <th>Tiêu Đề</th>
                            <th>Số Điện Thoại</th>
                            <th>Ngày Gửi</th>
                            <th>Ngày Liên Hệ</th>
                            <th>Mã Quản Lý Liên Hệ</th>
                            <th style="width: 26px;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                        <tr>
                            <td colspan="8">
                                <asp:DataPager runat="server" ID="datapager2" PageSize="1">
                                    <Fields>
                                        <asp:NumericPagerField ButtonType="Link" />
                                        <asp:NextPreviousPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="true"
                                            FirstPageText="Trang đầu" LastPageText="Trang cuối" NextPageText="Tiếp theo"
                                            PreviousPageText="Quay lại" ShowFirstPageButton="true" ShowLastPageButton="true"
                                            ShowNextPageButton="true" ShowPreviousPageButton="true" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lbEmail">
                            <%# Eval("EMAIL") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbTenHienThi">
                            <%# Eval("TEN_HIENTHI") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbTieuDe">
                            <%# Eval("TIEU_DE") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbSoDienThoai">
                            <%# Eval("SO_DIEN_THOAI") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbNgayGui">
                            <%# Eval("NGAY_GUI") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="Label1">
                            <%# Eval("THOI_GIAN_LH") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="Label2">
                            <%# Eval("MA_QL") %>
                    </asp:Label>
                </td>
                <td>
                    <a href="quanly-chitietlienhe.aspx?email=<%# Eval("EMAIL") %>"><i class="icon-pencil"></i></a>
                    <asp:LinkButton runat="server" CommandArgument='<%# Eval("EMAIL") %>' OnClick="btnDelete_Click" ID="btnDelete" OnClientClick='return confirm("Có chắc bạn muốn xóa? Nếu xóa sẽ ảnh hưởng tới các dữ liệu liên quan! Xin cẩn thận!")'><i class="icon-remove"></i></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>

    </asp:ListView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">Quản lý liên hệ</h1>
    </div>
</asp:Content>
