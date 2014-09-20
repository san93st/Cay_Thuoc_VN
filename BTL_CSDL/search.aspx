<%@ Page Title="" Language="C#" MasterPageFile="~/client.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="BTL_CSDL.search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <tr>
        <td class="top">
            <br />
            <h2>Kết quả tìm kiếm:</h2>
            <asp:ListView runat="server" ID="lv_Result" OnPagePropertiesChanging="lv_Result_PagePropertiesChanging">
                <ItemTemplate>
                    <div class="top_box">
                        <div style="width: 180px; height: 216px; background: url(&#39;/images/ebooks/3/head_first_jquery.jpg&#39;) no-repeat scroll 20% 20% transparent;">
                            <a href="chitiet.aspx?id=<%# Eval("MA_CAY") %>" title="<%# Eval("TEN_HIEN_THI") %>">
                                <img src="admin/<%# Eval("URL") %>" width="180" height="216" border="0" class="border" alt="<%# Eval("TEN_HIEN_THI") %>" />
                            </a>
                        </div>
                        <br>
                        <a href="chitiet.aspx?id=<%# Eval("MA_CAY") %>"><%# Eval("TEN_HIEN_THI") %></a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:DataPager runat="server" PagedControlID="lv_Result" ID="datapager1" PageSize="20">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="true" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </td>
    </tr>
</asp:Content>
