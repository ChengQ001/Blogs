var editor;
KindEditor.ready(function (K) {
    editor = K.create('textarea[id="content"]', {//textarea
        allowFileManager: true,                  //是否允许文件上传
        allowUpload: true,
        //fileManagerJson: '/KindEditor/ProcessRequest', //浏览文件方法
        uploadJson: '/admin/home/FileUploadKindEditor'          //上传文件方法
    });
});
layui.use(['form', 'layer', 'jquery', 'layedit', 'laydate'], function () {
    var form = layui.form(),
        layer = parent.layer === undefined ? layui.layer : parent.layer,
        laydate = layui.laydate,
        $ = layui.jquery;
   



    $.ajax({
        type: 'get',
        url: '/admin/home/GetModelArticle',//发送请求  
        data: { "blog_article_id": $('#blog_article_id').val() },
        dataType: "Json",
        success: function (result) {
            if (result.code == '0') {
                var blog_article_content = result.data.blog_article_content;
                var blog_article_label = result.data.blog_article_label;
                var blog_article_type_name = result.data.blog_article_type_name;
                var blog_article_img = result.data.blog_article_img;
                var blog_article_title = result.data.blog_article_title;
                var blog_article_type = result.data.blog_article_type;
                var blog_article_details = result.data.blog_article_details;
                $(".newsName").attr("value", blog_article_title);
                $(".newsImage").attr("value", blog_article_img);
                //$('#news_content').val(blog_article_content);
                editor.html(blog_article_content);
                $('#txtContent').val(blog_article_details);
                var lables = blog_article_label.split(",");
                for (var i = 0; i < lables.length; i++) {
                    $('input[type="checkbox"]').each(function () {
                        if ($(this).val() == lables[i]) {
                            $(this).click();
                        }
                    })
                }
                $('#newsType').siblings('.layui-form-select').find('dd').each(function () {
                    if ($(this).text() == blog_article_type_name) {
                        $(this).click();
                        return false;
                    }
                })
                $('#newsType').siblings('.layui-form-select').find('dd').val(blog_article_type_name);
                form.render(null, 'content'); //更新全部
            }
            else {
                layer.msg(result.message);
            }
        }
    });
    form.on("submit(addNews)", function (data) {
        var newsName = $(".newsName").val();
        var newsImage = $(".newsImage").val();
        var lableStr = '';
        var tuijian = data.field.tuijian;
        var haowen = data.field.haowen;
        var ganwu = data.field.ganwu;
        if (tuijian == '推荐' || tuijian == "on") {
            lableStr += '推荐,'
        }
        if (haowen == '好文' || haowen == "on") {
            lableStr += '好文,'
        }
        if (ganwu == '感悟' || ganwu == "on") {
            lableStr += '感悟,'
        }
        var newsType = $(".newsType").eq($(".newsType").val()).text();
        var newsTypeName = $(".newsType").find("option:selected").text();
        var newsTypeId = $(".newsType").val();
        var neirong = $(".neirong").val();
        var content = editor.html();
        $.ajax({
            type: 'post',
            url: '/admin/home/ArticleUpdate',//发送请求  
            data: { "blog_article_id": $('#blog_article_id').val(),"blog_article_img": newsImage, "blog_article_label": lableStr, "blog_article_title": newsName, "blog_article_content": content, "blog_article_type": newsTypeId, "blog_article_type_name": newsTypeName, "order_num": 0, "blog_article_details": neirong },
            dataType: "Json",
            success: function (result) {
                if (result.code == '0') {
                    layer.msg(result.message);
                    parent.location.reload();
                }
                else {
                    layer.msg(result.message);
                }
            }
        });
        return false;
    })




})
