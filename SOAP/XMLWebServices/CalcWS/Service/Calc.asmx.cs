/**
 * lufer
 * email
 * data
 * desc
 * */
using System.Web.Services;

namespace CalcWS.Service
{
    /// <summary>
    /// Serviço para implementar uma calculadora
    /// </summary>
    [WebService(Namespace = "http://esp.ipca.pt/",Description ="Serviços feitos na aula")]
    public class Calc : System.Web.Services.WebService
    {

        [WebMethod(Description ="Mostra alguma coisa")]
        public string ShowUpperCase(string s)
        {
            return s.ToUpper();
        }

        [WebMethod(Description ="Calcula a soma...")]
        public int Soma(int x, int y)
        {
            return (x + y);
        }
    }
}
