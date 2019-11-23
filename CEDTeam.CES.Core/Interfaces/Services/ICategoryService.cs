﻿using CEDTeam.CES.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategorysBySiteId(int siteId);
    }
}
