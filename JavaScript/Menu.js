var menuStatu = 1; //case 1:open; case 2:close;
$(document).ready(function () {
    MenuInit(); //初始化函数
});


function input() {
    //搜索框
    $(".IndexPageInput")[0].value = "";
    $(".IndexPageInput")[0].style.color = "#333";
}


function MenuInit() {

    $(".NewsList table tr").hover(
        function () {
            $(this).find(".NewsListTitle").attr("style", "background:url(../images/IDI_LINK_BG_1.gif) left no-repeat #ddd");
            $(this).find(".NewsListDate").attr("style", "background:#ddd");
        },
        function () {
            $(this).find(".NewsListTitle").attr("style", "background:url(../images/IDI_LINK_BG_1.gif) left no-repeat");
            $(this).find(".NewsListDate").attr("style", "background:#fff");
        });

        $("#footer .yy").hover(function () {
            $("#footer .yy .hide").show();
        }, function () {
            $("#footer .yy .hide").hide();
        });
}

function ReflashCode() {
    $("#code").attr("src", "securityCode.aspx?t=" + Math.floor(Math.random() * 10));
}



