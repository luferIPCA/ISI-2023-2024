/*
 * WCF
 * Web Services sobre Bases de Dados
 * */


using System.Data;
using System.ServiceModel;

namespace DBWS
{
    [ServiceContract]
    public interface IDB
    {
        [OperationContract]
        DataSet GetAllFlights();

        [OperationContract(Name ="GetAllHoteisCidade")]
        DataSet GetAllHoteis(string cidade);

        [OperationContract]
        DataSet GetAllHoteisComCapacidade(int capacidade);

    }


    
}
