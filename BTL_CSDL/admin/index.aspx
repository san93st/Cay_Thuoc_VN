<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BTL_CSDL.admin.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row-fluid">
        <div class="block">
            <a href="#page-stats" class="block-heading" data-toggle="collapse">Thống kê</a>
            <div id="page-stats" class="block-body collapse in">

                <div class="stat-widget-container">
                    <div class="stat-widget">
                        <div class="stat-button">
                            <p class="title">2,500</p>
                            <p class="detail">Lượt truy cập hiện tại</p>
                        </div>
                    </div>

                    <div class="stat-widget">
                        <div class="stat-button">
                            <p class="title">100</p>
                            <p class="detail">Số liên hệ mới</p>
                        </div>
                    </div>

                    <div class="stat-widget">
                        <div class="stat-button">
                            <p class="title">10</p>
                            <p class="detail">Số lượng cây thuốc</p>
                        </div>
                    </div>

                    <div class="stat-widget">
                        <div class="stat-button">
                            <p class="title">400</p>
                            <p class="detail">Số lượng họ thuốc</p>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class="row-fluid">
        <div class="block span6">
            <a href="#tablewidget" class="block-heading" data-toggle="collapse">Users<span class="label label-warning">+10</span></a>
            <div id="tablewidget" class="block-body collapse in">
                <table class="table">
                    <thead>
                        <tr>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Username</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Mark</td>
                            <td>Tompson</td>
                            <td>the_mark7</td>
                        </tr>
                        <tr>
                            <td>Ashley</td>
                            <td>Jacobs</td>
                            <td>ash11927</td>
                        </tr>
                        <tr>
                            <td>Audrey</td>
                            <td>Ann</td>
                            <td>audann84</td>
                        </tr>
                        <tr>
                            <td>John</td>
                            <td>Robinson</td>
                            <td>jr5527</td>
                        </tr>
                        <tr>
                            <td>Aaron</td>
                            <td>Butler</td>
                            <td>aaron_butler</td>
                        </tr>
                        <tr>
                            <td>Chris</td>
                            <td>Albert</td>
                            <td>cab79</td>
                        </tr>
                    </tbody>
                </table>
                <p><a href="users.html">More...</a></p>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="header">
        <h1 class="page-title">Bảng điều khiển chung</h1>
    </div>
</asp:Content>
