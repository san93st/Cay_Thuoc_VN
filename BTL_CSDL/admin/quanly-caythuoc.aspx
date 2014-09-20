<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="quanly-caythuoc.aspx.cs" Inherits="BTL_CSDL.admin.quanly_caythuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="btn-toolbar">
        <button class="btn btn-primary"><i class="icon-plus"></i><a href="quanly-chitietcaythuoc.aspx">Thêm cây thuốc mới</a></button>
        <div class="btn-group">
        </div>
    </div>
    <asp:Label runat="server" ID="lbDisplay" ForeColor="Red"></asp:Label>
    <asp:ListView ID="lv_caythuoc" runat="server" OnPagePropertiesChanging="lv_caythuoc_PagePropertiesChanging">
        <LayoutTemplate>
            <div class="well">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Mã Cây Thuốc</th>
                            <th>Tên Hiển Thị</th>
                            <th>Tên Khoa Học</th>
                            <th>Họ Cây Thuốc</th>
                            <th>Người Quản Lý</th>
                            <th>Tác Vụ Liên Quan</th>
                            <th style="width: 26px;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                        <tr>
                            <td colspan="7">
                                <asp:DataPager runat="server" PagedControlID="lv_caythuoc" ID="datapager1" PageSize="10">
                                    <Fields>
                                        <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ShowLastPageButton="true" ShowPreviousPageButton="false" />
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
                    <asp:Label runat="server" ID="lblMa_Ho">
                            <%# Eval("MA_CAY") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblTen_Hien_Thi">
                            <%# Eval("TEN_HIEN_THI") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblTen_KH">
                            <%# Eval("TEN_KH") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblMa_QL">
                            <%# Eval("HO_CAY_THUOC") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="Label1">
                            <%# Eval("MA_QL") %>
                    </asp:Label>
                </td>
                <td>
                    <a href="anh-caythuoc.aspx?id=<%# Eval("MA_CAY") %>">Ảnh</a>|
                    <a href="tenkhac-caythuoc.aspx?id=<%# Eval("MA_CAY") %>">Tên Khác</a>|
                    <a href="baithuoc-caythuoc.aspx?id=<%# Eval("MA_CAY") %>">Bài Thuốc</a>
                </td>
                <td>
                    <a href="quanly-chitietcaythuoc.aspx?id=<%# Eval("MA_CAY") %>"><i class="icon-pencil"></i></a>
                    <asp:LinkButton OnClick="btnDelete_Click" runat="server" CommandArgument='<%# Eval("MA_CAY") %>' ID="btnDelete" OnClientClick='return confirm("Có chắc bạn muốn xóa? Nếu xóa sẽ ảnh hưởng tới các dữ liệu liên quan! Xin cẩn thận!")'><i class="icon-remove"></i></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>

    </asp:ListView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">Quản lý cây thuốc</h1>
    </div>
</asp:Content>
