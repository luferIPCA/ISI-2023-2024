
/*
 * lufer
 * ISI
 * RESTful Service .NET 5.0
 * Adaptado de https://github.com/renatogroffe/ASPNETCore2_XML_APIs
 * */

using RESTServiceExample.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RESTServiceExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VariosController : ControllerBase
    {
        [HttpGet("Fahrenheit/{temperatura}")]
        public object GetConversaoFahrenheit(double temperatura)
        {
            Temperatura dados = new Temperatura();
            dados.ValorFahrenheit = temperatura;
            dados.ValorCelsius =
                Math.Round((temperatura - 32.0) / 1.8, 2);
            dados.ValorKelvin = dados.ValorCelsius + 273.15;

            return dados;
        }
    }
}
