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
            url: '/admin/home/ArticleAdd',//发送请求  
            data: { "blog_article_img": newsImage, "blog_article_label": lableStr, "blog_article_title": newsName, "blog_article_content": content, "blog_article_type": newsTypeId, "blog_article_type_name": newsTypeName, "order_num": 0, "blog_article_details": neirong },
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
