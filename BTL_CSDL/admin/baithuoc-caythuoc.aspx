<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="baithuoc-caythuoc.aspx.cs" Inherits="BTL_CSDL.admin.baithuoc_caythuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">
            <asp:Label runat="server" Text="Thêm Bài Thuốc Cho Cây Thuốc" ID="lbTitle"></asp:Label></h1>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Danh Sách Các Bài Thuốc</h2>
    <asp:Label ID="lbDisplay" runat="server" Text=""></asp:Label>
    <asp:ListView ID="lv_baithuoc" runat="server" OnPagePropertiesChanging="lv_baithuoc_PagePropertiesChanging">
        <LayoutTemplate>
            <div class="well">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Mã Bài Thuốc</th>
                            <th>Nội Dung</th>
                            <th style="width: 26px;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                        <tr>
                            <td colspan="3">
                                <asp:DataPager runat="server" PagedControlID="lv_baithuoc" ID="datapager1" PageSize="10">
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
                            <%# Eval("MA_BAI_THUOC") %>
                    </asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblTen_Hien_Thi">
                            <%# Eval("NOI_DUNG") %>
                    </asp:Label>
                </td>
                
                <td>
                    <asp:LinkButton OnClick="btnEdit_Click" CommandArgument='<%# Eval("MA_BAI_THUOC") %>' runat="server" ID="btnEdit" Text="edit"></asp:LinkButton>
                    <asp:LinkButton runat="server" CommandArgument='<%# Eval("MA_BAI_THUOC") %>' OnClick="btnDelete_Click" ID="btnDelete" OnClientClick='return confirm("Có chắc bạn muốn xóa? Nếu xóa sẽ ảnh hưởng tới các dữ liệu liên quan! Xin cẩn thận!")'><i class="icon-remove"></i></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>

    </asp:ListView>
    <br />
    <br />
    <h2>Thêm mới bài thuốc</h2>
    <div class="well">
        <div id="myTabContent" class="tab-content">
            <div class="tab-pane active in" id="home">
                <label>Mã Bài Thuốc:</label>
                <asp:TextBox ID="txtMaBT" Enabled="false" CssClass="input-xlarge" runat="server"></asp:TextBox>
                
                <label>Nội Dung</label>
                <asp:TextBox ID="txtND" TextMode="MultiLine"  CssClass="input-xlarge" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtND" ValidationGroup="save" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nội Dung Chưa Có Dữ Liệu"></asp:RequiredFieldValidator>
                <br />
                <asp:Button  runat="server" OnClick="Unnamed_Click" Text="Save" ValidationGroup="save"/>
            

            </div>
        </div>

    </div>
</asp:Content>
