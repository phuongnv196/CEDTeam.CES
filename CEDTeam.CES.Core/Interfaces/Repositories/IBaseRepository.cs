using System.Data;

namespace CEDTeam.CES.Core.Interfaces
{
    public interface IBaseRepository
    {
        IDbConnection GetConnection();
        IDbConnection GetConnectionDev();
    }
}
