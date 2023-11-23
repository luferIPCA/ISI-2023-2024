using System;

using System.Net.Mail;

using System.Web.Services;

namespace EmailWS.Services
{
    /// <summary>
    /// Summary description for EmailWS
    /// </summary>
    [WebService(Namespace = "http://www.ipca.pt/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmailValidatorWS : System.Web.Services.WebService
    {

        [WebMethod(Description = "Valida sintaticamente um endreeço de email")]
        public bool EmailValidator(string email)
        {

            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
