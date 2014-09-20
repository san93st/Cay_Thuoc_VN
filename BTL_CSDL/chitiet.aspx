<%@ Page Title="" Language="C#" MasterPageFile="~/client.Master" AutoEventWireup="true" CodeBehind="chitiet.aspx.cs" Inherits="BTL_CSDL.chitiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/jquery-1.10.1.min.js"></script>
    <script type="text/javascript" src="js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="js/jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="js/jquery.fancybox.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /*
			 *  Simple image gallery. Uses default settings
			 */

            $('.fancybox').fancybox();

            /*
			 *  Different effects
			 */

            // Change title type, overlay closing speed
            $(".fancybox-effects-a").fancybox({
                helpers: {
                    title: {
                        type: 'outside'
                    },
                    overlay: {
                        speedOut: 0
                    }
                }
            });

            // Disable opening and closing animations, change title type
            $(".fancybox-effects-b").fancybox({
                openEffect: 'none',
                closeEffect: 'none',

                helpers: {
                    title: {
                        type: 'over'
                    }
                }
            });

            // Set custom style, close if clicked, change title type and overlay color
            $(".fancybox-effects-c").fancybox({
                wrapCSS: 'fancybox-custom',
                closeClick: true,

                openEffect: 'none',

                helpers: {
                    title: {
                        type: 'inside'
                    },
                    overlay: {
                        css: {
                            'background': 'rgba(238,238,238,0.85)'
                        }
                    }
                }
            });

            // Remove padding, set opening and closing animations, close if clicked and disable overlay
            $(".fancybox-effects-d").fancybox({
                padding: 0,

                openEffect: 'elastic',
                openSpeed: 150,

                closeEffect: 'elastic',
                closeSpeed: 150,

                closeClick: true,

                helpers: {
                    overlay: null
                }
            });

            /*
			 *  Button helper. Disable animations, hide close button, change title type and content
			 */

            $('.fancybox-buttons').fancybox({
                openEffect: 'none',
                closeEffect: 'none',

                prevEffect: 'none',
                nextEffect: 'none',

                closeBtn: false,

                helpers: {
                    title: {
                        type: 'inside'
                    },
                    buttons: {}
                },

                afterLoad: function () {
                    this.title = 'Image ' + (this.index + 1) + ' of ' + this.group.length + (this.title ? ' - ' + this.title : '');
                }
            });


            /*
			 *  Thumbnail helper. Disable animations, hide close button, arrows and slide to next gallery item if clicked
			 */

            $('.fancybox-thumbs').fancybox({
                prevEffect: 'none',
                nextEffect: 'none',

                closeBtn: false,
                arrows: false,
                nextClick: true,

                helpers: {
                    thumbs: {
                        width: 50,
                        height: 50
                    }
                }
            });

            /*
			 *  Media helper. Group items, disable animations, hide arrows, enable media and button helpers.
			*/
            $('.fancybox-media')
				.attr('rel', 'media-gallery')
				.fancybox({
				    openEffect: 'none',
				    closeEffect: 'none',
				    prevEffect: 'none',
				    nextEffect: 'none',

				    arrows: false,
				    helpers: {
				        media: {},
				        buttons: {}
				    }
				});

            /*
			 *  Open manually
			 */

            $("#fancybox-manual-a").click(function () {
                $.fancybox.open('1_b.jpg');
            });

            $("#fancybox-manual-b").click(function () {
                $.fancybox.open({
                    href: 'iframe.html',
                    type: 'iframe',
                    padding: 5
                });
            });

            $("#fancybox-manual-c").click(function () {
                $.fancybox.open([
					{
					    href: '1_b.jpg',
					    title: 'My title'
					}, {
					    href: '2_b.jpg',
					    title: '2nd title'
					}, {
					    href: '3_b.jpg'
					}
                ], {
                    helpers: {
                        thumbs: {
                            width: 75,
                            height: 50
                        }
                    }
                });
            });


        });
	</script>
    <link rel="stylesheet" type="text/css" href="css/jquery.fancybox.css?v=2.1.5" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <tr>
        <td>
            <center>
                <b><asp:Label runat="server" ID="lbTenHienThi"></asp:Label></b><br /><br />
                <asp:Image runat="server" ID="imgAnhHienThi"/>
            </center>
            <br />
            <br />
            <p><b>Tên Khoa Học:</b><asp:Label runat="server" ID="lbTenKH"></asp:Label></p>
            <p><b>Họ:</b><asp:Label runat="server" ID="lbHoCayThuoc"></asp:Label></p>
            <p><b>Tên khác:</b><asp:Label runat="server" ID="lbTenKhac"></asp:Label></p>
            <div>
                <asp:Label runat="server" ID="lbND"></asp:Label>
            </div>
            <br />
            <b>Các Bài Thuốc:</b>
            <asp:ListView runat="server" ID="lv_baithuoc">
                <ItemTemplate>
                    <p><%# Eval("NOI_DUNG") %></p>
                </ItemTemplate>
            </asp:ListView>
            <b>Ảnh Cây Thuốc:</b>
            <p>
                <asp:ListView runat="server" ID="lv_anh">
                    <ItemTemplate>
                        <a class="fancybox" href="admin/<%# Eval("URL") %>" data-fancybox-group="gallery" title="<%# Eval("TEN_ANH") %>">
                    <img width="140" height="140" src="admin/<%# Eval("URL") %>" alt="" /></a>
                    </ItemTemplate>
                </asp:ListView>
	        </p>
        </td>
    </tr>

</asp:Content>
