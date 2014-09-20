<%@ Page Title="" Language="C#" MasterPageFile="~/client.Master" AutoEventWireup="true" CodeBehind="caythuoc.aspx.cs" Inherits="BTL_CSDL.caythuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <tr>
        <td>

            <asp:GridView Width="1000px" ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="MA_CAY" DataSourceID="SqlDataSource1" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" PageSize="5">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ImageField ControlStyle-Width="140" ControlStyle-Height="140" DataImageUrlFormatString="admin/{0}" DataImageUrlField="URL" HeaderText="Ảnh Cây Thuốc" DataAlternateTextField="TEN_HIEN_THI">
<ControlStyle Height="140px" Width="140px"></ControlStyle>
                    </asp:ImageField>
                    <asp:HyperLinkField DataNavigateUrlFields="MA_CAY" DataNavigateUrlFormatString="chitiet.aspx?id={0}" DataTextField="TEN_HIEN_THI" HeaderText="Tên Cây Thuốc" SortExpression="TEN_HIEN_THI" />
                    <asp:BoundField DataField="TEN_KH" HeaderText="Tên Khoa Học" SortExpression="TEN_KH" />
                    <asp:BoundField DataField="TEN_HIEN_THI1" HeaderText="Họ Cây Thuốc" SortExpression="TEN_HIEN_THI1" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CAYTHUOCVNConnectionString %>" SelectCommand="GET_CAYTHUOC_CLIENT" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

        </td>
    </tr>

</asp:Content>
