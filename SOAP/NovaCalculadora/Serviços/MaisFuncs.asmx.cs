using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NovaCalculadora.Serviços
{
    /// <summary>
    /// Summary description for MaisFuncs
    /// </summary>
    [WebService(Namespace = "http://esg.icpc.ola/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MaisFuncs : System.Web.Services.WebService
    {

        [WebMethod]
        public int MySoma(int x, int y)
        {
            CalcWS.CalcSoapClient ws = new CalcWS.CalcSoapClient();
            return (ws.Soma(x, y));
            
        }

        [WebMethod]
        public int Sub(int x, int y)
        {
            return (x - y);
        }
    }
}
