﻿using CEDTeam.CES.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface IShopeeService
    {
        ShopeeShopDto GetShopByCategoryId(string Id);
    }
}
