using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEDTeam.CES.Web.Controllers.api
{
    [Produces("application/json")]
    [Route("/api/v{version:apiVersion}/[controller]/[action]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {

    }
}