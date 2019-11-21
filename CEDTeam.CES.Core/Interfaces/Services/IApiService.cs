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
        //Tiki
        TikiHotSearchDto GetTikiHotSearch();
        TikiCategoryDto GetTikiTopProduct();
        //Sendo
        SendoHotSearchDto GetSendoHotSearch();
    }
}
