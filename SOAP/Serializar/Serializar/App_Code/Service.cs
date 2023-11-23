/*
 * by lufer
 * 
 * XML Web Services: 
 * 
 * Serialização:
 * - Gerir dados complexos
 * - Gerir Estruturas de Dados
 * - Simular uma Base de Dados
 *
 * Transacções
 *  - TransactionOption.RequiresNew
 *  - ContexUtil.SetAbort()    - rolled back
 *
 * */

using System;
using System.Collections;
using System.EnterpriseServices;        //Transacções
using System.Web.Services;

#region Hoteis
/// <summary>
/// Serviços para Gerir um conjunto de Hoteis
/// Testar Transacções
/// </summary>
[WebService(Namespace = "http://www.ipca.pt/ws/", Description = "Serviços para Gerir um conjunto de Hoteis")]
public class Service : WebService
{
     ArrayList hoteis = new ArrayList();    //simula uma BD

    public Service () {
        //inicializa Collection
        hoteis.Add(new Hotel("Axis", "Viana", 123));
        hoteis.Add(new Hotel("Alfa", "Lisboa", 700));
        hoteis.Add(new Hotel("Avis", "Braga", 77));
        hoteis.Add(new Hotel("NovoHotel", "Porto", 443));        
    }

    [WebMethod]
    public Hotel[] GetAllArrayHoteis()
    {
        Hotel[] aux = new Hotel[hoteis.Count];
        hoteis.CopyTo(aux);
        return (aux);

        //DataSet
        //ADO.NET - Bases de Dados
    }

    
    
    /// <summary>
    /// Método controlado por uma Transacção
    /// </summary>
    /// <param name="h"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    [WebMethod(TransactionOption=TransactionOption.RequiresNew)]
    public Hotel GetHotelDetails(string h, string c)
    {
        int x = 0;
        try
        {
            foreach (Hotel hot in hoteis)
            {
                if ((String.Compare(hot.nome, h) == 0) && (String.Compare(hot.cidade, c) == 0))
                {
                    return hot;
                }
            }
            //Caso não tenha encontrado, enviar "aviso"
            throw new Exception("Não existem hoteis " + h + " em " + c + "x = " + x);
        }
        catch
        {
            ContextUtil.SetAbort();             //gera o rooled back
            throw new Exception("Rooled Back...");
        }

        //Caso não ocorram problemas, é feito o Commit da transacção!
    }         
    #endregion

}

#region STRUCTS
/// <summary>
/// Struct para conter informação sobre um Hotel!
/// </summary>
public struct Hotel
{
    //private string nome;
    public string nome;
    public string cidade;
    public int capacidade;

    /// <summary>
    /// 
    /// </summary>
    public string Nome
    {
        get { return nome; }
        set { nome = value; }

    }

    /// <summary>
    /// construtor
    /// </summary>
    /// <param name="n"></param>
    /// <param name="c"></param>
    /// <param name="cp"></param>
    public Hotel(string n, string c, int cp)
    {
        nome = n;
        cidade = c;
        capacidade = cp;
    }

    /// <summary>
    /// Não é mapeado na serialização
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "Hotel: " + nome + " Cidade: " + cidade + " Quartos: " + capacidade;
    }
}
#endregion

