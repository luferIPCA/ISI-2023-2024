/*
 * lufer & Oscar
 * ISI
 * */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NovoWS.Controllers
{
    /// <summary>
    /// Controller versus ControllerBase
    ///     Controller:     permite views Web
    ///     ControllerBase: permite WebAPI requests
    /// </summary>
    [ApiController]
    public class Cities : ControllerBase
    {
        const int MAX = 10;

        private static List<string> cidades =
                      new List<string> { "Barcelos", "Braga",
                                     "Esposende", "Viana do Castelo" };
        [HttpGet]
        [Route("/")]
        public IEnumerable<string> GetCidades()
        {
            return cidades;
        }

        [HttpGet]
        [Route("/cidade/{i}")]
        public String GetCidade(int i)
        {
            if (i >= 0)
                return cidades[i];
            return "";
        }

        [HttpPost]
        [Route("/AddCidade")]
        public ActionResult AddCidade(ModeloPost cidade)
        {
            if (cidade.Nome.Length > 0 && cidades.Count < MAX)
            {
                //Se não existe, acrescenta!
                if (!cidades.Contains(cidade.Nome))
                {
                    cidades.Add(cidade.Nome);
                    return Ok("Sucesso");   //  200 StatusCodes.Status200OK
                }
                else
                    return Problem(detail: "Cidade já existente", title:"Nem penses!!!");
            }
            return NotFound(); //  404 StatusCodes.Status404NotFound

        }
    }

    public class ModeloPost
    {
        private string nome;

        [Required]  // using System.ComponentModel.DataAnnotations;
        public string Nome { get => nome; set => nome = value; }
    }
}
