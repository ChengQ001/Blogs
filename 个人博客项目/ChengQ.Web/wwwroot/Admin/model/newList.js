//分页参数设置 这些全局变量关系到分页的功能
var startAllAppoint = 1;//开始页数
var limitAllAppoint = 10;//每页显示数据条数
var dataLength = 0;//数据总条数
var totalPageAllAppoint = 0; 

layui.use(['laypage', 'layer', 'jquery'], function () {
    var layer = parent.layer === undefined ? layui.layer : parent.layer,
        laypage = layui.laypage,
        $ = layui.jquery;

    $(document).ready(function () {
        //ajax请求后台数据
        getShopCustomerManagePageInfo();
        $(".news_content").delegate('.bianji', 'click', function () {
            var dataId = $(this).attr('data-id');
            console.log(dataId);
            var index = layui.layer.open({
                title: "文章编辑",
                type: 2,
                content: "/admin/home/EditArticle?blog_article_id=" + dataId,
                success: function (layero, index) {
                    setTimeout(function () {
                        layui.layer.tips('点击此处返回文章列表', '.layui-layer-setwin .layui-layer-close', {
                            tips: 3
                        });
                    }, 500)
                }
            })
            layui.layer.full(index);
        });

        $(".news_content").delegate('.del','click', function () {
            var dataId = $(this).attr('data-id');
            //询问框
            layer.confirm('您确认要删除？', {
                btn: ['确认', '取消'] //按钮
            }, function () {
                $.ajax({
                    type: "get",
                    async: false,
                    url: "/admin/home/ArticleDelete",
                    data: { "blog_article_id": dataId },
                    success: function (data, status) {
                        if (data.code == 0) {
                            layer.msg('删除成功', { icon: 1, time: 1000 }, function () {
                                getShopCustomerManagePageInfo();
                            });
                        }
                        else {
                            layer.msg(data.message, { icon: 2 });
                        }
                    }
                });
            });
        })
    });

 


    //点击搜索时 搜索数据
    $(".search_btn").click(function () {
        startAllAppoint = 1;
        getShopCustomerManagePageInfo();
    })

    $(".batchRefresh").click(function () {
        startAllAppoint = 1;
        getShopCustomerManagePageInfo();
    })
    
    //添加文章
	//改变窗口大小时，重置弹窗的高度，防止超出可视区域（如F12调出debug的操作）
    $(window).one("resize", function () {
        $(".newsAdd_btn").click(function () {
            var index = layui.layer.open({
                title: "添加文章",
                type: 2,
                content: "/admin/home/AddArticle",
                success: function (layero, index) {
                    setTimeout(function () {
                        layui.layer.tips('点击此处返回文章列表', '.layui-layer-setwin .layui-layer-close', {
                            tips: 3
                        });
                    }, 500)
                }
            })
            layui.layer.full(index);
        })
    }).resize();
    //ajax请求后台数据
    function getShopCustomerManagePageInfo() {
        $.ajax({
            type: "get",
            async: false,
            url: "/admin/home/GetArticlePageList",
            data: { "pageIndex": startAllAppoint, "pageSize": limitAllAppoint, "filter": $(".search_input").val() },
            success: function (data, status) {
                startAllAppoint = data.data.currentPage;//当前页数(后台返回)
                dataLength = data.data.total;//数据总条数
                totalPageAllAppoint = data.data.pageCount;//总页数(后台返回)
                getShopCustomesInfo(data);
                toPage();
            }
        });
    }

    function getShopCustomesInfo(data) {
        var dataHtml;
        $.each(data.data.items, function (v, o) {
            var lableStr = o.blog_article_label;
            dataHtml += '<tr>' 
                + '<td>' + o.blog_article_id + '</td>'
                + '<td align="left">' + o.blog_article_title + '</td>' 
                + '<td>' + o.user_name + '</td>';
            dataHtml += '<td>' + o.create_time + '</td>';
            dataHtml += '<td>' + o.blog_article_type_name + '</td>'
                + '<td>' + lableStr.substring(0, lableStr.length - 1) +'</td>'
                + '<td>' + o.blog_article_num+'</td>'
                + '<td>'
                + '<button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-normal bianji" data-id="' + o.blog_article_id+'">编辑</button>'
                + '<button class="layui-btn layui-btn-sm layui-btn-radius layui-btn-danger del" data-id=' + o.blog_article_id+'>删除</button>'
                + '</td>'
                + '</tr>';
        });

        if (data.data.items.length > 0) {
            $(".news_content").html(dataHtml);
        } else {
            $(".news_content").html("<br/><span style='width:10%;height:30px;display:block;margin:0 auto;'>暂无数据</span>");
        }
        
    }

    function toPage() {
        laypage({
            cont: 'page',
            pages: totalPageAllAppoint //得到总页数，在layui2.X中使用count替代了，并且不是使用"总页数"，而是"总记录条数"
            , curr: startAllAppoint //当前页数
            , skip: true
            , jump: function (obj, first) {
                startAllAppoint = obj.curr; //当前页数
                if (!first) { //一定要加此判断，否则初始时会无限刷新
                    getShopCustomerManagePageInfo(); //一定要把翻页的ajax请求放到这里，不然会请求两次。
                }
                $('#ALLtotal').html("总条数 " + dataLength + "条");
            }
        });
    }
});


