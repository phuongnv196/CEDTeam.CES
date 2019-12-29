$(function () {
    categoryFunction.init();
});

var categoryFunction = function () {
    var initDOM = {
        _domURL: {
            getCategoryURL: '/category/get-sub-category-by-id'
        },
        _domClass: {
            categoryItemClass: 'cate-item',
            categoryItemAction: '.cate-item',
        },
        _domAttr: {
            cateStileId: 'cate-site-id',
            levelCate: 'cate-level',
            divCategoryItemClass: 'div-cate-site-id',
        }
    };

    var initEvent = function () {
        $(document).on('click', initDOM._domClass.categoryItemAction, function () {
            var categoryStileID = $(this).attr(initDOM._domAttr.cateStileId);
            var levelCategory = $(this).attr(initDOM._domAttr.levelCate);
            $.get(
                initDOM._domURL.getCategoryURL,
                {
                    categoryId: $(this).attr(initDOM._domAttr.cateStileId)
                }
            ).done(function (result) {
                if (result.length > 0) {
                    var stringParent = '';
                    var stringChild = '';
                    var stringAppend = '';
                    var initTmp = 0;
                    var totalResult = result.length;
                    $.each(result, function (index, value) {
                        initTmp++;
                        if (initTmp == 1) {
                            stringParent += '<div class="row">';
                            stringParent += '<div class="col-3">';
                            stringParent += '<a href="' + value.categoryUrl + '" target="_blank">' + value.level + '_' + value.categoryName + '</a>'
                            stringParent += '<a class="cate-item" cate-id="' + value.categoryId + '" parent-id="' + value.parent + '" site-id="' + value.siteId + '" cate-site-id="' + value.categorySiteId + '" cate-name="' + value.categoryName + '" cate-level="' + value.level + '"><i class="fa fa-angle-down" aria-hidden="true"></i></a>';
                            stringParent += '</div>';

                            stringChild += '<div class="hidden-category-' + value.level + '" style="display:none; margin-left: 30px" div-cate-site-id="' + value.categorySiteId + '">';
                            stringChild += '</div>';
                        }
                        if (initTmp > 1 && initTmp < 4) {
                            stringParent += '<div class="col-3">';
                            stringParent += '<a href="' + value.categoryUrl + '" target="_blank">' + value.level + '_' + value.categoryName + '</a>'
                            stringParent += '<a class="cate-item" cate-id="' + value.categoryId + '" parent-id="' + value.parent + '" site-id="' + value.siteId + '" cate-site-id="' + value.categorySiteId + '" cate-name="' + value.categoryName + '" cate-level="' + value.level + '"><i class="fa fa-angle-down" aria-hidden="true"></i></a>';
                            stringParent += '</div>';

                            stringChild += '<div class="hidden-category-' + value.level + '" style="display:none; margin-left: 30px" div-cate-site-id="' + value.categorySiteId + '">';
                            stringChild += '</div>';
                        }
                        if (initTmp == 4) {
                            initTmp = 0;
                            stringParent += '<div class="col-3">';
                            stringParent += '<a href="' + value.categoryUrl + '" target="_blank">' + value.level + '_' + value.categoryName + '</a>'
                            stringParent += '<a class="cate-item" cate-id="' + value.categoryId + '" parent-id="' + value.parent + '" site-id="' + value.siteId + '" cate-site-id="' + value.categorySiteId + '" cate-name="' + value.categoryName + '" cate-level="' + value.level + '"><i class="fa fa-angle-down" aria-hidden="true"></i></a>';
                            stringParent += '</div>';
                            stringParent += '</div>';

                            stringChild += '<div class="hidden-category-' + value.level + '" style="display:none; margin-left: 30px" div-cate-site-id="' + value.categorySiteId + '">';
                            stringChild += '</div>';

                            stringParent += stringChild;
                            stringChild = '';
                        }
                        if (index == totalResult - 1 && initTmp != 4) {
                            stringParent += '</div>';
                            stringParent += stringChild;
                            stringChild = '';
                        }
                    });
                    $('[' + initDOM._domAttr.divCategoryItemClass + '=' + categoryStileID + ']').html(stringParent);
                    $('.hidden-category-' + levelCategory).hide();
                    $('[' + initDOM._domAttr.divCategoryItemClass + '=' + categoryStileID + ']').show();
                }
                else {

                }
            });
        });
    };

    return {
        init: function () {
            initEvent();
        }
    };
}();

