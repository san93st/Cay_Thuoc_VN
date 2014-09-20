<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="quanly-user.aspx.cs" Inherits="BTL_CSDL.admin.quanly_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="btn-toolbar">
        <button class="btn btn-primary"><i class="icon-plus"></i><a href="quanly-chitietuser.aspx">Thêm quản lý mới</a></button>
        <div class="btn-group">
        </div>
    </div>
    <asp:Label ID="lbDisplay" runat="server" Text=""></asp:Label>
    <asp:ListView ID="ListView_QuanLy" runat="server" OnPagePropertiesChanging="ListView_QuanLy_PagePropertiesChanging">
        <LayoutTemplate>
            <div class="well">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Mã QL</th>
                            <th>Tên Quản Lý</th>
                            <th>Địa Chỉ</th>
                            <th>Email</th>
                            <th>Số Điện Thoại</th>
                            <th>Ngày Sinh</th>
                            <th>Is Admin</th>
                            <th style="width: 26px;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                        <tr>
                            <td colspan="8">
                                <asp:DataPager runat="server" PagedControlID="ListView_QuanLy" ID="datapager1" PageSize="10">
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
                            <%# Eval("MA_QL") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblTen_Hien_Thi">
                            <%# Eval("TEN_QL") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblTen_KH">
                            <%# Eval("DIA_CHI") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblMa_QL">
                            <%# Eval("EMAIL") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="Label1">
                            <%# Eval("SO_DIEN_THOAI") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="Label2">
                            <%# Eval("NGAY_SINH") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="Label3">
                       
                            <%# Eval("IS_ADMIN") %>
                    </asp:Label>
                </td>
                <td>
                    <a href="quanly-chitietuser.aspx?id=<%# Eval("MA_QL") %>"><i class="icon-pencil"></i></a>
                    <asp:LinkButton runat="server" CommandArgument='<%# Eval("MA_QL") %>' OnClick="btnDelete_Click" ID="btnDelete" OnClientClick='return confirm("Có chắc bạn muốn xóa? Nếu xóa sẽ ảnh hưởng tới các dữ liệu liên quan! Xin cẩn thận!")'><i class="icon-remove"></i></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>

    </asp:ListView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">Quản lý người dùng khác</h1>
    </div>
</asp:Content>
