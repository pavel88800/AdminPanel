namespace APProject.Controllers.Base
{
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class BaseApiAuthController : BaseApiController
    {
    }
}