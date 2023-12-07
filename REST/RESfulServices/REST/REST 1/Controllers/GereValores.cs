/*
 * ASP.NET Core Web API 3.1
 * lufer
 * ISI - 2023
 * */
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace REST11.Controllers
{
    //[Route("api/[controller]")] //    .../api/Valores/
    [Route("[controller]")]          //  .../Valores
    [ApiController]
    public class ValoresController : ControllerBase
    {
        public static List<int> valores = new List<int> { 2, 3, 4, 5, 6, 7 };

        [HttpGet]
        [Route("Get")]              // .../Valores/Get
        public List<int> GetValues()
        {
            return valores;
        }

        [HttpGet]
        [Route("Add/{v}")]          //.../Valores/Add/5
        public bool AddValores(int v)
        {
            if (valores.Contains(v)) return false;
            valores.Add(v);
            return true;
        }
    }

  
}
