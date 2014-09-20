<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="quanly-hocaythuoc.aspx.cs" Inherits="BTL_CSDL.admin.quanly_hocaythuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="btn-toolbar">
        <button class="btn btn-primary"><i class="icon-plus"></i><a href="HoCayThuoc_ChiTiet.aspx">Thêm họ cây thuốc mới</a></button>
        <div class="btn-group">
        </div>
    </div>
    <asp:Label runat="server" ID="lbDisplay" ForeColor="Red"></asp:Label>
    <asp:ListView ID="ListView_HoCayThuoc" OnPagePropertiesChanging="ListView_HoCayThuoc_PagePropertiesChanging" runat="server">
        <LayoutTemplate>
            <div class="well">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Mã họ</th>
                            <th>Tên Hiển Thị</th>
                            <th>Tên Khoa Học</th>
                            <th>Người Quản Lý</th>
                            <th style="width: 26px;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                        <tr>
                            <td colspan="5">
                                <asp:DataPager runat="server" PagedControlID="ListView_HoCayThuoc" ID="datapager1" PageSize="10">
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
                            <%# Eval("MA_HO") %>
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
                            <%# Eval("MA_QL") %>
                    </asp:Label>
                </td>
                <td>
                    <a href="HoCayThuoc_ChiTiet.aspx?id=<%# Eval("MA_HO") %>"><i class="icon-pencil"></i></a>
                    <asp:LinkButton runat="server" CommandArgument='<%# Eval("MA_HO") %>'  OnClick="btnDelete_Click" ID="btnDelete" OnClientClick='return confirm("Có chắc bạn muốn xóa? Nếu xóa sẽ ảnh hưởng tới các dữ liệu liên quan! Xin cẩn thận!")'><i class="icon-remove"></i></asp:LinkButton>
                    
                </td>
            </tr>
        </ItemTemplate>

    </asp:ListView>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">Quan lý họ cây thuốc</h1>
    </div>
</asp:Content>
