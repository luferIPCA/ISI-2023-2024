using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST1.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private static List<int> valores = new List<int> { 2, 5, 7, 8 };

        #region
        [HttpGet]
        [Route("exist/{val}")]      //calc/exist/{int}
        //ou simplesmente
        //[HttpGet("exist/{val}")]    //calc/exist/{int}
        //[Produces("application/xml")]   //devolve XML
        //[Consumes("application/xml", "application/json")]
        //[SwaggerOperation(Summary = "Verifica se valor existe")]
        public bool Exist(int val)
        {
            return valores.Contains(val);
        }

        //[HttpGet("show")]       //calc/all
        //[Route("all")]          //calc/all
        //ou simplesmente
        [HttpGet("show")]
        //[Produces("application/xml", "application/json")]   //XML e JSON
        public List<int> All()
        {
            return valores;
        }

        [HttpPost("addvalores")]       //calc/addvalores
        public bool Add(Values v)
        {
            if (Exist(v.X) || Exist(v.Y)) return false;

            if (!Exist(v.X)) valores.Add(v.X); 
            if (!Exist(v.Y)) valores.Add(v.Y); 
            
            return true;
        }

        [HttpGet("existmsg/{v}")]  
        public ActionResult<bool> ExistMsg(int v)
        {
            if (valores.Contains(v))
            {
                return Ok(true);    // 200 StatusCodes.Status200OK
            }
            return NotFound();  // 404 StatusCodes.Status404NotFound
        }



        #endregion

        #region EXTRA
        public class Values
        {
            int x, y;
            public int X { get => x ; set => x=value; }
            //ou
            public int Y { get { return y; } set { y = value; } }
        }
        #endregion
    }

    
}
