using CEDTeam.CES.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<FilterProductDto> GetProductAsync(int start, int length, string search, int columnSort, bool isAsc = true);

        Task<List<String>> GetLazadaCategoryAsync();
    }
}
