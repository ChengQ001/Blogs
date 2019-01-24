layui.use(['layer', 'form', 'element','jquery'], function () {

    var layer = layui.layer, $ = layui.jquery, form = layui.form(), element = layui.element();

    form.on('submit(login)', function (data) {
        var aa =  data.field;
        Login(aa);
        return false;
    });

})

function Login(data) {
    $.ajax({
        type: 'post',
        url: '/admin/home/ApiBlogsLogin',//发送请求  
        data: data,
        dataType: "Json",
        success: function (result) {
            console.log(result);
            if (result.code == '0') {
                layer.msg(result.message);
                window.location.href = "/admin/home/index";
            }
            else {
                layer.msg(result.message);
            }
        }
    });

}