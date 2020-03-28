using CEDTeam.CES.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEDTeam.CES.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("/api/v{version:apiVersion}/[controller]/[action]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    [CustomAPIAuthorize]
    public class BaseAPIController : ControllerBase
    {

    }
}