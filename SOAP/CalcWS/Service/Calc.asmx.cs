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
    /// Summary description for Calc
    /// </summary>
    [WebService(Namespace = "http://esp.ipca.pt/",Description ="Serviços feitos na aula")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Calc : System.Web.Services.WebService
    {

        [WebMethod(Description ="Mostra alguma coisa")]
        public string Ola()
        {
            return "Viva o Benfica";
        }

        [WebMethod(Description ="Calcula a soma...")]
        public int Soma(int x, int y)
        {
            return (x + y);
        }
    }
}
