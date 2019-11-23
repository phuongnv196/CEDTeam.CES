using CEDTeam.CES.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface IApiService
    {
        //Shopee
        ShopeeHotSearchDto GetShopeeHotSearch();
        ShopeeTopProductDto GetShopeeTopProduct();

        ShopeeHotKeyByCategoryDto ShopeeGetHotKeyByCategory(string cateId);
        //Tiki
        TikiHotSearchDto GetTikiHotSearch();    
        TikiCategoryDto GetTikiCategory();
        TikiTopProductDto GetTikiTopProductByCategory(int id, int limit, int page);
        //Sendo
        SendoHotSearchDto GetSendoHotSearch();
        ShopeeTopProductItem GetShopeeTopProductDetail(ShopeeProductItemCollectionDto listProducts);
        SendoCategoryDto GetSendoCategory();
        SendoCategoryInfoDto SendoCategoryInfo(string path);
        SendoTopProductDto GetSendoTopProductByCategory(int id, int page);
    }
}
