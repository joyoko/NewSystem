(function($){
    $.getUrlParam = function(name){
        var reg = new RegExp("(^|&)"+ name +"=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r!=null) return unescape(r[2]); return null;
    }
})(jQuery);

var giaUrl = "http://www2.gia.edu/reportcheck/index.cfm?fuseaction=home.showReportVerification&reportno=";
var PageSize = 15;
var PageIndex = 1;

$(document).ready(function () {

    Search($.getUrlParam('orderId'));

});

function Search(orderId) {
    //$("#loading").show();
    $.get("../App_JSON/AdminOrder.aspx", {
        "orderId": orderId,
        "PageSize": PageSize,                     //订单默认给30个钻石/页
        "PageIndex": PageIndex,                     //页码，默认给1
        "t": new Date().getMilliseconds()
    }, function (data) {
        //alert(data);
        setOrders(data);
    });
}


function setOrders(data) {
    var json = eval('(' + data + ')');
    var diamond = json.Data.diamond;

    

    if (json.ErrorNumber != 0) {
        alert(json.Message);
        window.location.href = "admin_login.aspx";
    }

    var orderId = json.Data.orderId;
    var count = json.Data.count;                        //总记录数量，用于计算页数
    var pageCount = Math.floor(count / PageSize) + 1;   //总页数
    var innerHtml = "";

    if (1 != PageIndex) {
        innerHtml += "<span onclick='PageIndex=1;Search(" + orderId + ");'>第一页</span>";
        innerHtml += "<span onclick='PageIndex--;Search(" + orderId + ");'>上一页</span>";
    }


    var start;
    var end;

    if (PageIndex > pageCount) {
        PageIndex = pageCount;
    }

    if (pageCount < 10) {
        //10页之内的，顺序显示即可
        start = 1;
        end = pageCount;
    } else {
        //10页以上，增加判断条件
        if (pageCount - PageIndex < 5) {
            //最后5页之内
            start = pageCount - 9;
            end = pageCount;
        } else if (PageIndex < 5) {
            start = 1;
            end = 10;
        } else {
            start = PageIndex - 4;
            end = PageIndex + 5;
        }
    }

    for (var i = start; i <= end; i++) {
        if (PageIndex == i) {
            innerHtml += "<span class='selected'";
        } else {
            innerHtml += "<span";
        }
        innerHtml += " onclick='PageIndex=";
        innerHtml += i;
        innerHtml += ";Search(" + orderId + ");'";
        innerHtml += ">";
        innerHtml += i;
        innerHtml += "</span>";
    }
    if (PageIndex < pageCount) {
        innerHtml += "<span onclick='PageIndex++;Search(" + orderId + " );'>下一页</span>";
        innerHtml += "<span onclick='PageIndex=" + pageCount + ";Search(" + orderId + ");'>最后一页（" + pageCount + "）</span>";
    }

    $(".Pager").html(innerHtml);




    $("#order_total_price").html("¥" + json.Data.totalPrice);
    $("#order_total_price").show();

    $("#order_total_count").html("" + json.Data.count);
    $("#order_total_count").show();

    $("#order_adddate").html("" + json.Data.adddate);
    $("#order_adddate").show();

    delete_all();
    for (var i = 0; i < diamond.length; i++) {
        add(diamond[i]);
    }
    //$("#loading").hide();
}

function delete_all() {
    $.each($("#diamond tr"), function (i, ele) {
        if (!$(ele).hasClass("diamond_title")) {
            $(ele).remove();
        }
    });
}

function add(diamond, status) {
    var otr = document.getElementById("diamond").insertRow(-1);
    var checkTd = document.createElement("td"); //多选框
    var otd0 = document.createElement("td"); //编号
    var otd1 = document.createElement("td"); //重量
    var otd2 = document.createElement("td"); //颜色
    var otd3 = document.createElement("td"); //净度
    var otd4 = document.createElement("td"); //切工
    var otd5 = document.createElement("td"); //抛光
    var otd6 = document.createElement("td"); //对称性
    var otd7 = document.createElement("td"); //荧光
    var otd8 = document.createElement("td"); //证书
    var otd9 = document.createElement("td"); //证书号
    var otd10 = document.createElement("td"); //价格
    var otd11 = document.createElement("td"); //放入购物车

    var otd_c1 = document.createElement("td");  //备注1
    var otd_c2 = document.createElement("td");  //备注2

    checkTd.innerHTML = '<input type="checkbox" class="check"  name="checkItem"><input type="hidden" id="h_' + ($("#diamond")[0].rows.length - 1) + '" value="' + diamond.DiamondId + '" />';

    if (diamond.Certificate == "GIA" && diamond.CertificateNumber != "") {
        //如果有GIA证书
        var link = "<a href='" + giaUrl + diamond.CertificateNumber + "&weight=" + diamond.Weight + "' target='_blank'>GIA</a>";
        otd8.innerHTML = '<span name="tab_8" id="tab_8_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + link + "</span>";
    } else {
        otd8.innerHTML = '<span name="tab_8" id="tab_8_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.Certificate + "</span>";
    }

    otd0.innerHTML = '<span name="tab_0" class="diamond_test" id="tab_0_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.Number + "</span>";
    otd1.innerHTML = '<span name="tab_1" id="tab_1_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.Weight + "</span>";
    otd2.innerHTML = '<span name="tab_2" id="tab_2_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.Color + "</span>";
    otd3.innerHTML = '<span name="tab_3" id="tab_3_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.Clarity + "</span>";
    otd4.innerHTML = '<span name="tab_4" id="tab_4_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.Cut + "</span>";
    otd5.innerHTML = '<span name="tab_5" id="tab_5_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.Polish + "</span>";
    otd6.innerHTML = '<span name="tab_6" id="tab_6_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.Symmetry + "</span>";
    otd7.innerHTML = '<span name="tab_7" id="tab_7_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.Fluorescence + "</span>";
    
    otd_c1.innerHTML = diamond.Remarks_1;
    otd_c2.innerHTML = diamond.Remarks_2;

    otd9.innerHTML = '<span name="tab_9" id="tab_9_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.CertificateNumber + "</span>";
    otd10.innerHTML = '<span class="price" name="tab_10" id="tab_10_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">¥' + diamond.Price + "</span>";
    otd11.innerHTML = '<span name="tab_11" id="tab_11_' + ($("#diamond")[0].rows.length - 1) + '" style="width:90%;">' + diamond.CaratPrice + '</span>';

    otr.appendChild(checkTd);
    otr.appendChild(otd0);
    otr.appendChild(otd1);
    otr.appendChild(otd2);
    otr.appendChild(otd3);
    otr.appendChild(otd4);
    otr.appendChild(otd5);
    otr.appendChild(otd6);
    otr.appendChild(otd7);

    otr.appendChild(otd_c1);
    otr.appendChild(otd_c2);

    otr.appendChild(otd8);
    otr.appendChild(otd9);
    otr.appendChild(otd10);
    otr.appendChild(otd11);

}


