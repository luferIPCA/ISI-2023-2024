/*
 * by lufer
 * 
 * Web Services:
 * 
 * - Serialização (II)
 *   - Classes próprias
 *   - As classes do serviço devem:
 *      - Ter o construtor por omissão
 *      - Devem ter Propriedades
 *      - Todos os métodos públicos são ignorados no cliente
 *      - Tudo o que é privado é ignorado
 *
 * - Costumizar Serialização
 *  - Com atributos XML
 *  - Serializar Arrays
 *  - Com IXmlSerializable (melhor controlo do XML)
 * */

using System;

using System.Web.Services;
using System.Collections;
//Serialização
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// Gere um conjunto de Hoteis
/// </summary>
[WebService(Namespace = "http://www.ipca.pt/ws/")]
public class Service : WebService
{
     ArrayList hoteis = new ArrayList();
     ArrayList hoteis2 = new ArrayList();
    public Service () {
        //inicializa Collection
        hoteis.Add(new HotelClass("Axis", "Viana", 123));
        hoteis.Add(new HotelClass("Alfa", "Lisboa", 700));
        hoteis.Add(new HotelClass("Aivis", "Braga", 77));
        hoteis.Add(new HotelClass("NovoHotel", "Porto", 443));

        hoteis2.Add(new HotelClassII("Axis", "Viana", 123));
        hoteis2.Add(new HotelClassII("Alfa", "Lisboa", 700));
        hoteis2.Add(new HotelClassII("Aivis", "Braga", 77));
        hoteis2.Add(new HotelClassII("NovoHotel", "Porto", 443));

    }

    #region Hoteis
    [WebMethod(Description = "Hoteis existentes...devolve HotelClass[] ")]
    public HotelClass[] GetAllHoteisClass()
    {
        HotelClass[] aux = new HotelClass[hoteis.Count];
        hoteis.CopyTo(aux);
        return (aux);
    }

    [WebMethod(Description = "Hoteis existentes...com IXMLSerializable")]
    public HotelClassII[] GetAllHoteisClassII()
    {
        HotelClassII[] aux = new HotelClassII[hoteis2.Count];
        hoteis2.CopyTo(aux);
        return (aux);
    }

    
    [WebMethod]
    public HotelClass GetHotelClass()
    {
        return new HotelClass("NomeHotel", "NomeCidade", 2000);
    }

    [WebMethod]
    public HotelClassII GetHotelClassII()
    {
        return new HotelClassII("NomeHotel", "NomeCidade", 2000);
    }
     
    #endregion

}

#region ClassHotel II
/// <summary>
/// Classe Hotel. 
/// Inclui informação para costumizar Serialização em XML
/// </summary>
public class HotelClassII: IXmlSerializable
{
    private string nome;
    private string cidade;
    private int capacidade;
    private int cod;
    private static int codTot=0;

    const string ns = "http://www.ipca.pt/ws/HotelClasse";

    /// <summary>
    /// Retorna a instância em XML
    /// </summary>
    /// <param name="w"></param>
    void IXmlSerializable.WriteXml(XmlWriter w)
    {
        w.WriteStartElement("HotelComClasse", ns);
        w.WriteStartAttribute("Id");
        w.WriteValue(cod.ToString());
        w.WriteEndAttribute();
        w.WriteElementString("Nome", ns, nome);
        w.WriteElementString("Cidade", ns, cidade);
        w.WriteElementString("Capacidade", ns, capacidade.ToString());
        //w.WriteElementString("Id", ns, cod.ToString());
        w.WriteEndElement();       
    }

    /// <summary>
    /// Descontinuado!
    /// </summary>
    /// <returns></returns>
    System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
    {
        return (null);
    }

    /// <summary>
    /// Caso seja utilizado uma instância como parâmetro
    /// </summary>
    /// <param name="r"></param>
    void IXmlSerializable.ReadXml(XmlReader r)
    {
        //throw new NotImplementedException("Por implementar...");
        r.MoveToContent();
        //r.ReadStartElement("HotelComClasse");
        nome = r.ReadElementString("Nome", ns);
        cidade = r.ReadElementString("Cidade", ns);
        capacidade = int.Parse(r.ReadElementString("Capacidade", ns));
        cod = int.Parse(r.ReadElementString("Id", ns));
        //r.ReadEndElement();
    }
    
    /// <summary>
    /// construtor
    /// </summary>
    /// <param name="n"></param>
    /// <param name="c"></param>
    /// <param name="cp"></param>
    public HotelClassII(string n, string c, int cp)
    {
        nome = n;
        cidade = c;
        capacidade = cp;
        this.cod=codTot++;
    }

    public HotelClassII() {}
    

    public override string ToString()
    {
        return "Hotel: " + nome + " Cidade: " + cidade + " Quartos: " + capacidade;
    }

    #region Propriedades
    /// <summary>
    /// Serializar com atributos
    /// </summary>
    [XmlAttribute("id")]
    public int Cod
    {
        get { return cod; }
        set { cod = value; }
    }

    [XmlElement("nom")]
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    [XmlElement("cid")]
    public string Cidade
    {
        get { return cidade; }
        set { cidade = value; }
    }

    [XmlElement("cap")]
    public int Capacidade
    {
        get { return capacidade; }
        set { capacidade = value; }
    }
    #endregion
}
#endregion

#region ClassHotel
/// <summary>
/// Classe Hotel. Inclui informação para Serialização com Atributos XML
/// </summary>
[XmlRootAttribute( ElementName = "HotelNovo", IsNullable = false, Namespace = "ipca:http://www.ipca.pt/ws/HotelClasse")]
public class HotelClass
{
    private string nome;
    private string cidade;
    private int capacidade;
    private int cod;
    private static int codTot = 0;    

    /// <summary>
    /// construtor
    /// </summary>
    /// <param name="n"></param>
    /// <param name="c"></param>
    /// <param name="cp"></param>
    public HotelClass(string n, string c, int cp)
    {
        nome = n;
        cidade = c;
        capacidade = cp;
        this.cod = codTot++;
    }

    public HotelClass() { }

    /// <summary>
    /// Não "passa" na serialização...
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "Hotel: " + nome + " Cidade: " + cidade + " Quartos: " + capacidade;
    }

    #region Propriedades
    /// <summary>
    /// Serializar com atributos
    /// </summary>
    [XmlAttribute(Namespace="http://www.ipca.pt/ws/HotelClasse",AttributeName="id")]
    public int Cod
    {
        get { return cod; }
        set { cod = value; }
    }

    [XmlElement(Namespace="http://www.ipca.pt/ws/HotelClasse", ElementName="nom")]
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    [XmlElement(Namespace="http://www.ipca.pt/ws/HotelClasse", ElementName="cid")]
    public string Cidade
    {
        get { return cidade; }
        set { cidade = value; }
    }

    [XmlElement("cap")]
    public int Capacidade
    {
        get { return capacidade; }
        set { capacidade = value; }
    }
    #endregion
}
#endregion

