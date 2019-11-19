using CEDTeam.CES.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProductAsync(int start, int length, string search, int columnSort, bool isAsc = true);
    }
}
