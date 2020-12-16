using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using WSReservas.Controllers;

namespace WSReservas.JWT
{
    public class RefreshTokenAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {

	}
}