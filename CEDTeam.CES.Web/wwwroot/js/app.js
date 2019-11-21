function LoadPartialViewWithAjax(divName, url, method, data, callback) {
    $(divName).html('<div class="col-xs-12 text-center text padding-top-15 padding-bottom-15"><small><i class="icon-ui-loading" aria-hidden="true"></i>&nbsp;&nbsp;Loading content...</small></div>');
    $.ajax({
        type: method,
        url: url,
        data: JSON.stringify(data),
        contentType: "application/json",
        datatype: "json",
        success: function (data) {
            $(divName).html(data);
            if (callback) {
                callback();
            }
        },
        cache: false,
        error: function (jqXHR) {
            var status = jqXHR.status;
            if (status !== 0) {
                // ShowAlert(false, '<strong>Error!</strong> Dynamic content load failed!');
            }
        }
    });
}