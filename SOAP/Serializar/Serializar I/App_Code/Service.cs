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
 *  - Consultar http://msdn.microsoft.com/en-us/library/2baksw0z%28VS.71%29.aspx
 *  - Com atributos XML
 *  - Serializar Arrays
 *  - Serializar Arrays como uma sequência de elementos
 *  - Serializar Classes
 *  - Serializar ArrayLists
 *  - Com IXmlSerializable (melhor controlo do XML) - Ver exemplo em FileWs
 * */

using System;
using System.Collections;
using System.Web.Services;
using System.Xml.Serialization;

#region Serializar
/// <summary>
/// Gere um conjunto de Objectos
/// </summary>
[WebService(Namespace = "http://www.ipca.pt/ws/")]
public class Service : System.Web.Services.WebService
{

    [XmlElement(Type = typeof(Pessoa))]
    ArrayList pessoas = new ArrayList();    //simula uma BD
    

    public Service()
    {
        //inicializa Collection
        pessoas.Add(new Pessoa("ola",12,"11"));
        pessoas.Add(new Pessoa("ole", 13,"22"));
        pessoas.Add(new Pessoa("oli", 14,"33"));
       
    }

    [WebMethod(Description="Devolve um array de Pessoas")]
    public Pessoa[] GetAllPessoas()
    {
        Pessoa[] aux = new Pessoa[pessoas.Count];
        pessoas.CopyTo(aux);
        return (aux);
    }

    [WebMethod(Description = "Devolve um objecto Pessoas serializada")]
    public MyPessoas GetAllPessoasII()
    {     
        Pessoa[] aux = new Pessoa[pessoas.Count];      
        pessoas.CopyTo(aux);
        MyPessoas p = new MyPessoas(aux);
        p.pessoas = aux;
        return (p);
    }


    [WebMethod(Description = "Devolve um ArralyList de Pessoas serializada")]
    [XmlInclude(typeof(MyPessoasII))]
    public MyPessoasII GetAllPessoasIII()
    {
        MyPessoasII aux = new MyPessoasII();
        aux.AddPessoas(new Pessoa("ola", 12, "11"));
        aux.AddPessoas(new Pessoa("ole", 13, "22"));
        aux.AddPessoas(new Pessoa("oli", 14, "33"));
        return (aux);
    }


    [WebMethod(Description = "Mostra uma Pessoa 'Serializada'")]
    public Pessoa ShowPessoa()
    {
        Pessoa p = new Pessoa();
        p.Nome = "Manuel";
        p.Idade = 24;
        return p;
    }

    [WebMethod(Description = "Mostra um Book")]
    public Book ShowBook()
    {
        Book aux = new Book();
        aux.ISBN="12";
        return (aux);        
    }
    
#endregion

}

/*
 * Serializar Arrays:
 * 
 * por defeito:
 * 
 * <MyPessoas>
 *  <pessoas>
 *      <Pessoa>
 *          <IdadePessoa>
 *          <NomePessoa>
 *      
 * com XMLElement (array como sequência de elementos):
 * 
 * <SetPessoas>
 *    <FichaPessoa>
 *        <IdadePessoa>
 *        <NomePessoa>
 *      
 
 * com XmlRootAttribute/XmlArrayAttribute:
 * 
 * <SetPessoas>
 *  <VariasPessoas>
 *      <Pessoa>
 *          <IdadePessoa>
 *          <NomePessoa>
 *          
 
 * * com XmlArrayItemAttribute:
 * 
 * <SetPessoas>
 *  <VariasPessoas>
 *      <FichaPessoa>
 *          <IdadePessoa>
 *          <NomePessoa>
 * 
 *          
 * com XmlArrayAttribute/XmlArrayItemAttribute ou XmlArray/XmlArrayItem
 * 
 * <SetPessoas>
 *  <VariasPessoas>
 *      <FichaPessoa>
 *          <IdadePessoa>
 *          <NomePessoa>
 * 
 * Serializar ArrayList:
 * 
 * */
[Serializable]
[XmlRootAttribute(ElementName = "SetPessoas", IsNullable = false, Namespace = "http://www.ipca.pt/ws/Pessoa")]
public class MyPessoas
{
  //[XmlArray("VariasPessoas")]
  //[XmlArrayItem("FichaPessoa")]
  //[XmlElement(ElementName="FichaPessoa")]
    public Pessoa[] pessoas;

    public MyPessoas() { }
    public MyPessoas(Pessoa[] aux) {
        pessoas = new Pessoa[aux.Length];
    }

}


/// <summary>
/// Serializar um ArrayList
/// </summary>
[XmlRoot(ElementName="MuitasPessoas", Namespace = "http://www.ipca.pt/ws/Pessoa")]
public class MyPessoasII
{    
    [XmlArray("ListaPessoas"), XmlArrayItem("Pessoa", typeof(Pessoa))]
    public ArrayList pessoasArrayList;    

    public MyPessoasII() {
        pessoasArrayList = new ArrayList();
    }

    /// <summary>
    /// Manipula ArrayLIst
    /// </summary>
    /// <param name="p"></param>
    public void AddPessoas(Pessoa p)
    {
        pessoasArrayList.Add(p);
    }

   
}
#region Classe Pessoa
[XmlRoot(ElementName = "Humano", IsNullable = false, Namespace = "http://www.ipca.pt/ws/Pessoa")]
//[XmlRootAttribute(ElementName = "Humano", IsNullable = false, Namespace = "http://www.ipca.pt/ws/Pessoa")]
public class Pessoa
{
    private String pNome;
    private Int32 pIdade;
    private string contaBancaria;

    /// <summary>
    /// Propriedade para manipular Name
    /// </summary>    
    [XmlElement(ElementName = "NomePessoa")]
    public String Nome
    {
        get
        {
            return pNome;
        }
        set
        {
            pNome = value;
        }
    }

    /// <summary>
    /// Propriedade para manipular Age
    /// </summary>
    [XmlElement(ElementName = "IdadePessoa")]
    public Int32 Idade
    {
        get
        {
            return pIdade;
        }
        set
        {
            pIdade = value;
        }
    }

    /// <summary>
    /// Propriedade para gerir contaBancaria
    /// Evitar que seja serializada
    /// </summary>
    [XmlIgnoreAttribute]
    public string ContaBancaria
    {
        get
        {
            return contaBancaria;
        }
        set
        {
            contaBancaria = value;
        }
    }

    public Pessoa()
    {
    }

    public Pessoa(string n, Int32 id, string cb)
    {
        Nome = n;
        Idade = id;
        contaBancaria = cb;
    }
}
#endregion

#region Book

public class Book
{
    //Por defeito o nome da tag é igual ao nome da variável. Neste caso é "ISBN"
    //Para alterar o nome da tag de ISBN para CodISBN
    //[XmlElement(ElementName = "CodISBN")]
    public string ISBN;
}

#endregion