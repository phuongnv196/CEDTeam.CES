$(document).ready(function () {
    categoryFunction.init();
});

var categoryFunction = function () {
    var initDOM = {
        _domURL: {
            getCategoryURL: '/category/get-sub-category-by-id'
        },
        _domClass: {
            categoryItemClass: 'cate-item',
            categoryItemAction: $(".cate-item"),
        },
        _domAttr: {
            cateStileId: 'cate-site-id',
            divCategoryItemClass: 'div-cate-site-id',
        }
    };

    var initEvent = function () {
        initDOM._domClass.categoryItemAction.on('click', function (e) {
            var categoryStileID = $(this).attr(initDOM._domAttr.cateStileId)
            $.get(
                initDOM._domURL.getCategoryURL,
                {
                    categoryId: $(this).attr(initDOM._domAttr.cateStileId)
                }
            ).done(function (result) {
                if (result) {
                    var stringAppend = '';
                    $.each(result, function (index, value) {
                        stringAppend += '<div class="row">';
                        stringAppend += '<div class="col-3">';
                        stringAppend += '<a href="' + value.categoryUrl + '" target="_blank">' + value.categoryName + '</a>'
                        stringAppend += '</div>';
                        stringAppend += '</div>';
                        stringAppend += '<div style="margin-left: 30px" div-cate-site-id="'+ value.categoryStileID +'">';
                        stringAppend += '</div>';
                        console.log(value);
                    });
                    console.log(result);
                    $('[' + initDOM._domAttr.divCategoryItemClass + '=' + categoryStileID + ']').append(stringAppend);              
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

