/*
 * by lufer
 * 
 * Web Services sobre Bases de Dados com ADO.NET (pag. 141 da Sebenta)
 * Typed DataSets
 * 
 * Receita:
 * 
 * 1- Incluir System.Data e System.Data."Driver"
 * 2- Definir conexão (directa ou externa)
 * 3- Definir Query
 * 4- Executar Query
 * 5- Tratar resultados
 * 
 * URLS:
 * http://www.connectionstrings.com/
 * https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
 * https://www.connectionstrings.com/store-connection-string-in-webconfig/
 * https://blog.elmah.io/the-ultimate-guide-to-connection-strings-in-web-config/
 * ADO.NET
 * http://msdn.microsoft.com/en-us/library/aa302325.aspx
 * */
using System.Configuration;     //aceder ao Web Config
using System.Data;
using System.Data.OleDb;        //Access; SQLServer;
//using System.Data.SqlClient;    //SQL Server

//using System.Data.OracleClient;   //Oracle Database

namespace DBWS
{

    public class DB : IDB
    {
        /// <summary>
        /// Devolve toda a informação sobre todos os Hoteis
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllFlights()
        {
            DataSet ds = new DataSet();

            //1º ConnectionString no Web Config
          
            string cs = ConfigurationManager.ConnectionStrings["VoosConnectionString"].ConnectionString;

            //2º OpenConnection
            OleDbConnection con = new OleDbConnection(cs);  //via OleDB
                                                               
            //SqlConnection con = new SqlConnection(c);     //via SQLServer
           
            //3º Query
            string q = "select * from Voos";
            
            //4º Execute
            OleDbDataAdapter da = new OleDbDataAdapter(q, con);
            //SqlDataAdapter da = new SqlDataAdapter(q, con);    //via SQLServer

            da.Fill(ds, "Voos");
        
            //Devolve o resultado
            return (ds);
        }

        /// <summary>
        /// Devolve toda a informação dos hoteis de determinada localidade
        /// </summary>
        /// <param name="criterio"></param>
        /// <returns></returns>
        public DataSet GetAllHoteis(string cidade)
        {
            DataSet ds = new DataSet();

            //1º ConnectionString
            string cs = ConfigurationManager.ConnectionStrings["turismoConnectionString"].ConnectionString;

            //2º OpenConnection
            OleDbConnection con = new OleDbConnection(cs);

            //3º Query Parametrizada
            string q = "select * from Hoteis where cidade=@cidade";    //aplicar critério
            //Errado: string q = "select * from Hoteis where cidade=" + cidade;
                     
            //4º Execute
            OleDbDataAdapter da = new OleDbDataAdapter(q, con);
            
            //Instancia parâmetros
            da.SelectCommand.Parameters.Add("@cidade", OleDbType.VarChar);
            da.SelectCommand.Parameters["@cidade"].Value = cidade;

            //Executa e preenche o DataSet com os resultados
            da.Fill(ds, "Hoteis1");

            return (ds);
        }

        /// <summary>
        /// devolve todos os Hoteis com capacidade para mais turistas
        /// </summary>
        /// <param name="capacidade"></param>
        /// <returns></returns>
        public DataSet GetAllHoteisComCapacidade(int capacidade)
        {
            DataSet ds = new DataSet();

            //1º ConnectionString
            string cs = ConfigurationManager.ConnectionStrings["turismoConnectionString"].ConnectionString;

            //2º OpenConnection
            OleDbConnection con = new OleDbConnection(cs);

            //3º Query Parametrizada
            string q = "SELECT nome, (capacidade-ocupacao) as livres, cidade FROM Hoteis WHERE (capacidade-ocupacao)>@capacidade; ";    //aplicar critério            

            //4º Prepara DataAdapter
            OleDbDataAdapter da = new OleDbDataAdapter(q, con);
            //Instancia parâmetros
            da.SelectCommand.Parameters.Add("@capacidade", OleDbType.Integer);
            da.SelectCommand.Parameters["@capacidade"].Value = capacidade;
            
            //Executa e preenche o DataSet com os resultados
            da.Fill(ds, "Hoteis2");

            return (ds);
        }
    }
}
