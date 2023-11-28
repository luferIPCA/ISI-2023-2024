/*
 * lufer
 * ISI
 * RESTful Service .NET 5.0
 * */
using System.Collections.Generic;

namespace RESTServiceExample.Model
{
    public class Alunos
    {
        private List<Aluno> turma;

        public Alunos ()
        {
            turma = new List<Aluno>();
        }


        public bool InsereAluno(Aluno a)
        {
            if (!turma.Contains(a))
            {
                turma.Add(a);
                return true;
            }
            return false;
        }

        //métodos para gerir uma turma!!!
    }
}
