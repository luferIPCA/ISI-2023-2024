/** 
 * lufer Calculator Services
 */
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

/// <summary>
/// RESTful Service
/// </summary>
namespace NovoWS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcController : ControllerBase
    {
        static List<int> aux = new List<int>();

        /// <summary>
        /// RESTful GET com passagem de parâmetros
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Incrementa/{x}")]
        public int Inc(int x)
        {
            return x + 1;
        }

        /// <summary>
        /// RESTful GET com passagem de parâmetros
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Sum/{x}/{y}")]
        public int Sum(int x, int y)
        {
            return (x + y);
        }

        /// <summary>
        /// RESTful sem parâmetros
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/SemParametro")]
        //[Route("api/SemParametro")] 
        public bool X()
        {
            return true;
        }

        /// <summary>
        /// RESTful POST com valores passados por classe
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/addNewInt")]
        public bool AddInt(Aux valor)
        {
            //Se não existe
            if (!aux.Contains(valor.X))
            {
                aux.Add(valor.X);
                return true;
            }
            return true;
        }

        /// <summary>
        /// RESTful GET por omissão
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/all")]
        public List<int> GetAll()
        {
            return aux;
        }
    }

    /// <summary>
    /// Classe auxiliar para passar valores no POST
    /// </summary>
    public class Aux
    {
        int x;
        public int X { get; set; }
    }


}
