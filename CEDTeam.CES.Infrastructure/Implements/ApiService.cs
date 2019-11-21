﻿using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Infrastructure.Constants;
using CEDTeam.CES.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Infrastructure.Implements
{
    public class ApiService : IApiService
    {
        public ShopeeHotSearchDto GetShopeeHotSearch()
        {
            return APIHelper.GetAsync<ShopeeHotSearchDto>(ApiConstant.SHOPEE_HOT_SEARCH_URL);
        }

        public TikiHotSearchDto GetTikiHotSearch()
        {
            return APIHelper.GetAsync<TikiHotSearchDto>(ApiConstant.TIKI_HOT_SEARCH_URL);
        }

        public SendoHotSearchDto GetSendoHotSearch()
        {
            return APIHelper.GetAsync<SendoHotSearchDto>(ApiConstant.SENDO_HOT_SEARCH_URL);
        }

        public ShopeeTopProductDto GetShopeeTopProduct()
        {
            return APIHelper.GetAsync<ShopeeTopProductDto>(ApiConstant.SHOPEE_TOP_PRODUCTS_URL);
        }

        public TikiCategoryDto GetTikiTopProduct()
        {
            TikiCategoryDto tikiCategory = APIHelper.GetAsync<TikiCategoryDto>(ApiConstant.TIKI_GET_CATEGORY_URL);
            //List<DataCategoryTiki> categories = tikiCategory?.data;
            //foreach (DataCategoryTiki category in categories)
            //{
            //    category.tikiTopProduct = APIHelper.GetAsync<TikiTopProductDto>(String.Format(ApiConstant.TIKI_TOP_PRODUCTS_BY_CATEGORY, category.id, 100, 1));
            //}
            return tikiCategory;
        }
    }
}
