using CEDTeam.CES.Core.Dtos;
using CEDTeam.CES.Core.Interfaces;
using CEDTeam.CES.Infrastructure.Constants;
using CEDTeam.CES.Infrastructure.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Infrastructure.Implements
{
    public class ShopeeService : IShopeeService
    {
        public ShopeeShopDto GetShopByCategoryId(string Id)
        {
            return APIHelper.GetAsync<ShopeeShopDto>(String.Format(ApiConstant.SHOPEE_GET_SHOP_URL, Id));
        }
    }
}
