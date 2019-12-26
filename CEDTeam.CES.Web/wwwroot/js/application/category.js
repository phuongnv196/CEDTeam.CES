var category = function () {
    var initEvent = function () {
        $(".cate-item").on("click", function (e) {
            $.get("/category/get-sub-category-by-id", { categoryId: $(e.target).attr("cate-site-id") })
                .done(function (data) {
                    if (data) {
                        $(e.target).html($(e.target).attr("cate-name"));
                        $(e.target).append("<ol><ol>");
                        var element = $(e.target).find("ol")[1];
                        $(data).each(function (i, e) {
                            $(element).append('<li class="cate-item" cate-id="' + e.categoryId + '" parent-id="' + e.parent + '" site-id="' + e.siteId + '" cate-site-id="' + e.categorySiteId + '" cate-name="' + e.categoryName + '">' + e.categoryName+'</li>')
                        });
                    }
                });
        });
    }

    return {
        init: function () {
            initEvent();
        }
    }
}();
$(function () {
    category.init();
});

