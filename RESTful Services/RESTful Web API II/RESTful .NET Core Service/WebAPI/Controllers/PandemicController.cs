/*
*	<copyright file="PandemicController.cs" company="IPCA">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
*	WebAPI RESTful Services in ASP.NET Core
* 	<author>lufer</author>
*   <date></date>
*	<description></description>
**/


/**
 * Multiple Controllers
 * see https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-5.0
 * */

using Microsoft.AspNetCore.Mvc;
using System;
namespace WebAPI.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/servicosPandemic")]
    //[ApiController]
    public class PandemicController : BaseController
    {
        //private static IIndicadoresModel ind;       //poderá não ser static
        //private static IIndicadoresHistory indH;    //convém ser static

        public PandemicController()
        {
        }

        #region GET

        //[HttpGet]                 // GET Operation
        //[ActionName("deaths")]    // com [action] na Route
        [HttpGet("GetDeaths")]
        public int Mortes()
        {
            return ind.Mortes;
        }

        [HttpGet("GetInfected")]
        public int Infetados()
        {
            return ind.Infetados;
        }

        [HttpGet("GetRecovered")]
        public int Recuperados()
        {
            return ind.Recuperados;
        }

        #endregion

        #region POST

        [HttpPost("deaths")]   // POST .../api/pandemic/death
        public bool MoreDeads(int v)
        {
            if (ind != null)
            {
                ind.Mortes += v;
               
                ind.Date = DateTime.Now.ToString();
                return true;
            }
            return false;
        }

        [HttpPost("infected")]
        public bool MoreInfected(int v)
        {
            if (ind != null)
            {
                ind.Infetados += v;
                ind.Date = DateTime.Now.ToString();
                return true;
            }
            return false;
        }


        [HttpPost("recovered")]
        public bool MoreRecovered(int v)
        {
            if (ind != null)
            {
                ind.Recuperados += v;
                ind.Date = DateTime.Now.ToString();
                return true;
            }
            return false;
        }

        #endregion 
    }
}
