
/**
 * Multiple Controllers
 * see https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-5.0
 * */

using Microsoft.AspNetCore.Mvc;

using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected static IIndicadoresModel ind;       //poderá não ser static
        protected static IIndicadoresHistory indH;

        /// <summary>
        /// SingleTon
        /// </summary>
        public BaseController()
        {
            if (ind == null)
                ind = new Indicador();
            if (indH == null)
                indH = new IndicadoresHistory();
        }


    }
}
