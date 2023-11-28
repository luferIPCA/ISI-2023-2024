/*
 * lufer
 * ISI
 * RESTful Service .NET 5.0
 * */
using RESTServiceExample.Model;
using Microsoft.AspNetCore.Mvc;

namespace RESTServiceExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        static Alunos t;

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public AlunosController()
        {
            if (t==null) t = new Alunos();
        }

        
        [HttpPost("insere")]
        public bool InsereAluno(Aluno a)
        {
            return t.InsereAluno(a);
        }


        [HttpGet("getAluno/{nome}")]
        public Aluno procuraAluno(string nome)
        {
            return null;
        }
    }
}
