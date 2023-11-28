/*
*	<copyright file="HistoryController.cs" company="IPCA">
*		Copyright (c) 2020 All Rights Reserved
*	</copyright>
*	WebAPI RESTfful Services in ASP.NET Core
* 	<author>lufer</author>
*   <date>15/12/2020 10:34:15 AM</date>
*	<description></description>
**/

/**
 * Multiple Controllers
 * see https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-5.0
 * */

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class HistoryController : BaseController
    {
        public HistoryController()
        { }

        #region HISTORY

        [HttpPost("saveCurrent")]
        public ActionResult Insert()   // insere o indicador corrente
        {
            if (indH.AddIndicador(ind))
                return Ok();    //  200 StatusCodes.Status200OK
            else
                return Unauthorized(); //  404 StatusCodes.Status404NotFound
        }

        [HttpPost("newIndicador")]
        public ActionResult Insert(Indicador i)   // insere o indicador corrente
        {
            if (indH.AddIndicador(i))
                return Ok();    //  200 StatusCodes.Status200OK
            else
                return Unauthorized(); //  404 StatusCodes.Status404NotFound
        }

        [HttpGet("indicador/{date}")]  // date == Data a procurar
        public ActionResult<Indicador> Indicador(string date)
        {
            if (indH != null)
            {
                return indH.GetIndicador(date);
            }
            return NotFound(); // 404 StatusCodes.Status404NotFound
        }

        #region ASYNC

        [HttpPost("newIndicadorSync")]
        public async Task<ActionResult> InsertSync(Indicador i)   // insere o indicador corrente
        {
            bool aux = await indH.AddIndicadorSync(i);
            
            if (aux)
                return Ok();            //  200 StatusCodes.Status200OK
            else
                return Unauthorized();  //  404 StatusCodes.Status404NotFound
        }

        [HttpGet("indicadorSync/{date}")]  // date == Data a procurar
        public async Task<ActionResult<Indicador>> IndicadorSync(string date)
        {
            if (indH != null)
            {
                return await indH.GetIndicadorAsync(date);
            }
            return NotFound(); // 404 StatusCodes.Status404NotFound
        }

        #endregion

        /// <summary>
        /// NOTA:será o serviço inicial a ser chamado! para "Publishing in Cloud"
        /// </summary>
        /// <returns></returns>
        //[HttpGet("indicador/all")]
        [HttpGet]
        [Route("/")]                
        public IEnumerable<IIndicadoresModel> AllIndicadores()
        {
            if (indH != null)
            {
                return indH.GetAllIndicadores();
            }
            return null;
        }


        [HttpPut("save")]
        public bool SaveAll()
        {
            indH.SaveHistory("Dados");
            return true;
        }
        #endregion


    }
}
