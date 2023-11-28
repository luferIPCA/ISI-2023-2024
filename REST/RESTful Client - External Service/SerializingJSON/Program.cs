/*
Serializar JSON

    Manipular o XML recebido
    http://developer.yahoo.com/dotnet/howto-xml_cs.html
 
    Usar RESTful com .NET
    https://msdn.microsoft.com/en-us/library/hh534080.aspx

    lufer
    ISI
*/
using System;

//Adicionar COM System.Runtime.Serialization em "Project Properties"...Assemblies
using System.Runtime.Serialization;         //DataContract
using System.Runtime.Serialization.Json;
using System.IO;

namespace Serializing_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            #region REVISÕES_SERIALIZAR JSON
            Person p = new Person();
            p.age = 23;
            p.name = "ola";

            //Serializar
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
            ser.WriteObject(stream1, p);
            stream1.Position = 0;

            StreamReader sr = new StreamReader(stream1);
            Console.Write("JSON para Pessoa: ");
            Console.WriteLine(sr.ReadToEnd());

            //Desserializar
            stream1.Position = 0;
            Person p2 = (Person)ser.ReadObject(stream1);
            Console.WriteLine("Idade=" + p2.age + " Nome=" + p2.name);
            #endregion

            Console.ReadKey();
        }
    }

    #region SERIALIZING
    [DataContract]
    internal class Person
    {
        [DataMember]
        internal string name;

        [DataMember]
        internal int age;
    }
    #endregion
}

