using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Layer.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public abstract class ApiBaseController : ControllerBase
    {
        protected string GetEmailFromToken() => User.FindFirstValue(ClaimTypes.Email)!;
    }
}
