/**
 * lufer
 * Serviço SOAP a partir de outro serviço externo!
 * */

using System.Web.Services;
using NovaCalculadora.WS1;
using System.Net.Mail;

namespace NovoCalcWS
{
    /// <summary>
    /// Summary description for MaisFuncs
    /// </summary>
    [WebService(Namespace = "http://est.ipca.pt/")]
    public class MaisFuncs : System.Web.Services.WebService
    {

        [WebMethod]
        public int MySoma(int x, int y)
        {
            MailAddress mail = new MailAddress("lufer@ipca.pt");

            NovaCalculadora.WS1.CalcSoapClient ws = new CalcSoapClient();
            return (ws.Soma(x, y));
        }

        [WebMethod]
        public int Sub(int x, int y)
        {
            return (x - y);
        }
    }
}
