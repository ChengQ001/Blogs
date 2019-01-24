using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChengQ.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BaseController : Controller
    {
    }
}